using PharmacySystem.Models;
using PharmacySystem.Presenters;
using PharmacySystem.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PharmacySystem.Views.DashboardForm
{
    public partial class HomeUI : Form, IHomeView
    {

        public HomeUI(string connectionString)
        {
            InitializeComponent();
            var presenter = new HomePresenter(this, connectionString);
            presenter.LoadEmployeeRoleChart();
        } 

        public void DisplayEmployeeRoleChart(List<RoleCountModel> roleCounts)
        {
            
            chartEmployeeRoles.Series.Clear();
            chartEmployeeRoles.Titles.Clear();

            // Thiết lập series cho biểu đồ
            var series = new Series("Số lượng nhân viên")
            {
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true, // Hiển thị giá trị trên mỗi cột
                LabelFormat = "N0"          // Định dạng số nguyên
            };
            chartEmployeeRoles.Series.Add(series);

            // Thêm dữ liệu vào biểu đồ
            foreach (var roleCount in roleCounts)
            {
                series.Points.AddXY(roleCount.Role, roleCount.Count);
            }

            // Tùy chỉnh trục và tiêu đề biểu đồ
            ConfigureChartDisplay();
        }

        private void ConfigureChartDisplay()
        {
            // Cấu hình trục x và trục y
            chartEmployeeRoles.ChartAreas[0].AxisX.Title = "Vai trò";
            chartEmployeeRoles.ChartAreas[0].AxisY.Title = "Số lượng nhân viên";

            // Đảm bảo trục y chỉ hiển thị số nguyên
            chartEmployeeRoles.ChartAreas[0].AxisY.LabelStyle.Format = "N0";

            // Thêm tiêu đề biểu đồ
            chartEmployeeRoles.Titles.Add("Thống kê số lượng nhân viên theo vai trò");

            // Đặt khoảng cách tối thiểu trên trục y để các giá trị hiển thị rõ
            chartEmployeeRoles.ChartAreas[0].AxisY.Interval = 1;
        }

       
    }
}
