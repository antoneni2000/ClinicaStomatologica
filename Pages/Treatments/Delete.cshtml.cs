using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Clinica.Data;
using Clinica.Models;
using Microsoft.AspNetCore.Authorization;

namespace Clinica.Pages.Treatments
{
    [Authorize(Roles = "Admin")]

    public class DeleteModel : PageModel
    {
        private readonly Clinica.Data.ClinicaContext _context;

        public DeleteModel(Clinica.Data.ClinicaContext context)
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

            var treatment = await _context.Treatment.FirstOrDefaultAsync(m => m.Id == id);

            if (treatment == null)
            {
                return NotFound();
            }
            else
            {
                Treatment = treatment;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treatment = await _context.Treatment.FindAsync(id);
            if (treatment != null)
            {
                Treatment = treatment;
                _context.Treatment.Remove(Treatment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
