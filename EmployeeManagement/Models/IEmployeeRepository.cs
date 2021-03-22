using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployee(int Id);
        Employee Add(Employee employee);
        Employee Delete(int Id);
        Employee Update(Employee changeEmployee);
    }
}
