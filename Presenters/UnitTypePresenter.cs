using PharmacySystem.Repositories.UnitTypeRepository;
using PharmacySystem.Services;
using PharmacySystem.Views.UnitTypeForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystem.Presenters
{
    public class UnitTypePresenter
    {
        private readonly UnitTypeService _unitTypeService;
        private readonly IUnitTypeView _unitTypeView;
        private readonly string _connectionString;
        public UnitTypePresenter(IUnitTypeView unitTypeView, string connectionString)
        {
            _unitTypeView = unitTypeView;
            _connectionString = connectionString;
            _unitTypeService = new UnitTypeService(_connectionString);
            _unitTypeView.AddUnitType += OnAddData;
            _unitTypeView.DeleteUnitType += OnDeleteData;
        }

        private void OnDeleteData(object sender, EventArgs e)
        {
            var selectedUnitType = _unitTypeView.SelectedUnitType;

            if (string.IsNullOrWhiteSpace(selectedUnitType))
            {
                MessageBox.Show("Vui lòng chọn một đơn vị để xóa", "Thông báo");
                return;
            }

            // Hiển thị hộp thoại xác nhận xóa
            var confirmationResult = MessageBox.Show(
                $"Bạn có chắc muốn xóa đơn vị '{selectedUnitType}' không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmationResult != DialogResult.Yes)
            {
                return;
            }

            try
            {
                
                bool isSuccessfull = _unitTypeService.DeleteUnitType(selectedUnitType);

                if (isSuccessfull)
                {
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không thể xóa đơn vị. Thử lại sau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi\nError: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void OnAddData(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_unitTypeView.UnitName))
            {
                MessageBox.Show("Vui lòng nhập tên đơn vị", "Thông báo");
                return;
            }
            try
            {
                bool isSuccessfull = _unitTypeService.AddUnitType(_unitTypeView.UnitName);
                if (isSuccessfull)
                {
                    MessageBox.Show("Thêm đơn vị thành công!", "Thông báo");
                }
                LoadData();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi\nError: {ex.Message}");
            }
        }

        public void LoadData()
        {
            var unitTypes = _unitTypeService.GetAllUnitTypes();
            if (unitTypes == null)
            {
                MessageBox.Show("Không có dữ liệu loại đơn vị.", "Thông báo");
            }
            else
            {
                _unitTypeView.LoadData(unitTypes);
            }
            
        }
    }
}
