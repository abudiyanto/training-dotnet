using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Training.Models;

namespace Training.Controllers
{
    public class PersonsController : Controller
    {
        // GET: Persons
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Show(string id, string name, string address)
        {
            var person = new Person()
            {
                IdPerson = id,
                FullName = name,
                Address = address
            };
            return View(person);
        }
    }
}