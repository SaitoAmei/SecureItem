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
        [ValidateAntiForgeryToken]
        public ActionResult Search(IFormCollection collection)
        {
            var model = new List<IntegritySecureData>();
            if (string.IsNullOrEmpty(collection["query"].ToString()))
                {
                 model = _context.IntegritySecureData.Where(x => x.Category == collection["type"].ToString()).ToList();

            }
            else 
            {
                 model = _context.IntegritySecureData.Where(x => x.Danger.Contains(collection["query"].ToString()) && x.Category == collection["type"].ToString()).ToList(); 
            }

            if (model.Any())
            {
                return View(model);
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet]

        public string _dataInit(int id)
        {
            var model = _context.IntegritySecureData.FirstOrDefault(x => x.dangerId == id).DangerAction;
            ViewBag.listForModal = model.Split("U+002E").ToList();
            return model;

        }

        [HttpGet]

        public ActionResult LogOff()
        {
            HttpContext.SignOutAsync().GetAwaiter();
            return RedirectToAction("Index", "Home");

        }
    }
}
