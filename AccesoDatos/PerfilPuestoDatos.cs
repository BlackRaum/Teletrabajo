using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class PerfilPuestoDatos
    {
        #region Variables globales
        private ConexionDatos conexion = new ConexionDatos();
        private BitacoraAccionesDatos bitacora = new BitacoraAccionesDatos();
        #endregion
         
        /// <summary>
        /// Fabián Quirós Masís
        /// 24/09/2018
        /// Efecto: devuelve el perfil del puesto del Funcionario
        /// Requiere: idFuncionario
        /// Modifica: -
        /// Devuelve: perfil de puesto 
        /// </summary>
        /// <returns> PerfilPuesto </returns>
        public PerfilPuesto getPerfilPuesto(int idFuncionario)
        {
            PerfilPuesto perfilPuesto = new PerfilPuesto();

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"SELECT teletrabajable,controles_internos,porcentaje,supervision,factibilidad_teletrabajo
                                                  ,teletrabajable_jefe,controles_internos_jefe,porcentaje_jefe,supervision_jefe
                                                  ,consideraciones_puesto_jefe,factibilidad_teletrabajo_jefe,observaciones_jefe
                                                  ,resultado_teletrabajable,resultado_control_internos,resultado_porcentaje
                                                  ,resultado_supervision,resultado_factibilidad,aprobacion_rrhh
                                            FROM dbo.PerfilPuesto
                                            WHERE id_funcionario = @id_funcionario and activo = @activo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_funcionario", idFuncionario);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

         
            while (reader.Read())
            {
                perfilPuesto.teletrabajable = Convert.ToBoolean(reader["teletrabajable"].ToString());
                perfilPuesto.controlesInternos = Convert.ToBoolean(reader["controles_internos"].ToString());
                perfilPuesto.porcentaje = Convert.ToInt16(reader["porcentaje"].ToString());
                perfilPuesto.supervision = Convert.ToBoolean(reader["supervision"].ToString());
                perfilPuesto.factibilidadTeletrabajo = Convert.ToBoolean(reader["factibilidad_teletrabajo"].ToString());
                
                perfilPuesto.teletrabajableJefe = Convert.ToBoolean(reader["teletrabajable_jefe"].ToString());
                perfilPuesto.controlesInternosJefe = Convert.ToBoolean(reader["controles_internos_jefe"].ToString());
                perfilPuesto.porcentajeJefe = Convert.ToInt16(reader["porcentaje_jefe"].ToString());
                perfilPuesto.supervisionJefe = Convert.ToBoolean(reader["supervision_jefe"].ToString());
                perfilPuesto.factibilidadTeletrabajoJefe = Convert.ToBoolean(reader["consideraciones_puesto_jefe"].ToString());

                perfilPuesto.teletrabajableResultado = Convert.ToInt16(reader["resultado_teletrabajable"].ToString());
                perfilPuesto.controlesInternosResultado = Convert.ToInt16(reader["resultado_control_internos"].ToString());
                perfilPuesto.porcentajeResultado = Convert.ToInt16(reader["resultado_porcentaje"].ToString());
                perfilPuesto.supervisionResultado = Convert.ToInt16(reader["resultado_supervision"].ToString());
                perfilPuesto.factibilidadTeletrabajoResultado = Convert.ToInt16(reader["resultado_factibilidad"].ToString());

                perfilPuesto.aprobacionRRHH = Convert.ToBoolean(reader["aprobacion_rrhh"].ToString());
            }

            sqlConnection.Close();

            return perfilPuesto;
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: inserta un perfil del puesto de un funcionario
        /// Requiere: PerfilPuesto  y el id del funcionario
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <returns>-</returns>
        public void insertarPerfilPuesto(PerfilPuesto perfilPuesto, int idFuncionario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"INSERT INTO dbo.PerfilPuesto
                                               (id_funcionario,teletrabajable,controles_internos,porcentaje,supervision,factibilidad_teletrabajo
                                               ,teletrabajable_jefe,controles_internos_jefe,porcentaje_jefe,supervision_jefe,consideraciones_puesto_jefe
                                               ,factibilidad_teletrabajo_jefe,observaciones_jefe,resultado_teletrabajable,resultado_control_internos
                                               ,resultado_porcentaje,resultado_supervision,resultado_factibilidad,aprobacion_rrhh,activo)
                                           VALUES(@id_funcionario,@teletrabajable,@controles_internos,@porcentaje,@supervision,@factibilidad_teletrabajo
                                                       @teletrabajable_jefe,@controles_internos_jefe,@porcentaje_jefe,@supervision_jefe@consideraciones_puesto_jefe,
                                                       @factibilidad_teletrabajo_jefe,@observaciones_jefe, @resultado_teletrabajable,@resultado_control_internos,
                                                       @resultado_porcentaje,@resultado_supervision,@resultado_factibilidad,@aprobacion_rrhh,@activo)";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_funcionario", idFuncionario);
            sqlCommand.Parameters.AddWithValue("@teletrabajable", perfilPuesto.teletrabajable);
            sqlCommand.Parameters.AddWithValue("@controles_internos", perfilPuesto.controlesInternos);
            sqlCommand.Parameters.AddWithValue("@porcentaje", perfilPuesto.porcentaje);
            sqlCommand.Parameters.AddWithValue("@supervision", perfilPuesto.supervision);
            sqlCommand.Parameters.AddWithValue("@factibilidad_teletrabajo", perfilPuesto.factibilidadTeletrabajo);
            sqlCommand.Parameters.AddWithValue("@teletrabajable_jefe", perfilPuesto.teletrabajable);
            sqlCommand.Parameters.AddWithValue("@controles_internos_jefe", perfilPuesto.controlesInternos);
            sqlCommand.Parameters.AddWithValue("@porcentaje_jefe", perfilPuesto.porcentaje);
            sqlCommand.Parameters.AddWithValue("@supervision_jefe", perfilPuesto.supervision);
            sqlCommand.Parameters.AddWithValue("@consideraciones_puesto_jefe", perfilPuesto.factibilidadTeletrabajo);
            sqlCommand.Parameters.AddWithValue("@factibilidad_teletrabajo_jefe", perfilPuesto.teletrabajable);
            sqlCommand.Parameters.AddWithValue("@resultado_teletrabajable", perfilPuesto.controlesInternos);
            sqlCommand.Parameters.AddWithValue("@resultado_control_internos", perfilPuesto.porcentaje);
            sqlCommand.Parameters.AddWithValue("@resultado_porcentaje", perfilPuesto.supervision);
            sqlCommand.Parameters.AddWithValue("@resultado_supervision", perfilPuesto.factibilidadTeletrabajo);
            sqlCommand.Parameters.AddWithValue("@resultado_factibilidad", perfilPuesto.supervision);
            sqlCommand.Parameters.AddWithValue("@aprobacion_rrhh", perfilPuesto.factibilidadTeletrabajo);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: actualiza de un perfil del puesto de un funcionario
        /// Requiere: PerfilPuesto
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <returns>-</returns>
        public void actualizarPerfilPuesto(PerfilPuesto perfilPuesto, int idFuncionario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.EvaluacionAspectoSeguridad
                                            SET activo = @activo 
                                            WHERE  id_funcionario = @id_funcionario";
            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_funcionario", idFuncionario);
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            insertarPerfilPuesto(perfilPuesto, idFuncionario);

        }
    }
}
