namespace Alcanos.Domain.Models
{
    public class RolOpcion
    {
        public int RolId { get; set; }
        public int OpcionId { get; set; }

        public virtual Opcion Opcion { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
