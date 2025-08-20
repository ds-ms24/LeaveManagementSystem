using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementSystem.Data.Configurations
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
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
        }
    }
}
