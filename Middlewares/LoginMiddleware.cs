using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using btl_web.Services.Interfaces;
using btl_web.Dtos;
using Newtonsoft.Json;
using btl_web.Models;
using btl_web.Services;

namespace btl_web.Middlewares
{
    public class LoginMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly IHttpContextAccessor _context;

        private readonly string[] pageCanAccessWithoutLogin = { "/account/register", "/account/login" };

        public LoginMiddleware(RequestDelegate next,
            IHttpContextAccessor context
            )
        {
            _next = next;
            _context = context;
        }

        public async Task Invoke(HttpContext context)
        {
            string userString = _context.HttpContext.Session.GetString("user");

            UserDto user = new UserDto();
            if (!string.IsNullOrEmpty(userString))
            {
                user = JsonConvert.DeserializeObject<UserDto>(userString);
            }

            //Check if 'isLogin' is not present in localStorage and the path is not / account / login or / account / register
            if (context.Request.Path != "/account/login" && context.Request.Path != "/account/register"
            && (user.Id == 0))
            {
                // Redirect to /account/login
                context.Response.Redirect("/account/login");
                return;
            }

            if ((context.Request.Path == "/account/login" || context.Request.Path == "/account/register")
            && (user.Id != 0))
            {
                // Redirect to /account/login
                context.Response.Redirect("/");
                return;
            }

            // Continue processing the request
            await _next(context);
        }
    }
}
