using BookClub.DAL;
using BookClub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
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

        string viewBagMessageLogi = null;

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> PersonalArea()
        {
            ViewBag.Countries = new List<string> { viewBagMessageLogi };
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

            viewBagMessageLogi = name.LoginID;

            if (user == null)
            {
                db.Names.Add(name);
                await db.SaveChangesAsync();
            }                      
            return RedirectToAction("PersonalArea" );
        }

        public IActionResult AddBook()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddBook(string id,UserBooks userBooks)
        {
            userBooks.SelectedBook = id;
            if (id == null)
            {
                //return RedirectToAction("AddBook");
            }
            return View(userBooks);
        }
        [HttpPost, ActionName("AddBook")]
        public async Task<IActionResult> DeleteConfirmed(string id ,UserBooks userBooks )
        {
            
            
            
            if (userBooks == null)
            {
                return RedirectToAction("Index");
            }
            
            db.UserBooks.Add(userBooks);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }


            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
