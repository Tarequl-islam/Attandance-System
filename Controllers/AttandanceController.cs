using AttandanceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AttandanceSystem.Controllers
{
    public class AttandanceController : Controller
    {
        ApplicationDbContext dbContext = new ApplicationDbContext();
        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.Entries = GetAllEntriesForDropdown();
            ViewBag.Persons = GetAllPersonForDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Attandance attandance)
        {
            ViewBag.Entries = GetAllEntriesForDropdown();
            ViewBag.Persons = GetAllPersonForDropdown();

            if (!ModelState.IsValid)
            {
                ViewBag.Message = "Model State Invalid";
            }
            else
            {
                var attandanceFromDB = dbContext.Attandances.ToList();
                foreach(var att in attandanceFromDB)
                {
                    if(attandance.PersonId==att.PersonId && attandance.Date==att.Date && attandance.IsEntryId == att.IsEntryId)
                    {
                        ViewBag.Message = "Change Entry Status!";
                        return View();
                    }
                }
                try
                {
                    dbContext.Attandances.Add(attandance);
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

        public List<SelectListItem> GetAllEntriesForDropdown()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){ Text = "--Select--", Value = ""},
                new SelectListItem(){ Text = "Entering", Value = "1"},
                new SelectListItem(){ Text = "Outgoing", Value = "2"}
            };
            return selectListItems;
        }

        public List<SelectListItem> GetAllPersonForDropdown()
        {
            var persons = dbContext.Persons.ToList();
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem(){ Text = "--Select--", Value = ""},
            };
            foreach(var person in persons)
            {
                SelectListItem sl = new SelectListItem();
                sl.Value = person.Id.ToString();
                sl.Text = person.Name;
                selectListItems.Add(sl);
            }
            return selectListItems;
        }
    }
}