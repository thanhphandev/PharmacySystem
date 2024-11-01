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

namespace PharmacySystem.Views.MainForm
{
    public partial class MainView : Form, IMainView
    {
        public event EventHandler Logout;
        public event EventHandler ShowDashboard;

        public MainView(string connectionString)
        {
            InitializeComponent();
            var presenter = new MainPresenter(this, connectionString);
            presenter.LoadData();
            AssociateAndRaiseViewEvents();
            CartItemsDataGrid.CellValueChanged += CartItemsDataGrid_CellValueChanged;

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

        private void AddMedicineItems(string code, string medicineName, decimal medicinePrice, string imageUrl)
        {

            IMedicineProduct medicineProduct = new MedicineProduct()
            {
                MedicineCode = code,
                MedicineName = medicineName,
                MedicinePrice = medicinePrice,
                MedicineImage = imageUrl
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

                    decimal price = product.MedicinePrice;
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
                product.MedicinePrice,
                CurrencyFormatter.FormatVND(product.MedicinePrice) // Initial amount
            });
            GetTotal();
        }


        public void LoadMedicineData(List<MedicineInfoModel> medicineInfo)
        {
            foreach (var item in medicineInfo)
            {
                AddMedicineItems(item.MedicineCode, item.MedicineName, item.MedicinePrice, item.MedicineImage);
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
            txtTempTotal.Text = CurrencyFormatter.FormatVND(total);
        }
    }
}
