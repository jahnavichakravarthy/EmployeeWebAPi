using System;
using ConsoleApp1API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1API.DAL
{
    interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
        Employee GetSingleEmployee(string employeeId);
        bool InsertEmployee(Employee employee);
        bool DeleteEmployee(string employeeId);
       bool UpdateEmployee(Employee employee);
    }
}
