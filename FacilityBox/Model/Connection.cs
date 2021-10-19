using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityBox.Model
{
    public class Connection
    {
        SqlConnection conn = new SqlConnection();
        public Connection()
        {
            conn.ConnectionString = @"Data Source=DESKTOP-UN7PDFQ\SQLEXPRESS;Initial Catalog=Facility;Integrated Security=True";
        }


        public SqlConnection Connect()
        {
            if(conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }

            return conn;
        }
    }
}
