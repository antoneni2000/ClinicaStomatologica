using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using Clinica.Models;
namespace Clinica.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu.")]
        [Range(0, double.MaxValue, ErrorMessage = "Costul tratamentului trebuie să fie pozitiv.")]
        public decimal TreatmentCost { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu.")]
        public string Medicine { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu.")]
        [Range(1, int.MaxValue, ErrorMessage = "Cantitatea trebuie să fie cel puțin 1.")]
        public int Quantity { get; set; }
    }
}