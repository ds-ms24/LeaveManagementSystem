using AutoMapper;
using LeaveManagementSystem.Web.Models.LeaveRequests;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services.LeaveRequests;

public class LeaveRequestsService(IMapper _mapper, UserManager<ApplicationUser> _userManager, 
    IHttpContextAccessor _httpContextAccessor, ApplicationDbContext _context) : ILeaveRequestsService
{
    public async Task CancelLeaveRequest(int leaveRequestId)
    {   
        var leaveRequest = await _context.LeaveRequests.FindAsync(leaveRequestId);
        leaveRequest.LeaveRequestStatusId = (int)LeaveRequestStatusEnum.Cancelled;
        //exception handling what if leaveRequest returns null

        //restore allocation days based on request
        var numberOfDays = leaveRequest.EndDate.DayNumber - leaveRequest.StartDate.DayNumber;
        var allocation = await _context.LeaveAllocations
            .FirstAsync(q => q.LeaveTypeId == leaveRequest.LeaveTypeId && q.EmployeeId ==
              leaveRequest.EmployeeId);

        allocation.Days += numberOfDays;

        await _context.SaveChangesAsync();
    }

    public async Task CreateLeaveRequest(LeaveRequestCreateVM model)
    {
        // map data to leave request data model
        var leaveRequest = _mapper.Map<LeaveRequest>(model);

        // get logged in employee id 
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
        leaveRequest.EmployeeId = user.Id;

        // set LeaveRequestStatusId to pending
        leaveRequest.LeaveRequestStatusId = (int)LeaveRequestStatusEnum.Pending;

        // save leave request
        _context.Add(leaveRequest);

        // deduct allocation days based on request
        var numberOfDays = model.EndDate.DayNumber - model.StartDate.DayNumber;
        var allocationToDeduct = await _context.LeaveAllocations
            .FirstAsync(q => q.LeaveTypeId == model.LeaveTypeId && q.EmployeeId == user.Id);

        allocationToDeduct.Days -= numberOfDays;

        await _context.SaveChangesAsync();
    }

    public async Task<EmployeeLeaveRequestListVM> AdminGetAllLeaveRequests()
    {
        var leaveRequests = await _context.LeaveRequests
            .Include(q => q.LeaveType)
            .ToListAsync();
        var approvedLeaveRequestsCount = leaveRequests.Count(q => q.LeaveRequestStatusId == (int)
            LeaveRequestStatusEnum.Approved);
        var pendingLeaveRequestsCount = leaveRequests.Count(q => q.LeaveRequestStatusId == (int)
            LeaveRequestStatusEnum.Pending);
        var declinedLeaveRequestsCount = leaveRequests.Count(q => q.LeaveRequestStatusId == (int)
            LeaveRequestStatusEnum.Declined);

        var leaveRequestModels = leaveRequests.Select(q => new LeaveRequestReadOnlyVM
        {
            StartDate = q.StartDate,
            EndDate = q.EndDate,
            Id = q.Id,
            LeaveType = q.LeaveType.Name,
            LeaveRequestStatus = (LeaveRequestStatusEnum)q.LeaveRequestStatusId,
            NumberOfDays = q.EndDate.DayNumber - q.StartDate.DayNumber
        }).ToList();

        var model = new EmployeeLeaveRequestListVM
        {
            ApprovedRequests = approvedLeaveRequestsCount,
            PendingRequests = pendingLeaveRequestsCount,
            DeclinedRequests = declinedLeaveRequestsCount,
            TotalRequests = leaveRequests.Count,
            LeaveRequests = leaveRequestModels 
        };

        return model;
    }

    public async Task<List<LeaveRequestReadOnlyVM>> GetEmployeeLeaveRequests()
    {
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
        var leaveRequests = await _context.LeaveRequests
            .Include(q => q.LeaveType)
            .Where(q => q.EmployeeId == user.Id)
            .ToListAsync();
        var model = leaveRequests.Select(q => new LeaveRequestReadOnlyVM
        {
            StartDate = q.StartDate,
            EndDate = q.EndDate,
            Id = q.Id,
            LeaveType = q.LeaveType.Name,
            LeaveRequestStatus = (LeaveRequestStatusEnum)q.LeaveRequestStatusId,
            NumberOfDays = q.EndDate.DayNumber - q.StartDate.DayNumber
        }).ToList();

        return model;
    }

    public async Task<bool> RequestDatesExceedAllocation(LeaveRequestCreateVM model)
    {
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
        var numberOfDays = model.EndDate.DayNumber - model.StartDate.DayNumber;
        var allocation = await _context.LeaveAllocations
            .FirstAsync(q => q.LeaveTypeId == model.LeaveTypeId && q.EmployeeId == user.Id);

        return allocation.Days < numberOfDays;
    }

    public async Task ReviewLeaveRequest(int leaveRequestId, bool approved)
    {
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
        var leaveRequest = await _context.LeaveRequests.FindAsync(leaveRequestId);
        leaveRequest.LeaveRequestStatusId = approved
            ? (int)LeaveRequestStatusEnum.Approved
            : (int)LeaveRequestStatusEnum.Declined;

        leaveRequest.ReviewerId = user.Id;

        if (!approved)
        {
            var allocation = await _context.LeaveAllocations
            .FirstAsync(q => q.LeaveTypeId == leaveRequest.LeaveTypeId && q.EmployeeId == leaveRequest.EmployeeId);
            var numberOfDays = leaveRequest.EndDate.DayNumber - leaveRequest.StartDate.DayNumber;
            allocation.Days += numberOfDays;
        }

        await _context.SaveChangesAsync();
    }

    public async Task<ReviewLeaveRequestVM> GetLeaveRequestForReview(int id)
    {
        var leaveRequest = await _context.LeaveRequests
            .Include(q => q.LeaveType)
            .FirstAsync(q => q.Id == id);
        var user = await _userManager.FindByIdAsync(leaveRequest.EmployeeId);

        var model = new ReviewLeaveRequestVM
        {
            StartDate = leaveRequest.StartDate,
            EndDate = leaveRequest.EndDate,
            NumberOfDays = leaveRequest.EndDate.DayNumber - leaveRequest.StartDate.DayNumber,
            LeaveRequestStatus = (LeaveRequestStatusEnum)leaveRequest.LeaveRequestStatusId,
            Id = leaveRequest.Id,
            LeaveType = leaveRequest.LeaveType.Name,
            RequestComments = leaveRequest.RequestComments,
            Employee = new Models.LeaveAllocations.EmployeeListVM
            {
                Id = leaveRequest.EmployeeId,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            }
        };

        return model;
    }
    
}
