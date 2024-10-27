using PharmacySystem.Models;
using PharmacySystem.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystem.Views.UnitTypeForm
{
    public partial class UnitTypeView : Form, IUnitTypeView
    {
        public event EventHandler AddUnitType;
        public event EventHandler DeleteUnitType;

        public UnitTypeView(string connectionString)
        {
            InitializeComponent();
            var presenter = new UnitTypePresenter(this, connectionString);
            presenter.LoadData();

            btnAdd.Click += delegate
            {
                AddUnitType?.Invoke(this, EventArgs.Empty);
            };
            btnDelete.Click += delegate
            {
                DeleteUnitType?.Invoke(this, EventArgs.Empty);
            };
        }

        public string SelectedUnitType
        {
            get => lstUnitType.SelectedItem?.ToString();
            set => lstUnitType.SelectedItem = value;
        }
        public string UnitName { get => txtUnitType.Text; set => txtUnitType.Text = value; }

        public void LoadData(List<UnitTypeModel> unitTypes)
        {
            txtUnitType.Text = string.Empty;
            lstUnitType.Items.Clear();
            foreach (var unitType in unitTypes)
            {
                if (!string.IsNullOrEmpty(unitType.UnitType))
                {
                    lstUnitType.Items.Add(unitType.UnitType);
                }
            }
        }
    }
}
