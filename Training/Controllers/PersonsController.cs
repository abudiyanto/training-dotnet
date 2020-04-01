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
        public ActionResult Looping(int number)
        {
            ViewBag.Statement = "Hello World!";
            return View(number);
        }
        public ActionResult Conditional(string name)
        {
            string answer = "bambang";
            if(name != null)
            {
                if(name.Equals(answer))
                {
                    return Content("Hello " + name);
                }
                else
                {
                    return Content("I'm Sorry");
                }
            }
            return Content("Please input name!");
        }
        public ActionResult Json()
        {
            var person = new Person()
            {
                IdPerson = "123",
                Address = "Babarsari",
                FullName = "Bambang"
            };
            return Json(person, JsonRequestBehavior.AllowGet);
        }
    }
}