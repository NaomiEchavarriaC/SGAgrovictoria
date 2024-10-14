using Microsoft.AspNetCore.Mvc;
using SGAgrovictoriaWEB.Entities;
using SGAgrovictoriaWEB.Interfaces;
using SGAgrovictoriaWEB.Permisos;
using System.Text.Json;

namespace SGAgrovictoriaWEB.Controllers
{
	[ServiceFilter(typeof(ValidarSesionAttribute))]
	public class CredencialController(ICredencialModel iCredencialModel) : Controller
    {
        [HttpGet]
        public IActionResult ConsultarCredenciales()
        {
            var respuesta = iCredencialModel.ConsultarCredenciales();

            if (respuesta.Codigo == 1)
            {
                return View(respuesta.Contenido);
            }

            ViewBag.Alerta = respuesta.Mensaje;
            return View(respuesta.Contenido);
        }

        [HttpGet]
        public IActionResult ActualizarEstadoCredencial(int idCredencial)
        {
            var respuesta = iCredencialModel.ActualizarEstadoCredencial(idCredencial);

            if (respuesta.Codigo == 1)
            {
                return RedirectToAction("ConsultarCredenciales", "Credencial");
            }

            ViewBag.Alerta = respuesta.Mensaje;
            return View();
        }
    }
}
