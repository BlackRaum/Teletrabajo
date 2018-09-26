using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class PersonaEmergenciaDatos
    {
        #region Variables globales
        private ConexionDatos conexion = new ConexionDatos();
        private BitacoraAccionesDatos bitacora = new BitacoraAccionesDatos();
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
            SqlConnection sqlconnection = conexion.conexionTeletrabajo();
            String consulta = @"SELECT id_persona, nombre_completo, telefono_fijo, telefono_celular, parentesco,direccion
                                              FROM dbo.PersonaEmergencia PE, dbo.ContactoEmergencia CE
                                              WHERE PE.id_persona= CE.id_persona_emergencia and CE.id_funcionario = @id_funcionario and activo = @activo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlconnection);
            sqlCommand.Parameters.AddWithValue("@id_funcionario", funcionario.idFuncionario);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            SqlDataReader reader;
            sqlconnection.Open();
            reader = sqlCommand.ExecuteReader();

            PersonaEmergencia personaEmergencia = new PersonaEmergencia();
            while (reader.Read())
            {
                personaEmergencia.idPersona = Convert.ToInt16(reader["id_persona"].ToString());
                personaEmergencia.nombreCompleto = reader["nombre_completo"].ToString();
                personaEmergencia.telefonoFijo = reader["telefono_fijo"].ToString();
                personaEmergencia.celular = reader["telefono_celular"].ToString();
                personaEmergencia.parentesco = reader["parentesco"].ToString();
                personaEmergencia.direccion = reader["direccion"].ToString();
            }

            sqlconnection.Close();

            return personaEmergencia;
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
        public int insertarPersonaEmergencia( PersonaEmergencia contactoEmergencia, Funcionario funcionario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"INSERT INTO dbo.PersonaEmergencia
                                            (nombre_completo,telefono_fijo,telefono_celular,parentesco,direccion,activo)
                                            VALUES(@nombre_completo,@telefono_fijo,@telefono_celular,@parentesco,@direccion,@activo)
                                            SELECT SCOPE_IDENTITY();";
            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@nombre_completo", contactoEmergencia.nombreCompleto);
            sqlCommand.Parameters.AddWithValue("@telefono_fijo", contactoEmergencia.telefonoFijo);
            sqlCommand.Parameters.AddWithValue("@telefono_celular", contactoEmergencia.celular);
            sqlCommand.Parameters.AddWithValue("@parentesco", contactoEmergencia.parentesco);
            sqlCommand.Parameters.AddWithValue("@direccion", contactoEmergencia.direccion);            
            sqlCommand.Parameters.AddWithValue("@activo", true);

            sqlConnection.Open();
            int idPersonaEmergencia = Convert.ToInt32(sqlCommand.ExecuteScalar());

            consulta = @"INSERT INTO dbo.ContactoEmergencia
                                   (id_funcionario,id_persona_emergencia,activo)
                                   VALUES (@id_funcionario,@id_persona_emergencia,@activo)";
            sqlCommand = new SqlCommand(consulta, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_funcionario", contactoEmergencia.nombreCompleto);
            sqlCommand.Parameters.AddWithValue("@id_persona_emergencia", contactoEmergencia.telefonoFijo);         
            sqlCommand.Parameters.AddWithValue("@activo", true);


            sqlConnection.Close();

            return idPersonaEmergencia;
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
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.ContactoEmergencia
                                             SET activo = @activo
                                             WHERE  id_persona_emergencia =@id_persona  and id_funcionario = @id_funcionario
                                             UPDATE dbo.PersonaEmergencia
                                             SET activo = 0
                                             WHERE  id_persona_emergencia =@id_persona";
            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_persona", contactoEmergencia.idPersona);
            sqlCommand.Parameters.AddWithValue("@id_funcionario", funcionario.idFuncionario);            
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            int idContactoActualizado = insertarPersonaEmergencia(contactoEmergencia, funcionario);

            return idContactoActualizado;
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
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.ContactoEmergencia
                                             SET activo = @activo
                                             WHERE  id_persona_emergencia =@id_persona  and id_funcionario = @id_funcionario
                                             UPDATE dbo.PersonaEmergencia
                                             SET activo = 0
                                             WHERE  id_persona_emergencia =@id_persona";
            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_persona", contactoEmergencia.idPersona);
            sqlCommand.Parameters.AddWithValue("@id_funcionario", funcionario.idFuncionario);
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            bitacora.insertarBitacoraAccion("Eliminar", "ContactoEmergencia", contactoEmergencia.idPersona, 0, funcionario.nombreCompleto);
            
        }
    }
}