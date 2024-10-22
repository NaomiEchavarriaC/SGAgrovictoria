using System.ComponentModel.DataAnnotations;

namespace SGAgrovictoriaWEB.Models
{
    public class AlertaModel
    {
        [Key]

        public int IdAlerta { get; set; }

        public string Descripcion { get; set; }
        public long IdProducto { get; set; }

        public string Categoria { get; set; }

        public bool Estado { get; set; }

        public string NombreProducto { get; set; }

        //public int Stock { get; set; }
        
    }
}
