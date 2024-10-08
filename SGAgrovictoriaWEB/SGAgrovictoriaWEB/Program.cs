using Microsoft.EntityFrameworkCore;
using SGAgrovictoriaWEB.Interfaces;
using SGAgrovictoriaWEB.Models;
using System;
using SGAgrovictoriaWEB.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICredencialModel, CredencialModel>();
//builder.Services.AddScoped<IProveedorModel, ProveedorModel>();


//Ingresar nombre de la instancia

var connectionString = builder.Configuration.GetConnectionString("server=DESKTOP-1MDIGEP\\MSSQLSERVER01;Database=SGAgroVictoriaDB;Trusted_Connection=True;TrustServerCertificate=True");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Inicio}/{action=InicioSesion}/{id?}");

app.Run();
