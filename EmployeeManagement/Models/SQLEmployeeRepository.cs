using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            _context = context;
        }
        public Employee Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = _context.Employees.Find(Id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            else
                throw new Exception("Your Employee is not exist");

            return employee;
        }

        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployee(int Id)
        {
            Employee employee = _context.Employees.Find(Id);
            if (employee != null)
                return employee;
            else
                throw new Exception("Your Emoloyee is not exist");
        }

        public Employee Update(Employee changeEmployee)
        {
            Employee employee = _context.Employees.FirstOrDefault(i => i.Id == changeEmployee.Id);
            if (employee != null)
            {
                employee.Name = changeEmployee.Name;
                employee.Email = changeEmployee.Email;
                employee.Department = changeEmployee.Department;
                _context.Employees.Update(employee);
                _context.SaveChanges();
            }
            else
                throw new Exception("Your Employee is not exist");

            return employee;
        }
    }
}
