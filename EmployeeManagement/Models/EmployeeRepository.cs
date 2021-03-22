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
            _employeesList = new List<Employee>()
            {
                new Employee(){ Id=1,Name="Reza",Email="Reza@gmail.com",Department=Dept.HR},
                new Employee(){ Id=2,Name="Ali",Email="Ali@gmail.com",Department=Dept.IT},
                new Employee(){ Id=3,Name="Mohammad",Email="Mohammad@gmail.com",Department=Dept.None},
                new Employee(){ Id=4,Name="Ehsan",Email="Ehsan@gmail.com",Department=Dept.Payroll}
            };
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeesList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeesList.FirstOrDefault(f => f.Id == Id);
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeesList.Max(i => i.Id) + 1;
            _employeesList.Add(employee);
            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = _employeesList.FirstOrDefault(i => i.Id == Id);

            if (employee != null)
                _employeesList.Remove(employee);
            else
                throw new Exception("Your Employee is not exist");

            return employee;
        }

        public Employee Update(Employee changeEmployee)
        {
            Employee employee = _employeesList.FirstOrDefault(i => i.Id == changeEmployee.Id);

            if (employee != null)
            {
                employee.Name = changeEmployee.Name;
                employee.Email = changeEmployee.Email;
                employee.Department = changeEmployee.Department;
            }
            else
                throw new Exception("Your Employee is not exist");

            return employee;
        }
    }
}
