using Microsoft.EntityFrameworkCore;
using phoneCATALOG.Data;
using phoneCATALOG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace phoneCATALOG.Controllers
{
    public class HomeController : Controller
    {
        private phoneCATALOGContext db = new phoneCATALOGContext();

       

        public ActionResult Index()
        {
            Phone phone = new Phone();
            phone.myPhoneList = db.Phones.ToList();
            ViewBag.Title = "Home Page";

            return View("Index", phone);
        }

        public ActionResult Edit(int id)
        {

            Phone myphone = db.Phones.SingleOrDefault(a => a.Id == id);
            if (myphone != null)
                return View("Edit", myphone);
            else
                return View("Index");
        }
        [HttpPost]
        public string AddNewContact(Phone newPhone)
        {

            if(newPhone != null)
            {
                db.Phones.Add(newPhone);
                db.SaveChanges();
                return "ok";
            }
            return "nok";
        }

        [HttpGet]
        public string DeleteContact(int contactId)
        {
            if (db.Phones.Any(a => a.Id == contactId))
            {
                Phone forDelete = db.Phones.Single(a => a.Id == contactId);
                db.Phones.Remove(forDelete);
                db.SaveChanges();
                return "ok";
            }
            return "nok";
           

        }

        [HttpPost]
        public string EditContact(Phone phone, int contactId)
        {
            Phone storedPhone = db.Phones.SingleOrDefault(a => a.Id == contactId);
            if (storedPhone != null)
            {
                storedPhone.FullName = phone.FullName;
                storedPhone.PhoneNumber = phone.PhoneNumber;
                storedPhone.Type = phone.Type;
                db.SaveChanges();

            }


            return "ok";
        }
    }
}
