using PharmacySystem.Presenters.SupplierPresenter;
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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace PharmacySystem.Views.SuppliersForm
{
    public partial class AddSupplierForm : BaseAddForm, IAddSupplierView
    {
        private bool isEditMode;
        private int id;
        public AddSupplierForm(string connectionString)
        {
            InitializeComponent();
            new AddSupplierPresenter(this, connectionString);
        }

        public string LabelHeader { get => lbHeader.Text; set => lbHeader.Text = value; }
        public bool IsEditMode { get => isEditMode; set => isEditMode = value; }
        public string SupplierName { get => txtSupplierName.Text; set => txtSupplierName.Text = value; }
        public string SupplierPhone { get => txtSupplierPhone.Text; set => txtSupplierPhone.Text = value; }
        public string SupplierAddress { get => txtSupplierAddress.Text; set => txtSupplierAddress.Text = value; }
        public int SupplierId { get => id; set => id = value; }

        public event EventHandler AddSupplier;
        public event EventHandler UpdateSupplier;

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
                UpdateSupplier?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                AddSupplier?.Invoke(this, EventArgs.Empty);
            }
        }

        
    }
}
