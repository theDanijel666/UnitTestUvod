using MVC_employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_tests.Helpers
{
    internal class TestHelper
    {
        public IEnumerable<Employee> GetTestEmployees()
        {
            return new List<Employee>() { 
                new Employee()
                {
                    Id=1,
                    Name="Niđo"
                },
                new Employee()
                {
                    Id=2,
                    Name="Ana"
                }
                //,
                //new Employee()
                //{
                //    Id=3,
                //    Name="Thomas"
                //}
            };
        }

        public Employee getTestEmployee()
        {
            return new Employee()
            {
                Id = 1,
                Name = "Niđo"
            };
        }
    }
}
