using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGAgrovictoriaWEB.Data;
using SGAgrovictoriaWEB.Models;

namespace SGAgrovictoriaWEB.Controllers
{
	public class AccesoController : Controller

	{
		private readonly AppDbContext _context;
		private readonly ILogger<AccesoController> _logger;

		public AccesoController(ILogger<AccesoController> logger, AppDbContext context)
		{
			_logger = logger;
			_context = context;
		}


		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
        private readonly IHttpContextAccessor _httpContextAccessor;

        [HttpPost]
		public async Task<IActionResult> Login(UsuarioModel credencial)
		{
            var usuario = await _context.Credenciales.FirstOrDefaultAsync(m => m.Usuario == credencial.Usuario && m.Clave == credencial.Clave);

			if (usuario == null)
			{
				ViewData["Mensaje"] = "Usuario no encontrado";
				return View();
			}
			else
			{
				HttpContext.Session.SetString("usuario", usuario.Usuario);
				return RedirectToAction("Home", "Home");
			}
		}
	}
}
