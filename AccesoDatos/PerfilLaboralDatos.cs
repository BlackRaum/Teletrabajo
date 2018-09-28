using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class PerfilLaboralDatos
    {
        #region Variables globales
        private ConexionDatos conexion = new ConexionDatos();
        private BitacoraAccionesDatos bitacora = new BitacoraAccionesDatos();
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
            SqlConnection sqlconnection = conexion.conexionTeletrabajo();

            PerfilLaboral perfilFuncionario = new PerfilLaboral();

            String consulta = @"SELECT autoregulacion,eficiencia_teletrabajo,trabajo_presencial,
	                                       atencion_publico,tics,observaciones,aprobacion_rrhh
                                           FROM dbo.PerfilLaboral
                                           WHERE id_funcionario = @id_funcionario and activo = @activo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlconnection);
            sqlCommand.Parameters.AddWithValue("@id_funcionario", idFuncionario);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            SqlDataReader reader;
            sqlconnection.Open();
            reader = sqlCommand.ExecuteReader();

            PerfilLaboral perfilLaboral = new PerfilLaboral();

            while (reader.Read())
            {
                perfilLaboral.autoregulacion = Convert.ToBoolean(reader["autoregulacion"].ToString());
                perfilLaboral.eficienciaTeletrabajo = Convert.ToBoolean(reader["eficiencia_teletrabajo"].ToString());
                perfilLaboral.trabajoPresencial = Convert.ToBoolean(reader["trabajo_presencial"].ToString());
                perfilLaboral.atencionPublico = reader["atencion_publico"].ToString();
                perfilLaboral.tics = Convert.ToBoolean(reader["tics"].ToString());
                perfilLaboral.atencionPublico = reader["observaciones"].ToString();
                perfilLaboral.autoregulacion = Convert.ToBoolean(reader["aprobacion_rrhh"].ToString());
            }

            sqlconnection.Close();

            return perfilFuncionario;
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
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"INSERT INTO dbo.PerfilLaboral
                                            (id_funcionario,autoregulacion,eficiencia_teletrabajo,trabajo_presencial
                                            ,atencion_publico,tics,observaciones,aprobacion_rrhh,activo)
                                            VALUES(@id_funcionario,@autoregulacion,@eficiencia_teletrabajo,@trabajo_presencial
                                                        ,@atencion_publico,@tics,@observaciones,@aprobacion_rrhh,@activo)";
            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_funcionario", idFuncionario);
            sqlCommand.Parameters.AddWithValue("@eficiencia_teletrabajo", perfilLaboral.eficienciaTeletrabajo);
            sqlCommand.Parameters.AddWithValue("@trabajo_presencial", perfilLaboral.trabajoPresencial);
            sqlCommand.Parameters.AddWithValue("@atencion_publico", perfilLaboral.atencionPublico);
            sqlCommand.Parameters.AddWithValue("@tics", perfilLaboral.tics);
            sqlCommand.Parameters.AddWithValue("@observaciones", perfilLaboral.observaciones);
            sqlCommand.Parameters.AddWithValue("@aprobacion_rrhh", perfilLaboral.aprobacionRRHH);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

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
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.PerfilLaboral
                                            SET activo = @activo
                                            WHERE  id_funcionario = @id_funcionario ";
            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_funcionario", idFuncionario);
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            insertarPerfilLaboral(perfilLaboral, idFuncionario);

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
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.PerfilLaboral
                                            SET activo = @activo
                                            WHERE  id_funcionario = @id_funcionario ";
            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_funcionario", funcionario.idFuncionario);
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            bitacora.insertarBitacoraAccion("Eliminar", "ContactoEmergencia", funcionario.idFuncionario, 0, funcionario.nombreCompleto);

        }
    }
}
