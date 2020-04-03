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
    [Authorize(Roles = "Administrator")]
    public class VehiclesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vehicles
        [AllowAnonymous]
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
            var color = db.Colors.Select(i => new SelectListItem()
            {
                Text = i.Title,
                Value = i.IdColor,
                Selected = false
            }).ToArray();
            ViewBag.Colors = color;
            var year = db.Years.Select(i => new SelectListItem()
            {
                Text = i.Title,
                Value = i.IdYear,
                Selected = false
            }).ToArray();
            ViewBag.Years = year;
            var fuel = db.Fuels.Select(i => new SelectListItem()
            {
                Text = i.Title,
                Value = i.IdFuel,
                Selected = false
            }).ToArray();
            ViewBag.Fuels = fuel;
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
                var fuel = db.Fuels.Find(addVehicle.Fuel);
                var color = db.Colors.Find(addVehicle.Color);
                var year = db.Years.Find(addVehicle.Year);
                if (category != null)
                {
                    var vehicle = new Vehicle()
                    {
                        IdVehicle = Guid.NewGuid().ToString(),
                        Name = addVehicle.Name,
                        Capacity = addVehicle.Capacity,
                        Category = category,
                        Color = color,
                        Descriptions = addVehicle.Descriptions,
                        Fuel = fuel,
                        RegistrationNumber = addVehicle.RegistrationNumber,
                        Wheel = addVehicle.Wheel,
                        Year = year
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
            var vehicle = db.Vehicles.Include("Category").Include("Color").Include("Fuel").Include("Year").Where(x => x.IdVehicle == id)
                .SingleOrDefault();
            if (vehicle == null)
            {
                return HttpNotFound();
            }

            var categories = db.Categories.Select(i => new SelectListItem()
            {
                Text = i.Title,
                Value = i.IdCategory,
                Selected = false
            }).ToArray();
            if (vehicle.Category != null)
            {
                foreach (var l in categories)
                {
                    if (vehicle.Category.IdCategory == l.Value)
                    {
                        l.Selected = true;
                    }
                }
            }
            ViewBag.Categories = categories;

            var colors = db.Colors.Select(i => new SelectListItem()
            {
                Text = i.Title,
                Value = i.IdColor,
                Selected = false
            }).ToArray();
            if (vehicle.Color != null)
            {
                foreach (var l in colors)
                {
                    if (vehicle.Color.IdColor == l.Value)
                    {
                        l.Selected = true;
                    }
                }
            }
            ViewBag.Colors = colors;

            var year = db.Years.Select(i => new SelectListItem()
            {
                Text = i.Title,
                Value = i.IdYear,
                Selected = false
            }).ToArray();
            if (vehicle.Year != null)
            {
                foreach (var l in year)
                {
                    if (vehicle.Year.IdYear == l.Value)
                    {
                        l.Selected = true;
                    }
                }
            }
            ViewBag.Years = year;

            var fuels = db.Fuels.Select(i => new SelectListItem()
            {
                Text = i.Title,
                Value = i.IdFuel,
                Selected = false
            }).ToArray();
            if (vehicle.Fuel != null)
            {
                foreach (var l in fuels)
                {
                    if (vehicle.Fuel.IdFuel == l.Value)
                    {
                        l.Selected = true;
                    }
                }
            }
            ViewBag.Fuels = fuels;

            return View(vehicle);
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
                var vehicle = db.Vehicles.Find(editVehicle.IdVehicle);
                var category = db.Categories.Find(editVehicle.Category);
                var fuel = db.Fuels.Find(editVehicle.Fuel);
                var color = db.Colors.Find(editVehicle.Color);
                var year = db.Years.Find(editVehicle.Year);
                if (category != null && fuel != null && color != null && year != null)
                {
                    vehicle.Name = editVehicle.Name;
                    vehicle.Descriptions = editVehicle.Descriptions;
                    vehicle.Wheel = editVehicle.Wheel;
                    vehicle.Color = color;
                    vehicle.Fuel = fuel;
                    vehicle.Capacity = editVehicle.Capacity;
                    vehicle.RegistrationNumber = editVehicle.RegistrationNumber;
                    vehicle.Year = year;
                    vehicle.Category = category;
                }
                db.Entry(vehicle).State = EntityState.Modified;
                var result = db.SaveChanges();
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }

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
