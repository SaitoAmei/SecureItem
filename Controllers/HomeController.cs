using Microsoft.AspNetCore.Mvc;
using SecureItem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Antiforgery;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using SecureItem.Data;
using System.Linq;

namespace SecureItem.Controllers
{

    public class HomeController : Controller
    {
        private ApplicationDbContext _context { get; set; }
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LoginUserModel model)
        {
            var user = _context.Users.Any(x => x.Login == model.UserName && x.Passwors == model.Password);
            if (!ModelState.IsValid)
            { return View(); }
            if (user)
            {
                var claims = new List<Claim>
                {
                new Claim("Admin","Admin")
                };

                var claimIdentity = new ClaimsIdentity(claims, "Cookie");
                var claimPrincipal = new ClaimsPrincipal(claimIdentity);
                await HttpContext.SignInAsync("Cookie", claimPrincipal);

                return RedirectToAction("Index", "Admin");
            }
            else 
            {
                return View("Index");
            }
        }
    }
}
