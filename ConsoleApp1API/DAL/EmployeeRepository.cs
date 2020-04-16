using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ConsoleApp1API.Models;
using System.Data.SqlClient;
using System.Data;
using System.Web;

namespace ConsoleApp1API.DAL
{
 

    public class EmployeeRepository:IEmployeeRepository
    {
        private IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDetailsDB"].ConnectionString);
        public List<Employee> GetEmployees()
        {
            return this._db.Query<Employee>("Select * From EMPLOYEES").ToList();
        }
            public Employee GetSingleEmployee(string employeeId)
        {
            return _db.Query<Employee>("Select * From EMPLOYEES" +
                " WHERE Id = @Id ", new { employeeId }).SingleOrDefault();
        }

        public bool InsertEmployee(Employee employee)
        {
            //int rowsAffected = this._db.Execute(@"INSERT INTO EMPLOYEES(Id, Name, Age, Salary) Values(@Id, @Name, @Age, @Salary)"); //new { CustomerFirstName = ourCustomer.CustomerFirstName, CustomerLastName = ourCustomer.CustomerLastName, IsActive = true });
            //int rowsAffected = this._db.Execute(@"INSERT Customer([Id],[Name],[Age],[Salary]) values (@Id, @Name, @Age, @Salary)", new { Id = employee.Id, Name = employee.Name, Age = employee.Age, Salary = employee.Salary });
            string sqlQuery = "INSERT INTO EMPLOYEES (Id, Name, Age, Salary) Values (@Id, @Name, @Age, @Salary);";
                int rowsAffected = db.Execute(sqlQuery, employee);
           if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteEmployee(string employeeId)
        {
           int rowsAffected = this._db.Execute(@"DELETE FROM EMPLOYEES WHERE Id = @Id",new{ Id = employeeId });
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;

        }

        public bool  UpdateEmployee(Employee employee)
        {
            int rowsAffected = this._db.Execute("UPDATE [Employee] SET [Id] = @Id ,[Name] = @Name, [Age] = @Age,[Salary] = @Salary WHERE Id = " + employee.Id, employee);
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }   
    }
}
