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
            //ToDo: Read this from configuration.
            _connectionString = "datasource=localhost;port=3306;username=root;password=PASS;database=hospital;";
            //_connectionString = "datasource=b1tbcsdqeoa5js5ykpeh-mysql.services.clever-cloud.com;port=3306;username=uemgs7eqsmjuiluq;password=sq03eJQHOmxmzrFGHRFS;database=b1tbcsdqeoa5js5ykpeh;";
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
                MySqlCommand command = new MySqlCommand(query, connection);

                connection.Open();
                for (int i = 0; i < fields.Length; i++)
                {
                    table.Columns.Add(fields[i]);
                }
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DataRow row = table.NewRow();
                        for (int i = 0; i < fields.Length; i++)
                        {
                            row[fields[i]] = reader[fields[i]].ToString();
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
