using PharmacySystem.Models;
using PharmacySystem.Repositories.MedicineGroupRepository;
using PharmacySystem.Views.MedicineCategoryForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystem.Presenters
{
    public class MedicineGroupViewPresenter
    {
        private readonly IMedicineCategoryView _medicineCategoryView;
        private readonly IMedicineGroup _repository;
        private readonly string _connectionString;

        public MedicineGroupViewPresenter(IMedicineCategoryView medicineCategoryView, string connectionString )
        {
            _medicineCategoryView = medicineCategoryView;
            
            _connectionString = connectionString;
            _repository = new MedicineGroupRepository(_connectionString);
  
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
                List<MedicineGroupModel> medicineGroups = _repository.GetAllMedicineGroups();

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
                MedicineCategoryAddForm view = new MedicineCategoryAddForm(_connectionString)
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

                    _repository.AddMedicineGroup(newMedicineGroup);
                    MessageBox.Show("Nhóm thuốc đã được thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    view.CloseForm();
                    LoadData();
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

                MedicineCategoryAddForm view = new MedicineCategoryAddForm(_connectionString)
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


                    currentMedicineGroup.GroupCode = view.GroupCode.Trim();
                    currentMedicineGroup.GroupName = view.GroupName.Trim();
                    currentMedicineGroup.Description = view.Content.Trim();

                    _repository.UpdateMedicineGroup(oldGroupCode, currentMedicineGroup);

                    MessageBox.Show("Nhóm thuốc đã được cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    view.CloseForm();
                    LoadData();
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
                if(result != DialogResult.Yes)
                {
                    return;
                }
                _repository.DeleteMedicineGroup(medicineGroup.GroupCode);
                LoadData();
            }
        }

        public void SearchMedicineGroups(string searchText)
        {
            try
            {
               
                List<MedicineGroupModel> allMedicineGroups = _repository.GetAllMedicineGroups();

                
                var filteredMedicineGroups = allMedicineGroups
                    .Where(mg => mg.GroupCode.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 mg.GroupName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 mg.Description.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();

                _medicineCategoryView.DisplayMedicineGroups(filteredMedicineGroups);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching data: {ex.Message}");
            }
        }

        


    }

}
