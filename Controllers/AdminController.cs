using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecureItem.Data;
using SecureItem.Models;
using System.Collections.Generic;
using System.Linq;

namespace SecureItem.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ApplicationDbContext _context { get; set; }
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(IFormCollection collection)
        {
            var a1= collection["query"].ToString();
            var a2 =collection["type"].ToString();
            var model = _context.IntegritySecureData.Where(x => x.Danger.Contains(collection["query"].ToString()) && x.Category == collection["type"].ToString()).ToList();
            if (model.Any())
            {
                //var qq = collection["type"];
                return View(model);
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet]

        public ActionResult LogOff()
        {
            HttpContext.SignOutAsync().GetAwaiter();
            return RedirectToAction("Index", "Home");

        }
    }
}
