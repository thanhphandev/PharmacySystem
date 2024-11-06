using PharmacySystem.Models;
using PharmacySystem.Presenters;
using PharmacySystem.Presenters.MedicineGroupPresenter;
using PharmacySystem.Views.DashboardForm.BaseForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace PharmacySystem.Views.MedicineCategoryForm
{
    public partial class MedicineCategoryView : BaseManagementForm, IMedicineCategoryView
    {
        private readonly string _connectionString;
        public event EventHandler UpdateData;
        public event EventHandler DeleteData;
        public event EventHandler AddData;
        public event EventHandler RefreshData;
        public event EventHandler SearchMedicineGroupsBasedOnFilter;

        public MedicineCategoryView(string connectionString)
        {

            InitializeComponent();
            _connectionString = connectionString;
            new MedicineGroupViewPresenter(this, _connectionString);
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            cbFilter.SelectedItem = "Tên Nhóm";

            btnAdd.Click += delegate
            {
                AddData?.Invoke(this, EventArgs.Empty);
            };

            btnRefresh.Click += delegate
            {
                RefreshData?.Invoke(this, EventArgs.Empty);
            };

            txtSearch.TextChanged += delegate
            {
                SearchMedicineGroupsBasedOnFilter?.Invoke(this, EventArgs.Empty);
            };

            cbFilter.SelectedIndexChanged += delegate
            {
                SearchMedicineGroupsBasedOnFilter?.Invoke(this, EventArgs.Empty);
            };

        }

        public string TextSearch { get => txtSearch.Text; set => txtSearch.Text = value; }
        public string TextFilter { get => cbFilter.SelectedItem?.ToString(); set => cbFilter.SelectedItem = value; }

        public void DisplayMedicineGroups(List<MedicineGroupModel> medicineGroups)
        {
            MedicineGroupDataGrid.Rows.Clear();

            foreach (var medicineGroup in medicineGroups)
            {
                MedicineGroupDataGrid.Rows.Add(
                    medicineGroups.IndexOf(medicineGroup) + 1,
                    medicineGroup.GroupCode,
                    medicineGroup.GroupName,
                    medicineGroup.Description
                    );
            }

        }


        public MedicineGroupModel GetSelectedMedicineGroup()
        {
            if (MedicineGroupDataGrid.CurrentRow != null)
            {
                return new MedicineGroupModel
                {
                    GroupCode = MedicineGroupDataGrid.CurrentRow.Cells["GroupCode"].Value.ToString(),
                    GroupName = MedicineGroupDataGrid.CurrentRow.Cells["GroupName"].Value.ToString(),
                    Description = MedicineGroupDataGrid.CurrentRow.Cells["Description"].Value.ToString()
                };

            }
            return null;
        }

        private void MedicineGroupDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MedicineGroupDataGrid.CurrentCell.OwningColumn.Name == "Edit")
            {
                UpdateData?.Invoke(this, EventArgs.Empty);
            }

            if (MedicineGroupDataGrid.CurrentCell.OwningColumn.Name == "Delete")
            {
                DeleteData?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
