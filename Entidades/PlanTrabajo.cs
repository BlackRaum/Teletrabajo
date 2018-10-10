using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PlanTrabajo
    {
        public int idPlan { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public Boolean aprobacionJefe { get; set; }
        public List<Objetivo> metas { get; set; }

        public PlanTrabajo()
        {
            metas = new List<Objetivo>();
        }
    }
}
