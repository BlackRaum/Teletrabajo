using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Entregable
    {
        public int idEntregable { get; set; }
        public String descripcion { get; set; }
        public String tipoEntrega { get; set; }
        public String tipoEntregable { get; set; }
        public DateTime fechaEntrega { get; set; }
        public String nombreArchivo { get; set; }
        public String rutaArchivo { get; set; }
        public Boolean completado { get; set; }

    }
}
