using Microsoft.AspNetCore.Mvc;

namespace SGAgrovictoriaWEB.Controllers
{
	public class Ejemplo : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
