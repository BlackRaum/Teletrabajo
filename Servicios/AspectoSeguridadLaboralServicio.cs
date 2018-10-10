using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class AspectoSeguridadLaboralServicio
    {
        #region variables
        AspectoSeguridadLaboralDatos aspectoSeguridadData = new AspectoSeguridadLaboralDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 24/09/2018
        /// Efecto: devuelve una lista de Aspectos de Seguridad Laboral 
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de Aspectos de Seguridad Laboral
        /// </summary>
        /// <returns> List<AspectoSeguridadLaboral> </returns>
        public AspectoSeguridadLaboral getAspectoSeguridadLaboral(int idAspecto)
        {
            return aspectoSeguridadData.getAspectoSeguridadLaboral(idAspecto);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 24/09/2018
        /// Efecto: devuelve una lista de Aspectos de Seguridad Laboral 
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de Aspectos de Seguridad Laboral
        /// </summary>
        /// <returns> List<AspectoSeguridadLaboral> </returns>
        public List<AspectoSeguridadLaboral> getAspectosSeguridadLaboral()
        {
            return aspectoSeguridadData.getAspectosSeguridadLaboral();
        }
        /// <summary>
        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: inserta un aspecto de seguridad laboral en la bd
        /// Requiere: AspectoSeguridadLaboral     
        /// Modifica:-
        /// Devuelve:int idAspecto
        /// </summary>
        /// <returns>int</returns>
        public int insertarAspectoSeguridadLaboral(AspectoSeguridadLaboral aspecto)
        {
            return aspectoSeguridadData.insertarAspectoSeguridadLaboral(aspecto);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: actualiza la información de un aspecto de seguridad laboral 
        /// Requiere: AspectoSeguridadLaboral
        /// Modifica:-
        /// Devuelve: int idAspecto
        /// </summary>
        /// <returns>int</returns>
        public int actualizarAspectoSeguridadLaboral(AspectoSeguridadLaboral aspecto, String usuario)
        {
            return aspectoSeguridadData.actualizarAspectoSeguridadLaboral(aspecto,usuario);
        }

        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: elimina la información de un aspecto de seguridad laboral
        /// Requiere: AspectoSeguridadLaboral, Funcionario     
        /// Modifica:-
        /// Devuelve:int idContactoEmergencia
        /// </summary>
        /// <returns>-</returns>
        public void eliminarAspectoSeguridadLaboral(AspectoSeguridadLaboral aspecto, String usuario)
        {
            aspectoSeguridadData.eliminarAspectoSeguridadLaboral(aspecto, usuario);
        }
    }
}
