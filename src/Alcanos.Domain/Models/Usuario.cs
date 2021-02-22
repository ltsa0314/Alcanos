using System;
using System.Collections.Generic;

namespace Alcanos.Domain.Models
{
    public class Usuario
    {

        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public string Correo { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual ICollection<UsuarioRol> UsuarioRol { get; set; }
    }
}
