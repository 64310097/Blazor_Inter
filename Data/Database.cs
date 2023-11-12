using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace BlazorMySQL.Data
{
    public class Database
    {
        private readonly string MySQLConnectionString;

        public Database()
        {
            MySQLConnectionString = "Server= 127.0.0.1; Database=emplyoeeDB; Uid=patch; pwd=Ln#157514;";
        }

        public DataTable MySQLConnection_Datatable()
        {
            DataTable dtDaten = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(MySQLConnectionString))
            {
                conn.Open();

                MySqlCommand SelectCommand = new MySqlCommand("Select * from employee LIMIT 15 ",conn);

                using (MySqlDataReader rdr = SelectCommand.ExecuteReader())
                {
                    dtDaten.Load(rdr);
                }
                conn.Close();
            }
            return dtDaten;
        }

          public DataTable GetProjectData()
        {
            DataTable dtproject = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(MySQLConnectionString))
            {
                conn.Open();

                MySqlCommand selectCommand = new MySqlCommand("SELECT * FROM project", conn);

                using (MySqlDataReader rdr = selectCommand.ExecuteReader())
                {
                    dtproject.Load(rdr);
                }
                conn.Close();
            }

            return dtproject;
        }

        public DataTable GetDepartmentData()
{
   DataTable dtdepartment = new DataTable();

using (MySqlConnection conn = new MySqlConnection(MySQLConnectionString))
{
    conn.Open();

    MySqlCommand selectCommand = new MySqlCommand("SELECT * FROM department ", conn);

    using (MySqlDataReader rdr = selectCommand.ExecuteReader())
    {
        dtdepartment.Load(rdr);
    }

    conn.Close();
}

return dtdepartment;

    }
}
}
