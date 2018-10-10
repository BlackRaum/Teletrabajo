using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class EquipoConexionDatos
    {
        #region Variables globales
        private ConexionDatos conexion = new ConexionDatos();
        private BitacoraAccionesDatos bitacora = new BitacoraAccionesDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 05/10/2018
        /// Efecto: devuelve una lista de EquipoConexion según solictud de teletrabajo
        /// Requiere: id Solicitud
        /// Modifica: -
        /// Devuelve: Lista de EquipoConexion 
        /// </summary>
        /// <returns> List<EquipoConexion> </returns>
        public List<EquipoConexion> getEquipoConexion(int idSolicitud)
        {
            List<EquipoConexion> listaEquiposConexion = new List<EquipoConexion>();

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"SELECT id_equipo,descripcion_equipo,posee
                                             FROM dbo.EquipoConexion
                                             WHERE id_solicitud = @id_solicitud and activo = @activo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_solicitud", idSolicitud);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                EquipoConexion equipoConexion = new EquipoConexion
                {
                    idEquipoConexion = Convert.ToInt16(reader["id_objetivo"].ToString()),
                    descripcion = reader["descripcion"].ToString(),
                    posee = Convert.ToBoolean(reader["duracion"].ToString())
                };

                listaEquiposConexion.Add(equipoConexion);
            }

            sqlConnection.Close();

            return listaEquiposConexion;
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 05/10/2018
        /// Efecto: ingresa la información de un entregable a la bd
        /// Requiere: Entregable, id Meta
        /// Modifica: -
        /// Devuelve: Id Entregable
        /// </summary>
        /// <returns> int </returns>
        public int insertarEquipoConexion(EquipoConexion equipoConexion, int idSolicitud)
        {

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();


            String consulta = @"INSERT INTO dbo.EquipoConexion (id_solicitud,descripcion_equipo,posee,activo)
                                            VALUES(@id_solicitud,@descripcion_equipo,@posee,@activo)
                                            SELECT SCOPE_IDENTITY();";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_solicitud", idSolicitud);
            sqlCommand.Parameters.AddWithValue("@descripcion_equipo", equipoConexion.descripcion);
            sqlCommand.Parameters.AddWithValue("@posee", equipoConexion.posee);        
            sqlCommand.Parameters.AddWithValue("@activo", true);

            sqlConnection.Open();
            int idEntregable = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return idEntregable;
        }


        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: actualiza un equipoConexion asociado a una solicitud de teletrabajo
        /// Requiere: EquipoConexion,  idSolicitud,  usuario
        /// Modifica: EquipoConexion
        /// Devuelve: idEquipo
        /// </summary>
        /// <returns> int </returns>
        public int actualizarEquipoConexion(EquipoConexion equipoConexion, int idSolicitud, String usuario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.EquipoConexion
                                                    SET activo = @activo
                                             WHERE id_equipo = @id_equipo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_equipo", equipoConexion.idEquipoConexion);
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            int idEquipo = insertarEquipoConexion(equipoConexion,idSolicitud);

            bitacora.insertarBitacoraAccion("Actualizar", "EquipoConexion", equipoConexion.idEquipoConexion, idEquipo, usuario);

            return idEquipo;
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 05/10/2018
        /// Efecto: elimina un equipoConexion asociado a una solicitud de teletrabajo
        /// Requiere: EquipoConexion,  usuario
        /// Modifica: EquipoConexion
        /// Devuelve: -
        /// </summary>
        /// <returns> - </returns>
        public void eliminarEquipoConexion(EquipoConexion equipoConexion, String usuario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.EquipoConexion
                                                    SET activo = @activo
                                             WHERE id_equipo = @id_equipo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_equipo", equipoConexion.idEquipoConexion);
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            bitacora.insertarBitacoraAccion("Eliminar", "EquipoConexion", equipoConexion.idEquipoConexion, 0, usuario);
        }
    }
}
