using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConsoleApp1API.DAL;
using ConsoleApp1API.Models;


namespace ConsoleApp1API.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeeRepository employeeRepository = new EmployeeRepository();
        // GET: api/Employee
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return employeeRepository.GetEmployees();
        }

        // GET: api/Employee/5
        [HttpGet]
        public Employee Get(string id)
        {
            return employeeRepository.GetSingleEmployee(id);
        }

        // POST: api/Employee
       /// [Route("Employees")]
        [HttpPost]
        public bool Post([FromBody]Employee employee)
        {
            return employeeRepository.InsertEmployee(employee);
        }

        // PUT: api/Employee/5
        [HttpPut]
        public bool Put( [FromBody]Employee employee)
        {
            return employeeRepository.UpdateEmployee(employee);
        }

        // DELETE: api/Employee/5
        [HttpDelete]
        public bool Delete(string id)
        {
            return employeeRepository.DeleteEmployee(id);
        }
    }
}
