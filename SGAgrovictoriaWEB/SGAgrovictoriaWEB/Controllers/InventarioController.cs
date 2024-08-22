using Microsoft.AspNetCore.Mvc;

namespace SGAgrovictoriaWEB.Controllers
{
    public class InventarioController : Controller
    {
        public IActionResult ConsultarInventario()
        {
            return View();
        }
    }
}
