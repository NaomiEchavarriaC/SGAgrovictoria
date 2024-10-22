using System.ComponentModel.DataAnnotations;

namespace SGAgrovictoriaWEB.Models
{
    public class InventarioModel
    {

        [Key]
        public long IdProducto { get; set; }
        public long IdCategoria { get; set; }

        public bool Estado { get; set; }

        public string NombreProducto {  get; set; }

        public double PrecioUnitario { get; set; }

        public string RutaImagen { get; set; }

        public int Stock { get; set; }
        public DateTime FechaIngreso { get; set; }

        public DateTime UltimoIngreso { get; set; }





    }
}
