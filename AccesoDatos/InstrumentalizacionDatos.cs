using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class InstrumentalizacionDatos
    {
        #region Variables globales
        private ConexionDatos conexion = new ConexionDatos();
        private BitacoraAccionesDatos bitacora = new BitacoraAccionesDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 07/10/2018
        /// Efecto: devuelve una lista de instrumentos según solictud de teletrabajo
        /// Requiere: id Solicitud
        /// Modifica: -
        /// Devuelve: Lista de Instrumentalizacion 
        /// </summary>
        /// <returns> List<Instrumentalizacion> </returns>
        public List<Instrumentalizacion> getInstrumentalizacion(int idSolicitud)
        {
            List<Instrumentalizacion> listaInstrumentalizacion = new List<Instrumentalizacion>();

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"SELECT id_instrumento,descripcion_instrumento,aprobacion_jefe
                                             FROM dbo.Instrumentalizacion
                                             WHERE id_solitud=@id_solitud and activo = @activo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_solitud", idSolicitud);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Instrumentalizacion instrumento= new Instrumentalizacion
                {
                    idInstrumento = Convert.ToInt16(reader["id_instrumento"].ToString()),
                    descripcionInstrumento =reader["descripcion_instrumento"].ToString(),
                    aprovacionJefe = Convert.ToBoolean(reader["aprobacion_jefe"].ToString())                   
                };

                listaInstrumentalizacion.Add(instrumento);
            }

            sqlConnection.Close();

            return listaInstrumentalizacion;
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 07/10/2018
        /// Efecto: ingresa la información de un instrumento a la bd
        /// Requiere: Instrumentalizacion, id Solicitud
        /// Modifica: -
        /// Devuelve: Id Instrumentalizacion
        /// </summary>
        /// <returns> int </returns>
        public int insertarInstrumentalizacion(Instrumentalizacion instrumento, int idSolicitud)
        {

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();


            String consulta = @"INSERT INTO dbo.Instrumentalizacion(id_solitud,descripcion_instrumento,aprobacion_jefe,activo)                                                                                
                                            VALUES(@id_solitud,@descripcion_instrumento,@aprobacion_jefe,@activo)
                                            SELECT SCOPE_IDENTITY();";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_solitud", idSolicitud);
            sqlCommand.Parameters.AddWithValue("@descripcion_instrumento", instrumento.descripcionInstrumento);
            sqlCommand.Parameters.AddWithValue("@aprobacion_jefe", instrumento.aprovacionJefe);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            sqlConnection.Open();
            int idInstrumento = Convert.ToInt16(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return idInstrumento;
        }


        /// <summary>
        /// Fabián Quirós Masís
        /// 07/10/2018
        /// Efecto: actualiza un equipoConexion asociado a una solicitud de teletrabajo
        /// Requiere: Instrumentalizacion,  idSolicitud,  usuario
        /// Modifica: Instrumentalizacion
        /// Devuelve: idEquipo
        /// </summary>
        /// <returns> int </returns>
        public int actualizarInstrumentalizacion(Instrumentalizacion instrumento, int idSolicitud, String usuario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.Instrumentalizacion
                                               SET activo = @activo
                                            WHERE id_instrumento = @id_instrumento";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_instrumento", instrumento.idInstrumento );
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            int idInstrumentalizacion = insertarInstrumentalizacion(instrumento,idSolicitud);

            bitacora.insertarBitacoraAccion("Actualizar", "Instrumentalizacion", instrumento.idInstrumento, idInstrumentalizacion, usuario);

            return idInstrumentalizacion;
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 07/10/2018
        /// Efecto: elimina un instrumento asociado a una solicitud de teletrabajo
        /// Requiere: Instrumentalizacion,  usuario
        /// Modifica: Instrumentalizacion
        /// Devuelve: -
        /// </summary>
        /// <returns> - </returns>
        public void eliminarInstrumentalizacion(Instrumentalizacion instrumento, String usuario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.Instrumentalizacion
                                               SET activo = @activo
                                            WHERE id_instrumento = @id_instrumento";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_instrumento", instrumento.idInstrumento );
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            bitacora.insertarBitacoraAccion("Eliminar", "Instrumentalizacion", instrumento.idInstrumento, 0, usuario);
        }
    }
}
