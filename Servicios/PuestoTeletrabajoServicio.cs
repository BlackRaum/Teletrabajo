using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class PuestoTeletrabajoServicio
    {

        #region variables 
        PuestoTeletrabajoDatos puestoTeletrabajoDatos = new PuestoTeletrabajoDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 24/09/2018
        /// Efecto: devuelve un Puesto Teletrabajo de un funcionario
        /// Requiere: idFuncionario
        /// Modifica: -
        /// Devuelve: un puesto de Teletrabajo
        /// </summary>
        /// <returns> PuestoTeletrabajo </returns>
        public PuestoTeletrabajo getPuestoTeletrabajo(int idFuncionario)
        {
            return puestoTeletrabajoDatos.getPuestoTeletrabajo(idFuncionario);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: inserta una evaluacion de un aspecto de seguridad laboral en la bd
        /// Requiere: EvaluacionAspectoSeguridad  y el id del funcionario
        /// Modifica:-
        /// Devuelve: -
        /// </summary>
        /// <returns>-</returns>
        public void insertarEvaluacionAspectoSeguridad(EvaluacionAspectoSeguridad aspectoEvaluacion, int idFuncionario)
        {
            puestoTeletrabajoDatos.insertarEvaluacionAspectoSeguridad(aspectoEvaluacion, idFuncionario);
        }

            /// <summary>
            /// Fabián Quirós Masís
            /// 26/09/2018
            /// Efecto: actualiza la información de un aspecto de seguridad laboral 
            /// Requiere: EvaluacionAspectoSeguridad
            /// Modifica:-
            /// Devuelve: int idAspecto
            /// </summary>
            /// <returns>int</returns>
            public void actualizarEvaluacionAspectoSeguridad(EvaluacionAspectoSeguridad aspectoEvaluacion, int idFuncionario)
        {
            puestoTeletrabajoDatos.insertarEvaluacionAspectoSeguridad(aspectoEvaluacion, idFuncionario);
        }

     }
}
