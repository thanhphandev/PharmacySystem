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


namespace PharmacySystem.Presenters.MedicineGroupPresenter
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
            _medicineCategoryView.SearchMedicineGroupsBasedOnFilter += OnSearchMedicineGroupsBasedOnFilter;
            LoadData();
        }

        private void OnSearchMedicineGroupsBasedOnFilter(object sender, EventArgs e)
        {
            string filter = _medicineCategoryView.TextFilter;
            string textSearch = _medicineCategoryView.TextSearch;

            if (!string.IsNullOrWhiteSpace(textSearch))
            {
                if (filter == "Mã nhóm")
                {
                    SearchMedicineGroups(textSearch, searchByCode: true, searchByName: false);
                }
                else
                {
                    SearchMedicineGroups(textSearch, searchByCode: false, searchByName: true);
                }
            }
            else
            {
                LoadData();
            }
        }
        
        private void OnRefreshData(object sender, EventArgs e)
        { 
            LoadData();
        }

        private void LoadData()
        {

            try
            {
                _medicineCategoryView.TextSearch = string.Empty;
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
                MedicineCategoryAddForm view = new MedicineCategoryAddForm(_connectionString)
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
                    OldGroupCode = currentMedicineGroup.GroupCode,
                    GroupCode = currentMedicineGroup.GroupCode,
                    GroupName = currentMedicineGroup.GroupName,
                    Content = currentMedicineGroup.Description,
                    IsEditMode = true,
                    LabelHeader = "Cập nhật nhóm thuốc"
                };

                view.ShowDialog();
                LoadData();
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

        private void SearchMedicineGroups(string searchText, bool searchByCode = true, bool searchByName = true)
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