using System.Diagnostics;
using LeaveManagementSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Define business logic
            // ... 

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
              
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {   
            // queries
            // calculations

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            // here it is creating a new object of a class called ErrorViewModel (class can be called whatever you want)
            // proper naming conventions tells me that this is a ViewModel class designed for a page called Error.

            // Ultimately the Action is preparing this data, or an object of this class as data to be returned with the view.
                       
        }
    }
}
