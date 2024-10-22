using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGAgrovictoriaWEB.Data;
using SGAgrovictoriaWEB.Models;

namespace SGAgrovictoriaWEB.Controllers
{
    public class InventarioController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<InventarioController> _logger;

        public InventarioController(ILogger<InventarioController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> ConsultarProductos()
        {
            return View(await _context.Productos.ToListAsync());
        }

        // Detalles del proveedor por su ID 
        public async Task<IActionResult> ConsultarProducto(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var producto = await _context.Productos.FirstOrDefaultAsync(m => m.IdProducto == id);

            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        public IActionResult AgregarProducto()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarProducto(InventarioModel producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction("ConsultarProductos");

            }
            return View(producto);
        }

        //Editar proveedor por su ID
        public async Task<IActionResult> EditarProducto(long id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> EditarProducto(InventarioModel producto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.IdProducto))
                    {
                        return NotFound();

                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ConsultarProductos));
            }
            return View(producto);

        }


        
        

        





        //Verificar si el proveedor existe
        private bool ProductoExists(long id)
        {
            return _context.Productos.Any(e => e.IdProducto == id);


        }

    }
}
