using SGAgrovictoriaWEB.Entities;

namespace SGAgrovictoriaWEB.Interfaces
{
    public interface ICredencialModel
    {
        Respuesta ConsultarCredenciales();
        Respuesta ActualizarEstadoCredencial(int idCredencial);
    }
}
