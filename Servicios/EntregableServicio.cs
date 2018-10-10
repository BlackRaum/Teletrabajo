using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class EntregableServicio
    {
        #region
        EntregableDatos entregableDatos = new EntregableDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: devuelve una lista de entregables según meta
        /// Requiere: id Meta
        /// Modifica: -
        /// Devuelve: Lista de Entregables 
        /// </summary>
        /// <returns> List<Entregable> </returns>
        public List<Entregable> getEntregableMeta(int idMeta)
        {
            return entregableDatos.getEntregableMeta(idMeta);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: ingresa la información de un entregable a la bd
        /// Requiere: Entregable, id Meta
        /// Modifica: -
        /// Devuelve: Id Entregable
        /// </summary>
        /// <returns> int </returns>
        public int insertarEntregable(Entregable entregable, int idMeta)
        {
            return entregableDatos.insertarEntregable(entregable,idMeta);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: actualiza una meta asociado a un objetivo
        /// Requiere: Meta, id Objetivo 
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <returns> int </returns>
        public int actualizarMeta(Entregable entregable, int idMeta, String usuario)
        {
            return entregableDatos.actualizarMeta(entregable,idMeta,usuario);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: elimina una meta asociado a un Objetivo
        /// Requiere: Objetivo, Funcionario
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <returns> - </returns>
        public void eliminarEntregable(Entregable entregable, String usuario)
        {
            entregableDatos.eliminarEntregable(entregable,usuario);
        }
    }
}
