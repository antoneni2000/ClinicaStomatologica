using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Clinica.Data;
using Clinica.Models;
using Microsoft.AspNetCore.Authorization;

namespace Clinica.Pages.Treatments
{
    [Authorize(Roles = "Admin")]

    public class CreateModel : PageModel
    {
        private readonly Clinica.Data.ClinicaContext _context;

        public CreateModel(Clinica.Data.ClinicaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Treatment Treatment { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Treatment.Add(Treatment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
