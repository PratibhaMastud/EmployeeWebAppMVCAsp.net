using Microsoft.EntityFrameworkCore;
using EmployeeModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRepository
{
    public class UserDbContext : DbContext
    {
        public UserDbContext()
        {

        }
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
       
    }
}


