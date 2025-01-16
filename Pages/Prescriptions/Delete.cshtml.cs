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
    public class DeleteModel : PageModel
    {
        private readonly Clinica.Data.ClinicaContext _context;

        public DeleteModel(Clinica.Data.ClinicaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Prescription Prescription { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescription.FirstOrDefaultAsync(m => m.Id == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescription.FindAsync(id);
            if (prescription != null)
            {
                Prescription = prescription;
                _context.Prescription.Remove(Prescription);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
