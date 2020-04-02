using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Training.ViewModels
{
    public class AddVehicle
    {
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public int Wheel { get; set; }
        public string Color { get; set; }
        public string Fuel { get; set; }
        public int Capacity { get; set; }
        public string RegistrationNumber { get; set; }
        public string Year { get; set; }
        public string Category { get; set; }
    }
}