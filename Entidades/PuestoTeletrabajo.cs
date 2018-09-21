using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PuestoTeletrabajo
    {

        public List<EvaluacionAspectoSeguridad> aspectoSeguridadLaboral { get; set; }

        public PuestoTeletrabajo()
        {
            aspectoSeguridadLaboral = new List<EvaluacionAspectoSeguridad>();
        }
    }
}
