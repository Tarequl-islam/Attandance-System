using AttandanceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AttandanceSystem.Controllers
{
    public class PersonController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Person
        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(Person person)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Model State Invalid";
            }
            else
            {
                var personFromDB = dbContext.Persons.ToList();
                foreach (var p in personFromDB)
                {
                    if (person.Phone==p.Phone)
                    {
                        ViewBag.Message = "Phone must be Unique!";
                        return View();
                    }
                }
                try
                {
                    dbContext.Persons.Add(person);
                    dbContext.SaveChanges();
                    ViewBag.Message = "Save Successful";
                    ModelState.Clear();
                }
                catch
                {
                    ViewBag.Message = "Save Failed";
                }
            }
            return View();
        }
    }
}