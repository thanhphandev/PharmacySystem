using PharmacySystem.Models;
using PharmacySystem.Services;
using PharmacySystem.Views.MedicineCategoryForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystem.Presenters.MedicineGroupPresenter
{
    public class AddMedicineGroupPresenter
    {
        private readonly IMedicineGroupAddForm _view;
        private readonly string _connectionString;
        private readonly MedicineGroupService _medicineGroupService;

        public AddMedicineGroupPresenter(IMedicineGroupAddForm view, string connectionString)
        {
            _view = view;
            _connectionString = connectionString;

            _medicineGroupService = new MedicineGroupService(_connectionString);
            _view.AddMedicineGroup += OnAddData;
            _view.UpdateMedicineGroup += OnUpdateData;
        }

        private void OnAddData(object sender, EventArgs e)
        {
            MedicineGroupModel newMedicineGroup = new MedicineGroupModel
            {
                GroupCode = _view.GroupCode.Trim(),
                GroupName = _view.GroupName.Trim(),
                Description = _view.Content.Trim()
            };


            if (string.IsNullOrWhiteSpace(newMedicineGroup.GroupCode) || string.IsNullOrWhiteSpace(newMedicineGroup.GroupName))
            {
                MessageBox.Show("Mã nhóm và tên nhóm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra tính duy nhất của GroupCode khi thêm mới
            bool isAddSuccessfull = _medicineGroupService.AddMedicineGroup(newMedicineGroup);
            if (isAddSuccessfull)
            {
                MessageBox.Show("Nhóm thuốc đã được thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _view.CloseForm();
            }
            else
            {
                MessageBox.Show("Mã nhóm đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OnUpdateData(object sender, EventArgs e)
        {
            string oldGroupCode = _view.GroupCode.Trim(); // Get old value to determine ID group code
            string newGroupCode = _view.GroupCode.Trim(); // Get new value to update
            string newGroupName = _view.GroupName.Trim();
            string newContent = _view.Content.Trim();

            if (string.IsNullOrWhiteSpace(newGroupCode) || string.IsNullOrWhiteSpace(newGroupName))
            {
                MessageBox.Show("Mã nhóm và tên nhóm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!newGroupCode.Equals(oldGroupCode))
            {
                var existGroup = _medicineGroupService.CheckGroupExist(newGroupCode);
                if (existGroup != null)
                {
                    MessageBox.Show("Mã nhóm đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var updatedGroupCode = new MedicineGroupModel()
            {
                GroupCode = newGroupCode,
                GroupName = newGroupName,
                Description = newContent
            };
            

            bool isUpdateSuccessfull = _medicineGroupService.UpdateMedicineGroup(oldGroupCode, updatedGroupCode);
            if (isUpdateSuccessfull)
            {
                MessageBox.Show("Nhóm thuốc đã được cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _view.CloseForm();
            }
        }

    }
}
