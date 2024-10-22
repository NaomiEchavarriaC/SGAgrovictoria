using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGAgrovictoriaWEB.Data;
using SGAgrovictoriaWEB.Models;
namespace SGAgrovictoriaWEB.Controllers
{
    public class AlertaController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<AlertaController> _logger;

        public AlertaController(ILogger<AlertaController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public async Task<IActionResult> AlertaStockBajo()
        {
            // Obtener todos los productos de la base de datos
            var ListaProductos = await _context.Productos.ToListAsync();

            // Definir el umbral de stock bajo
            int umbralStockBajo = 10;

            // Filtrar los productos que tengan un stock bajo
            var productosConStockBajo = ListaProductos.Where(p => p.Stock <= umbralStockBajo).ToList();

            // Pasar ambos, la lista completa de productos y los productos con stock bajo a la vista
            ViewBag.ProductosConStockBajo = productosConStockBajo;

            return View(ListaProductos);
        }








        public IActionResult Index()
        {
            return View();
        }
    }
}
