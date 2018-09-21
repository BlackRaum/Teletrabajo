using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EvaluacionAspectoSeguridad
    {
        public String cumple { get; set; }
        public String mejora { get; set; }
        public String observacion { get; set; }
        public AspectoSeguridadLaboral aspectoSeguridad { get; set; }

        public EvaluacionAspectoSeguridad()
        {
            aspectoSeguridad = new AspectoSeguridadLaboral();
        }
    }
}
