using Microsoft.AspNetCore.Mvc;

namespace SGAgrovictoriaWEB.Controllers
{
    public class ReporteController : Controller
    {
        public IActionResult ConsultarReportes()
        {
            return View();
        }
    }
}
