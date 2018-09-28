using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class PerfilLaboralServicio
    {
        #region
        PerfilLaboralDatos perfilLaboralDatos = new PerfilLaboralDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 28/09/2018
        /// Efecto: devuelve un Perfil Laboral de un funcionario
        /// Requiere: idFuncionario
        /// Modifica: -
        /// Devuelve: un Perfil Laboral
        /// </summary>
        /// <returns> PerfilLaboral </returns>
        public PerfilLaboral getPerfilLaboral(int idFuncionario)
        {
            return perfilLaboralDatos.getPerfilLaboral(idFuncionario);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 28/09/2018
        /// Efecto: inserta el perfil laboral de un funcionario
        /// Requiere: PerfilLaboral, idFuncionario
        /// Modifica:-
        /// Devuelve: -
        /// </summary>
        /// <returns>-</returns>
        public void insertarPerfilLaboral(PerfilLaboral perfilLaboral, int idFuncionario)
        {
            perfilLaboralDatos.insertarPerfilLaboral(perfilLaboral, idFuncionario);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: actualiza de forma logica el perfil laboral de un funcionario
        /// Requiere: PerfilLaboral, idFuncionario
        /// Modifica: PerfilLaboral
        /// Devuelve: -
        /// </summary>
        /// <returns>-</returns>
        public void actualizarPerfilLaboral(PerfilLaboral perfilLaboral, int idFuncionario)
        {
            perfilLaboralDatos.actualizarPerfilLaboral(perfilLaboral, idFuncionario);
        }

        /// 26/09/2018
        /// Efecto: elimina de forma logica el perfil laboral de un funcionario
        /// Requiere: PerfilLaboral, Funcionario
        /// Modifica:-
        /// Devuelve:-
        /// </summary>
        /// <returns>-</returns>
        public void eliminarPerfilLaboral(PerfilLaboral perfilLaboral, Funcionario funcionario)
        {
            perfilLaboralDatos.eliminarPerfilLaboral(perfilLaboral,funcionario);
        }
    }
}
