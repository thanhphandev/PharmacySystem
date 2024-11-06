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
            
            AssociateAndRaiseViewEvents();
        }

        public event EventHandler LoadFinancialReport;

        private void AssociateAndRaiseViewEvents()
        {
            DateTime fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime toDate = DateTime.Now;
            dtpFromDate.Value = fromDate;
            dtpToDate.Value = toDate;
            dtpFromDate.ValueChanged += delegate 
            {
               LoadFinancialReport?.Invoke(this, EventArgs.Empty);
            };
            
            dtpToDate.ValueChanged += delegate 
            {
               LoadFinancialReport?.Invoke(this, EventArgs.Empty);
            };
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
            // Clear existing chart
            RevenueChartControl.Series.Clear();
            RevenueChartControl.Titles.Clear();

            BillsChartControl.Series.Clear();
            BillsChartControl.Titles.Clear();

            AvgRevenueChartControl.Series.Clear();
            AvgRevenueChartControl.Titles.Clear();

            // Create chart series
            var revenueChart = new Series("Doanh thu")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                LabelFormat = "C0"
            };

            var billsChart = new Series("Số hóa đơn")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                LabelFormat = "N0" // Integer format
            };

            var avgRevenueChart = new Series("Doanh thu trung bình")
            {
                ChartType = SeriesChartType.Line,
                IsValueShownAsLabel = true,
                LabelFormat = "C0" // Currency format
            };

            // Add data to the chart series
            foreach (var report in financialReport)
            {
                revenueChart.Points.AddXY(report.Date.ToString("dd/MM/yyyy"), report.TotalRevenue);
                billsChart.Points.AddXY(report.Date.ToString("dd/MM/yyyy"), report.TotalBills);
                avgRevenueChart.Points.AddXY(report.Date.ToString("dd/MM/yyyy"), report.AverageReceiveAmount);
            }

            // Add series to the chart control
            RevenueChartControl.Series.Add(revenueChart);
            BillsChartControl.Series.Add(billsChart);
            AvgRevenueChartControl.Series.Add(avgRevenueChart);

            // Configure chart
            RevenueChartControl.ChartAreas[0].AxisX.Title = "Ngày";
            RevenueChartControl.ChartAreas[0].AxisY.Title = "Giá trị";
            RevenueChartControl.Titles.Add("Báo cáo lợi nhuận");
            
            BillsChartControl.ChartAreas[0].AxisX.Title = "Ngày";
            BillsChartControl.ChartAreas[0].AxisY.Title = "Giá trị";
            BillsChartControl.Titles.Add("Báo cáo hóa đơn");
            
            AvgRevenueChartControl.ChartAreas[0].AxisX.Title = "Ngày";
            AvgRevenueChartControl.ChartAreas[0].AxisY.Title = "Giá trị";
            AvgRevenueChartControl.Titles.Add("Báo cáo lợi nhuận bình quân");
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
