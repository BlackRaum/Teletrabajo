using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ConexionDatos
    {
        BaseDatos baseDatos = new BaseDatos();
        Archivo archivo = new Archivo();

        /*
         * Jonathan Fonseca Vallejos
         * 13/ene/2017
         * Método que lee el del archivo los datos del servidor y establece la conexión con el servidor Login.
         */
        public SqlConnection conexionLogin()
        {
            baseDatos = archivo.leerArchivo();
            SqlConnection conn = new SqlConnection();

            baseDatos.servidorLogin = "163.178.106.21";
            baseDatos.baseLogin = "Login";
            baseDatos.usuarioLogin = "sa";
            baseDatos.contrasenaLogin = "sa123!!";
            archivo.guardarArchivo(baseDatos);

            String connectionString
             = @"Data Source=" + baseDatos.servidorLogin
             + ";Initial Catalog=" + baseDatos.baseLogin
             + ";User ID=" + baseDatos.usuarioLogin
             + ";Password=" + baseDatos.contrasenaLogin
             + ";Trusted_Connection=False;";

            conn.ConnectionString = connectionString;

            return conn;
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 06/04/2018
        /// Efecto: 
        /// Requiere:-
        /// Modifica:-
        /// Devuelve: Conexion de la BD SIBO
        /// </summary>
        /// <returns>SqlConnection</returns>
        public SqlConnection conexionSIBO()
        {
            baseDatos = archivo.leerArchivo();
            SqlConnection conn = new SqlConnection();

            //baseDatos.servidorSIBO = "163.178.106.21";
            //baseDatos.baseSIBO = "Inventario";
            //baseDatos.usuarioSIBO = "sa";
            //baseDatos.contrasenaSIBO = "sa123!!";
            //archivo.guardarArchivo(baseDatos);

            String connectionString
                = @"Data Source=" + baseDatos.servidorTeletrabajo
                + ";Initial Catalog=" + baseDatos.servidorTeletrabajo
                + ";User ID=" + baseDatos.servidorTeletrabajo
                + ";Password=" + baseDatos.servidorTeletrabajo
                + ";Trusted_Connection=False;";

            conn.ConnectionString = connectionString;

            return conn;
        }
    }
}
