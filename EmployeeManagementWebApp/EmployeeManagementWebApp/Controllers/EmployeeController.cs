using EmployeeModel;
using EmployeeRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EmployeeManagementWebApp.Controllers
{
    //[ApiController]
    public class EmployeeController : ControllerBase
    {
        private IRepository repository;
        public EmployeeController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]  
        [Route("api/addedEmployee")]
        public IActionResult AddEmployee([FromBody]Employee employee)
        {
            var result = this.repository.CreateEmployee(employee);
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(result);
            }
            else
            {
                return this.BadRequest();
            }
        }

        [HttpPost]
        [Route("api/Login")]
        public IActionResult GetLoginDetails([FromBody] Employee employee)
        {
            var result = this.repository.LoginToEmployee(employee.Email, employee.Password);
            if (result.Equals("LOGIN SUCCESS"))
            {
                return this.Ok(result);
            }
            else
            {
                return this.BadRequest();
            }
        }

        [HttpGet]
        [Route("api/getEmployee")]
        public IActionResult GetEmpployeeById(string EmployeeId)
        {
            try
            {
                IEnumerable<Employee> employeeList = this.repository.GetEmployee(EmployeeId);
                return this.Ok(employeeList);
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("api/delete/{EmployeeId}/")]
        public IActionResult DeleteParticularEmployee([FromRoute]int EmployeeId)
        {
            var result = this.repository.DeleteEmployee(EmployeeId);
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(result);
            }
            else
            {
                return this.BadRequest();
            }
        }

        [HttpGet]
        [Route("api/GetEmployeeDetail")]
        public IActionResult GetEmployee(int EmployeeId)
        {
            try
            {
                IEnumerable<Employee> list = this.repository.GetEmployee(EmployeeId);
                return this.Ok(list);

            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("api/update/{EmployeeId}")]
        public IActionResult UpdateEmployee([FromBody]Employee employee, int EmployeeId)
        {
            employee.EmployeeId = EmployeeId;
            var result = this.repository.UpdateEmployeeDetails(employee);
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(result);
            }
            else
            {
                return this.BadRequest();
            }
        }


    }
}
