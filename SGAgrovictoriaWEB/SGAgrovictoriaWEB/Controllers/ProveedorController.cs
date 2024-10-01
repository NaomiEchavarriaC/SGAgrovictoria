using Microsoft.AspNetCore.Mvc;
using SGAgrovictoriaWEB.Interfaces;

namespace SGAgrovictoriaWEB.Controllers
{
    public class ProveedorController(IProveedorModel iProveedorModel) : Controller
    {
        public IActionResult ConsultarProveedores()
        {
            var respuesta = iProveedorModel.ConsultarProveedores();

            if (respuesta.Codigo == 1)
            {
                return View(respuesta.Contenido);
            }

            ViewBag.Alerta = respuesta.Mensaje;
            return View(respuesta.Contenido);
        }
    }
}
