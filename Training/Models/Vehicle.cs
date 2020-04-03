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
        public Color Color { get; set; }
        public Fuel Fuel { get; set; }
        public int Capacity { get; set; }
        public string RegistrationNumber { get; set; }
        public Year Year { get; set; }
        public Category Category { get; set; }
    }
    public class Category
    {
        [Key]
        public string IdCategory { get; set; }
        public string Title { get; set; }
    }
    public class Color
    {
        [Key]
        public string IdColor { get; set; }
        public string Title { get; set; }
    }
    public class Fuel
    {
        [Key]
        public string IdFuel { get; set; }
        public string Title { get; set; }
    }
    public class Year
    {
        [Key]
        public string IdYear { get; set; }
        public string Title { get; set; }
    }
}