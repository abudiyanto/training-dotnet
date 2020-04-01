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
    }
}