using ASPCoreMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ASPCoreMVC.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            ViewData.Add("ReturnUrl", ReturnUrl);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserDetails user, string ReturnUrl)
        {
            //validate user 
            if (user.UserName == "admin" && user.Password == "admin123" && user.Role=="Admin")
            {
                //sign in the user and redirect to the requested page
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Role,"Admin")                    
                };
                
                var claimsIdentity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                    new ClaimsPrincipal(claimsIdentity));

                return Redirect(ReturnUrl);
            }
            else if(user.UserName=="guest" && user.Password=="guest")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                return Redirect(ReturnUrl);
            }
            else
            {
                ViewData.Add("ReturnUrl", ReturnUrl);
                ViewData.Add("msg", "invalid username/passwoprd");
                return View(user);
            }            
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Employees/Index");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
