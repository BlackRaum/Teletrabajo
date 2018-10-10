using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class PlanTrabajoDatos
    {
        #region Variables globales
        private ConexionDatos conexion = new ConexionDatos();
        private BitacoraAccionesDatos bitacora = new BitacoraAccionesDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: devuelve el plan de trabajo asociado a un funcionario
        /// Requiere: idFuncionario
        /// Modifica: -
        /// Devuelve: Plan de Trabajo
        /// </summary>
        /// <returns> PlanTrabajo </returns>
        public PlanTrabajo getPlanTrabajo(int idFuncionario)
        {
            PlanTrabajo planTrabajo = new PlanTrabajo();

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();


            String consulta = @"SELECT id_plan,fecha_inicio,feacha_fin,aprobacion_jefe
                                            FROM dbo.PlanTrabajo
                                            WHERE id_funcionario = @id_funcionario and activo = @activo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_funcionario", idFuncionario);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                planTrabajo.idPlan = Convert.ToInt16(reader["id_plan"].ToString());
                planTrabajo.fechaInicio = Convert.ToDateTime(reader["fecha_inicio"].ToString());
                planTrabajo.fechaFin = Convert.ToDateTime(reader["feacha_fin"].ToString());
                planTrabajo.aprobacionJefe = Convert.ToBoolean(reader["aprobacion_jefe"].ToString());
            }

            sqlConnection.Close();

            return planTrabajo;
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: devuelve el plan de trabajo asociado a un funcionario
        /// Requiere: idFuncionario
        /// Modifica: -
        /// Devuelve: Plan de Trabajo
        /// </summary>
        /// <returns> PlanTrabajo </returns>
        public int insertarPlanTrabajo(PlanTrabajo planTrabajo, int idFuncionario)
        {
         

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();


            String consulta = @"INSERT INTO dbo.PlanTrabajo
                                                        (id_funcionario,fecha_inicio,feacha_fin,activo)
                                            VALUES(@id_funcionario,@fecha_inicio,@feacha_fin,@activo)
                                             SELECT SCOPE_IDENTITY();";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_funcionario", idFuncionario);
            sqlCommand.Parameters.AddWithValue("@fecha_inicio", planTrabajo.fechaInicio);
            sqlCommand.Parameters.AddWithValue("@feacha_fin", planTrabajo.fechaFin);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            sqlConnection.Open();           
            int idPlan = Convert.ToInt32(sqlCommand.ExecuteScalar());

            sqlConnection.Close();

            return idPlan;
        }


        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: actualiza un plan de trabajo asociado a un funcionario
        /// Requiere: PlanTrabajo, idFuncionario
        /// Modifica: -
        /// Devuelve: Plan de Trabajo
        /// </summary>
        /// <returns> - </returns>
        public void actualizarPlanTrabajo(PlanTrabajo planTrabajo, int idFuncionario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.PlanTrabajo
                                                   SET fecha_inicio =@fecha_inicio
                                                      ,feacha_fin = @feacha_fin
                                                      ,aprobacion_jefe = @aprobacion_jefe
                                                      ,activo = @activo
                                             WHERE id_funcionario = @id_funcionario";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_funcionario", idFuncionario);
            sqlCommand.Parameters.AddWithValue("@fecha_inicio", idFuncionario);
            sqlCommand.Parameters.AddWithValue("@feacha_fin", idFuncionario);
            sqlCommand.Parameters.AddWithValue("@aprobacion_jefe", idFuncionario);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();            
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: devuelve el plan de trabajo asociado a un funcionario
        /// Requiere: idFuncionario
        /// Modifica: -
        /// Devuelve: Plan de Trabajo
        /// </summary>
        /// <returns> PlanTrabajo </returns>
        public void eliminarPlanTrabajo(PlanTrabajo planTrabajo, Funcionario funcionario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.PlanTrabajo
                                                   SET activo = @activo
                                             WHERE id_funcionario = @id_funcionario";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_funcionario", funcionario.idFuncionario);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            bitacora.insertarBitacoraAccion("Eliminar", "PlanTrabajo", planTrabajo.idPlan, 0, funcionario.nombreCompleto);
        }

    }
}
