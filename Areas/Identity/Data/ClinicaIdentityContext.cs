using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Data
{ 

    public class ClinicaIdentityContext : IdentityDbContext<IdentityUser>
    {
        public ClinicaIdentityContext(DbContextOptions<ClinicaIdentityContext> options)
            : base(options)
        {
        }

    public DbSet<Clinica.Models.Doctor> Doctor { get; set; } = default!;
    public DbSet<Clinica.Models.Patient> Patient { get; set; } = default!;
    public DbSet<Clinica.Models.Treatment> Treatment { get; set; } = default!;
    public DbSet<Clinica.Models.Prescription> Prescription { get; set; } = default!;
    public DbSet<Clinica.Models.Appointment> Appointment { get; set; } = default!;
    }
}