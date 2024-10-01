using Microsoft.AspNetCore.Mvc;
using SGAgrovictoriaWEB.Entities;
using SGAgrovictoriaWEB.Interfaces;
using System.Text.Json;

namespace SGAgrovictoriaWEB.Controllers
{
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
    }
}
