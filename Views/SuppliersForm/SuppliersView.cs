﻿using PharmacySystem.Models;
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

namespace PharmacySystem.Views.SuppliersForm
{
    public partial class SuppliersView : BaseManagementForm, ISuppliersView
    {
        private readonly string _connectionString;
        public event EventHandler AddData;
        public event EventHandler RefreshData;
        public event EventHandler UpdateData;
        public event EventHandler DeleteData;
        public event EventHandler SearchMedicineGroupsBasedOnFilter;

        public SuppliersView(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            new SupplierViewPresenter(this, _connectionString);
            AssociateAndRaiseViewEvents();

        }
        private void AssociateAndRaiseViewEvents()
        {
            cbFilter.SelectedItem = "All";

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

        public void DisplaySuppliers(List<SupplierModel> suppliers)
        {
            SupplierDataGrid.Rows.Clear();

            foreach (var supplier in suppliers)
            {
                SupplierDataGrid.Rows.Add(
                    supplier.SupplierId,
                    supplier.SupplierName,
                    supplier.SupplierPhone,
                    supplier.SupplierAddress
                    );
            }
        }

        public SupplierModel GetSelectedSupplier()
        {
            if (SupplierDataGrid.CurrentRow != null)
            {
                return new SupplierModel
                {
                    SupplierId = Convert.ToInt32(SupplierDataGrid.CurrentRow.Cells["Index"].Value),
                    SupplierName = SupplierDataGrid.CurrentRow.Cells["SupplierName"].Value.ToString(),
                    SupplierPhone = SupplierDataGrid.CurrentRow.Cells["SupplierPhone"].Value.ToString(),
                    SupplierAddress = SupplierDataGrid.CurrentRow.Cells["SupplierAddress"]?.Value.ToString()
                };

            }
            return null;
        }

        private void SupplierDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SupplierDataGrid.CurrentCell.OwningColumn.Name == "Edit")
            {
                UpdateData?.Invoke(this, EventArgs.Empty);
            }

            if (SupplierDataGrid.CurrentCell.OwningColumn.Name == "Delete")
            {
                DeleteData?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
