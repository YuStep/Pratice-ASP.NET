using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using testir.Models;

namespace testir.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PersonContext db;
        public HomeController(PersonContext context)
        {
            db = context;
        }
        public IActionResult Index(string name = null,string surname = null)
        {
            IEnumerable<Person> users = db.Persones.ToList();
            if (!String.IsNullOrEmpty(name) && String.IsNullOrEmpty(surname)) // Фильтрация только по имени
            {
                users = users.Where(p => p.Name.Contains(name));
            }   
            else if (String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(surname)) // Фильтрация только по фамилии
            {
                users = users.Where(p => p.Surname.Contains(surname));
            }
            else if(!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(surname)) // Фильтрация по имени и фамилии
            {
                users = users.Where(p => (p.Name.Contains(name) && p.Surname.Contains(surname)));
            }
            return View(users);
        }

        public IActionResult Check(int ID)
        {
            Person b = db.Persones.Include(t => t.PFRStorages).Where(t => t.Id == ID).ToList()[0]; // Взятие необходимой модели по ID
      
            return View(b);
        }

        [HttpGet]
        public IActionResult AddPFR(int ID)
        {
            Person person = db.Persones.Find(ID); //Взятие необходимой модели по ID
            return View(person);
        }
        [HttpPost]
        public IActionResult AddPFR(PFRStorage storage)
        {
            if (ModelState.IsValid) 
            {
            //db.Storages.Add(storage);
            db.Storages.Add(new PFRStorage { Period = storage.Period, Suma = storage.Suma, PersonId = storage.PersonId, Person = storage.Person }); 
            db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Person person)
        {

            if (ModelState.IsValid)
            {
                db.Persones.Add(person);
                // сохраняем в бд все изменения
                db.SaveChanges();
            }
            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Person b = db.Persones.Find(id);
            if (b == null)
            {
                return NotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            
            Person b = db.Persones.FirstOrDefault(p=>p.Id == id); // Удаление человека
            if (b != null)
            {
                db.Persones.Remove(b);
                db.SaveChanges();
            }

            PFRStorage c = db.Storages.FirstOrDefault(p => p.PersonId == id); // Удаление платежей человека
            if (c != null)
            {
                db.Storages.Remove(c);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
