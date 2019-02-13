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
  public  class EmployeeRepository : IEmployeeRepository // Реализаций CRUD операция для сотрудников
    {
        private string connectionString = @"Data Source=SLILSY\SQLEXPRESS;Initial Catalog=Task;Integrated Security=True";
        private SqlConnection connection = null;
        public EmployeeRepository()
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
        public void Create(Employee item)
        {
            string sql = string.Format("INSERT INTO Employee(SurName, Name, MiddleName, Employmentdate, Position, CompanyId)VALUES(@SurName, @Name, @MiddleName, @Employmentdate, @Position, @CompanyId)");
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                // Добавить параметры

                cmd.Parameters.AddWithValue("@Name", item.Name);
                cmd.Parameters.AddWithValue("@Surname", item.Surname);
                cmd.Parameters.AddWithValue("@Position", item.Position);
                cmd.Parameters.AddWithValue("@Employmentdate", item.Employmentdate);
                cmd.Parameters.AddWithValue("@Middlename", item.Middlename);
                cmd.Parameters.AddWithValue("@CompanyId", item.CompanyId);

                cmd.ExecuteNonQuery();
            }
           
        }
        public void Update(Employee item)
        {
            string sql = string.Format("UPDATE [Employee] SET SurName = '{0}', Name = '{1}', MiddleName = '{2}', Employmentdate = '{3}',Position='{4}',CompanyId='{5}' WHERE Id = '{6}';",
                item.Surname,item.Name,item.Middlename,item.Employmentdate,item.Position,item.CompanyId, item.Id);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
            string sql = string.Format("Delete from [Employee] where Id = '{0}'", id);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }
        public Employee Get(int id)
        {
            DataTable table = new DataTable();
            Employee employee = new Employee();
            string sql = string.Format("SELECT Employee.Id,Employee.Name,Employee.SurName,Employee.MiddleName,Employee.Employmentdate,Employee.Position,Employee.CompanyId,Company.CompanyName FROM Employee JOIN Company ON Employee.CompanyId = Company.Id Where Employee.Id = '{0}'", id);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                table.Load(dr);
                foreach (DataRow item in table.Rows)
                {
                    employee.Id = Int32.Parse(item["Id"].ToString());
                    employee.Name = item["Name"].ToString();
                    employee.Surname = item["Surname"].ToString();
                    employee.Middlename = item["Middlename"].ToString();
                    employee.Position = item["Position"].ToString();
                  
                    employee.Employmentdate = Convert.ToDateTime(item["Employmentdate"].ToString());
                    employee.Companyname = item["CompanyName"].ToString();

                }
                dr.Close();
            }
            return employee;
        }
        public List<Employee> GetAll()
        {
            List<Employee> list = new List<Employee>();
            DataTable table = new DataTable();
            
            string sql = string.Format("SELECT Employee.Id,Employee.Name,Employee.SurName,Employee.MiddleName,Employee.Employmentdate,Employee.Position,Employee.CompanyId,Company.CompanyName FROM Employee JOIN Company ON Employee.CompanyId = Company.Id ");
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                table.Load(dr);
                foreach (DataRow item in table.Rows)
                {
                    Employee employee = new Employee {
                        Id = Int32.Parse(item["Id"].ToString()),
                    Name = item["Name"].ToString(),
                    Surname = item["Surname"].ToString(),
                    Middlename = item["Middlename"].ToString(),
                    Position = item["Position"].ToString(),

                   Employmentdate = Convert.ToDateTime(item["Employmentdate"].ToString()),
                    Companyname = item["CompanyName"].ToString()
                };
                    list.Add(employee);
                }
                dr.Close();
            }
            return list;
        }

    }
}
