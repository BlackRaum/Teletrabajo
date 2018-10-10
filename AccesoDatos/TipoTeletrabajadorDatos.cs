using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class TipoTeletrabajadorDatos
    {

        #region Variables globales
        private ConexionDatos conexion = new ConexionDatos();
        private BitacoraAccionesDatos bitacora = new BitacoraAccionesDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 05/10/2018
        /// Efecto: devuelve una lista de TipoTeletrabajador según solictud de teletrabajo
        /// Requiere: id Solicitud
        /// Modifica: -
        /// Devuelve: Lista de TipoTeletrabajador 
        /// </summary>
        /// <returns> List<TipoTeletrabajador> </returns>
        public List<TipoTeletrabajador> getTipoTeletrabajador(int idSolicitud)
        {
            List<TipoTeletrabajador> listaTiposTeletrabajador = new List<TipoTeletrabajador>();

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"SELECT id_tipo,descripcion,otros_requerimientos      
                                             FROM dbo.TipoTeletrabajador
                                             WHERE activo = @activo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_solicitud", idSolicitud);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                TipoTeletrabajador tipoTeletrabajador = new TipoTeletrabajador
                {
                    idTipoTeletrabajador = Convert.ToInt16(reader["id_objetivo"].ToString()),
                    descripcion = reader["descripcion"].ToString(),
                    otrosRequerimientos = reader["otros_requerimientos"].ToString()
                };

                listaTiposTeletrabajador.Add(tipoTeletrabajador);
            }

            sqlConnection.Close();

            return listaTiposTeletrabajador;
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
        public int insertarTipoTeletrabajador(TipoTeletrabajador tipoDesplazamiento, int idSolicitud)
        {

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();


            String consulta = @"INSERT INTO dbo.TipoTeletrabajador(descripcion,otros_requerimientos,activo)
                                            VALUES(@descripcion,@otros_requerimientos,@activo)
                                            SELECT SCOPE_IDENTITY();";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@descripcion", tipoDesplazamiento.descripcion);
            sqlCommand.Parameters.AddWithValue("@otros_requerimientos", tipoDesplazamiento.otrosRequerimientos);
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
        /// Requiere: TipoTeletrabajador,  idSolicitud,  usuario
        /// Modifica: TipoTeletrabajador
        /// Devuelve: idEquipo
        /// </summary>
        /// <returns> int </returns>
        public int actualizarTipoTeletrabajador(TipoTeletrabajador tipoDesplazamiento, int idSolicitud, String usuario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.TipoTeletrabajador
                                               SET activo = @activo
                                            WHERE id_tipo = @id_tipo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_tipo", tipoDesplazamiento.idTipoTeletrabajador);
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            int idTipo = insertarTipoTeletrabajador(tipoDesplazamiento, idSolicitud);

            bitacora.insertarBitacoraAccion("Actualizar", "TipoTeletrabajador", tipoDesplazamiento.idTipoTeletrabajador, idTipo, usuario);

            return idTipo;
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 05/10/2018
        /// Efecto: elimina un equipoConexion asociado a una solicitud de teletrabajo
        /// Requiere: TipoTeletrabajador,  usuario
        /// Modifica: TipoTeletrabajador
        /// Devuelve: -
        /// </summary>
        /// <returns> - </returns>
        public void eliminarTipoTeletrabajador(TipoTeletrabajador tipoDesplazamiento, String usuario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.TipoTeletrabajador
                                               SET activo = @activo
                                            WHERE id_tipo = @id_tipo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_tipo", tipoDesplazamiento.idTipoTeletrabajador);
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            bitacora.insertarBitacoraAccion("Eliminar", "TipoTeletrabajador", tipoDesplazamiento.idTipoTeletrabajador, 0, usuario);
        }
    }
}