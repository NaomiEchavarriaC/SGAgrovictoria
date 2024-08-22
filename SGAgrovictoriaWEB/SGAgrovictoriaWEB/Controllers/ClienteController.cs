using Microsoft.AspNetCore.Mvc;

namespace SGAgrovictoriaWEB.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult ConsultarClientes()
        {
            return View();
        }

		public IActionResult AgregarCliente()
		{
			return View();
		}

		public IActionResult ActualizarCliente()
		{
			return View();
		}
	}
}
