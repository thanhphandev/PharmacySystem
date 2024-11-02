using PharmacySystem.Repositories.UserRepository;
using PharmacySystem.Views.DashboardForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Presenters
{
    public class HomePresenter
    {
        private readonly string _connectionString;
        private readonly IHomeView _view;
        private readonly UserRepository _userRepository;
        public HomePresenter(IHomeView view, string connectionString)
        {
            _connectionString = connectionString;
            _view = view;

            _userRepository = new UserRepository(_connectionString);
        }

        public async void LoadEmployeeRoleChart()
        {
            var roleCounts = await _userRepository.GetEmployeeCountByRole();
            _view.DisplayEmployeeRoleChart(roleCounts);
        }
    }
}
