using EmployeeModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRepository
{
    public interface IRepository
    {
        public string CreateEmployee(Employee employee);
        public string LoginToEmployee(string Email, string Password);
        public IEnumerable<Employee> GetEmployee(string EmployeeId);
        public string DeleteEmployee(int EmployeeId);
        public IEnumerable<Employee> GetEmployeeByID(int EmployeeId);
        public string UpdateEmployeeDetails(Employee employee);
        public string SendEmailForForgotPass(string emailAddress);
        public string ResetEmployeePassword(string oldpassword, string newpassword);


    }
}
