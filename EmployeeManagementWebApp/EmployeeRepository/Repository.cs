// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Repository.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Pratibha Mastud"/>
// --------------------------------------------------------------------------------------------------------------------


namespace EmployeeRepository
{
    using EmployeeModel;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
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
        public string DeleteEmployee(int id)
        {
            Employee employee = employeeContext.Employees.Find(id);
            if (employee == null)
            {
                return "Not Found.";
            }
            employeeContext.Employees.Remove(employee);
            employeeContext.SaveChanges();
            return "SUCCESS";
        }

        public IEnumerable<Employee> GetEmployeeByID(int EmployeeId)
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(this.employeeContext.Employees.Find(EmployeeId));
            return employees;
        }

        public string UpdateEmployeeDetails(Employee updateEmployee)
        {
            try
            {
                this.employeeContext.Employees.Update(updateEmployee);
                this.employeeContext.SaveChangesAsync();
                return "SUCCESS";
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
        }

        public string SendEmailForForgotPass(string emailAdd)
        {
            string body;
            string subject = "EmployeeManagements Credential";
            var entry = this.employeeContext.Employees.FirstOrDefault(x => x.Email == emailAdd);
            if (entry != null)
            {
                body = entry.Password;
            }
            else
            {
                return "Not Found";
            }
            using (MailMessage mailMessage = new MailMessage("karandepratibha999@gmail.com", emailAdd))
            {
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("karandepratibha999@gmail.com", "pratibha999");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
                return "SUCCESS";
            }
        }

        public string ResetEmployeePassword(string oldPassword, string newPassword)
        {
            var resetPassword = employeeContext.Employees.FirstOrDefault(pass => pass.Password == oldPassword);
            if (resetPassword != null)
            {
                resetPassword.Password = newPassword;
                employeeContext.Entry(resetPassword).State = EntityState.Modified;
                employeeContext.SaveChanges();
                return "SUCCESS";
            }
            else
            {
                return "NOT_FOUND";
            }
        }
    }
}
