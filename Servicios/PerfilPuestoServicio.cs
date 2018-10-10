using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class PerfilPuestoServicio
    {
        #region
        PerfilPuestoDatos perfilPuestoDatos = new PerfilPuestoDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 24/09/2018
        /// Efecto: devuelve el perfil del puesto del Funcionario
        /// Requiere: idFuncionario
        /// Modifica: -
        /// Devuelve: perfil de puesto 
        /// </summary>
        /// <returns> PerfilPuesto </returns>
        public PerfilPuesto getPerfilPuesto(int idFuncionario)
        {
            return perfilPuestoDatos.getPerfilPuesto(idFuncionario);
        }
        /// <summary>
        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: inserta un perfil del puesto de un funcionario
        /// Requiere: PerfilPuesto  y el id del funcionario
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <returns>-</returns>
        public void insertarPerfilPuesto(PerfilPuesto perfilPuesto, int idFuncionario)
        {
            perfilPuestoDatos.insertarPerfilPuesto(perfilPuesto, idFuncionario);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: actualiza de un perfil del puesto de un funcionario
        /// Requiere: PerfilPuesto
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <returns>-</returns>
        public void actualizarPerfilPuesto(PerfilPuesto perfilPuesto, int idFuncionario)
        {
            perfilPuestoDatos.actualizarPerfilPuesto(perfilPuesto, idFuncionario);
        }
    }
}
