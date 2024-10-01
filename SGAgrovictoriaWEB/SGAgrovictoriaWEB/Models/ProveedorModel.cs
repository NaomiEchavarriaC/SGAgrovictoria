using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SGAgrovictoriaWEB.Entities;
using SGAgrovictoriaWEB.Interfaces;
using System.Data;

namespace SGAgrovictoriaWEB.Models
{
    public class ProveedorModel(IConfiguration iConfiguration) : IProveedorModel
    {
        public Respuesta ConsultarProveedores()
        {
            Respuesta respuesta = new Respuesta();

            using (var db = new SqlConnection(iConfiguration.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var resultado = db.Query<Proveedor>("SP_Consultar_Proveedores", new { }, commandType: CommandType.StoredProcedure);

                if (resultado.Count() > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "La información de los proveedores se ha encontrado exitosamente";
                    respuesta.Contenido = resultado;
                    return respuesta;
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "Ha ocurrido un error al cargar los proveedores";
                    respuesta.Contenido = false;
                    return respuesta;
                }
            }
        }

        public Respuesta ActualizarEstadoProveedor(int idProveedor)
        {
            Respuesta respuesta = new Respuesta();

            using (var db = new SqlConnection(iConfiguration.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var resultado = db.Execute("SP_Actualizar_EstadoProveedor",
                                            new { idProveedor },
                                            commandType: System.Data.CommandType.StoredProcedure);

                if (resultado > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "OK";
                    respuesta.Contenido = true;
                    return respuesta;
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "El estado del proveedor no se pudo actualizar";
                    respuesta.Contenido = false;
                    return respuesta;
                }
            }
        }
    }
}
