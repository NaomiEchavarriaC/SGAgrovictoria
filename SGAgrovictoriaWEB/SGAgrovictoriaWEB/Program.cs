using Microsoft.EntityFrameworkCore;
using SGAgrovictoriaWEB.Models;
using System;
using SGAgrovictoriaWEB.Data;
using Microsoft.Extensions.Options;
using SGAgrovictoriaWEB.Permisos;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

<<<<<<< Updated upstream
builder.Services.AddScoped<ICredencialModel, CredencialModel>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ValidarSesionAttribute>(); // Registrar el filtro

builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30); // Tiempo de inactividad
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true; // Para cumplir con el GDPR si es necesario
});
builder.Services.AddSession();
=======
>>>>>>> Stashed changes

//builder.Services.AddScoped<IProveedorModel, ProveedorModel>();


//Ingresar nombre de la instancia

var connectionString = builder.Configuration.GetConnectionString("\"Server=DESKTOP-1MDIGEP\\MSSQLSERVER01;Database=SGAgroVictoriaDB;Trusted_Connection=True;TrustServerCertificate=True\"");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));


var app = builder.Build(); 
app.UseSession();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Acceso}/{action=Login}");

app.Run();
