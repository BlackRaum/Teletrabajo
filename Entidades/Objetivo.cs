using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Objetivo
    {
        public int idObjetivo { get; set; }
        public String descripcion { get; set; }
        public List<Meta> metas { get; set; }

        public Objetivo()
        {
            metas = new List<Meta>();
        }
    }
}