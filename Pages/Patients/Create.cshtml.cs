using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Clinica.Data;
using Clinica.Models;

namespace Clinica.Pages.Patients
{
    public class CreateModel : PageModel
    {
        private readonly Clinica.Data.ClinicaContext _context;

        public CreateModel(Clinica.Data.ClinicaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "Email");
            return Page();
        }

        [BindProperty]
        public Patient Patient { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Patient.Add(Patient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
