using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class PuestoTeletrabajoDatos
    {
        #region Variables globales
        private ConexionDatos conexion = new ConexionDatos();
        private BitacoraAccionesDatos bitacora = new BitacoraAccionesDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 24/09/2018
        /// Efecto: devuelve un Puesto Teletrabajo de un funcionario
        /// Requiere: idFuncionario
        /// Modifica: -
        /// Devuelve: un puesto de Teletrabajo
        /// </summary>
        /// <returns> PuestoTeletrabajo </returns>
        public PuestoTeletrabajo getPuestoTeletrabajo(int idFuncionario)
        {
            SqlConnection sqlconnection = conexion.conexionTeletrabajo();

            PuestoTeletrabajo puestoTeletrabajo = new PuestoTeletrabajo();

            String consulta = @"SELECT PT.id_funcionario,ASL.id_aspecto,ASL.descripcion,PT.cumple,PT.mejora,PT.observacion
                                            FROM dbo.PuestoTeletrabajo PT  INNER JOIN EvaluacionAspectoSeguridad ASL ON PT.id_aspecto = ASL.id_aspecto
                                            WHERE id_funcionario = @id_funcionario and PT.activo = @activo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlconnection);
            sqlCommand.Parameters.AddWithValue("@id_funcionario", idFuncionario);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            SqlDataReader reader;
            sqlconnection.Open();
            reader = sqlCommand.ExecuteReader();

            List<EvaluacionAspectoSeguridad> listaEvaluacionAspectos = new List<EvaluacionAspectoSeguridad>();
            while (reader.Read())
            {
                EvaluacionAspectoSeguridad evaluacionAspecto = new EvaluacionAspectoSeguridad();
                evaluacionAspecto.aspectoSeguridad.idAspecto = Convert.ToInt16(reader["id_aspecto"].ToString());
                evaluacionAspecto.aspectoSeguridad.descripcion = reader["descripcion"].ToString();
                evaluacionAspecto.cumple= reader["cumple"].ToString();
                evaluacionAspecto.observacion= reader["observacion"].ToString();
                evaluacionAspecto.mejora = reader["mejora"].ToString();

                listaEvaluacionAspectos.Add(evaluacionAspecto);
            }

            sqlconnection.Close();
            puestoTeletrabajo.aspectoSeguridadLaboral = listaEvaluacionAspectos;

            return puestoTeletrabajo;
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: inserta una evaluacion de un aspecto de seguridad laboral en la bd
        /// Requiere: EvaluacionAspectoSeguridad  y el id del funcionario
        /// Modifica:-
        /// Devuelve: -
        /// </summary>
        /// <returns>-</returns>
        public void insertarEvaluacionAspectoSeguridad(EvaluacionAspectoSeguridad aspectoEvaluacion, int idFuncionario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"INSERT INTO dbo.PuestoTeletrabajo
                                        (id_funcionario,id_aspecto,cumple,mejora,observacion,activo)
                                        VALUES(@id_funcionario,@id_aspecto,@cumple,@mejora,@observacion,@activo)";
            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_funcionario", idFuncionario);
            sqlCommand.Parameters.AddWithValue("@id_aspecto", aspectoEvaluacion.aspectoSeguridad.idAspecto);
            sqlCommand.Parameters.AddWithValue("@cumple", aspectoEvaluacion.cumple);
            sqlCommand.Parameters.AddWithValue("@mejora", aspectoEvaluacion.mejora);
            sqlCommand.Parameters.AddWithValue("@observacion", aspectoEvaluacion.observacion);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();
      
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: actualiza la información de un aspecto de seguridad laboral 
        /// Requiere: EvaluacionAspectoSeguridad
        /// Modifica:-
        /// Devuelve: int idAspecto
        /// </summary>
        /// <returns>int</returns>
        public void actualizarEvaluacionAspectoSeguridad(EvaluacionAspectoSeguridad aspectoEvaluacion, int idFuncionario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.EvaluacionAspectoSeguridad
                                            SET activo = @activo 
                                            WHERE  id_funcionario = @id_funcionario and id_aspecto = @id_aspecto";
            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_funcionario", idFuncionario);
            sqlCommand.Parameters.AddWithValue("@id_aspecto", aspectoEvaluacion.aspectoSeguridad.idAspecto);
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            insertarEvaluacionAspectoSeguridad(aspectoEvaluacion, idFuncionario);

        }
    }
}
