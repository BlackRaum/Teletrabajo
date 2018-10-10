using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class MetaDatos
    {
        #region Variables globales
        private ConexionDatos conexion = new ConexionDatos();
        private BitacoraAccionesDatos bitacora = new BitacoraAccionesDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: devuelve una lista de metas pertenecientes a un objetivo
        /// Requiere: idObjetivo
        /// Modifica: -
        /// Devuelve: Lista de Objetivos 
        /// </summary>
        /// <returns> List<Objetivo> </returns>
        public List<Meta> getMetasObjetivo(int idObjetivo)
        {
            List<Meta> listaMeta = new List<Meta>();

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"SELECT id_meta,nombre,duracion,descripcion,activo
                                              FROM dbo.MetaObjetivo
                                              WHERE id_objetivo = @id_objetivo and  activo = @activo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_objetivo", idObjetivo);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Meta meta = new Meta
                {
                    idMeta = Convert.ToInt16(reader["id_objetivo"].ToString()),
                    nombre = reader["nombre"].ToString(),
                    duracion = reader["duracion"].ToString(),
                    descripcion = reader["descripcion"].ToString()
                };

                listaMeta.Add(meta);
            }

            sqlConnection.Close();

            return listaMeta;
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: ingresa la información de una meta a la bd
        /// Requiere: Meta, id Objetivo
        /// Modifica: -
        /// Devuelve: Id Meta
        /// </summary>
        /// <returns> int </returns>
        public int insertarObjetivo(Meta meta, int idObjetivo)
        {

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();


            String consulta = @"INSERT INTO dbo.MetaObjetivo(id_objetivo, nombre, duracion, descripcion, activo)
                                            VALUES(@id_objetivo,@nombre,@duracion,@descripcion,@activo)
                                            SELECT SCOPE_IDENTITY();";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_objetivo", idObjetivo);
            sqlCommand.Parameters.AddWithValue("@nombre", meta.nombre);
            sqlCommand.Parameters.AddWithValue("@duracion", meta.duracion);
            sqlCommand.Parameters.AddWithValue("@descripcion", meta.descripcion);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            sqlConnection.Open();
            int idMeta = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return idMeta;
        }


        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: actualiza una meta asociado a un objetivo
        /// Requiere: Meta, id Objetivo 
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <returns> - </returns>
        public void actualizarMeta(Meta meta, int idObjetivo)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.MetaObjetivo
                                               SET nombre = @nombre
                                                  ,duracion = @duracion
                                                  ,descripcion = @descripcion
                                                  ,activo = @activo
                                            WHERE id_objetivo = @id_objetivo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_objetivo", idObjetivo);
            sqlCommand.Parameters.AddWithValue("@nombre", meta.nombre);
            sqlCommand.Parameters.AddWithValue("@duracion", meta.duracion);
            sqlCommand.Parameters.AddWithValue("@descripcion", meta.descripcion);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: elimina una meta asociado a un Objetivo
        /// Requiere: Objetivo, Funcionario
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <returns> - </returns>
        public void eliminarMeta(Meta meta, Funcionario funcionario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.MetaObjetivo
                                               SET  activo = @activo
                                            WHERE id_meta = @id_meta";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_meta", meta.idMeta);
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            bitacora.insertarBitacoraAccion("Eliminar", "Meta", meta.idMeta, 0, funcionario.nombreCompleto);
        }
    }
}
