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
            new HomePresenter(this, connectionString);
            FromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            ToDate = DateTime.Now;
        }

        public DateTime FromDate { get => dtpFromDate.Value; set => dtpFromDate.Value = value; }
        public DateTime ToDate { get => dtpToDate.Value; set => dtpToDate.Value = value; }

        public void DisplayEmployeeRoleChart(List<RoleCountModel> roleCounts)
        {
            
            chartEmployeeRoles.Series.Clear();
            chartEmployeeRoles.Titles.Clear();

            var series = new Series("Số lượng nhân viên")
            {
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true, // Hiển thị giá trị trên mỗi cột
                LabelFormat = "N0"          // Định dạng số nguyên
            };
            chartEmployeeRoles.Series.Add(series);

            foreach (var roleCount in roleCounts)
            {
                series.Points.AddXY(roleCount.Role, roleCount.Count);
            }

            ConfigureChartDisplay();
        }

        public void DisplayFinancialReport(List<POSBillReport> financialReport) 
        {
            
            FinanceChartControl.Series.Clear();
            FinanceChartControl.Titles.Clear();

            // Tạo biểu đồ doanh thu
            var revenueChart = new Series("Doanh thu")
            {
                ChartType = SeriesChartType.Line,
                IsValueShownAsLabel = true,
                LabelFormat = "C0" // Định dạng tiền tệ
            };
            FinanceChartControl.Series.Add(revenueChart);

            // Tạo biểu đồ số hóa đơn
            var billsChart = new Series("Số hóa đơn")
            {
                ChartType = SeriesChartType.Line,
                IsValueShownAsLabel = true,
                LabelFormat = "N0" // Định dạng số nguyên
            };
            FinanceChartControl.Series.Add(billsChart);

            // Tạo biểu đồ doanh thu trung bình
            var avgRevenueChart = new Series("Doanh thu trung bình")
            {
                ChartType = SeriesChartType.Line,
                IsValueShownAsLabel = true,
                LabelFormat = "C0" // Định dạng tiền tệ
            };
            FinanceChartControl.Series.Add(avgRevenueChart);

            // Thêm dữ liệu vào các biểu đồ
            foreach (var report in financialReport)
            {
                revenueChart.Points.AddXY(report.Date.ToString("dd/MM/yyyy"), report.TotalRevenue);
                billsChart.Points.AddXY(report.Date.ToString("dd/MM/yyyy"), report.TotalBills);
                avgRevenueChart.Points.AddXY(report.Date.ToString("dd/MM/yyyy"), report.AverageReceiveAmount);
            }

            // Cấu hình biểu đồ
            FinanceChartControl.ChartAreas[0].AxisX.Title = "Ngày";
            FinanceChartControl.ChartAreas[0].AxisY.Title = "Giá trị";
            FinanceChartControl.Titles.Add("Báo cáo tài chính");
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
