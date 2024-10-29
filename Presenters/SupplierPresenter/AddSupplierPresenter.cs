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
    public class AddSupplierPresenter
    {
        private readonly string _connectionString;
        private readonly IAddSupplierView _addSupplierView;
        private readonly SupplierService _supplierService;

        public AddSupplierPresenter(IAddSupplierView addSupplierView, string connectionString)
        {
            _connectionString = connectionString;
            _addSupplierView = addSupplierView;
            _supplierService = new SupplierService(_connectionString);

            _addSupplierView.AddSupplier += OnAddData;
            _addSupplierView.UpdateSupplier += OnUpdateData;

        }
        private void OnAddData(object sender, EventArgs e)
        {
            SupplierModel newSupplier = new SupplierModel
            {
                SupplierName = _addSupplierView.SupplierName.Trim(),
                SupplierPhone = _addSupplierView.SupplierPhone.Trim(),
                SupplierAddress = _addSupplierView.SupplierAddress.Trim()
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
                _addSupplierView.CloseForm();
                
            }
            else
            {
                MessageBox.Show("Thêm nhà cung cấp thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OnUpdateData(object sender, EventArgs e)
        {
            
            int id = _addSupplierView.SupplierId;
            string newSupplierName = _addSupplierView.SupplierName.Trim();
            string newSupplierPhone = _addSupplierView.SupplierPhone.Trim();
            string newSupplierAddress = _addSupplierView.SupplierAddress;


            var updatedSupplier = new SupplierModel
            {
                SupplierId = id,
                SupplierName = newSupplierName,
                SupplierPhone = newSupplierPhone,
                SupplierAddress = newSupplierAddress
            };

            if (!IsValidSupplierData(updatedSupplier)) return;

            bool isUpdateSuccessfull = _supplierService.UpdateSupplier(id, updatedSupplier);
            if (isUpdateSuccessfull)
            {
                MessageBox.Show("Nhà cung cấp đã được cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _addSupplierView.CloseForm();
            }

        }

        private bool IsValidSupplierData(SupplierModel supplier)
        {
            if (string.IsNullOrWhiteSpace(supplier.SupplierName) || string.IsNullOrWhiteSpace(supplier.SupplierPhone))
            {
                MessageBox.Show("Tên nhà cung cấp và số điện thoại không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!IsValidPhoneNumber(supplier.SupplierPhone))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {

            var cleaned = new string(phoneNumber.Where(char.IsDigit).ToArray());
            return cleaned.Length >= 10 && cleaned.Length <= 15;
        }
    }
}
