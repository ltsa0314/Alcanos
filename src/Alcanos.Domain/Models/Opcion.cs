using System.Collections.Generic;

namespace Alcanos.Domain.Models
{
    public class Opcion
    {
        public int OpcionId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<RolOpcion> RolOpcion { get; set; }
    }
}
