using BEEPOApp.DAL;
using BEEPOApp.Repositories;

namespace BEEPOApp.Persistence
{
    public class UnitofWork : IUnitofWork
    {
        private readonly HRISContext _context;

        public IEmployeeRepository Employee { get; private set; }

        public UnitofWork(HRISContext context)
        {
            _context = context;
            Employee = new EmployeeRepository(context);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}