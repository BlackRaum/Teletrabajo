using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class PlanTrabajoServicio
    {

        #region
        PlanTrabajoDatos planTrabajoDatos = new PlanTrabajoDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: devuelve el plan de trabajo asociado a un funcionario
        /// Requiere: idFuncionario
        /// Modifica: -
        /// Devuelve: Plan de Trabajo
        /// </summary>
        /// <returns> PlanTrabajo </returns>
        public PlanTrabajo getPlanTrabajo(int idFuncionario)
        {
            return planTrabajoDatos.getPlanTrabajo(idFuncionario);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: devuelve el plan de trabajo asociado a un funcionario
        /// Requiere: idFuncionario
        /// Modifica: -
        /// Devuelve: Plan de Trabajo
        /// </summary>
        /// <returns> PlanTrabajo </returns>
        public int insertarPlanTrabajo(PlanTrabajo planTrabajo, int idFuncionario)
        {
            return planTrabajoDatos.insertarPlanTrabajo(planTrabajo, idFuncionario);
        }
        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: devuelve el plan de trabajo asociado a un funcionario
        /// Requiere: idFuncionario
        /// Modifica: -
        /// Devuelve: Plan de Trabajo
        /// </summary>
        /// <returns> PlanTrabajo </returns>
        public int actualizarPlanTrabajo(PlanTrabajo planTrabajo, int idFuncionario)
        {
            return actualizarPlanTrabajo(planTrabajo, idFuncionario);
        }
        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: devuelve el plan de trabajo asociado a un funcionario
        /// Requiere: idFuncionario
        /// Modifica: -
        /// Devuelve: Plan de Trabajo
        /// </summary>
        /// <returns> PlanTrabajo </returns>
        public void eliminarPlanTrabajo(PlanTrabajo planTrabajo, Funcionario funcionario)
        {
            planTrabajoDatos.eliminarPlanTrabajo(planTrabajo, funcionario);
        }
    }
}
