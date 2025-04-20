using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PharmacySystem.Repositories.UnitTypeRepository
{
    public class UnitTypeRepository : IUnitTypeRepository
    {
        private readonly string _connectionString;
        
        public UnitTypeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddUnitType(string unitType)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                 
                    string query = "INSERT INTO unit_types(name) VALUES (@UnitType)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("UnitType", unitType);

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


        public void DeleteUnitType(string unitType)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = "DELETE FROM unit_types WHERE name =@UnitType";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("UnitType", unitType);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            } 
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<UnitTypeModel> GetAllUnitTypes()
        {
            List<UnitTypeModel> unitTypes = new List<UnitTypeModel>();
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM unit_type";
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UnitTypeModel unitType = new UnitTypeModel
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                UnitType = reader["name"].ToString()
                            };
                            unitTypes.Add(unitType);
                        }
                    }
                }
            }
            return unitTypes;
        }

    }
}
