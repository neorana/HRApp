using System.Collections.Generic;
using System.Linq;
using BEEPOApp.Models;

namespace BEEPOApp.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        void Add(Employee employee);
    }
}