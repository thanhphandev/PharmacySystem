using MySql.Data.MySqlClient;
using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Repositories.SupplierRepository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly string _connectionString;
        public SupplierRepository(string connectionString) 
        {
            _connectionString = connectionString;
        }

        public void AddSupplier(SupplierModel supplier)
        {
            try
            {
               using (var connection = new MySqlConnection(_connectionString))
               {
                    string query = "INSERT INTO supplier (supplier_name, supplier_phone, supplier_address) VALUES (@SupplierName, @SupplierPhone, @SupplierAddress)";
                    using(var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("SupplierName", supplier.SupplierName);
                        command.Parameters.AddWithValue("SupplierPhone", supplier.SupplierPhone);
                        command.Parameters.AddWithValue("SupplierAddress", supplier.SupplierAddress);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }

               }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void DeleteSupplier(int id)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string query = "DELETE FROM supplier WHERE id = @SupplierId";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("SupplierId", id);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting supplier: " + ex.Message);
            }
        }

        public List<SupplierModel> GetAllSuppliers()
        {
            List<SupplierModel> suppliers = new List<SupplierModel>();
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string query = "SELECT * FROM supplier";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var supplier = new SupplierModel
                                {
                                    SupplierId = reader.GetInt32("id"),
                                    SupplierName = reader.GetString("supplier_name"),
                                    SupplierPhone = reader.GetString("supplier_phone"),
                                    SupplierAddress = reader.GetString("supplier_address")
                                };

                                suppliers.Add(supplier);
                            }
                        }
                    }
                }
                return suppliers;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving all suppliers: " + ex.Message);
            }
        }

        public void UpdateSupplier(int id, SupplierModel supplier)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string query = @"UPDATE supplier 
                                     SET supplier_name = @SupplierName, 
                                         supplier_phone = @SupplierPhone, 
                                         supplier_address = @SupplierAddress 
                                     WHERE id = @SupplierId";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("SupplierId", id);
                        command.Parameters.AddWithValue("SupplierName", supplier.SupplierName);
                        command.Parameters.AddWithValue("SupplierPhone", supplier.SupplierPhone);
                        command.Parameters.AddWithValue("SupplierAddress", supplier.SupplierAddress);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating supplier: " + ex.Message);
            }
        }

        
    }
    
}
