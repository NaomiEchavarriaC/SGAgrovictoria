using Dapper;
using Microsoft.Data.SqlClient;
using SGAgrovictoriaWEB.Entities;

namespace SGAgrovictoriaWEB.Models
{
    public class UbicacionModel(IConfiguration iConfiguration)
    {
        public Respuesta ObtenerUbicaciones()
        {
            Respuesta respuesta = new Respuesta();

            using (var db = new SqlConnection(iConfiguration.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var resultado = db.Query<Ubicacion>("SP_GET_UBICACIONES", new { }, commandType: System.Data.CommandType.StoredProcedure);

                if (resultado.Count() > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "La información de las ubicaciones se ha encontrado exitosamente";
                    respuesta.Contenido = resultado;
                    return respuesta;
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "Ha ocurrido un error al cargar las ubicaciones";
                    respuesta.Contenido = false;
                    return respuesta;
                }
            }
        }
    }
}
