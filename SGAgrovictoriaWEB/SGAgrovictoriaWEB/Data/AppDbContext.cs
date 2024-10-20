using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using SGAgrovictoriaWEB.Models;

namespace SGAgrovictoriaWEB.Data

{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ProveedorModel> Proveedores { get; set; }
        public DbSet<UsuarioModel> Credenciales { get; set; }

        public DbSet<InventarioModel> Productos { get; set; }


        /*
         Se debe insertar la siguiente linea de codigo en caso de agregar un nuevo modelo
         
         public DbSet<EjemploModel> {Nombre de la tabla de la BD} { get; set; }

        

        */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //Ingresar nombre de la instancia

            optionsBuilder.UseSqlServer("Server=DESKTOP-1MDIGEP\\MSSQLSERVER01;Database=SGAgroVictoriaDB;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            
        }




    }
}
