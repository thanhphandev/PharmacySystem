using Mysqlx.Crud;
using PharmacySystem.Models;
using PharmacySystem.Presenters.MedicinePresenter;
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


namespace PharmacySystem.Views.MedicinesForm
{
    public partial class AddMedicineForm : BaseAddForm, IAddMedicineForm
    {
        private string selectedImagePath;
        private bool isEditMode;

        public event EventHandler AddMedicine;
        public event EventHandler UpdateMedicine;
        public event EventHandler LeaveTextBoxName;

        public AddMedicineForm(string connectionString)
        {
            InitializeComponent();
            new AddMedicinePresenter(this, connectionString);
            txtName.Leave += delegate
            {
                LeaveTextBoxName?.Invoke(this, EventArgs.Empty);
            };
        }

        // LoadData from database
        public void SetAutoCompleteNameData(List<string> medicineName)
        {
            AutoCompleteStringCollection suggest = new AutoCompleteStringCollection();
            suggest.AddRange(medicineName.ToArray());

            // Configure TextBox for autocomplete
            txtName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtName.AutoCompleteCustomSource = suggest;
        }
        public void LoadMedicineGroups(List<MedicineGroupModel> medicineGroups)
        {
            cbMedicineGroup.DataSource = medicineGroups;
            cbMedicineGroup.DisplayMember = "GroupName";
            cbMedicineGroup.ValueMember = "GroupCode";
        }
        public void LoadUnitTypes(List<UnitTypeModel> unitTypes)
        {
            cbUnitType.DataSource = unitTypes;
            cbUnitType.DisplayMember = "UnitType";
            cbUnitType.ValueMember = "Id";
        }
        public void LoadSuppliers(List<SupplierModel> suppliers)
        {
            cbSupplier.DataSource = suppliers;
            cbSupplier.DisplayMember = "SupplierName";
            cbSupplier.ValueMember = "SupplierId";
        }

        // Properties
        public string LabelHeader { get => lbHeader.Text; set => lbHeader.Text = value; }
        public string MedicineCode
        { 
            get => txtCode.Text;
            set
            {
                txtCode.Text = value;
                txtCode.ReadOnly = true;
            }
        }
        public string MedicineName { get => txtName.Text; set => txtName.Text = value; }
        public int UnitType
        {
            get => (int)cbUnitType.SelectedValue;
            set 
            {
                cbUnitType.SelectedValue = value;
                cbUnitType.Enabled = false;
            }
        }
        public decimal MedicinePrice
        {
            get => decimal.TryParse(txtPrice.Text, out var price) ? price : 0;
            set
            {
                txtPrice.Text = value.ToString("F2");
                txtPrice.ReadOnly = true;
            }
        }

        public string MedicineImage
        {
            get => selectedImagePath;
            set
            {
                selectedImagePath = value;
                pbMedicineImage.ImageLocation = selectedImagePath;
                btnBrowse.Hide();
            }
        }
        public string MedicineContent 
        {
            get => txtContent.Text;
            set 
            {
                txtContent.Text = value;
                txtContent.ReadOnly = true;
            }
        }
        public string MedicineElement 
        {
            get => txtElement.Text;
            set
            {
                txtElement.Text = value;
                txtElement.ReadOnly = true;
            }
        }
        public string GroupCode {
            get => cbMedicineGroup.SelectedValue?.ToString() ?? string.Empty;
            set 
            {
                cbMedicineGroup.SelectedValue = value;
                cbMedicineGroup.Enabled = false;
            }
        }
        public DateTime ExpireDate { get => txtExpireDate.Value; set => txtExpireDate.Value = value; }
        public int SupplierId { get => (int)cbSupplier.SelectedValue; set => cbSupplier.SelectedValue = value; }
        public int Quantity
        {
            get => int.TryParse(txtQuantity.Text, out var quantity) ? quantity : 0;
            set => txtQuantity.Text = value.ToString();
        }
        public bool IsEditMode { get => isEditMode; set => isEditMode = value; }

        public void CloseForm()
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName;
                    pbMedicineImage.Image = Image.FromFile(selectedImagePath);
                    
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsEditMode)
            {
                UpdateMedicine?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                AddMedicine?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
