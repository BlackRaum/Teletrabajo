using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class InstrumentalizacionServicio
    {

        #region Variables globales
        private InstrumentalizacionDatos instrumentalizacionDatos = new InstrumentalizacionDatos();

        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 07/10/2018
        /// Efecto: devuelve una lista de instrumentos según solictud de teletrabajo
        /// Requiere: id Solicitud
        /// Modifica: -
        /// Devuelve: Lista de Instrumentalizacion 
        /// </summary>
        /// <returns> List<Instrumentalizacion> </returns>
        public List<Instrumentalizacion> getInstrumentalizacion(int idSolicitud)
        {
            return instrumentalizacionDatos.getInstrumentalizacion(idSolicitud);
        }


        /// <summary>
        /// Fabián Quirós Masís
        /// 07/10/2018
        /// Efecto: ingresa la información de un instrumento a la bd
        /// Requiere: Instrumentalizacion, id Solicitud
        /// Modifica: -
        /// Devuelve: Id Instrumentalizacion
        /// </summary>
        /// <returns> int </returns>
        public int insertarInstrumentalizacion(Instrumentalizacion instrumento, int idSolicitud)
        {
            return instrumentalizacionDatos.insertarInstrumentalizacion(instrumento, idSolicitud);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 07/10/2018
        /// Efecto: actualiza un equipoConexion asociado a una solicitud de teletrabajo
        /// Requiere: Instrumentalizacion,  idSolicitud,  usuario
        /// Modifica: Instrumentalizacion
        /// Devuelve: idEquipo
        /// </summary>
        /// <returns> int </returns>
        public int actualizarInstrumentalizacion(Instrumentalizacion instrumento, int idSolicitud, String usuario)
        {
            return instrumentalizacionDatos.actualizarInstrumentalizacion(instrumento, idSolicitud, usuario);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 07/10/2018
        /// Efecto: elimina un instrumento asociado a una solicitud de teletrabajo
        /// Requiere: Instrumentalizacion,  usuario
        /// Modifica: Instrumentalizacion
        /// Devuelve: -
        /// </summary>
        /// <returns> - </returns>
        public void eliminarInstrumentalizacion(Instrumentalizacion instrumento, String usuario)
        {
            instrumentalizacionDatos.eliminarInstrumentalizacion(instrumento,usuario);
        }
    }
}
