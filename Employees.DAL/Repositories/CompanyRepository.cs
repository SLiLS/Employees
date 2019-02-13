using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.DAL.Entities;
using Employees.DAL.Interfaces;
using System.Data.SqlClient;
using System.Data;

namespace Employees.DAL.Repositories
{
  public   class CompanyRepository : ICompanyRepository
    {
       private string connectionString = @"Data Source=SLILSY\SQLEXPRESS;Initial Catalog=Task;Integrated Security=True";
        private SqlConnection connection = null;
        public CompanyRepository()
        {
            connection = new SqlConnection(connectionString);
           
        }
        public void OpenConnection()
        {
            connection.Open();
        }
        public void CloseConnection()
        {
            connection.Close();
        }
        public void Create(Company item)
        {
             string sql = string.Format("Insert Into [Company]" +
                   "(CompanyName, Size, Organizationalform) Values( @CompanyName, @Size, @Organizationalform)");
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                // Добавить параметры
               
                cmd.Parameters.AddWithValue("@CompanyName", item.CompanyName);
                cmd.Parameters.AddWithValue("@Size", item.Size);
                cmd.Parameters.AddWithValue("@Organizationalform", item.Organizationalform);

                cmd.ExecuteNonQuery();
            }
        }
        public void Update(Company item)
        {
            string sql = string.Format("UPDATE [Company] SET CompanyName = '{0}', Size = '{1}', OrganizationalForm = '{2}' WHERE Id = '{3}';",
                item.CompanyName,item.Size,item.Organizationalform,item.Id);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
        public void Delete (int id)
        {
            string sql2 = string.Format("Delete from [Employee] where CompanyId = '{0}'", id);
            using (SqlCommand cmd = new SqlCommand(sql2, connection))
            {
                cmd.ExecuteNonQuery();
            }
            string sql = string.Format("Delete from [Company] where Id = '{0}'", id);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {               
                cmd.ExecuteNonQuery();               
            }
            
        }
        public Company Get (int id)
        {
            DataTable table = new DataTable();
            Company company = new Company();
            string sql = string.Format("Select * From [Company] where Id='{0}'",id);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                table.Load(dr);
                foreach (DataRow item in table.Rows)
                {
                    company.Id = Int32.Parse(item["Id"].ToString());
                    company.Size = Int32.Parse(item["Size"].ToString());
                    company.CompanyName = item["CompanyName"].ToString();
                    company.Organizationalform = item["Organizationalform"].ToString();


                }
                dr.Close();
            }
            return company;
        }
        public List<Company> GetAll()
        {
            List<Company> list = new List<Company>();
            DataTable table = new DataTable();
            
            string sql = string.Format("Select * From [Company] ");
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                table.Load(dr);
                foreach (DataRow item in table.Rows)
                {
                    Company company = new Company {
                       Id = Int32.Parse(item["Id"].ToString()),
                    Size = Int32.Parse(item["Size"].ToString()),
                    CompanyName = item["CompanyName"].ToString(),
                    Organizationalform = item["Organizationalform"].ToString()
                };

                    list.Add(company);
                }
                dr.Close();
            }
            return  list;
        }

    }
}
