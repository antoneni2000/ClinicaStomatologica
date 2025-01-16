using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Clinica.Data;
using Clinica.Models;

namespace Clinica.Pages.Doctors
{
    public class DetailsModel : PageModel
    {
        private readonly Clinica.Data.ClinicaContext _context;

        public DetailsModel(Clinica.Data.ClinicaContext context)
        {
            _context = context;
        }

        public Doctor Doctor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor.FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }
            else
            {
                Doctor = doctor;
            }
            return Page();
        }
    }
}
