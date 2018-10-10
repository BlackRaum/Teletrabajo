using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class PersonaEmergenciaServicio
    {
        #region variables globales
        private PersonaEmergenciaDatos personaEmergenciaDatos = new PersonaEmergenciaDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 24/09/2018
        /// Efecto: devuelve la persona de emergencia según funcionario
        /// Requiere: Id del funcionario
        /// Modifica:-
        /// Devuelve: devuelve el objeto Persona de Emergencia
        /// </summary>
        /// <returns> PersonaEmergencia </returns>
        public PersonaEmergencia getPersonaEmergencia(Funcionario funcionario)
        {
            return personaEmergenciaDatos.getPersonaEmergencia(funcionario);
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: inserta un contacto de emergencia de un funcionario
        /// Requiere: PersonaEmergencia, Funcionario     
        /// Modifica:-
        /// Devuelve:int idContactoEmergencia
        /// </summary>
        /// <returns>int</returns>
        public int insertarPersonaEmergencia(PersonaEmergencia contactoEmergencia, Funcionario funcionario)
        {
            return personaEmergenciaDatos.insertarPersonaEmergencia(contactoEmergencia, funcionario);
        }
        /// <summary>
        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: actualiza la información de un contacto de emergencia de un funcionario 
        /// Requiere: PersonaEmergencia, Funcionario     
        /// Modifica:-
        /// Devuelve:int idContactoEmergencia
        /// </summary>
        /// <returns>int</returns>
        public int actualizarPersonaEmergencia(PersonaEmergencia contactoEmergencia, Funcionario funcionario)
        {
            return personaEmergenciaDatos.actualizarPersonaEmergencia(contactoEmergencia, funcionario);
        }

        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: elimina la información de un contacto de emergencia de un funcionario 
        /// Requiere: PersonaEmergencia, Funcionario     
        /// Modifica:-
        /// Devuelve:int idContactoEmergencia
        /// </summary>
        /// <returns>int</returns>
        public void eliminarPersonaEmergencia(PersonaEmergencia contactoEmergencia, Funcionario funcionario)
        {
            personaEmergenciaDatos.eliminarPersonaEmergencia(contactoEmergencia,funcionario);
        }
    }
}
