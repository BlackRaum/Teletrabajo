using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class HorarioServicio
    {

        #region Variables globales
        HorarioDatos horarioDatos = new HorarioDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 07/10/2018
        /// Efecto: devuelve una lista de Horario según solictud de teletrabajo
        /// Requiere: id Solicitud
        /// Modifica: -
        /// Devuelve: Lista de Horario 
        /// </summary>
        /// <returns> List<Horario> </returns>
        public List<Horario> getHorarios(int idSolicitud)
        {
            return horarioDatos.getHorarios(idSolicitud);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 07/10/2018
        /// Efecto: ingresa la información de un horario a la bd
        /// Requiere: Entregable, id Meta
        /// Modifica: -
        /// Devuelve: Id Entregable
        /// </summary>
        /// <returns> int </returns>
        public int insertarHorario(Horario horario)
        {
            return horarioDatos.insertarHorario(horario);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: actualiza un horario asociado a una solicitud de teletrabajo
        /// Requiere: Horario,  idSolicitud,  usuario
        /// Modifica: Horario
        /// Devuelve: idEquipo
        /// </summary>
        /// <returns> int </returns>
        public int actualizarHorario(Horario horario, String usuario)
        {
            return horarioDatos.actualizarHorario(horario,usuario);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 07/10/2018
        /// Efecto: elimina un horario asociado a una solicitud de teletrabajo
        /// Requiere: Horario,  usuario
        /// Modifica: Horario
        /// Devuelve: -
        /// </summary>
        /// <returns> - </returns>
        public void eliminarHorario(Horario horario, String usuario)
        {
            horarioDatos.eliminarHorario(horario,usuario);
        }
     }
}
