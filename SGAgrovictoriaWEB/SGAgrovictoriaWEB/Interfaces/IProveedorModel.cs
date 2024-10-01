using SGAgrovictoriaWEB.Entities;

namespace SGAgrovictoriaWEB.Interfaces
{
    public interface IProveedorModel
    {
        Respuesta ConsultarProveedores();
        Respuesta ActualizarEstadoProveedor(int idProveedor);
    }
}
