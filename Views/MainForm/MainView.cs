using PharmacySystem.Models;
using PharmacySystem.Presenters;
using PharmacySystem.Services;
using PharmacySystem.Views.UIComponents;
using PharmacySystem.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PharmacySystem.Views.PaymentForm;

namespace PharmacySystem.Views.MainForm
{
    public partial class MainView : Form, IMainView
    {
        public event EventHandler Logout;
        public event EventHandler ShowDashboard;
        public event EventHandler SearchMedicinesByNameAndGroup;
        public event EventHandler PurchaseMedicine;

        public MainView(string connectionString)
        {
            InitializeComponent();
            new MainPresenter(this, connectionString);
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            LoadUserData();
            btnLogout.Click += delegate
            {
                Logout?.Invoke(this, EventArgs.Empty);
            };
            btnDashboard.Click += delegate
            {
                ShowDashboard?.Invoke(this, EventArgs.Empty);
            };
            btnPayment.Click += delegate
            {
                PurchaseMedicine?.Invoke(this, EventArgs.Empty);
            };
            cbMedicineGroup.SelectedIndexChanged -= delegate { SearchMedicinesByNameAndGroup?.Invoke(this, EventArgs.Empty); };
            txtSearch.TextChanged -= delegate { SearchMedicinesByNameAndGroup?.Invoke(this, EventArgs.Empty); };
            
            cbMedicineGroup.SelectedIndexChanged += (s, e) =>
            {
                SearchMedicinesByNameAndGroup?.Invoke(this, EventArgs.Empty);
            };

            txtSearch.TextChanged += (s, e) =>
            {       
                SearchMedicinesByNameAndGroup?.Invoke(this, EventArgs.Empty);
            };
            btnCancel.Click += delegate
            {
                ClearCartItems();
            };
            CartItemsDataGrid.CellValueChanged += CartItemsDataGrid_CellValueChanged;

        }

        public void LoadMedicineGroups(List<MedicineGroupModel> medicineGroups)
        {
            cbMedicineGroup.DataSource = medicineGroups;
            cbMedicineGroup.DisplayMember = "GroupName";
            cbMedicineGroup.ValueMember = "GroupCode";
        }

        public void LoadUserData()
        {
            lbFullName.Text = "Xin chào, " + UserSession.FullName;
        }

        public void LoadMedicineData(List<MedicineProductModel> medicineInfo)
        {
            MedicineProductPanel.Controls.Clear();
            if (medicineInfo != null)
            {
                foreach (var item in medicineInfo)
                {
                    AddMedicineItems(item);
                }
            }
        }

        private void CartItemsDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == CartItemsDataGrid.Columns["dgvQuantity"].Index && e.RowIndex >= 0)
            {
                var row = CartItemsDataGrid.Rows[e.RowIndex];
                int quantity = Convert.ToInt32(row.Cells["dgvQuantity"].Value?.ToString());
                
                if (quantity <= 0)
                {
                    MessageBox.Show("Số lượng không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    row.Cells["dgvQuantity"].Value = 1;
                    return;
                }
                decimal price = Convert.ToDecimal(row.Cells["dgvPrice"].Value.ToString().Replace("₫", "").Replace(".", "").Trim());
                row.Cells["dgvAmount"].Value = CurrencyFormatter.FormatVND(quantity * price);
                GetTotal();
                
            }
        }
   

        public string TextSearch { get => txtSearch.Text; set => txtSearch.Text = value; }
        public decimal TotalAmount { get => Convert.ToDecimal(txtTotal.Text.Replace("₫", "").Replace(".", "").Trim()); set => txtTotal.Text = CurrencyFormatter.FormatVND(value); }
        public string MedicineGroup { get => cbMedicineGroup.SelectedValue?.ToString() ; set => cbMedicineGroup.SelectedValue = value; }
        public decimal GrandTotal
        {
            get
            {
                // Attempt to parse the value, if null or invalid, return 0
                return decimal.TryParse(txtChange.Text.Replace("₫", "").Replace(".", "").Trim(), out var value) && value != 0 ? value : 0;
            }
            set
            {
              
                if (value == 0)
                {
                    return;
                }
                txtChange.Text = CurrencyFormatter.FormatVND(value);
            }
        }


        public void CloseForm()
        {
            this.Close();
        }

