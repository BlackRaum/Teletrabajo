using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class UnidadTrabajoServicios
    {
        #region
        UnidadTrabajoDatos unidadtrabajoDatos = new UnidadTrabajoDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: inserta un contacto de emergencia de un funcionario
        /// Requiere: PersonaEmergencia, Funcionario     
        /// Modifica:-
        /// Devuelve:int idContactoEmergencia
        /// </summary>
        /// <returns>int</returns>
        public List<UnidadTrabajo> getUnidadTrabajo()
        {
            return unidadtrabajoDatos.getUnidadTrabajo();
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: inserta una unidad de trabajo
        /// Requiere: UnidadTrabajo
        /// Modifica:-
        /// Devuelve:int idUnidadTrabajo
        /// </summary>
        /// <returns>int</returns>
        public int insertarUnidadTrabajo(UnidadTrabajo unidad)
        {
            return unidadtrabajoDatos.insertarUnidadTrabajo(unidad);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: actualiza la información de una unidad de trabajo
        /// Requiere: UnidadTrabajo, Usuario     
        /// Modifica:-
        /// Devuelve:int idContactoEmergencia
        /// </summary>
        /// <returns>int</returns>
        public int actualizarUnidadTrabajo(UnidadTrabajo unidad)
        {
           return unidadtrabajoDatos.actualizarUnidadTrabajo(unidad);
        }

        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: elimina la información de un contacto de emergencia de un funcionario 
        /// Requiere: PersonaEmergencia, Funcionario     
        /// Modifica:-
        /// Devuelve:int idContactoEmergencia
        /// </summary>
        /// <returns>int</returns>
        public void eliminarUnidadTrabajo(UnidadTrabajo unidad, Funcionario funcionario)
        {
            unidadtrabajoDatos.eliminarUnidadTrabajo(unidad,funcionario);
        }
    }
}
