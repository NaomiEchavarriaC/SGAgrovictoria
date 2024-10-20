using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SGAgrovictoriaWEB.Entities;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace SGAgrovictoriaWEB.Models
{


    //Crud con logica dentro de .net


    //Creacion del modelo
    public class ProveedorModel
    {

        [Key]
        public long IdProveedor { get; set; }
        public string NombreProveedor { get; set; }

        public string DescripcionProveedor { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public bool Estado { get; set; }

        public string RutaImagen { get; set; }
        public long IdDistrito { get; set; }
    }

}
