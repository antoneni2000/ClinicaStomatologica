using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Clinica.Data;
using Clinica.Models;

namespace Clinica.Pages.Appointments
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
        ViewData["DoctorID"] = new SelectList(_context.Doctor, "Id", "Name");
        ViewData["PatientID"] = new SelectList(_context.Set<Patient>(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Appointment.Add(Appointment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
