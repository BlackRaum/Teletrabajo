using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SolicitudTeletrabajo
    {
        public int idSolicitud { get; set; }
        public String justificacion { get; set; }
        public Boolean personalACargo { get; set; }
        public int cantidadPersonal { get; set; }
        public Boolean supervisionRemotaPersonal { get; set; }
        public Boolean hijos { get; set; }
        public int cantidadHijos { get; set; }
        public String edadesHijos { get; set; }
        public Boolean acuerdoInstrumentalizacion { get; set; }
        public Boolean acuerdoInspecciones { get; set; }
        public Boolean acuerdoEspacioFisico { get; set; }
        public Boolean acuerdoMetas { get; set; }
        public Boolean acuerdoContrato { get; set; }
        public String comentarios { get; set; }
        public String descripcionEspacio { get; set; }
        public Boolean aprobacionJefe { get; set; }
        public Boolean aprobacionRRHH { get; set; }

        public Horario horario { get; set; }
        public TipoDesplazamiento tipoDesplazamiento { get; set; }
        public TipoTeletrabajador tipoTeletrabajador { get; set; }
        public List<FuncionFuncionario> funciones { get; set; }
        public List<EquipoConexion> equipoConexiones { get; set; }
        public List<Instrumentalizacion> instrumentos { get; set; }


}
}
