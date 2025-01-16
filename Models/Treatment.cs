using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace Clinica.Models
{
    public class Treatment
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Numele tratamentului trebuie sa fie intre 3 si 30 de caractere!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu.")]
        [Range(0, int.MaxValue, ErrorMessage = "Costul tratamentului trebuie să fie pozitiv.")]

        public int Cost { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu.")]
        public string Description { get; set; }
    }
}