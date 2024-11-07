using MySql.Data.MySqlClient;
using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystem.Repositories.POSBillRepository
{
    public class POSBillRepository : IPOSBillRepository
    {
        private readonly string _connectionString;
        public POSBillRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void AddPosBill(decimal receiveAmount, int employeeId)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    // SQL query for inserting into pos_bill
                    string query = "INSERT INTO pos_bill(pos_bill_receive, employee_id) VALUES (@ReceiveAmount, @EmployeeId)";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("ReceiveAmount", receiveAmount);
                        command.Parameters.AddWithValue("EmployeeId", employeeId);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Capture and rethrow any exceptions for better error visibility
                throw new Exception("Error while adding POS bill: " + ex.Message);
            }
        }

        public List<POSBillReport> GetFinancialReport(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var reports = new List<POSBillReport>();

                using (var connection = new MySqlConnection(_connectionString))
                {
                    string query = @"
                SELECT
                    DATE(pos_bill_time) AS Date,
                    SUM(pos_bill_receive) AS TotalRevenue,
                    COUNT(*) AS TotalBills,
                    AVG(pos_bill_receive) AS AverageReceiveAmount
                FROM
                    pos_bill
                WHERE
                    pos_bill_time BETWEEN @FromDate AND @ToDate
                GROUP BY
                    DATE(pos_bill_time)
                ORDER BY
                    DATE(pos_bill_time);
                ";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FromDate", fromDate);
                        command.Parameters.AddWithValue("@ToDate", toDate);

                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                POSBillReport report = new POSBillReport
                                {
                                    Date = reader.GetDateTime("Date"),
                                    TotalRevenue = reader.GetDecimal("TotalRevenue"),
                                    TotalBills = reader.GetInt32("TotalBills"),
                                    AverageReceiveAmount = reader.GetDecimal("AverageReceiveAmount")
                                };

                                reports.Add(report);
                            }
                        }
                    }
                }

                return reports;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting financial report: " + ex.Message);
            }
        }

    }
}
