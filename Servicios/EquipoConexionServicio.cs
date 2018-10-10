using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class EquipoConexionServicio
    {

        #region
        EquipoConexionDatos equipoConexionDatos = new EquipoConexionDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 05/10/2018
        /// Efecto: devuelve una lista de EquipoConexion según solictud de teletrabajo
        /// Requiere: id Solicitud
        /// Modifica: -
        /// Devuelve: Lista de EquipoConexion 
        /// </summary>
        /// <returns> List<EquipoConexion> </returns>
        public List<EquipoConexion> getEquipoConexion(int idSolicitud)
        {
            return equipoConexionDatos.getEquipoConexion(idSolicitud);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 05/10/2018
        /// Efecto: ingresa la información de un entregable a la bd
        /// Requiere: Entregable, id Meta
        /// Modifica: -
        /// Devuelve: Id Entregable
        /// </summary>
        /// <returns> int </returns>
        public int insertarEquipoConexion(EquipoConexion equipoConexion, int idSolicitud)
        {
            return equipoConexionDatos.insertarEquipoConexion(equipoConexion,idSolicitud);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: actualiza un equipoConexion asociado a una solicitud de teletrabajo
        /// Requiere: EquipoConexion,  idSolicitud,  usuario
        /// Modifica: EquipoConexion
        /// Devuelve: idEquipo
        /// </summary>
        /// <returns> int </returns>
        public int actualizarEquipoConexion(EquipoConexion equipoConexion, int idSolicitud, String usuario)
        {
            return equipoConexionDatos.actualizarEquipoConexion(equipoConexion, idSolicitud,usuario);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 05/10/2018
        /// Efecto: elimina un equipoConexion asociado a una solicitud de teletrabajo
        /// Requiere: EquipoConexion,  usuario
        /// Modifica: EquipoConexion
        /// Devuelve: -
        /// </summary>
        /// <returns> - </returns>
        public void eliminarEquipoConexion(EquipoConexion equipoConexion, String usuario)
        {
             equipoConexionDatos.eliminarEquipoConexion(equipoConexion, usuario);
        }
    }
}
