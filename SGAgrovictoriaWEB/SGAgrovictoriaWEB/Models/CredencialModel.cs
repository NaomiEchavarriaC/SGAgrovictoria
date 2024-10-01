using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SGAgrovictoriaWEB.Entities;
using SGAgrovictoriaWEB.Interfaces;
using System.Data;

namespace SGAgrovictoriaWEB.Models
{
    public class CredencialModel(IConfiguration iConfiguration) : ICredencialModel
    {
        public Respuesta ConsultarCredenciales()
        {
            Respuesta respuesta = new Respuesta();

            using (var db = new SqlConnection(iConfiguration.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var resultado = db.Query<Credencial>("SP_Consultar_Credenciales", new { }, commandType: CommandType.StoredProcedure);

                if (resultado.Count() > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "La información de los usuarios se ha encontrado exitosamente";
                    respuesta.Contenido = resultado;
                    return respuesta;
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "Ha ocurrido un error al cargar los usuarios";
                    respuesta.Contenido = false;
                    return respuesta;
                }
            }
        }

        public Respuesta ActualizarEstadoCredencial(int idCredencial)
        {
            Respuesta respuesta = new Respuesta();

            using (var db = new SqlConnection(iConfiguration.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var resultado = db.Execute("SP_Actualizar_EstadoCredencial",
                                            new { idCredencial },
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
                    respuesta.Mensaje = "El estado del credencial no se pudo actualizar";
                    respuesta.Contenido = false;
                    return respuesta;
                }
            }
        }
    }
}
