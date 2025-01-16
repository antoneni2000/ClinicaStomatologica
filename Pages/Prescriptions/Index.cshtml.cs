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
    public class IndexModel : PageModel
    {
        private readonly Clinica.Data.ClinicaContext _context;

        public IndexModel(Clinica.Data.ClinicaContext context)
        {
            _context = context;
        }

        public IList<Prescription> Prescription { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Prescription = await _context.Prescription
                .Include(p => p.Patient)
                .Include(p => p.Treatment).ToListAsync();
        }
    }
}
