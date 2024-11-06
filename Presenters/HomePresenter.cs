using PharmacySystem.Repositories.UserRepository;
using PharmacySystem.Services;
using PharmacySystem.Views.DashboardForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystem.Presenters
{
    public class HomePresenter
    {
        private readonly string _connectionString;
        private readonly IHomeView _view;
        private readonly UserRepository _userRepository;
        private readonly POSService _posService;
        public HomePresenter(IHomeView view, string connectionString)
        {
            _connectionString = connectionString;
            _view = view;

            _userRepository = new UserRepository(_connectionString);
            _posService = new POSService(_connectionString);

            _view.LoadFinancialReport += OnLoadFinancialReport;
            LoadEmployeeRoleChart();
            LoadFinancialReport();
        }

        private void OnLoadFinancialReport(object sender, EventArgs e)
        {
            LoadFinancialReport();
        }

        private async void LoadEmployeeRoleChart()
        {
            var roleCounts = await _userRepository.GetEmployeeCountByRole();
            _view.DisplayEmployeeRoleChart(roleCounts);
        }

        private void LoadFinancialReport()
        {
            DateTime fromDate = _view.FromDate;
            DateTime toDate = _view.ToDate;
            var financialReport = _posService.GetFinancialReport(fromDate, toDate);
            _view.DisplayFinancialReport(financialReport);
        }
    }
}
