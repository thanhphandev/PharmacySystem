using PharmacySystem.Models;
using PharmacySystem.Repositories.UserRepository;
using PharmacySystem.Services;
using PharmacySystem.Services.MedicineService;
using PharmacySystem.Views;
using PharmacySystem.Views.DashboardForm;
using PharmacySystem.Views.LoginForm;
using PharmacySystem.Views.MainForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystem.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _mainView;
        private readonly AuthService _authService;
        private readonly MedicineService _medicineService;
        private readonly MedicineGroupService _medicineGroup;
        private readonly string _connectionString;

        public MainPresenter(IMainView mainView, string connectionString)
        {
            _mainView = mainView;
            _connectionString = connectionString;

            _authService = new AuthService(_connectionString);
            _medicineService = new MedicineService(_connectionString);
            _medicineGroup = new MedicineGroupService(_connectionString);

            _mainView.Logout += OnLogout;
            _mainView.ShowDashboard += OnShowDashboard;
        }

        public void LoadData()
        {
            LoadMedicineGroups();
            LoadAllMedicines();
        }

        public void LoadAllMedicines()
        {
            var medicineProducts = _medicineService.GetAllMedicineProduct();

            _mainView.LoadMedicineData(medicineProducts);
        }


        private void LoadMedicineGroups()
        {
            var medicineGroups = _medicineGroup.GetAllMedicineGroups();
            medicineGroups.Insert(0, new MedicineGroupModel
            {
                GroupCode = null,
                GroupName = "Tất cả"
            });

            _mainView.LoadMedicineGroups(medicineGroups);
        }

        public void FilterMedicinesByGroupId(string groupId)
        {
            var filteredMedicines = _medicineService.GetMedicineProductsByGroupCode(groupId);
            _mainView.LoadMedicineData(filteredMedicines);
        }

        public void SearchMedicines(string searchText, string groupCode)
        {
            try
            {
                List<MedicineProductModel> medicines;

                if (!string.IsNullOrEmpty(groupCode))
                {
                    // Search within the selected group
                    medicines = _medicineService.GetMedicineProductsByNameAndGroup(searchText, groupCode);
                }
                else
                {
                    // Search across all groups
                    medicines = _medicineService.GetMedicineProductsByNameAndGroup(searchText, null);
                }

                _mainView.LoadMedicineData(medicines); // Display results in the view
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during search: {ex.Message}");
            }
        }

        private void OnShowDashboard(object sender, EventArgs e)
        {
            DashboardView dashboardView = new DashboardView(_connectionString);
            dashboardView.Show();
            _mainView.CloseForm();
        }

        private void OnLogout(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn đăng xuất không?!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return;
            }
            LoginView loginView = new LoginView(_connectionString);
            loginView.Show();
            _authService.Logout();
            _mainView.CloseForm();
        }
    }
}
