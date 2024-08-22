using Microsoft.AspNetCore.Mvc;

namespace SGAgrovictoriaWEB.Controllers
{
    public class FacturacionController : Controller
    {
        public IActionResult ConsultarFacturacion()
        {
            return View();
        }

        public IActionResult FacturacionCarrito()
        {
            return View();
        }
    }
}
