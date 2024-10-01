namespace SGAgrovictoriaWEB.Entities
{
    public class Credencial
    {
        public long? IdEmpleado { get; set; }
        public int? Identificacion { get; set; }
        public string? NombreEmpleado { get; set; }
        public string? ApellidoEmpleado { get; set; }
        public long? IdTipoCredencial { get; set; }
        public string? NombreTipoCredencial { get; set; }
        public long? IdCredencial { get; set; }
        public string? Estado { get; set; }
        public string? Usuario { get; set; }
        public string? Clave { get; set; }
    }
}
