using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeesList;

        public EmployeeRepository()
        {
            _employeesList = new List<Employee>
            {
                new Employee{ Id=1,Name="Reza",Email="Reza@gmail.com",Department="Stuff"},
                new Employee{ Id=2,Name="Ali",Email="Ali@gmail.com",Department="Driver"},
                new Employee{ Id=3,Name="Mohammad",Email="Mohammad@gmail.com",Department="University"},
                new Employee{ Id=4,Name="Ehsan",Email="Ehsan@gmail.com",Department="Country"}
            };

        }

        public Employee GetEmployee(int Id)
        {
            return _employeesList.FirstOrDefault(f => f.Id == Id);
        }
    }
}
