using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ObjetivoDatos
    {
        #region Variables globales
        private ConexionDatos conexion = new ConexionDatos();
        private BitacoraAccionesDatos bitacora = new BitacoraAccionesDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: devuelve una lista de objetivos pertenecientes a un plan de trabajo de un funcionario
        /// Requiere: idPlan
        /// Modifica: -
        /// Devuelve: Lista de Objetivos 
        /// </summary>
        /// <returns> List<Objetivo> </returns>
        public List<Objetivo> getObtivosPlanTrabajo(int idPlan)
        {
            List<Objetivo> listaObjetivo = new List<Objetivo>();

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"SELECT id_objetivo,descripcion_objetivo
                                            FROM dbo.ObjetivoPlanTrabajo
                                            WHERE id_plan = @id_plan and activo = @activo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_plan", idPlan);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Objetivo objetivo = new Objetivo
                {
                    idObjetivo = Convert.ToInt16(reader["id_objetivo"].ToString()),
                    descripcion = reader["descripcion_objetivo"].ToString()
                };

                listaObjetivo.Add(objetivo);
            }

            sqlConnection.Close();

            return listaObjetivo;
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: ingresa la información de objetivo a la bd
        /// Requiere: Objetivo, id Plan de trabajo
        /// Modifica: -
        /// Devuelve: Id Objetivo
        /// </summary>
        /// <returns> int </returns>
        public int insertarObjetivo(Objetivo objetivo, int idPlan)
        {

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();


            String consulta = @"INSERT INTO dbo.ObjetivoPlanTrabajo
                                                   (id_plan,descripcion_objetivo,activo)
                                             VALUES(@id_plan,@descripcion_objetivo,@)
                                            SELECT SCOPE_IDENTITY();";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_plan", idPlan);
            sqlCommand.Parameters.AddWithValue("@descripcion_objetivo", objetivo.descripcion);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            sqlConnection.Open();
            int idObjetivo = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return idObjetivo;
        }


        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: actualiza un objetivo asociado a un plan de trabajo
        /// Requiere: Objetivo, Id Plan
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <returns> - </returns>
        public void actualizarObjetivo(Objetivo objetivo)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.ObjetivoPlanTrabajo
                                                   SET descripcion_objetivo = @descripcion_objetivo
                                                      , activo = @activo                                           
                                              WHERE id_objetivo = @id_objetivo ";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_objetivo",objetivo.idObjetivo);
            sqlCommand.Parameters.AddWithValue("@descripcion_objetivo", objetivo.descripcion);          
            sqlCommand.Parameters.AddWithValue("@activo", true);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();        
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: elimina un objetivo asociado a un plan de trabajo
        /// Requiere: Objetivo, Id Plan, Funcionario
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <returns> - </returns>
        public void eliminarObjetivo(Objetivo objetivo, Funcionario funcionario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.ObjetivoPlanTrabajo
                                                   SET activo = @activo                                           
                                              WHERE id_objetivo = @id_objetivo ";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_objetivo", objetivo.idObjetivo);
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            bitacora.insertarBitacoraAccion("Eliminar", "Objetivo", objetivo.idObjetivo, 0, funcionario.nombreCompleto);
        }


    }
}
