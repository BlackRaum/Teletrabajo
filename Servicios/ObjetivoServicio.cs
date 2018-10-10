using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ObjetivoServicio
    {

        #region
        ObjetivoDatos objetivoDatos = new ObjetivoDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: devuelve una lista de objetivos pertenecientes a un plan de trabajo de un funcionario
        /// Requiere: idPlan
        /// Modifica: -
        /// Devuelve: Lista de Objetivos 
        /// </summary>
        /// <returns> List<Objetivo> </returns>
        public List<Objetivo> getObtivosPlanTrabajo(int idPlan)
        {
            return objetivoDatos.getObtivosPlanTrabajo(idPlan);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: ingresa la información de objetivo a la bd
        /// Requiere: Objetivo, id Plan de trabajo
        /// Modifica: -
        /// Devuelve: Id Objetivo
        /// </summary>
        /// <returns> int </returns>
        public int insertarObjetivo(Objetivo objetivo, int idPlan)
        {
            return objetivoDatos.insertarObjetivo(objetivo, idPlan);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: actualiza un objetivo asociado a un plan de trabajo
        /// Requiere: Objetivo, Id Plan
        /// Modifica: -
        /// Devuelve: id del Objetivo
        /// </summary>
        /// <returns> int </returns>
        public void actualizarObjetivo(Objetivo objetivo)
        {
             objetivoDatos.actualizarObjetivo(objetivo);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: elimina un objetivo asociado a un plan de trabajo
        /// Requiere: Objetivo, Id Plan, Funcionario
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <returns> - </returns>
        public void eliminarObjetivo(Objetivo objetivo, Funcionario funcionario)
        {
            objetivoDatos.eliminarObjetivo(objetivo, funcionario);
        }
    }
}
