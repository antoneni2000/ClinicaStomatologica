using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinica.Data;
using Clinica.Models;
using Microsoft.AspNetCore.Authorization;

namespace Clinica.Pages.Treatments
{
    [Authorize(Roles = "Admin")]

    public class EditModel : PageModel
    {
        private readonly Clinica.Data.ClinicaContext _context;

        public EditModel(Clinica.Data.ClinicaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Treatment Treatment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatment =  await _context.Treatment.FirstOrDefaultAsync(m => m.Id == id);
            if (treatment == null)
            {
                return NotFound();
            }
            Treatment = treatment;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Treatment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreatmentExists(Treatment.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TreatmentExists(int id)
        {
            return _context.Treatment.Any(e => e.Id == id);
        }
    }
}
