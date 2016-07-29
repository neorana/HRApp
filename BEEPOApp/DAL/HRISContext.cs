using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BEEPOApp.Models;


namespace BEEPOApp.DAL
{
    public class HRISContext: DbContext 
    {
        public HRISContext() : base("HRISContext")
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
     
    }
}