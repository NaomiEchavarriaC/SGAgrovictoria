using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGAgrovictoriaWEB.Data;
using SGAgrovictoriaWEB.Models;
using Microsoft.AspNetCore.Mvc;
using SGAgrovictoriaWEB.Permisos;

namespace SGAgrovictoriaWEB.Controllers
{
	[ServiceFilter(typeof(ValidarSesionAttribute))]
	public class UsuarioController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }
       
   
    //get: Products
    public async Task<IActionResult> ConsultarUsuarios()
    {
        return View(await _context.Credenciales.ToListAsync());
    }

    // Detalles del proveedor por su ID 
    public async Task<IActionResult> ConsultarUsuario(int id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var usuario = await _context.Credenciales.FirstOrDefaultAsync(m => m.IdCredencial == id);

        if (usuario == null)
        {
            return NotFound();
        }
        return View(usuario);
    }
		[HttpPost]
		public async Task<IActionResult> Login(UsuarioModel credencial)
        {
           
            var usuario = await _context.Credenciales.FirstOrDefaultAsync(m => m.Usuario == credencial.Usuario && m.Clave==credencial.Clave);

            if (usuario == null)
            {
                ViewData["Mensaje"] = "Usuario no encontrado";
                return View();
            }
            else
            {
				return RedirectToAction("PantallaPrincipal", "Inicio");
			}
		}
        //get: Proveedor/create
        public IActionResult AgregarUsuario()
        {
            return View();
        }

        //POST : Proveedor/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarUsuario(UsuarioModel credencial)
        {
            if (ModelState.IsValid)
            {
               
                _context.Add(credencial);
                await _context.SaveChangesAsync();
                return RedirectToAction("ConsultarUsuarios");

            }
            return View(credencial);
        }
        //Editar proveedor por su ID
        public async Task<IActionResult> EditarUsuario(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var usuario = await _context.Credenciales.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> EditarUsuario(UsuarioModel credencial)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(credencial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(credencial.IdCredencial))
                    {
                        return NotFound();

                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ConsultarUsuarios));
            }
            return View(credencial);

        }



        //get proveedor/delete
        public async Task<IActionResult> EliminarUsuario(long id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Credenciales.FirstOrDefaultAsync(x => x.IdCredencial == id);

            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }


        public async Task<IActionResult> ConfirmarBorrado(long IdUsuario)
        {
            var credencial = await _context.Credenciales.FindAsync(IdUsuario);
            _context.Credenciales.Remove(credencial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ConsultarUsuarios));
        }


        //Verificar si el proveedor existe
        private bool UsuarioExists(long id)
        {
            return _context.Credenciales.Any(e => e.IdCredencial == id);


        }
    }
}
