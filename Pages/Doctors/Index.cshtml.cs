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
    public class IndexModel : PageModel
    {
        private readonly Clinica.Data.ClinicaContext _context;

        public IndexModel(Clinica.Data.ClinicaContext context)
        {
            _context = context;
        }

        public IList<Doctor> Doctor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Doctor = await _context.Doctor.ToListAsync();
        }
    }
}
