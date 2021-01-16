using EmployeeModel;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EmployeeRepository
{
    public class Repository : IRepository
    {
        UserDbContext employeeContext;

        public Repository(UserDbContext userDbContext)
        {
            this.employeeContext = userDbContext;
        }

        public string CreateEmployee(Employee employee)
        {
            this.employeeContext.Employees.Add(employee);
            this.employeeContext.SaveChanges();
            string message = "SUCCESS";
            return message;
        }


        public string LoginToEmployee(string Email, string Password)
        {
            string message;
            var Login = this.employeeContext.Employees
                        .Where(x => x.Email == Email && x.Password == Password).SingleOrDefault();
            if (Login != null)
            {
                message = "LOGIN SUCCESS";
            }
            else
            {
                message = "LOGIN UNSUCCESSFUL";

            }
            return message;
        }

        public IEnumerable<Employee> GetEmployee(string EmployeeId)
        {
            List<Employee> employees = new List<Employee>();
            employees = employeeContext.Employees.ToList();
            return employees;
        }

    }
}
