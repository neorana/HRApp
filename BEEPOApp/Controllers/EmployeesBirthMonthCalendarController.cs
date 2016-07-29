using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BEEPOApp.DAL;
using BEEPOApp.Models;
using BEEPOApp.Persistence;

namespace BEEPOApp.Controllers
{
    [Authorize]
    public class EmployeesBirthMonthCalendarController : ApiController
    {
        private readonly HRISContext _context;
        private readonly IUnitofWork _unitofWork;

        public EmployeesBirthMonthCalendarController()
        {
            _context = new HRISContext();
            _unitofWork = new UnitofWork(_context);
        }

        public IEnumerable<Employee> Get()
        {
            int currentmonth = DateTime.Today.Month;

            var employees = _unitofWork.Employee.GetEmployees()
                        .Where(e => e.BirthDate.Month == currentmonth);

            return employees;
        }
    }
}
