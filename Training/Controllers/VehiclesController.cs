using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Training.Models;

namespace Training.Controllers
{
    public class VehiclesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Vehicles.ToList());
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vehicle = db.Vehicles.Include("Category").Where(x => x.IdVehicle == id)
                .SingleOrDefault();
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }
        // GET: Vehicles/Create
        public ActionResult Create()
        {
            var categories = db.Categories.Select(i => new SelectListItem()
            {
                Text = i.Title,
                Value = i.IdCategory,
                Selected = false
            }).ToArray();
            ViewBag.Categories = categories;
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModels.AddVehicle addVehicle)
        {
            if (ModelState.IsValid)
            {
                var category = db.Categories.Find(addVehicle.Category);
                if(category != null)
                {
                    var vehicle = new Vehicle()
                    {
                        IdVehicle = Guid.NewGuid().ToString(),
                        Name = addVehicle.Name,
                        Capacity = addVehicle.Capacity,
                        Category = category,
                        Color = addVehicle.Color,
                        Descriptions = addVehicle.Descriptions,
                        Fuel = addVehicle.Fuel,
                        RegistrationNumber = addVehicle.RegistrationNumber,
                        Wheel = addVehicle.Wheel,
                        Year = addVehicle.Year
                    };
                    db.Vehicles.Add(vehicle);
                    var result = db.SaveChanges();
                    if(result > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(addVehicle);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Include("Category").Where(x => x.IdVehicle == id)
                .SingleOrDefault();
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            else
            {
                var categories = db.Categories.Select(i => new SelectListItem()
                {
                    Text = i.Title,
                    Value = i.IdCategory,
                    Selected = false
                }).ToArray();
                foreach(var item in categories)
                {
                    if(vehicle.Category != null)
                    {
                        if (item.Value == vehicle.Category.IdCategory)
                        {
                            item.Selected = true;
                        }
                    }
                }
                ViewBag.Categories = categories;
                return View(vehicle);
            }
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewModels.EditVehicle editVehicle)
        {
            if (ModelState.IsValid)
            {
                var vehicle = db.Vehicles.Include("Category").Where(x => x.IdVehicle == editVehicle.IdVehicle)
                    .SingleOrDefault();
                var category = db.Categories.Find(editVehicle.Category);
                if(vehicle != null)
                {
                    vehicle.Category = category;
                    vehicle.Color = editVehicle.Color;
                    vehicle.Year = editVehicle.Year;
                    vehicle.Name = editVehicle.Name;
                    vehicle.Wheel = editVehicle.Wheel;
                    vehicle.Descriptions = editVehicle.Descriptions;
                    vehicle.Capacity = editVehicle.Capacity;
                }
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(editVehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
