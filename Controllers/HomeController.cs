using btl_web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace btl_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BtlWebContext btlWebContext;


        public HomeController(ILogger<HomeController> logger, BtlWebContext btlWebContext)
        {
            _logger = logger;
            this.btlWebContext = btlWebContext;
        }

        public IActionResult Index()
        {
            var test = btlWebContext.Users.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}