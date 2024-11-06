namespace PharmacySystem.Views.DashboardForm
{
    partial class HomeUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartEmployeeRoles = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RevenueChartControl = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.AvgRevenueChartControl = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BillsChartControl = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartEmployeeRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RevenueChartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvgRevenueChartControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillsChartControl)).BeginInit();
            this.SuspendLayout();
            // 
            // chartEmployeeRoles
            // 
            this.chartEmployeeRoles.BackColor = System.Drawing.SystemColors.ControlLightLight;
            chartArea1.Name = "ChartArea1";
            this.chartEmployeeRoles.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartEmployeeRoles.Legends.Add(legend1);
            this.chartEmployeeRoles.Location = new System.Drawing.Point(65, 80);
            this.chartEmployeeRoles.Name = "chartEmployeeRoles";
            this.chartEmployeeRoles.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartEmployeeRoles.Series.Add(series1);
            this.chartEmployeeRoles.Size = new System.Drawing.Size(306, 199);
            this.chartEmployeeRoles.TabIndex = 1;
            this.chartEmployeeRoles.Text = "chart2";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(703, 54);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(124, 20);
            this.dtpToDate.TabIndex = 3;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(497, 54);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(124, 20);
            this.dtpFromDate.TabIndex = 3;
            this.dtpFromDate.Value = new System.DateTime(2024, 11, 1, 23, 12, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(494, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Từ ngày";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(700, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Đến ngày";
            // 
            // RevenueChartControl
            // 
            chartArea2.Name = "ChartArea1";
            this.RevenueChartControl.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.RevenueChartControl.Legends.Add(legend2);
            this.RevenueChartControl.Location = new System.Drawing.Point(408, 80);
            this.RevenueChartControl.Name = "RevenueChartControl";
            this.RevenueChartControl.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.RevenueChartControl.Series.Add(series2);
            this.RevenueChartControl.Size = new System.Drawing.Size(419, 199);
            this.RevenueChartControl.TabIndex = 1;
            this.RevenueChartControl.Text = "chart2";
            // 
            // AvgRevenueChartControl
            // 
            chartArea3.Name = "ChartArea1";
            this.AvgRevenueChartControl.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.AvgRevenueChartControl.Legends.Add(legend3);
            this.AvgRevenueChartControl.Location = new System.Drawing.Point(66, 295);
            this.AvgRevenueChartControl.Name = "AvgRevenueChartControl";
            this.AvgRevenueChartControl.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.AvgRevenueChartControl.Series.Add(series3);
            this.AvgRevenueChartControl.Size = new System.Drawing.Size(305, 216);
            this.AvgRevenueChartControl.TabIndex = 1;
            this.AvgRevenueChartControl.Text = "chart2";
            // 
            // BillsChartControl
            // 
            chartArea4.Name = "ChartArea1";
            this.BillsChartControl.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.BillsChartControl.Legends.Add(legend4);
            this.BillsChartControl.Location = new System.Drawing.Point(408, 295);
            this.BillsChartControl.Name = "BillsChartControl";
            this.BillsChartControl.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.BillsChartControl.Series.Add(series4);
            this.BillsChartControl.Size = new System.Drawing.Size(419, 216);
            this.BillsChartControl.TabIndex = 1;
            this.BillsChartControl.Text = "chart2";
            // 
            // HomeUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(865, 555);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.BillsChartControl);
            this.Controls.Add(this.AvgRevenueChartControl);
            this.Controls.Add(this.RevenueChartControl);
            this.Controls.Add(this.chartEmployeeRoles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HomeUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomeUI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.chartEmployeeRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RevenueChartControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvgRevenueChartControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillsChartControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartEmployeeRoles;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart RevenueChartControl;
        private System.Windows.Forms.DataVisualization.Charting.Chart AvgRevenueChartControl;
        private System.Windows.Forms.DataVisualization.Charting.Chart BillsChartControl;
    }
}