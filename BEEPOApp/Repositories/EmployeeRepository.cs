using System.Collections.Generic;
using System.Linq;
using BEEPOApp.DAL;
using BEEPOApp.Models;

namespace BEEPOApp.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HRISContext _context;

        public EmployeeRepository(HRISContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.Select(e=> e);
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
        }
    }
}