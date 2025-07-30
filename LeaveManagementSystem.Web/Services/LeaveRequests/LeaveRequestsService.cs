using LeaveManagementSystem.Web.Models.LeaveRequests;

namespace LeaveManagementSystem.Web.Services.LeaveRequests
{
    public class LeaveRequestsService : ILeaveRequestsService
    {
        public Task CancelLeaveRequest(int leaveRequestId)
        {
            throw new NotImplementedException();
        }

        Task ILeaveRequestsService.CreateLeaveRequest(LeaveRequestCreateVM model)
        {
            throw new NotImplementedException();
        }

        Task<LeaveRequestListVM> ILeaveRequestsService.GetAllLeaveRequests()
        {
            throw new NotImplementedException();
        }

        Task<EmployeeLeaveRequestListVM> ILeaveRequestsService.GetEmployeeLeaveRequests()
        {
            throw new NotImplementedException();
        }

        Task ILeaveRequestsService.ReviewLeaveRequest(ReviewLeaveRequestVM model)
        {
            throw new NotImplementedException();
        }
    }
}
