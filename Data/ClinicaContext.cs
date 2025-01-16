using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Clinica.Models;

namespace Clinica.Data
{
    public class ClinicaContext : DbContext
    {
        public ClinicaContext (DbContextOptions<ClinicaContext> options)
            : base(options)
        {
        }

        public DbSet<Clinica.Models.Doctor> Doctor { get; set; } = default!;
        public DbSet<Clinica.Models.Appointment> Appointment { get; set; } = default!;
        public DbSet<Clinica.Models.Patient> Patient { get; set; } = default!;
        public DbSet<Clinica.Models.Prescription> Prescription { get; set; } = default!;
        public DbSet<Clinica.Models.Treatment> Treatment { get; set; } = default!;
        
    }
}
