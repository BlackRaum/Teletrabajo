using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class AspectoSeguridadLaboralDatos
    {
        #region Variables globales
        private ConexionDatos conexion = new ConexionDatos();
        private BitacoraAccionesDatos bitacora = new BitacoraAccionesDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 24/09/2018
        /// Efecto: devuelve una lista de Aspectos de Seguridad Laboral 
        /// Requiere: -
        /// Modifica: -
        /// Devuelve: lista de Aspectos de Seguridad Laboral
        /// </summary>
        /// <returns> List<AspectoSeguridadLaboral> </returns>
        public List<AspectoSeguridadLaboral> getAspectosSeguridadLaboral()
        {
            SqlConnection sqlconnection = conexion.conexionTeletrabajo();
            List<AspectoSeguridadLaboral> listaAspectos = new List<AspectoSeguridadLaboral>();
            String consulta = @"SELECT id_aspecto,descripcion 
                                            FROM Teletrabajo.dbo.AspectoSeguridadLaboral
                                            Where activo = @activo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlconnection);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            SqlDataReader reader;
            sqlconnection.Open();
            reader = sqlCommand.ExecuteReader();


            while (reader.Read())
            {
                AspectoSeguridadLaboral aspectoSeguridad = new AspectoSeguridadLaboral
                {
                    idAspecto = Convert.ToInt16(reader["id_aspecto"].ToString()),
                    descripcion = reader["descripcion"].ToString()
                };

                listaAspectos.Add(aspectoSeguridad);
            }

            sqlconnection.Close();

            return listaAspectos;
        }
    }
}
