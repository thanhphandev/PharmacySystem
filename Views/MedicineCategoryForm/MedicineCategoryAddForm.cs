using Mysqlx.Crud;
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

namespace PharmacySystem.Views.MedicineCategoryForm
{
    public partial class MedicineCategoryAddForm : BaseAddForm, IMedicineGroupAddForm
    {

        private bool isEditMode;
        private string oldGroupCode;
        public MedicineCategoryAddForm(string connectionString)
        {
            new AddMedicineGroupPresenter(this, connectionString);
            InitializeComponent();

        }

        public string GroupCode { get => txtCode.Text; set => txtCode.Text = value; }
        public string GroupName { get => txtNameGroup.Text; set => txtNameGroup.Text = value; }
        public string Content { get => txtContent.Text; set => txtContent.Text = value; }
        public string LabelHeader { get => lbHeader.Text; set => lbHeader.Text = value; }
        public bool IsEditMode { get => isEditMode; set => isEditMode = value; }
        public string OldGroupCode { get => oldGroupCode; set => oldGroupCode = value; }

        public event EventHandler AddMedicineGroup;
        public event EventHandler UpdateMedicineGroup;

        public void CloseForm()
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsEditMode)
            {
                UpdateMedicineGroup?.Invoke(this, EventArgs.Empty);
            } else
            {
                AddMedicineGroup?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
