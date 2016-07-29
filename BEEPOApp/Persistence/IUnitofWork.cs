using BEEPOApp.Repositories;

namespace BEEPOApp.Persistence
{
    public interface IUnitofWork
    {
        IEmployeeRepository Employee { get; }
        void Commit();
    }
}