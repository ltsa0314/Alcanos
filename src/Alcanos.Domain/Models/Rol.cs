using System.Collections.Generic;

namespace Alcanos.Domain.Models
{
    public class Rol
    {
        public int RolId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<RolOpcion> RolOpcion { get; set; }
        public virtual ICollection<UsuarioRol> UsuarioRol { get; set; }
    }
}
