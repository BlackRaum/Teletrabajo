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
        UnidadTrabajoDatos unidadTrabajoDatos = new UnidadTrabajoDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: obtiene una unidad de trabajo por id
        /// Requiere: Id unidad de trabajo 
        /// Modifica:-
        /// Devuelve: Unidad de trabajo
        /// </summary>
        /// <returns>UnidadTrabajo</returns>
        public UnidadTrabajo getUnidadTrabajo(int idUnidad)
        {
            return unidadTrabajoDatos.getUnidadTrabajo(idUnidad);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: obtiene todas las unidades de la base datos.
        /// Requiere: PersonaEmergencia, Funcionario     
        /// Modifica:-
        /// Devuelve: Lista de UnidadTrabajo
        /// </summary>
        /// <returns>List<UnidadTrabajo></returns>
        public List<UnidadTrabajo> getUnidadesTrabajo()
        {
            return unidadTrabajoDatos.getUnidadesTrabajo();
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
            return unidadTrabajoDatos.insertarUnidadTrabajo(unidad);
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
            return unidadTrabajoDatos.actualizarUnidadTrabajo(unidad);
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
            unidadTrabajoDatos.eliminarUnidadTrabajo(unidad, funcionario);
        }
    }
}
