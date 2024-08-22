using Microsoft.AspNetCore.Mvc;

namespace SGAgrovictoriaWEB.Controllers
{
    public class InicioController : Controller
    {
        [HttpGet]
        public IActionResult InicioSesion()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PantallaPrincipal()
        {
            return View();
        }
        public IActionResult FacturacionCarrito()
        {
            return View();
        }
        public IActionResult FacturacionLista()
        {
            return View();
        }
        public IActionResult Reportes()
        {
            return View();
        }
        public IActionResult Contabilidad()
        {
            return View();
        }
    }
}
