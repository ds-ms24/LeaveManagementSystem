using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Web.Controllers;

[Authorize]
public class LeaveRequestsController : Controller
{
    // Employee View requests
    public async Task<IActionResult> Index()
    {
        return View();
    }

    // Employee Create reqests
    public async Task<IActionResult> Create()
    {
        return View();
    }

    // Employee Create reqests
    [HttpPost]
    public async Task<IActionResult> Create(int create /*Use VM*/)
    {
        return View();
    }

    // Employee Cancel reqests
    [HttpPost]
    public async Task<IActionResult> Cancel(int leaveRequestId)
    {
        return View();
    }

    // Admin/Supe review reqests
    public async Task<IActionResult> ListRequests()
    {
        return View();
    }

    // Admin/Supe review reqests
    public async Task<IActionResult> Review(int leaveRequestId)
    {
        return View();
    }

    // Admin/Supe review reqests
    [HttpPost]
    public async Task<IActionResult> Review(/*Use VM*/)
    {
        return View();
    }
}
