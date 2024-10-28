using PharmacySystem.Common;
using PharmacySystem.Models;
using PharmacySystem.Services;
using PharmacySystem.Views;
using PharmacySystem.Views.MedicineCategoryForm;
using PharmacySystem.Views.RegisterForm;
using PharmacySystem.Views.SuppliersForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystem.Presenters
{
    public class SupplierPresenter
    {
        private readonly string _connectionString;

        private readonly ISuppliersView _suppliersView;
        private readonly SupplierService _supplierService;
        public SupplierPresenter(ISuppliersView suppliersView, string connectionString)
        {
            _suppliersView = suppliersView;
            _connectionString = connectionString;
            _supplierService = new SupplierService(_connectionString);

            _suppliersView.AddData += OnAddData;
            _suppliersView.UpdateData += OnUpdateData;
            _suppliersView.DeleteData += OnDeleteData;
            _suppliersView.RefreshData += OnRefreshData;
        }

        private void OnRefreshData(object sender, EventArgs e)
        {
            _suppliersView.TextSearch = string.Empty;
            LoadData();
        }

        public void LoadData()
        {

            try
            {
                List<SupplierModel> suppliers = _supplierService.GetAllSuppliers();

                _suppliersView.DisplaySuppliers(suppliers);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }


        private void OnAddData(object sender, EventArgs e)
        {
            try
            {
                AddSupplierForm view = new AddSupplierForm()
                {
                    IsEditMode = false
                };

                view.AddSupplier += (s, args) =>
                {
                    SupplierModel newSupplier = new SupplierModel
                    {
                        SupplierName = view.SupplierName.Trim(),
                        SupplierPhone = view.SupplierPhone.Trim(),
                        SupplierAddress = view.SupplierAddress.Trim()
                    };


                    if (string.IsNullOrWhiteSpace(newSupplier.SupplierName) || string.IsNullOrWhiteSpace(newSupplier.SupplierPhone))
                    {
                        MessageBox.Show("Tên nhà cung cấp và số điện thoại không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!IsValidPhoneNumber(newSupplier.SupplierPhone))
                    {
                        MessageBox.Show("Vui lòng nhập số điện thoại hợp lệ!", "Thông báo");
                        return;
                    }


                    bool isAddSuccessfull = _supplierService.AddSupplier(newSupplier);
                    if (isAddSuccessfull)
                    {
                        MessageBox.Show("Nhà cung cấp đã được thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        view.CloseForm();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Thêm nhà cung cấp thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };


                view.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding data: {ex.Message}");
            }
        }

        private void OnUpdateData(object sender, EventArgs e)
        {
            var currentSupplier = _suppliersView.GetSelectedSupplier();
            if (currentSupplier == null)
            {
                MessageBox.Show("Cần chọn nhà cung cấp để cập nhật!");
                return;
            }

            try
            {
                AddSupplierForm view = new AddSupplierForm()
                {
                    SupplierName = currentSupplier.SupplierName,
                    SupplierPhone = currentSupplier.SupplierPhone,
                    SupplierAddress = currentSupplier.SupplierAddress,
                    IsEditMode = true
                };

                view.LabelHeader = "Cập nhật thông tin nhà cung cấp";
                view.UpdateSupplier += (s, args) =>
                {
                    int id = currentSupplier.SupplierId;
                    string newSupplierName = view.SupplierName.Trim();
                    string newSupplierPhone = view.SupplierPhone.Trim();
                    string newSupplierAddress = view.SupplierAddress;

                    if (string.IsNullOrWhiteSpace(newSupplierName) || string.IsNullOrWhiteSpace(newSupplierPhone))
                    {
                        MessageBox.Show("Tên nhà cung cấp và số điện thoại nhóm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!IsValidPhoneNumber(newSupplierPhone))
                    {
                        MessageBox.Show("Vui lòng nhập số điện thoại hợp lệ!", "Thông báo");
                        return;
                    }


                    currentSupplier.SupplierName = newSupplierName;
                    currentSupplier.SupplierPhone = newSupplierPhone;
                    currentSupplier.SupplierAddress = newSupplierAddress;


                    bool isUpdateSuccessfull = _supplierService.UpdateSupplier(id, currentSupplier);
                    if (isUpdateSuccessfull)
                    {
                        MessageBox.Show("Nhà cung cấp đã được cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        view.CloseForm();
                        LoadData();
                    }else
                    {
                        MessageBox.Show("Nhà cung cấp đã được cập nhat FAIL", "Thông báo");
                    }
                   

                };

                view.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating data: {ex.Message}");
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

        private bool IsValidPhoneNumber(string phoneNumber)
        {

            var cleaned = new string(phoneNumber.Where(char.IsDigit).ToArray());
            return cleaned.Length >= 10 && cleaned.Length <= 15;
        }

    }
}
