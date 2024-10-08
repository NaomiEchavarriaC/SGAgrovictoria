using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGAgrovictoriaWEB.Data;
using SGAgrovictoriaWEB.Models;

namespace SGAgrovictoriaWEB.Controllers
{

    public class ProveedorController : Controller
    {
        //Logica del crud dentro de .net


        private readonly AppDbContext _context;
        private readonly ILogger<ProveedorController> _logger;

        public ProveedorController(ILogger<ProveedorController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        //get: Products
        public async Task<IActionResult> ConsultarProveedores()
        {
            return View(await _context.Proveedores.ToListAsync());
        }

        // Detalles del proveedor por su ID 
        public async Task<IActionResult> ConsultarProveedor(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var proveedor = await _context.Proveedores.FirstOrDefaultAsync(m => m.IdProveedor == id);

            if (proveedor == null)
            {
                return NotFound();
            }
            return View(proveedor);
        }


        //get: Proveedor/create
        public IActionResult AgregarProveedor()
        {
            return View();
        }

        //POST : Proveedor/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarProveedor(ProveedorModel proveedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proveedor);
                await _context.SaveChangesAsync();
                return RedirectToAction("ConsultarProveedores");

            }
            return View(proveedor);
        }



        //Editar proveedor por su ID
        public async Task<IActionResult> EditarProveedor(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var proveedor = await _context.Proveedores.FindAsync(id);

            if (proveedor == null)
            {
                return NotFound();
            }
            return View(proveedor);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> EditarProveedor(ProveedorModel proveedor)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proveedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProveedorExists(proveedor.IdProveedor))
                    {
                        return NotFound();

                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ConsultarProveedores));
            }
            return View(proveedor);

        }



        //get proveedor/delete
        public async Task<IActionResult> EliminarProveedor(long id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedores.FirstOrDefaultAsync(x => x.IdProveedor == id);

            if (proveedor == null)
            {
                return NotFound();
            }
            return View(proveedor);
        }


        public async Task<IActionResult> ConfirmarBorrado(long IdProveedor)
        {
            var proveedor = await _context.Proveedores.FindAsync(IdProveedor);
            _context.Proveedores.Remove(proveedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ConsultarProveedores));
        }


        //Verificar si el proveedor existe
        private bool ProveedorExists(long id)
        {
            return _context.Proveedores.Any(e => e.IdProveedor == id);


        }




    }

    /*
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

    */







}
