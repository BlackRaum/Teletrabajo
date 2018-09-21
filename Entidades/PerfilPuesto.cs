using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PerfilPuesto
    {
        public Boolean teletrabajable { get; set; }
        public Boolean controlesInternos { get; set; }
        public Boolean  supervision { get; set; }
        public Boolean factibilidadTeletrabajo { get; set; }
        public int porcentaje { get; set; }
        public Boolean teletrabajableJefe { get; set; }
        public Boolean controlesInternosJefe { get; set; }
        public Boolean supervisionJefe { get; set; }
        public Boolean factibilidadTeletrabajoJefe { get; set; }
        public int porcentajeJefe { get; set; }
        public int teletrabajableResultado { get; set; }
        public int controlesInternosResultado { get; set; }
        public int supervisionResultado { get; set; }
        public int factibilidadTeletrabajoResultado { get; set; }
        public int porcentajeResultado { get; set; }
        public Boolean aprobacionRRHH { get; set; }

        public PerfilPuesto()
        {

        }
    }
}
