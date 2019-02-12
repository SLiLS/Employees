using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Configuration;

namespace Employees.DAL.Connection
{
    public class NewConnection
    {
        private SqlConnection connect = null;
        private SqlDataAdapter adapter = null;
        private string connectionString = @"Data Source=SLILSY\SQLEXPRESS;Initial Catalog=usersdb;Integrated Security=True";
        public NewConnection ()
        {
            adapter = new SqlDataAdapter();
            connect = new SqlConnection(connectionString);
           
        }

    }
}
