using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class MetaServicio
    {
        #region
        MetaDatos metaDatos = new MetaDatos();
        #endregion
        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: devuelve una lista de metas pertenecientes a un objetivo
        /// Requiere: idObjetivo
        /// Modifica: -
        /// Devuelve: Lista de Objetivos 
        /// </summary>
        /// <returns> List<Objetivo> </returns>
        public List<Meta> getMetasObjetivo(int idObjetivo)
        {
            return metaDatos.getMetasObjetivo(idObjetivo);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: ingresa la información de una meta a la bd
        /// Requiere: Meta, id Objetivo
        /// Modifica: -
        /// Devuelve: Id Meta
        /// </summary>
        /// <returns> int </returns>
        public int insertarObjetivo(Meta meta, int idObjetivo)
        {
            return metaDatos.insertarObjetivo(meta,idObjetivo);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: actualiza una meta asociado a un objetivo
        /// Requiere: Meta, id Objetivo 
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <returns> - </returns>
        public void actualizarMeta(Meta meta, int idObjetivo)
        {
            metaDatos.actualizarMeta(meta,idObjetivo);
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
        public void eliminarMeta(Meta meta, Funcionario funcionario)
        {
            metaDatos.eliminarMeta(meta,funcionario);
        }
    }
}
