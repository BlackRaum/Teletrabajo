using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PersonaEmergencia
    {
        public int idPersona { get; set; }
        public String nombreCompleto { get; set; }
        public String telefonoFijo { get; set; }
        public String celular { get; set; }
        public String parentesco { get; set; }
        public String direccion { get; set; }

        public PersonaEmergencia()
        {

        }
    }
}
