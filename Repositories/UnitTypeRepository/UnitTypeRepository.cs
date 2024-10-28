using MySql.Data.MySqlClient;
using PharmacySystem.Models;
using System;
using System.Collections.Generic;
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
                using (var connection = new MySqlConnection(_connectionString))
                {
                 
                    string query = "INSERT INTO unit_type(unit_name) VALUES (@UnitType)";
                    using (var command = new MySqlCommand(query, connection))
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
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string query = "DELETE FROM unit_type WHERE unit_name =@UnitType";
                    using (var command = new MySqlCommand(query, connection))
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
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM unit_type";
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UnitTypeModel unitType = new UnitTypeModel
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                UnitType = reader["unit_name"].ToString()
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
