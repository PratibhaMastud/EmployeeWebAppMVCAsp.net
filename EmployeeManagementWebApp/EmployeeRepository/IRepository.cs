using EmployeeModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRepository
{
    public interface IRepository
    {
        public string CreateEmployee(Employee employee);

        public IEnumerable<Employee> GetEmployee(string EmployeeId);
    }
}
