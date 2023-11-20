using btl_web.Dtos;
using btl_web.Models;
using btl_web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace btl_web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(IFormCollection formCollection)
        {
            string email = formCollection["email"];
            string password = formCollection["password"];

            return Ok(_userService.Login(email, password));
        }

        [HttpPost]
        public IActionResult Logout()
        {
            return Ok(_userService.Logout());
        }

        //[HttpPost]
        //public IActionResult Logout(IFormCollection formCollection)
        //{
        //    return Ok(_userService.Logout());
        //}

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(IFormCollection formCollection)
        {
            return Ok(_userService.Register(new UserDto(formCollection["Password"], formCollection["RePassword"], formCollection["Email"], formCollection["FullName"])));
        }
    }
}
