using BookClub.DAL;
using BookClub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookClub.Controllers
{
    public class HomeController : Controller
    {
        
        
            private MyDbContext db;
            public HomeController(MyDbContext context)
            {
                db = context;
            }
        

        public async Task<IActionResult> Index()
        {
            return View(await db.Books.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Name name)
        {
            var user = db.Names.Find(name.LoginID);
            
            if (user == null )
            {
                db.Names.Add(name);
                await db.SaveChangesAsync();
            }
            
            
            
            return RedirectToAction("Index");
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
