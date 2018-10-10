using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class FuncionFuncionarioDatos
    {
        #region Variables globales
        private ConexionDatos conexion = new ConexionDatos();
        private BitacoraAccionesDatos bitacora = new BitacoraAccionesDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 05/10/2018
        /// Efecto: devuelve una lista de funciones de un funcionario según la solicitud de teletrabajo
        /// Requiere: id Solicitud
        /// Modifica: -
        /// Devuelve: Funciones Funcionario
        /// </summary>
        /// <returns> List<FuncionFuncionario> </returns>
        public List<FuncionFuncionario> getFuncionesSolicitud(int idSolicitud)
        {
            List<FuncionFuncionario> listraFunciones = new List<FuncionFuncionario>();

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"SELECT id_funcion,descripcion_funcion,teletrabajable
                                            FROM dbo.FuncionFuncionario
                                            WHERE id_solicitud = @id_solicitud and activo = @activo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_solicitud", idSolicitud);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                FuncionFuncionario entregable = new FuncionFuncionario
                {
                    idFuncion = Convert.ToInt16(reader["id_funcion"].ToString()),
                    descripcion = reader["descripcion_funcion"].ToString(),
                    isTeletrabajable = Convert.ToBoolean(reader["teletrabajable"].ToString())                   
                };

                listraFunciones.Add(entregable);
            }

            sqlConnection.Close();

            return listraFunciones;
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 05/10/2018
        /// Efecto: ingresa la información de una Funcion de un Funcionario a la bd
        /// Requiere: FuncionFuncionario, id Solicitud
        /// Modifica: -
        /// Devuelve: Id FuncionFuncionario
        /// </summary>
        /// <returns> int </returns>
        public int insertarFuncion(FuncionFuncionario funcion, int idSolicitud)
        {

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();


            String consulta = @"INSERT INTO dbo.FuncionFuncionario
                                                   (id_solicitud,descripcion_funcion,teletrabajable,activo)
                                            VALUES(@id_solicitud,@descripcion_funcion,@teletrabajable,@activo)
                                            SELECT SCOPE_IDENTITY();";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_solicitud", idSolicitud);
            sqlCommand.Parameters.AddWithValue("@descripcion_funcion", funcion.descripcion);
            sqlCommand.Parameters.AddWithValue("@teletrabajable", funcion.isTeletrabajable);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            sqlConnection.Open();
            int idFuncion = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return idFuncion;
        }


        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: actualiza una funcion de un funcionario de una solicitud de teletrabajo
        /// Requiere: funcion, id Solicitud 
        /// Modifica: FuncionFuncionario funcion, int idSolicitud
        /// Devuelve: -
        /// </summary>
        /// <returns> int </returns>
        public int actualizarFuncion(FuncionFuncionario funcion, int idSolicitud, String usuario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.FuncionFuncionario
                                                  SET activo = @activo
                                            WHERE id_funcion = @id_funcion";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_entregable", funcion.idFuncion);
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            int idFuncion = insertarFuncion(funcion, idSolicitud);

            bitacora.insertarBitacoraAccion("Actualizar", "FuncionFuncionario", funcion.idFuncion, idFuncion, usuario);

            return idFuncion;
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 05/10/2018
        /// Efecto: elimina una funcion de un funcionario asociado a una solicitud de teletrabajo
        /// Requiere: FuncionFuncionario, Funcionario
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <returns> - </returns>
        public void eliminarFuncionFuncionario(FuncionFuncionario funcion, String usuario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.FuncionFuncionario
                                                  SET activo = @activo
                                            WHERE id_funcion = @id_funcion";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_entregable", funcion.idFuncion);
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            bitacora.insertarBitacoraAccion("Eliminar", "Entregable", funcion.idFuncion, 0, usuario);
        }
    }
}