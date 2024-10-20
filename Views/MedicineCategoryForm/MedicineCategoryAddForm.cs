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
    public partial class MedicineCategoryAddForm : BaseAddForm, IMedicineGroupAddForm
    {
       
        public MedicineCategoryAddForm(string connectionString)
        {
            InitializeComponent();

            new MedicineGroupPresenter(this, connectionString);
            btnSave.Click += delegate
            {
                AddMedicineGroup?.Invoke(this, EventArgs.Empty);
            };

        }

        public string GroupCode { get => txtCode.Text; set => txtCode.Text = value; }
        public string GroupName { get => txtNameGroup.Text; set => txtNameGroup.Text = value; }
        public string Content { get => txtContent.Text; set => txtContent.Text = value; }

        public event EventHandler AddMedicineGroup;

        public void CloseForm()
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
    }
}
