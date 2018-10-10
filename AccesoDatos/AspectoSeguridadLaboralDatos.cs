using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class AspectoSeguridadLaboralDatos
    {
        #region Variables globales
        private ConexionDatos conexion = new ConexionDatos();
        private BitacoraAccionesDatos bitacora = new BitacoraAccionesDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 24/09/2018
        /// Efecto: devuelve una lista de Aspectos de Seguridad Laboral 
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de Aspectos de Seguridad Laboral
        /// </summary>
        /// <returns> List<AspectoSeguridadLaboral> </returns>
        public AspectoSeguridadLaboral getAspectoSeguridadLaboral(int idAspecto)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

           
            String consulta = @"SELECT id_aspecto,descripcion 
                                            FROM Teletrabajo.dbo.AspectoSeguridadLaboral
                                            Where id_aspecto=@id_aspecto and activo = @activo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_aspecto", idAspecto);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            AspectoSeguridadLaboral aspectoSeguridad = new AspectoSeguridadLaboral();
            while (reader.Read())
            {                           
                aspectoSeguridad.idAspecto = Convert.ToInt16(reader["id_aspecto"].ToString());
                aspectoSeguridad.descripcion = reader["descripcion"].ToString();                   
            }

            sqlConnection.Close();

            return aspectoSeguridad;
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 24/09/2018
        /// Efecto: devuelve una lista de Aspectos de Seguridad Laboral 
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de Aspectos de Seguridad Laboral
        /// </summary>
        /// <returns> List<AspectoSeguridadLaboral> </returns>
        public List<AspectoSeguridadLaboral> getAspectosSeguridadLaboral()
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();
            List<AspectoSeguridadLaboral> listaAspectos = new List<AspectoSeguridadLaboral>();
            String consulta = @"SELECT id_aspecto,descripcion 
                                            FROM Teletrabajo.dbo.AspectoSeguridadLaboral
                                            Where activo = @activo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();


            while (reader.Read())
            {
                AspectoSeguridadLaboral aspectoSeguridad = new AspectoSeguridadLaboral
                {
                    idAspecto = Convert.ToInt16(reader["id_aspecto"].ToString()),
                    descripcion = reader["descripcion"].ToString()
                };

                listaAspectos.Add(aspectoSeguridad);
            }

            sqlConnection.Close();

            return listaAspectos;
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: inserta un aspecto de seguridad laboral en la bd
        /// Requiere: AspectoSeguridadLaboral     
        /// Modifica:-
        /// Devuelve:int idAspecto
        /// </summary>
        /// <returns>int</returns>
        public int insertarAspectoSeguridadLaboral( AspectoSeguridadLaboral aspecto )
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"INSERT INTO dbo.AspectoSeguridadLaboral
                                            (descripcion,activo)
                                             VALUES(@descripcion,@activo)
                                            SELECT SCOPE_IDENTITY();";
            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@descripcion", aspecto.descripcion);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            sqlConnection.Open();
            int idAspecto= Convert.ToInt32(sqlCommand.ExecuteScalar());

            sqlConnection.Close();

            return idAspecto;
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: actualiza la información de un aspecto de seguridad laboral 
        /// Requiere: AspectoSeguridadLaboral
        /// Modifica:-
        /// Devuelve: int idAspecto
        /// </summary>
        /// <returns>int</returns>
        public int actualizarAspectoSeguridadLaboral(AspectoSeguridadLaboral aspecto, String usuario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.AspectoSeguridadLaboral
                                            SET activo = @activo 
                                            WHERE id_aspecto = @id_aspecto";
            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_aspecto", aspecto.idAspecto);           
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            int idAspecto = insertarAspectoSeguridadLaboral(aspecto);

            bitacora.insertarBitacoraAccion("Actualizar", "AspectoSeguridadLaboral", aspecto.idAspecto, idAspecto, usuario);

            return idAspecto;
        }

        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: elimina la información de un aspecto de seguridad laboral
        /// Requiere: AspectoSeguridadLaboral, Funcionario     
        /// Modifica:-
        /// Devuelve:int idContactoEmergencia
        /// </summary>
        /// <returns>-</returns>
        public void eliminarAspectoSeguridadLaboral(AspectoSeguridadLaboral aspecto, String usuario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.AspectoSeguridadLaboral
                                            SET activo = @activo 
                                            WHERE id_aspecto = @id_aspecto";
            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_aspecto", aspecto.idAspecto);
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            bitacora.insertarBitacoraAccion("Eliminar", "AspectoSeguridadLaboral", aspecto.idAspecto, 0, usuario);
        }
    }
}
