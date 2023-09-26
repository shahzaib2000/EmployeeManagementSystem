using Dapper;

using EmployeeManagementDAL.Interface;
using System.Data;
using System.Data.SqlClient;
using EmployeeManagementModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementDAL
{
    public class EmployeeRepo : EmployeeRepoInterface
    {
        string connectionString = "Data Source=LAPTOP-0G1FUQD9\\SQLEXPRESS;Initial Catalog=EmployeeManagementSystem;User ID=sa;Password=admin123";

        public List<Employee> GetEmployees()
        {
            string output_query = "SELECT [Id], [Name], [Designation], [Department] FROM Employee;";
            IDbConnection connection = null;

            using (connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                List<Employee> AllEmployees = connection.Query<Employee>(output_query).ToList();
                connection.Close();
                return AllEmployees;
            }
        }


        public void addEmployee(Employee emp)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Name", emp.Name, DbType.String);
            parameters.Add("@Designation", emp.Designation, DbType.String);
            parameters.Add("@Department", emp.Department, DbType.String);

            string output_query = "INSERT INTO [dbo].[Employee] (Name, Designation, Department) VALUES (@Name, @Designation, @Department);";
            IDbConnection connection = null;

            using (connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                connection.Query<Employee>(output_query, parameters);
                connection.Close();
            }
        }
        public void delEmployeebyId(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id, DbType.String);

            string output_query = "DELETE FROM [dbo].[Employee] WHERE id = @Id;";
            IDbConnection connection = null;

            using (connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                connection.Query<Employee>(output_query, parameters);
                connection.Close();
            }
        }

        public Employee getEmployeeInfoById(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id, DbType.String);

            string output_query = "SELECT [Id], [Name], [Designation], [Department] FROM Employee WHERE id = @Id;";
            IDbConnection connection = null;

            using (connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                Employee result = connection.Query<Employee>(output_query, parameters).FirstOrDefault();
                connection.Close();
                return result;
            }

            return null;

        }

        public void updateEmployee(int id, Employee emp)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", id, DbType.Int64);
            parameters.Add("@Name", emp.Name, DbType.String);
            parameters.Add("@Designation", emp.Designation, DbType.String);
            parameters.Add("@Department", emp.Department, DbType.String);
     

            string output_query = "UPDATE [dbo].[Employee] SET [Name] = @Name, [Designation] = @Designation, [Department] = @Department WHERE id = @Id;";
            IDbConnection connection = null;

            using (connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                connection.Query<Employee>(output_query, parameters);
                connection.Close();
            }
        }
    }
}