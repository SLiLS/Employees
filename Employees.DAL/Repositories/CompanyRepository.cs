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
                   "(Name, Size, Organizationalform) Values( @Name, @Size, @Organizationalform)");
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                // Добавить параметры
               
                cmd.Parameters.AddWithValue("@Name", item.Name);
                cmd.Parameters.AddWithValue("@Size", item.Size);
                cmd.Parameters.AddWithValue("@Organizationalform", item.Organizationalform);

                cmd.ExecuteNonQuery();
            }
        }
        public void Update(Company item)
        {
            string sql = string.Format("UPDATE [Company] SET Name = '{0}', Size = '{1}', OrganizationalForm = '{2}' WHERE Id = '{3}';",
                item.Name,item.Size,item.Organizationalform,item.Id);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
        public void Delete (int id)
        {
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
                    company.Size = Int32.Parse(dr["Size"].ToString());
                    company.Name = dr["Name"].ToString();
                    company.Organizationalform = dr["Organizationalform"].ToString();


                }
                dr.Close();
            }
            return company;
        }
        public List<Company> GetAll()
        {
            List<Company> list = new List<Company>();
            DataTable table = new DataTable();
            Company company = new Company();
            string sql = string.Format("Select * From [Company] ");
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                table.Load(dr);
                foreach (DataRow item in table.Rows)
                {
                    company.Id = Int32.Parse(item["Id"].ToString());
                    company.Size = Int32.Parse(dr["Size"].ToString());
                    company.Name = dr["Name"].ToString();
                    company.Organizationalform = dr["Organizationalform"].ToString();

                    list.Add(company);
                }
                dr.Close();
            }
            return  list;
        }

    }
}
