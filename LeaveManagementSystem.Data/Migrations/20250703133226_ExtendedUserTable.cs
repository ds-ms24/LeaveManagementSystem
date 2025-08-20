using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d513918-4fde-4d68-9645-bbbb77dbcb19",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d40f31c8-990f-4ca2-816f-adbd2c51520c", new DateOnly(1950, 12, 1), "Default", "Admin", "AQAAAAIAAYagAAAAEJ9VfZS6okTmSrQAT0hZE78rk+JMwWlR+tl5kYrKe91fCYIpbP8NwiM485sBq210ZQ==", "aae84012-a4c2-40b4-aad5-2de96ed8074f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d513918-4fde-4d68-9645-bbbb77dbcb19",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "071f58d8-4ac1-4d8f-bdb0-50776268c099", "AQAAAAIAAYagAAAAEOUZkTeWZ5VZ15n4sJuN5YBSwZfPrzBg9AAVIKayuioj3wQWGJEzyu991JHxnm/QKQ==", "98fa2e1e-50b2-4246-be9e-7b7dbf3b7bf7" });
        }
    }
}
