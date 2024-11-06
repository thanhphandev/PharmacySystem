using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}
