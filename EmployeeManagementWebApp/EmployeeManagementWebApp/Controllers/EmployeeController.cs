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
    }
}
