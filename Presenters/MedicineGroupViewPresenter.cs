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
        private readonly IMedicineCategoryView _view;
        private readonly IMedicineGroup _repository;
        private readonly string _connectionString;

        public MedicineGroupViewPresenter(IMedicineCategoryView view, string connectionString )
        {
            _view = view;
            
            _connectionString = connectionString;
            _repository = new MedicineGroupRepository(_connectionString);
            // Đăng ký sự kiện
            _view.AddData += OnAddData;
            //_view.UpdateData += OnUpdateData;
            _view.DeleteData += OnDeleteData;
        }

        private void OnAddData(object sender, EventArgs e)
        {
            try
            {
                MedicineCategoryAddForm view = new MedicineCategoryAddForm(_connectionString);
                view.ShowDialog();
                LoadData();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding data: {ex.Message}");
            }
        }

        public void LoadData()
        {
            try
            {
                List<MedicineGroupModel> medicineGroups = _repository.GetAllMedicineGroups();
                _view.DisplayMedicineGroups(medicineGroups);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        //private void OnUpdateData(object sender, EventArgs e)
        //{
        //    var medicineGroup = _view.GetSelectedMedicineGroup();
        //    if (medicineGroup != null)
        //    {
        //        _repository.UpdateMedicineGroup()
        //        OnLoadData(sender, e); // Tải lại dữ liệu sau khi cập nhật
        //    }
        //}

        private void OnDeleteData(object sender, EventArgs e)
        {
            var medicineGroup = _view.GetSelectedMedicineGroup();
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
    }

}
