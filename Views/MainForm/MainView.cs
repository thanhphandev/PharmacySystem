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
        private readonly MainPresenter _presenter;
        private readonly string _connectionString;

        public string TextSearch { get => txtSearch.Text; set => txtSearch.Text = value; }
        public decimal TotalAmount { get => Convert.ToDecimal(txtTotal.Text.Replace("₫", "").Replace(".", "").Trim()); set => txtTotal.Text = CurrencyFormatter.FormatVND(value); }

        public MainView(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            var presenter = new MainPresenter(this, connectionString);
            _presenter = presenter;
            presenter.LoadData();
            AssociateAndRaiseViewEvents();
            CartItemsDataGrid.CellValueChanged += CartItemsDataGrid_CellValueChanged;
        }

        public void LoadMedicineGroups(List<MedicineGroupModel> medicineGroups)
        {
            cbMedicineGroup.DataSource = medicineGroups;
            cbMedicineGroup.DisplayMember = "GroupName";
            cbMedicineGroup.ValueMember = "GroupCode";
        }

        private void CartItemsDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Update only for the Quantity column
            if (e.ColumnIndex == CartItemsDataGrid.Columns["dgvQuantity"].Index && e.RowIndex >= 0)
            {
                var row = CartItemsDataGrid.Rows[e.RowIndex];

                if (decimal.TryParse(row.Cells["dgvPrice"].Value?.ToString(), out decimal price) &&
                    int.TryParse(row.Cells["dgvQuantity"].Value?.ToString(), out int quantity))
                {
                    row.Cells["dgvAmount"].Value = CurrencyFormatter.FormatVND(price * quantity);
                    GetTotal(); // Update total whenever quantity changes
                }
            }
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

        }

        public void LoadUserData()
        {
            lbFullName.Text = "Xin chào, " + UserSession.FullName;
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
            foreach (DataGridViewRow row in CartItemsDataGrid.Rows)
            {
                if (string.Equals(row.Cells["dgvCode"].Value?.ToString(), product.MedicineCode, StringComparison.OrdinalIgnoreCase))
                {
                    int currentQuantity = Convert.ToInt32(row.Cells["dgvQuantity"].Value);
                    int newQuantity = currentQuantity + 1;
                    row.Cells["dgvQuantity"].Value = newQuantity;

                    decimal price = Convert.ToDecimal(row.Cells["dgvPrice"].Value.ToString().Replace("₫", "").Replace(".", "").Trim());
                    row.Cells["dgvAmount"].Value = CurrencyFormatter.FormatVND(newQuantity * price);
                    GetTotal();
                    return;
                }
            }

            // Add new item to cart if it doesn't exist
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


        public void LoadMedicineData(List<MedicineProductModel> medicineInfo)
        {
            MedicineProductPanel.Controls.Clear();
            foreach (var item in medicineInfo)
            {
                
                AddMedicineItems(item);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CartItemsDataGrid.Rows.Clear();

            GetTotal();
        }

        private void cbMedicineGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedGroupCode = cbMedicineGroup.SelectedValue as string;

            if (string.IsNullOrEmpty(selectedGroupCode))
            {
                _presenter.LoadAllMedicines();
                if (!string.IsNullOrEmpty(TextSearch))
                {
                    _presenter.SearchMedicines(TextSearch, null);
                }
            }
            else
            {
                _presenter.FilterMedicinesByGroupId(selectedGroupCode);
                if (!string.IsNullOrEmpty(TextSearch))
                {
                    _presenter.SearchMedicines(TextSearch, selectedGroupCode);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _presenter.SearchMedicines(TextSearch, cbMedicineGroup.SelectedValue as string);
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            decimal totalAmount = Convert.ToDecimal(txtChange.Text.Replace("₫", "").Replace(".", "").Trim());
            var paymentView = new PaymentView(totalAmount);
            new PaymentPresenter(paymentView, this, _connectionString);

            paymentView.ShowDialog();
            paymentView.CloseForm();
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
