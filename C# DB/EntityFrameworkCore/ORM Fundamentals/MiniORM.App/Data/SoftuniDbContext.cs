using MiniORM.App.Data.Entities;

namespace MiniORM.App.Data
{
    public class SoftuniDbContext : DbContext
    {
        public SoftuniDbContext(string connectionSting)
            : base(connectionSting)
        {
        }

        public DbSet<Employee> Employees { get; }

        public DbSet<Department> Departments { get; }

        public DbSet<Project> Projects { get; }

        public DbSet<EmployeeProject> EmployeesProjects { get; }
    }
}
