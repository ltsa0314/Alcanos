using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alcanos.Api.Dtos
{
    public class UsuarioDto
    {

        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public string Correo { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
