using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Training.ViewModels
{
    public class AddVehicle
    {
        [Required(ErrorMessage = "Nama Tidak Boleh Kosong")]
        public string Name { get; set; }
        [Required]
        public string Descriptions { get; set; }
        [Required]
        public int Wheel { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Fuel { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public string RegistrationNumber { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string Category { get; set; }
    }
    public class EditVehicle
    {
        public string IdVehicle { get; set; }
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