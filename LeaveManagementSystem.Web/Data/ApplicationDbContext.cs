using LeaveManagementSystem.Web.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data
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
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    //by default is a string, but really is a GUID
                    Id = "a7926378-077b-403e-abda-04561b387349",
                    //human readable version
                    Name = "Employee",
                    //used if running comparison
                    NormalizedName = "EMPLOYEE"
                },
                new IdentityRole
                {
                    Id = "141c95b6-ada2-4148-b22a-f5e77e2ae639",
                    Name = "Supervisor",
                    NormalizedName = "SUPERVISOR"
                },
                new IdentityRole
                {
                    Id = "bebd31a3-20a8-47d7-932b-e993f405e28d",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                });

            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>()
                .HasData(new ApplicationUser
                {
                    Id = "8d513918-4fde-4d68-9645-bbbb77dbcb19",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true,
                    FirstName = "Default",
                    LastName = "Admin",
                    DateOfBirth = new DateOnly(1950,12,01)
                });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "bebd31a3-20a8-47d7-932b-e993f405e28d",
                    UserId = "8d513918-4fde-4d68-9645-bbbb77dbcb19"
                });
        }
        //access modifier - method modifier - return type - method name - parameter type - parameter name

        public DbSet<LeaveType> LeaveTypes { get; set; }
        //access modifier - property type <entity set> - property name - read - assign

        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        //access modifier - property type <entity set> - property name - read - assign

        public DbSet<Period> Periods { get; set; }
        //access modifier - property type <entity set> - property name - read - assign

    }
}
