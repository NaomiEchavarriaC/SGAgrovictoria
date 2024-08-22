using Microsoft.AspNetCore.Mvc;

namespace SGAgrovictoriaWEB.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult ConsultarUsuarios()
        {
            return View();
        }
        public IActionResult AgregarUsuario ()
        {
            return View();
        }

        public IActionResult ActualizarUsuario()
        {
            return View();
        }
    }
}
