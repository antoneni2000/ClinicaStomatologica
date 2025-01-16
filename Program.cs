using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Clinica.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>policy.RequireRole("Admin"));
});

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Doctors");
    options.Conventions.AuthorizeFolder("/Patients");
    options.Conventions.AuthorizeFolder("/Treatments/Edit", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Treatments/Create", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Treatments/Delete", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Prescriptions");
    options.Conventions.AuthorizeFolder("/Appointments");
});
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ClinicaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ClinicaContext") ?? throw new InvalidOperationException("Connection string 'ClinicaContext' not found.")));

builder.Services.AddDbContext<ClinicaIdentityContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ClinicaContext") ?? 
    throw new InvalidOperationException("Connection string 'Nume_Pren_Lab2Context' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options =>options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
      .AddEntityFrameworkStores<ClinicaIdentityContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
