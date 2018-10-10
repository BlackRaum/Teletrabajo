using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class FuncionarioServicio
    {
        #region
        FuncionarioDatos funcionarioDatos = new FuncionarioDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 24/09/2018
        /// Efecto: devuelve un funcionario 
        /// Requiere: idFuncionario
        /// Modifica: -
        /// Devuelve: Funcionario
        /// </summary>
        /// <returns> Funcionario </returns>
        public Funcionario getFuncionario(int idFuncionario)
        {
            return funcionarioDatos.getFuncionario(idFuncionario);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 24/09/2018
        /// Efecto: devuelve un funcionario 
        /// Requiere: idFuncionario
        /// Modifica: -
        /// Devuelve: Funcionario
        /// </summary>
        /// <returns> Funcionario </returns>
        public List<Funcionario> getFuncionarios()
        {
            return funcionarioDatos.getFuncionarios();
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 24/09/2018
        /// Efecto: inserta un funcionario en la bd
        /// Requiere: funcionario
        /// Modifica: -
        /// Devuelve: id del funcionario
        /// </summary>
        /// <returns> int </returns>
        public int insertarFuncionario(Funcionario funcionario)
        {
            return funcionarioDatos.insertarFuncionario(funcionario);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 24/09/2018
        /// Efecto: actualiza la información un funcionario en la bd
        /// Requiere: funcionario
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <returns> - </returns>
        public void actualizarFuncionario(Funcionario funcionario)
        {
            funcionarioDatos.actualizarFuncionario(funcionario);
        }

        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: elimina la información de un aspecto de seguridad laboral
        /// Requiere: AspectoSeguridadLaboral, Funcionario     
        /// Modifica:-
        /// Devuelve:int idContactoEmergencia
        /// </summary>
        /// <returns>-</returns>
        public void eliminarFuncionario(Funcionario funcionario, String usuario)
        {
            funcionarioDatos.eliminarFuncionario(funcionario, usuario);
        }
    }
}
