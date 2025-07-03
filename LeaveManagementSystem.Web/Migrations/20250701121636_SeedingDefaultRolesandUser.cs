using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Web.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDefaultRolesandUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "141c95b6-ada2-4148-b22a-f5e77e2ae639", null, "Supervisor", "SUPERVISOR" },
                    { "a7926378-077b-403e-abda-04561b387349", null, "Employee", "EMPLOYEE" },
                    { "bebd31a3-20a8-47d7-932b-e993f405e28d", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8d513918-4fde-4d68-9645-bbbb77dbcb19", 0, "071f58d8-4ac1-4d8f-bdb0-50776268c099", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEOUZkTeWZ5VZ15n4sJuN5YBSwZfPrzBg9AAVIKayuioj3wQWGJEzyu991JHxnm/QKQ==", null, false, "98fa2e1e-50b2-4246-be9e-7b7dbf3b7bf7", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bebd31a3-20a8-47d7-932b-e993f405e28d", "8d513918-4fde-4d68-9645-bbbb77dbcb19" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "141c95b6-ada2-4148-b22a-f5e77e2ae639");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7926378-077b-403e-abda-04561b387349");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bebd31a3-20a8-47d7-932b-e993f405e28d", "8d513918-4fde-4d68-9645-bbbb77dbcb19" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bebd31a3-20a8-47d7-932b-e993f405e28d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d513918-4fde-4d68-9645-bbbb77dbcb19");
        }
    }
}