        private void AddMedicineItems(MedicineProductModel medicine)
        {

            IMedicineProduct medicineProduct = new MedicineProduct()
            {
                MedicineCode = medicine.MedicineCode,
                MedicineName = medicine.MedicineName,
                MedicinePrice = medicine.Price,
                Quantity = medicine.Quantity,
                UnitType = medicine.MedicineUnit,
                MedicineImage = medicine.ImageUrl
            };
            
            MedicineProductPanel.Controls.Add((MedicineProduct)medicineProduct);
            medicineProduct.AddToCart += (sender, e) =>
            {
                AddOrUpdateCartItem((MedicineProduct)sender);
            };

        }

        private void AddOrUpdateCartItem(MedicineProduct product)
        {

            if (product.Quantity <= 0)
            {
                MessageBox.Show("Thuốc hiện đã hết hàng, không thể thêm vào giỏ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in CartItemsDataGrid.Rows)
            {
                if (string.Equals(row.Cells["dgvCode"].Value?.ToString(), product.MedicineCode, StringComparison.OrdinalIgnoreCase))
                {
                    int currentQuantity = Convert.ToInt32(row.Cells["dgvQuantity"].Value);
                    int newQuantity = currentQuantity + 1;

                    if (newQuantity > product.Quantity)
                    {
                        MessageBox.Show("Không đủ số lượng thuốc trong kho.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    row.Cells["dgvQuantity"].Value = newQuantity;
                    decimal price = Convert.ToDecimal(row.Cells["dgvPrice"].Value.ToString().Replace("₫", "").Replace(".", "").Trim());
                    row.Cells["dgvAmount"].Value = CurrencyFormatter.FormatVND(newQuantity * price);
                    GetTotal();
                    return;
                }
            }

            CartItemsDataGrid.Rows.Add(new object[]
            {
                CartItemsDataGrid.Rows.Count + 1,
                product.MedicineCode,
                product.MedicineName,
                1, // Initial quantity
                CurrencyFormatter.FormatVND(product.MedicinePrice),
                CurrencyFormatter.FormatVND(product.MedicinePrice)
            });
            GetTotal();
        }

        public void UpdateMedicineProductPanel(MedicineProduct updatedProduct)
        {
            foreach (Control control in MedicineProductPanel.Controls)
            {
                if (control is MedicineProduct medicineProduct &&
                    medicineProduct.MedicineCode == updatedProduct.MedicineCode)
                {
                    medicineProduct.Quantity = updatedProduct.Quantity;
                    break;
                }
            }
        }

        private void GetTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in CartItemsDataGrid.Rows)
            {
                total += Convert.ToDecimal(row.Cells["dgvAmount"].Value.ToString().Replace("₫", "").Replace(".", "").Trim());
            }

            txtTotal.Text = CurrencyFormatter.FormatVND(total);
            decimal vat = total * 0.1m; // VAT is 10% of total
            txtVAT.Text = CurrencyFormatter.FormatVND(vat); 
            txtChange.Text = CurrencyFormatter.FormatVND(total + vat);
        }

        private void CartItemsDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= CartItemsDataGrid.Rows.Count)
            {
                return; // Ignore clicks outside valid rows
            }
            if (CartItemsDataGrid.CurrentCell.OwningColumn.Name == "Delete")
            { 
                
                CartItemsDataGrid.Rows.RemoveAt(e.RowIndex);

                GetTotal();
            }
        }

        public void ClearCartItems()
        {
            CartItemsDataGrid.Rows.Clear();

            GetTotal();
        }

        
        public List<MedicineProductModel> GetCartItems()
        {
            var cartItems = new List<MedicineProductModel>();

            foreach (DataGridViewRow row in CartItemsDataGrid.Rows)
            {
                if (row.IsNewRow) continue;

                var medicineCode = row.Cells["dgvCode"].Value?.ToString();
                if (int.TryParse(row.Cells["dgvQuantity"].Value?.ToString(), out int quantity) && !string.IsNullOrEmpty(medicineCode))
                {
                    var item = new MedicineProductModel
                    {
                        MedicineCode = medicineCode,
                        MedicineName = row.Cells["dgvName"].Value?.ToString(),
                        Quantity = quantity,
                        Price = Convert.ToDecimal(row.Cells["dgvPrice"].Value.ToString().Replace("₫", "").Replace(".", "").Trim()),
                        //MedicineUnit = row.Cells["dgvUnitType"].Value?.ToString(),
                    };

                    cartItems.Add(item);
                }
            }

            return cartItems;
        }

    
    }
}
