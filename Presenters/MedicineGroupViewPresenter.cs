using PharmacySystem.Common;
using PharmacySystem.Models;
using PharmacySystem.Repositories.MedicineGroupRepository;
using PharmacySystem.Services;
using PharmacySystem.Views.MedicineCategoryForm;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PharmacySystem.Presenters
{
    public class MedicineGroupViewPresenter
    {
        private readonly IMedicineCategoryView _medicineCategoryView;
        private readonly string _connectionString;
        private readonly MedicineGroupService _medicineGroupService;


        public MedicineGroupViewPresenter(IMedicineCategoryView medicineCategoryView, string connectionString)
        {
            _medicineCategoryView = medicineCategoryView;
            _connectionString = connectionString;
            _medicineGroupService = new MedicineGroupService(_connectionString);

            _medicineCategoryView.AddData += OnAddData;
            _medicineCategoryView.UpdateData += OnUpdateData;
            _medicineCategoryView.DeleteData += OnDeleteData;
            _medicineCategoryView.RefreshData += OnRefreshData;
        }

        private void OnRefreshData(object sender, EventArgs e)
        {
            _medicineCategoryView.TextSearch = string.Empty;
            LoadData();
        }

        public void LoadData()
        {

            try
            {
                List<MedicineGroupModel> medicineGroups = _medicineGroupService.GetAllMedicineGroups();

                _medicineCategoryView.DisplayMedicineGroups(medicineGroups);
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
                MedicineCategoryAddForm view = new MedicineCategoryAddForm()
                {
                    IsEditMode = false
                };

                view.AddMedicineGroup += (s, args) =>
                {
                    MedicineGroupModel newMedicineGroup = new MedicineGroupModel
                    {
                        GroupCode = view.GroupCode.Trim(),
                        GroupName = view.GroupName.Trim(),
                        Description = view.Content.Trim()
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
                        view.CloseForm();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Mã nhóm đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            var currentMedicineGroup = _medicineCategoryView.GetSelectedMedicineGroup();
            if (currentMedicineGroup == null)
            {
                MessageBox.Show("Cần chọn một nhóm để cập nhật!");
                return;
            }

            try
            {
                MedicineCategoryAddForm view = new MedicineCategoryAddForm()
                {
                    GroupCode = currentMedicineGroup.GroupCode,
                    GroupName = currentMedicineGroup.GroupName,
                    Content = currentMedicineGroup.Description,
                    IsEditMode = true
                };

                view.LabelHeader = "Cập nhật nhóm thuốc";
                view.UpdateMedicineGroup += (s, args) =>
                {
                    string oldGroupCode = currentMedicineGroup.GroupCode;
                    string newGroupCode = view.GroupCode.Trim();
                    string newGroupName = view.GroupName.Trim();

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


                    currentMedicineGroup.GroupCode = newGroupCode;
                    currentMedicineGroup.GroupName = newGroupName;
                    currentMedicineGroup.Description = view.Content.Trim();

                    bool isUpdateSuccessfull = _medicineGroupService.UpdateMedicineGroup(oldGroupCode, currentMedicineGroup);
                    if (isUpdateSuccessfull)
                    {
                        MessageBox.Show("Nhóm thuốc đã được cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        view.CloseForm();
                        LoadData();
                    }
                    _medicineCategoryView.TextSearch = string.Empty;

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
            var medicineGroup = _medicineCategoryView.GetSelectedMedicineGroup();
            if (medicineGroup != null)
            {
                var result = MessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    return;
                }
                _medicineGroupService.DeleteMedicineGroup(medicineGroup.GroupCode);
                LoadData();
            }
        }



        public void SearchMedicineGroups(string searchText, bool searchByCode = true, bool searchByName = true)
        {
            try
            {
                List<MedicineGroupModel> allMedicineGroups = _medicineGroupService.GetAllMedicineGroups();

                string normalizedSearchText = DiacriticsRemover.RemoveDiacritics(searchText).ToLowerInvariant();

                var filteredMedicineGroups = allMedicineGroups.Where(mg =>
                    (searchByCode && DiacriticsRemover.RemoveDiacritics(mg.GroupCode).ToLowerInvariant().Contains(normalizedSearchText)) ||
                    (searchByName && DiacriticsRemover.RemoveDiacritics(mg.GroupName).ToLowerInvariant().Contains(normalizedSearchText))
                ).ToList();

                _medicineCategoryView.DisplayMedicineGroups(filteredMedicineGroups);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching data: {ex.Message}");
            }
        }

    }

}