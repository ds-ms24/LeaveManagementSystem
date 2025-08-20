using LeaveManagementSystem.Data.Migrations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LeaveManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    //access modifier - class type - class name - inherits from - base class with <user type>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //access modifier - constructor - parameter type<parameter type> - parameter name - base constructor call

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }
        //access modifier - property type <entity set> - property name - read - assign

        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        //access modifier - property type <entity set> - property name - read - assign

        public DbSet<Period> Periods { get; set; }
        //access modifier - property type <entity set> - property name - read - assign

        public DbSet<LeaveRequestStatus> LeaveRequestStatuses { get; set; }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }
    }
}
