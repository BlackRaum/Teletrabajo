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
    }
}
