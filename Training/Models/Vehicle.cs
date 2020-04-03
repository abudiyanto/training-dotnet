using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Training.Models
{
    public class Vehicle
    {
        [Key]
        public string IdVehicle { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public int Wheel { get; set; }
        public string Color { get; set; }
        public string Fuel { get; set; }
        public Capacity Capacity { get; set; }
        public string RegistrationNumber { get; set; }
        public string Year { get; set; }
        public Category Category { get; set; }
    }
    public class Category
    {
        [Key]
        public string IdCategory { get; set; }
        public string Title { get; set; }
    }
    public class Capacity
    {
        [Key]
        public string IdCapacity { get; set; }
        public string Title { get; set; }
    }
}