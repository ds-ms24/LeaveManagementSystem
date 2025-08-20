using LeaveManagementSystem.Data.Migrations;

namespace LeaveManagementSystem.Application.Services.Users;

public interface IUserService
{
    Task<List<ApplicationUser>> GetEmployees();
    Task<ApplicationUser> GetLoggedInUser();
    Task<ApplicationUser> GetUserById(string userId);
}