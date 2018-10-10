using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class FuncionFuncionarioServicio
    {
        #region
        FuncionFuncionarioDatos funcionFuncionarioDatos = new FuncionFuncionarioDatos();
        #endregion


        /// <summary>
        /// Fabián Quirós Masís
        /// 05/10/2018
        /// Efecto: devuelve una lista de funciones de un funcionario según la solicitud de teletrabajo
        /// Requiere: id Solicitud
        /// Modifica: -
        /// Devuelve: Funciones Funcionario
        /// </summary>
        /// <returns> List<FuncionFuncionario> </returns>
        public List<FuncionFuncionario> getFuncionesSolicitud(int idSolicitud)
        {
            return funcionFuncionarioDatos.getFuncionesSolicitud(idSolicitud);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 05/10/2018
        /// Efecto: ingresa la información de una Funcion de un Funcionario a la bd
        /// Requiere: FuncionFuncionario, id Solicitud
        /// Modifica: -
        /// Devuelve: Id FuncionFuncionario
        /// </summary>
        /// <returns> int </returns>
        public int insertarFuncion(FuncionFuncionario funcion, int idSolicitud)
        {
            return funcionFuncionarioDatos.insertarFuncion(funcion, idSolicitud);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: actualiza una funcion de un funcionario de una solicitud de teletrabajo
        /// Requiere: funcion, id Solicitud 
        /// Modifica: FuncionFuncionario funcion, int idSolicitud
        /// Devuelve: -
        /// </summary>
        /// <returns> int </returns>
        public int actualizarFuncion(FuncionFuncionario funcion, int idSolicitud, String usuario)
        {
            return funcionFuncionarioDatos.actualizarFuncion(funcion, idSolicitud, usuario);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 05/10/2018
        /// Efecto: elimina una funcion de un funcionario asociado a una solicitud de teletrabajo
        /// Requiere: FuncionFuncionario, Funcionario
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <returns> - </returns>
        public void eliminarFuncionFuncionario(FuncionFuncionario funcion, String usuario)
        {
            funcionFuncionarioDatos.eliminarFuncionFuncionario(funcion, usuario);
        }
    }
}
