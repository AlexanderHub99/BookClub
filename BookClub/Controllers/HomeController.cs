using BookClub.DAL;
using BookClub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BookClub.Controllers
{
    public class HomeController : Controller
    {

        //инициализация бд в контроллере
        private MyDbContext db;
        public HomeController(MyDbContext context)
        {
            db = context;
        }


        //View Index имеет гиперссылку на регистрацию и логин
        public IActionResult Index()
        {
            return View();
        }

        //  Create проверяет на наличие регистрации пользователя если не зарегистрирован создает кейс с новым логином
        // В Create инициализируется кук файл с логином пользователя
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Name name)
        {
            //проверка на индивидуальность Login
            var user = db.Names.Find(name.LoginID);
            //инициализация кук файла 
            Microsoft.AspNetCore.Http.CookieOptions options = new Microsoft.AspNetCore.Http.CookieOptions();
            options.Expires = DateTime.Now.AddDays(2);
            Response.Cookies.Append("name", name.LoginID, options);
            //если ключ Login не найден создает новую учетную запись 
            if (user == null)
            {
                db.Names.Add(name);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("PersonalArea");
        }
        //личный кабинет Personal Area имеет в себе ссылку на прочитанные книги , ссылку на добавление книги в прочитанные
        public async Task<IActionResult> PersonalArea()
        {
            if (Request.Cookies["name"] != null)
            {
                @ViewBag.Message = Request.Cookies["name"];
            }

            return View(await db.Books.ToListAsync());
        }
        //AddBook отвечает за добавление книги выбранной пользователем в прочитанные
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddBook(string id, UserBooks userBooks)
        {
            userBooks.SelectedBook = id;
            if (id == null)
            {
                return RedirectToAction("AddBook");
            }
            return View(userBooks);
        }
        [HttpPost, ActionName("AddBook")]
        public async Task<IActionResult> DeleteConfirmed(string id, UserBooks userBooks)
        {



            if (userBooks == null)
            {
                return RedirectToAction("PersonalArea");
            }
            //прикрепляю login пользователя к прочитанной книге на стороне сервера 
            userBooks.LoginName = Request.Cookies["name"];
            db.UserBooks.Add(userBooks);
            await db.SaveChangesAsync();

            return RedirectToAction("PersonalArea");
        }
        //MyBooK кабинет с прочитанными книгами и ссылкой на удаление
        public async Task<IActionResult> MyBooK()
        {
            if (Request.Cookies["name"] != null)
            {
                @ViewBag.Message = Request.Cookies["name"];
            }
            return View(await db.UserBooks.ToListAsync());
        }
        //Удаление книги из списка прочитанных
        [HttpGet]
        public ActionResult Delete(int id)
        {
            UserBooks b = db.UserBooks.Find(id);
            if (b == null)
            {
                return RedirectToAction("MyBooK");
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserBooks b = db.UserBooks.Find(id);
            if (b == null)
            {
                return RedirectToAction("MyBooK");
            }
            db.UserBooks.Remove(b);
            db.SaveChanges();

            return RedirectToAction("MyBooK");
        }
        //Создано генератором ASP:NET Core 5 для отслеживания ошибок связанных с HttpContext
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
