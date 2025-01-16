using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Clinica.Data;
using Clinica.Models;

namespace Clinica.Pages.Prescriptions
{
    public class DetailsModel : PageModel
    {
        private readonly Clinica.Data.ClinicaContext _context;

        public DetailsModel(Clinica.Data.ClinicaContext context)
        {
            _context = context;
        }

        public Prescription Prescription { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescription
                .Include(p => p.Patient)
                .Include(p => p.Treatment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prescription == null)
            {
                return NotFound();
            }
            else
            {
                Prescription = prescription;
            }
            return Page();
        }
    }
}
