using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Meta
    {
        public int idMeta { get; set; }
        public String nombre { get; set; }
        public String duracion { get; set; }
        public String descripcion { get; set; }
        public List<Entregable> entregables { get; set; }

        public Meta()
        {
            entregables = new List<Entregable>();
        }
    }
}
