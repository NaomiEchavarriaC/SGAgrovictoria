using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGAgrovictoriaWEB.Permisos;

namespace SGAgrovictoriaWEB.Controllers
{
	[ServiceFilter(typeof(ValidarSesionAttribute))]

	public class HomeController : Controller
	{
		[HttpGet]
		public IActionResult Home()
		{
			return View();
		}
	}

}
