using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class TipoDesplazamientoDatos
    {

        #region Variables globales
        private ConexionDatos conexion = new ConexionDatos();
        private BitacoraAccionesDatos bitacora = new BitacoraAccionesDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 05/10/2018
        /// Efecto: devuelve una lista de TipoDesplazamiento según solictud de teletrabajo
        /// Requiere: id Solicitud
        /// Modifica: -
        /// Devuelve: Lista de TipoDesplazamiento 
        /// </summary>
        /// <returns> List<TipoDesplazamiento> </returns>
        public List<TipoDesplazamiento> getTipoDesplazamiento()
        {
            List<TipoDesplazamiento> listaEquiposConexion = new List<TipoDesplazamiento>();

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"SELECT id_tipo,nombre
                                             FROM dbo.TipoDesplazamiento
                                             WHERE  activo = @activo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                TipoDesplazamiento equipoConexion = new TipoDesplazamiento
                {
                    idTipoDesplazamiento = Convert.ToInt16(reader["id_objetivo"].ToString()),
                    nombre = reader["descripcion"].ToString(),
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
        public int insertarTipoDesplazamiento(TipoDesplazamiento tipoDesplazamiento)
        {

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();


            String consulta = @"INSERT INTO dbo.TipoDesplazamiento(nombre,activo)
                                            VALUES(@nombre,@activo)
                                            SELECT SCOPE_IDENTITY();";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@nombre", tipoDesplazamiento.nombre);        
            sqlCommand.Parameters.AddWithValue("@activo", true);

            sqlConnection.Open();
            int idTipo = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return idTipo;
        }


        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: actualiza un equipoConexion asociado a una solicitud de teletrabajo
        /// Requiere: TipoDesplazamiento,  idSolicitud,  usuario
        /// Modifica: TipoDesplazamiento
        /// Devuelve: idEquipo
        /// </summary>
        /// <returns> int </returns>
        public int actualizarTipoDesplazamiento(TipoDesplazamiento tipoDesplazamiento, String usuario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.TipoDesplazamiento
                                               SET activo = @activo
                                            WHERE id_tipo = @id_tipo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_tipo", tipoDesplazamiento.idTipoDesplazamiento);
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            int idTipo = insertarTipoDesplazamiento(tipoDesplazamiento);

            bitacora.insertarBitacoraAccion("Actualizar", "TipoDesplazamiento", tipoDesplazamiento.idTipoDesplazamiento, idTipo, usuario);

            return idTipo;
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 05/10/2018
        /// Efecto: elimina un equipoConexion asociado a una solicitud de teletrabajo
        /// Requiere: TipoDesplazamiento,  usuario
        /// Modifica: TipoDesplazamiento
        /// Devuelve: -
        /// </summary>
        /// <returns> - </returns>
        public void eliminarTipoDesplazamiento(TipoDesplazamiento tipoDesplazamiento, String usuario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.TipoDesplazamiento
                                               SET activo = @activo
                                            WHERE id_tipo = @id_tipo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_tipo", tipoDesplazamiento.idTipoDesplazamiento);
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            bitacora.insertarBitacoraAccion("Eliminar", "TipoDesplazamiento", tipoDesplazamiento.idTipoDesplazamiento, 0, usuario);
        }
    }
}