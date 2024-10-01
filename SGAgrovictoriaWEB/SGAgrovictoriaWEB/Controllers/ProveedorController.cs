using Microsoft.AspNetCore.Mvc;
using SGAgrovictoriaWEB.Interfaces;
using SGAgrovictoriaWEB.Models;

namespace SGAgrovictoriaWEB.Controllers
{
    public class ProveedorController(IProveedorModel iProveedorModel) : Controller
    {
        [HttpGet]
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

        [HttpGet]
        public IActionResult ActualizarEstadoProveedor(int idProveedor)
        {
            var respuesta = iProveedorModel.ActualizarEstadoProveedor(idProveedor);

            if (respuesta.Codigo == 1)
            {
                return RedirectToAction("ConsultarProveedores", "Proveedor");
            }

            ViewBag.Alerta = respuesta.Mensaje;
            return View();
        }
    }

    
}
