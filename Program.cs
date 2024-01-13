using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProiectSemestru.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Consultations");
    options.Conventions.AuthorizeFolder("/Doctors");
    options.Conventions.AuthorizeFolder("/Patients");
    options.Conventions.AuthorizeFolder("/Visits");
    options.Conventions.AuthorizeFolder("/Prescriptions");
});

// Add services to the container.
builder.Services.AddDbContext<ProiectSemestruContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProiectSemestruContext") ?? throw new InvalidOperationException("Connectionstring 'ProiectSemestruContext' not found.")));
builder.Services.AddDbContext<LibraryIdentityContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProiectSemestruContext") ?? throw new InvalidOperationException("Connectionstring 'ProiectSemestruContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<LibraryIdentityContext>();




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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
