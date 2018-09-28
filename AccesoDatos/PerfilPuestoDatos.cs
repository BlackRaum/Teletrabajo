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

            SqlConnection sqlconnection = conexion.conexionTeletrabajo();

            String consulta = @"SELECT teletrabajable,controles_internos,porcentaje,supervision,factibilidad_teletrabajo
                                                  ,teletrabajable_jefe,controles_internos_jefe,porcentaje_jefe,supervision_jefe
                                                  ,consideraciones_puesto_jefe,factibilidad_teletrabajo_jefe,observaciones_jefe
                                                  ,resultado_teletrabajable,resultado_control_internos,resultado_porcentaje
                                                  ,resultado_supervision,resultado_factibilidad,aprobacion_rrhh
                                            FROM dbo.PerfilPuesto
                                            WHERE id_funcionario = @id_funcionario and activo = @activo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlconnection);
            sqlCommand.Parameters.AddWithValue("@id_funcionario", idFuncionario);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            SqlDataReader reader;
            sqlconnection.Open();
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

            sqlconnection.Close();

            return perfilPuesto;
        }
    }
}
