using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class UnidadTrabajoDatos
    {
        #region Variables globales
        private ConexionDatos conexion = new ConexionDatos();
        private BitacoraAccionesDatos bitacora = new BitacoraAccionesDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: obtiene una unidad de trabajo por id
        /// Requiere: Id unidad de trabajo 
        /// Modifica:-
        /// Devuelve: Unidad de trabajo
        /// </summary>
        /// <returns>UnidadTrabajo</returns>
        public UnidadTrabajo getUnidadTrabajo(int idUnidad)
        {
         
            SqlConnection sqlConnection = conexion.conexionLogin();
            String consulta = @"SELECT id_unidad,nombre,numero_extension,telefono,direccion
                                             FROM dbo.UnidadTrabajo
                                             Where id_unidad = @id_unidad activo = @activo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_unidad", true);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();
            UnidadTrabajo unidad = new UnidadTrabajo();
            while (reader.Read())
            {
                unidad.idUnidad = Convert.ToInt16(reader["id_unidad"].ToString());
                unidad.nombre = reader["nombre"].ToString();
                unidad.numeroExtension = reader["numero_extension"].ToString();
                unidad.telefono = reader["telefono"].ToString();
                unidad.direccion = reader["direccion"].ToString();                            
            }

            return unidad;
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: obtiene todas las unidades de la base datos.
        /// Requiere: PersonaEmergencia, Funcionario     
        /// Modifica:-
        /// Devuelve: Lista de UnidadTrabajo
        /// </summary>
        /// <returns>List<UnidadTrabajo></returns>
        public List<UnidadTrabajo> getUnidadesTrabajo()
        {
            List<UnidadTrabajo> unidadesTrabajo = new List<UnidadTrabajo>();

            SqlConnection sqlConnection = conexion.conexionLogin();
            String consulta = @"SELECT id_unidad,nombre,numero_extension,telefono,direccion
                                             FROM dbo.UnidadTrabajo
                                             Where activo = @activo ORDER BY nombre ASC  ";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                UnidadTrabajo unidad = new UnidadTrabajo
                {
                    idUnidad = Convert.ToInt16(reader["id_unidad"].ToString()),
                    nombre = reader["nombre"].ToString(),
                    numeroExtension = reader["numero_extension"].ToString(),
                    telefono = reader["telefono"].ToString(),
                    direccion = reader["direccion"].ToString()
                };

                unidadesTrabajo.Add(unidad);
            }

                return unidadesTrabajo;
        }
        /// <summary>
        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: inserta una unidad de trabajo
        /// Requiere: UnidadTrabajo
        /// Modifica:-
        /// Devuelve:int idUnidadTrabajo
        /// </summary>
        /// <returns>int</returns>
        public int insertarUnidadTrabajo(UnidadTrabajo unidad)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"INSERT INTO dbo.UnidadTrabajo
                                            (nombre,numero_extension,telefono,direccion,activo)
                                            VALUES(@nombre,@numero_extension,@telefono,@direccion,@activo)
                                            SELECT SCOPE_IDENTITY();";
            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@nombre", unidad.nombre);
            sqlCommand.Parameters.AddWithValue("@numero_extension", unidad.numeroExtension);
            sqlCommand.Parameters.AddWithValue("@telefono", unidad.telefono);
            sqlCommand.Parameters.AddWithValue("@direccion", unidad.direccion); 
            sqlCommand.Parameters.AddWithValue("@activo", true);

            sqlConnection.Open();
            int idUnidadTrabajo = Convert.ToInt32(sqlCommand.ExecuteScalar());

            sqlConnection.Close();

            return idUnidadTrabajo;
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: actualiza la información de una unidad de trabajo
        /// Requiere: UnidadTrabajo, Usuario     
        /// Modifica:-
        /// Devuelve:int idContactoEmergencia
        /// </summary>
        /// <returns>int</returns>
        public int actualizarUnidadTrabajo(UnidadTrabajo unidad)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.UnidadTrabajo
                                             SET activo = @activo
                                             WHERE  id_unidad =@id_unidad";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_unidad", unidad.idUnidad);
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            int idContactoActualizado = insertarUnidadTrabajo(unidad);

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
        public void eliminarUnidadTrabajo(UnidadTrabajo unidad, Funcionario funcionario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.UnidadTrabajo
                                             SET activo = @activo
                                             WHERE  id_unidad =@id_unidad";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_unidad", unidad.idUnidad);
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            bitacora.insertarBitacoraAccion("Eliminar", "UnidadTrabajo", unidad.idUnidad, 0, funcionario.nombreCompleto);

        }


    }
}
