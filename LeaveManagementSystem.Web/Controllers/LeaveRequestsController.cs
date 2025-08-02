using LeaveManagementSystem.Web.Models.LeaveRequests;
using LeaveManagementSystem.Web.Services.LeaveRequests;
using LeaveManagementSystem.Web.Services.LeaveTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LeaveManagementSystem.Web.Controllers;

[Authorize]
public class LeaveRequestsController(ILeaveTypesService _leaveTypesService, 
    ILeaveRequestsService _leaveRequestsService) : Controller
{
    // Employee View requests
    public async Task<IActionResult> Index()
    {
        return View();
    }

    // Employee Create requests
    public async Task<IActionResult> Create()
    {
        var leaveTypes = await _leaveTypesService.GetAll();
        var leaveTypesList = new SelectList(leaveTypes, "Id", "Name");
        var model = new LeaveRequestCreateVM
        {
            StartDate = DateOnly.FromDateTime(DateTime.Now),
            EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
            LeaveTypes = leaveTypesList,
        };
        return View(model);
    }

    // Employee Create requests
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(LeaveRequestCreateVM model)
    {   
        if (ModelState.IsValid)
        {
            await _leaveRequestsService.CreateLeaveRequest(model);
        }

        var leaveTypes = await _leaveTypesService.GetAll();
        model.LeaveTypes = new SelectList(leaveTypes, "Id", "Name");
        return View(model);
    }

    // Employee Cancel requests
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Cancel(int leaveRequestId)
    {
        return View();
    }

    // Admin/Supervisor review requests
    public async Task<IActionResult> ListRequests()
    {
        return View();
    }

    // Admin/Supe review requests
    public async Task<IActionResult> Review(int leaveRequestId)
    {
        return View();
    }

    // Admin/Supervisor review requests
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Review(/*Use VM*/)
    {
        return View();
    }
}
