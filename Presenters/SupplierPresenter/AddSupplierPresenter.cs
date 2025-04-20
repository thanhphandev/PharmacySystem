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
            var newSupplier = new SupplierModel
            {
                Name = _addSupplierView.SupplierName.Trim(),
                Phone = _addSupplierView.SupplierPhone.Trim(),
                Address = _addSupplierView.SupplierAddress?.Trim(),
                TaxCode = _addSupplierView.TaxCode?.Trim()
            };

            var (Success, ErrorMessage) = _supplierService.AddSupplier(newSupplier);

            if (Success)
            {
                MessageBox.Show("Nhà cung cấp đã được thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _addSupplierView.CloseForm();
            }
            else
            {
                MessageBox.Show(ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OnUpdateData(object sender, EventArgs e)
        {
            var updatedSupplier = new SupplierModel
            {
                ID = _addSupplierView.SupplierId,
                Name = _addSupplierView.SupplierName.Trim(),
                Phone = _addSupplierView.SupplierPhone.Trim(),
                Address = _addSupplierView.SupplierAddress?.Trim(),
                TaxCode = _addSupplierView.TaxCode?.Trim()
            };

            var (Success, ErrorMessage) = _supplierService.UpdateSupplier(updatedSupplier.ID, updatedSupplier);

            if (Success)
            {
                MessageBox.Show("Nhà cung cấp đã được cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _addSupplierView.CloseForm();
            }
            else
            {
                MessageBox.Show(ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
