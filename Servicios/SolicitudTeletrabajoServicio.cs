using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class SolicitudTeletrabajoServicio
    {
        #region Variables globales
        private SolicitudTeletrabajoDatos solicitudTeletrabajoDatos = new SolicitudTeletrabajoDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 07/10/2018
        /// Efecto: devuelve una solicitud de teletrabajo asociada a un funcionario
        /// Requiere: id Solicitante (id Funcionario)
        /// Modifica: -
        /// Devuelve: Solicitud de Teletrabajo 
        /// </summary>
        /// <returns> SolicitudTeletrabajo </returns>
        public SolicitudTeletrabajo getSolicitudTeletrabajo(int idSolicitante)
        {
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 07/10/2018
        /// Efecto: ingresa la información de un instrumento a la bd
        /// Requiere: SolicitudTeletrabajo, id Solicitud
        /// Modifica: -
        /// Devuelve: Id SolicitudTeletrabajo
        /// </summary>
        /// <returns> int </returns>
        public int insertarSolicitudTeletrabajo(SolicitudTeletrabajo solicitud, int idSolicitante)
        {
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 07/10/2018
        /// Efecto: actualiza un equipoConexion asociado a una solicitud de teletrabajo
        /// Requiere: SolicitudTeletrabajo,  usuario
        /// Modifica: SolicitudTeletrabajo
        /// Devuelve: -
        /// </summary>
        /// <returns> - </returns>
        public void aprobacionSolicitudTeletrabajoJefe(SolicitudTeletrabajo solicitudTeletrabajo)
        {
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 07/10/2018
        /// Efecto: actualiza un equipoConexion asociado a una solicitud de teletrabajo
        /// Requiere: SolicitudTeletrabajo,  usuario
        /// Modifica: SolicitudTeletrabajo
        /// Devuelve: -
        /// </summary>
        /// <returns> - </returns>
        public void aprobacionSolicitudTeletrabajoRRHH(SolicitudTeletrabajo solicitudTeletrabajo)
        {
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 07/10/2018
        /// Efecto: elimina un instrumento asociado a una solicitud de teletrabajo
        /// Requiere: SolicitudTeletrabajo,  usuario
        /// Modifica: SolicitudTeletrabajo
        /// Devuelve: -
        /// </summary>
        /// <returns> - </returns>
        public void eliminarSolicitudTeletrabajo(SolicitudTeletrabajo solicitudTeletrabajo, String usuario)
        {
        }

    }
}
