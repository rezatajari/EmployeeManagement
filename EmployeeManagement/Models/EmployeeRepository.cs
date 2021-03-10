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
                new Employee{ Id=1,Name="Reza",Email="Reza@gmail.com",Department=Dept.HR},
                new Employee{ Id=2,Name="Ali",Email="Ali@gmail.com",Department=Dept.IT},
                new Employee{ Id=3,Name="Mohammad",Email="Mohammad@gmail.com",Department=Dept.None},
                new Employee{ Id=4,Name="Ehsan",Email="Ehsan@gmail.com",Department=Dept.Payroll}
            };

        }

        public Employee GetEmployee(int Id)
        {
            return _employeesList.FirstOrDefault(f => f.Id == Id);
        }
    }
}
