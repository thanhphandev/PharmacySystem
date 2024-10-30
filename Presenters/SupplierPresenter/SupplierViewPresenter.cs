using PharmacySystem.Common;
using PharmacySystem.Models;
using PharmacySystem.Services;
using PharmacySystem.Views.SuppliersForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystem.Presenters.SupplierPresenter
{
    public class SupplierViewPresenter
    {
        private readonly string _connectionString;
        private readonly ISuppliersView _suppliersView;
        private readonly SupplierService _supplierService;


        public SupplierViewPresenter(ISuppliersView suppliersView, string connectionString)
        {
            _suppliersView = suppliersView;
            _connectionString = connectionString;
            _supplierService = new SupplierService(_connectionString);

            _suppliersView.AddData += OnAddData;
            _suppliersView.UpdateData += OnUpdateData;
            _suppliersView.DeleteData += OnDeleteData;
            _suppliersView.RefreshData += OnRefreshData;
        }

        private void OnAddData(object sender, EventArgs e)
        {
            try
            {
                AddSupplierForm view = new AddSupplierForm(_connectionString)
                {
                    IsEditMode = false
                };

                view.ShowDialog();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding data: {ex.Message}");
            }
        }

        private void OnUpdateData(object sender, EventArgs e)
        {
            var currentSupplier = _suppliersView.GetSelectedSupplier();
            try
            {
                AddSupplierForm view = new AddSupplierForm(_connectionString)
                {
                    SupplierId = currentSupplier.SupplierId,
                    SupplierName = currentSupplier.SupplierName,
                    SupplierPhone = currentSupplier.SupplierPhone,
                    SupplierAddress = currentSupplier.SupplierAddress,
                    IsEditMode = true,
                    LabelHeader = "Cập nhật thông tin nhà cung cấp"
                };

                view.ShowDialog();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating data: {ex.Message}");
            }
        }

        private void OnRefreshData(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {

            try
            {
                _suppliersView.TextSearch = string.Empty;
                List<SupplierModel> suppliers = _supplierService.GetAllSuppliers();
                _suppliersView.DisplaySuppliers(suppliers);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }


        private void OnDeleteData(object sender, EventArgs e)
        {
            var supplier = _suppliersView.GetSelectedSupplier();
            if (supplier != null)
            {
                var result = MessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    return;
                }
                _supplierService.DeleteSupplier(supplier.SupplierId);
                LoadData();
            }
        }


        public void SearchMedicineGroups(string searchText, bool searchByAddress = true, bool searchByPhone = true, bool searchByName = true)
        {
            try
            {
                List<SupplierModel> allSuppliers = _supplierService.GetAllSuppliers();

                string normalizedSearchText = DiacriticsRemover.RemoveDiacritics(searchText).ToLowerInvariant();

                var filteredMedicineGroups = allSuppliers.Where(mg =>
                    (searchByAddress && DiacriticsRemover.RemoveDiacritics(mg.SupplierAddress).ToLowerInvariant().Contains(normalizedSearchText)) ||
                    (searchByName && DiacriticsRemover.RemoveDiacritics(mg.SupplierName).ToLowerInvariant().Contains(normalizedSearchText)) ||
                    (searchByPhone && DiacriticsRemover.RemoveDiacritics(mg.SupplierPhone).ToLowerInvariant().Contains(normalizedSearchText))
                ).ToList();

                _suppliersView.DisplaySuppliers(filteredMedicineGroups);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching data: {ex.Message}");
            }
        }

    }
}
