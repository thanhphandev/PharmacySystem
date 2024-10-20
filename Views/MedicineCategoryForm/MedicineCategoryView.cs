using PharmacySystem.Models;
using PharmacySystem.Presenters;
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


namespace PharmacySystem.Views.MedicineCategoryForm
{
    public partial class MedicineCategoryView : BaseManagementForm, IMedicineCategoryView
    {
        private readonly string _connectionString;

        public event EventHandler LoadData;

        public event EventHandler UpdateData;
        public event EventHandler DeleteData;
        public event EventHandler AddData;

        public MedicineCategoryView(string connectionString)
        {
           
            InitializeComponent();
            _connectionString = connectionString;
            var presenter = new MedicineGroupViewPresenter(this, _connectionString);
            presenter.LoadData();
            btnAdd.Click += delegate
            {
                AddData?.Invoke(this, EventArgs.Empty);
            };
            

        }


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

        public void UpdateIndexColumn()
        {
            for (int i = 0; i < MedicineGroupDataGrid.Rows.Count; i++)
            {
                MedicineGroupDataGrid.Rows[i].Cells["Index"].Value = i + 1;
            }
        }

        private void MedicineGroupDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(MedicineGroupDataGrid.CurrentCell.OwningColumn.Name == "Edit")
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
