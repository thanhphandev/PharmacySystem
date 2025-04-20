using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = "INSERT INTO suppliers (name, phone, address, tax_code) VALUES (@Name, @Phone, @Address, @TaxCode)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("Name", supplier.Name);
                        command.Parameters.AddWithValue("Phone", supplier.Phone);
                        command.Parameters.AddWithValue("Address", supplier.Address);
                        command.Parameters.AddWithValue("TaxCode", supplier.TaxCode);

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
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = "DELETE FROM suppliers WHERE id = @ID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("ID", id);

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
            var suppliers = new List<SupplierModel>();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = "SELECT * FROM suppliers";
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var supplier = new SupplierModel
                                {
                                    ID = reader.GetInt32(reader.GetOrdinal("id")),
                                    Name = reader.GetString(reader.GetOrdinal("name")),
                                    Phone = reader.IsDBNull(reader.GetOrdinal("phone")) ? null : reader.GetString(reader.GetOrdinal("phone")),
                                    Address = reader.IsDBNull(reader.GetOrdinal("address")) ? null : reader.GetString(reader.GetOrdinal("address")),
                                    TaxCode = reader.IsDBNull(reader.GetOrdinal("tax_code")) ? null : reader.GetString(reader.GetOrdinal("tax_code"))
                                };

                                suppliers.Add(supplier);
                            }
                        }
                    }
                }

                return suppliers;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Database error retrieving suppliers: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving all suppliers: " + ex.Message, ex);
            }
        }



        public void UpdateSupplier(int id, SupplierModel supplier)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = @"UPDATE suppliers 
                             SET name = @Name, 
                                 phone = @Phone, 
                                 address = @Address,
                                 tax_code = @TaxCode
                             WHERE id = @Id";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@Name", supplier.Name);
                        command.Parameters.AddWithValue("@Phone", supplier.Phone ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Address", supplier.Address ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@TaxCode", supplier.TaxCode ?? (object)DBNull.Value);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating supplier: " + ex.Message, ex);
            }
        }

    }

}