using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class BitacoraAccionesDatos
    {
        private ConexionDatos conexion = new ConexionDatos();


        /// <summary>
        /// Fabián Quirós Masís
        /// 06/04/2018
        /// Efecto: 
        /// Requiere: 
        /// Modifica:
        /// Devuelve: 
        /// </summary>
        /// <returns></returns>
        public void insertarBitacoraAccion(String accion, String tabla, int idRegistroAnterior, int idRegistroNuevo, String usuario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            SqlCommand sqlCommand = new SqlCommand("INSERT Bitacora (accion,tabla,id_registro_anterior,id_registro_nuevo,usuario,fecha_registro) " +
                                                    "values(@accion,@tabla,@idRegistroAnterior,@idRegistroNuevo,@usuario,@fechaRegistro);", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@accion", accion);
            sqlCommand.Parameters.AddWithValue("@tabla", tabla);
            sqlCommand.Parameters.AddWithValue("@idRegistroAnterior", idRegistroAnterior);
            sqlCommand.Parameters.AddWithValue("@idRegistroNuevo", idRegistroNuevo);
            sqlCommand.Parameters.AddWithValue("@usuario", usuario);
            sqlCommand.Parameters.AddWithValue("@fechaRegistro", DateTime.Now);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();

            sqlConnection.Close();
        }

    }
}
