using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class EntregableDatos
    {
        #region Variables globales
        private ConexionDatos conexion = new ConexionDatos();
        private BitacoraAccionesDatos bitacora = new BitacoraAccionesDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 05/10/2018
        /// Efecto: devuelve una lista de entregables según meta
        /// Requiere: id Meta
        /// Modifica: -
        /// Devuelve: Lista de Entregables 
        /// </summary>
        /// <returns> List<Entregable> </returns>
        public List<Entregable> getEntregableMeta(int idMeta)
        {
            List<Entregable> listaEntregables = new List<Entregable>();

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"SELECT id_entregable,id_meta,descripcion,tipo_entrega,tipo_entregable,
		                                            fecha_entrega,nombre_archivo,ruta_archivo,completado,activo
                                            FROM dbo.EntregableMeta
                                            WHERE id_meta = @id_meta and  activo = @activo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_meta", idMeta);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Entregable entregable = new Entregable
                {
                    idEntregable = Convert.ToInt16(reader["id_objetivo"].ToString()),
                    descripcion = reader["descripcion"].ToString(),
                    tipoEntrega = reader["nombre"].ToString(),
                    tipoEntregable = reader["duracion"].ToString(),
                    fechaEntrega = Convert.ToDateTime(reader["nombre"].ToString()),
                    nombreArchivo = reader["duracion"].ToString(),
                    rutaArchivo = reader["nombre"].ToString(),
                    completado = Convert.ToBoolean(reader["duracion"].ToString())
                };

                listaEntregables.Add(entregable);
            }

            sqlConnection.Close();

            return listaEntregables;
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
        public int insertarEntregable(Entregable entregable, int idMeta)
        {

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();


            String consulta = @"INSERT INTO dbo.EntregableMeta
                                                (id_meta,descripcion,tipo_entrega,tipo_entregable,fecha_entrega,
			                                    nombre_archivo,ruta_archivo,completado,activo)
                                            VALUES(@id_meta,@descripcion,@tipo_entrega,@tipo_entregable,@fecha_entrega
                                                         ,@nombre_archivo,@ruta_archivo,@completado,activo)
                                            SELECT SCOPE_IDENTITY();";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_objetivo", idMeta);
            sqlCommand.Parameters.AddWithValue("@descripcion", entregable.descripcion);
            sqlCommand.Parameters.AddWithValue("@tipo_entrega", entregable.tipoEntrega);
            sqlCommand.Parameters.AddWithValue("@tipo_entregable", entregable.tipoEntregable);
            sqlCommand.Parameters.AddWithValue("@fecha_entrega", entregable.fechaEntrega);
            sqlCommand.Parameters.AddWithValue("@nombre_archivo", entregable.nombreArchivo);
            sqlCommand.Parameters.AddWithValue("@ruta_archivo", entregable.rutaArchivo);
            sqlCommand.Parameters.AddWithValue("@completado", entregable.completado);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            sqlConnection.Open();
            int idEntregable = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return idEntregable;
        }


        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: actualiza una meta asociado a un objetivo
        /// Requiere: Meta, id Objetivo 
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <returns> int </returns>
        public int actualizarMeta(Entregable entregable, int idMeta, String usuario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.EntregableMeta
                                                   SET activo = @activo
                                            WHERE id_entregable = @id_entregable";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_entregable", entregable.idEntregable);           
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            int idEntregable = insertarEntregable(entregable, idMeta);

            bitacora.insertarBitacoraAccion("Actualizar", "Entregable", entregable.idEntregable, idEntregable, usuario);

            return idEntregable;
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 05/10/2018
        /// Efecto: elimina una meta asociado a un Objetivo
        /// Requiere: Objetivo, Funcionario
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <returns> - </returns>
        public void eliminarEntregable(Entregable entregable, String usuario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.EntregableMeta
                                                   SET activo = @activo
                                            WHERE id_entregable = @id_entregable";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_entregable", entregable.idEntregable);
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            bitacora.insertarBitacoraAccion("Eliminar", "Entregable", entregable.idEntregable, 0, usuario);
        }
    }
}