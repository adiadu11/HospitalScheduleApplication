using HospitalSchedulerApplication.Abstract.DataAccessInterfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSchedulerApplication.DataAccess
{
    public class MySqlCrudRepo : IDBCrudRepo
    {
        private readonly string _connectionString;
        public MySqlCrudRepo()
        {
            _connectionString = "datasource=localhost;port=3306;username=root;password=PASS;database=hospital;";
        }
        public int ExecuteQuery(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                //This is command class which will handle the query and connection object.
                MySqlCommand command = new MySqlCommand(query, connection);
                
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
                return rowsAffected;
            }
        }
        public DataTable ExecuteQuery(string query, string[] fields)
        {
            DataTable table = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                //This is command class which will handle the query and connection object.
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();
                for (int i = 0; i < fields.Length; i++)
                {
                    table.Columns.Add(fields[i]);
                }
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    // Here our query will be executed and data saved into the database.
                    while (reader.Read())
                    {
                        DataRow row = table.NewRow();
                        for (int i = 0; i < fields.Length; i++)
                        {
                            row[fields[i]] = (string)reader[fields[i]];
                        }
                        table.Rows.Add(row);
                    }
                }
                connection.Close();
            }
            return table;
        }
    }
}
