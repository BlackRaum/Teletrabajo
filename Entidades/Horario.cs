using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Horario
    {
        public int idHorario { get; set; }
        public String horaEntrada { get; set; }
        public String horaSalidad { get; set; }
        public String tipoJornada { get; set; }
        public String otrosSenalamientos { get; set; }
        public Boolean lunes { get; set; }
        public Boolean martes { get; set; }
        public Boolean miercoles { get; set; }
        public Boolean jueves { get; set; }
        public Boolean viernes { get; set; }
        public Boolean sabado { get; set; }
        public Boolean domingo { get; set; }

        public Horario()
        {
        }
    }
}
