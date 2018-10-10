using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class SolicitudTeletrabajoDatos
    {
        #region Variables globales
        private ConexionDatos conexion = new ConexionDatos();
        private BitacoraAccionesDatos bitacora = new BitacoraAccionesDatos();
        #endregion     

        /// <summary>
        /// Fabián Quirós Masís
        /// 07/10/2018
        /// Efecto: devuelve una solicitud de teletrabajo asociada a un funcionario
        /// Requiere: id Solicitante (id Funcionario)
        /// Modifica: -
        /// Devuelve: Solicitud de Teletrabajo 
        /// </summary>
        /// <returns> SolicitudTeletrabajo </returns>
        public SolicitudTeletrabajo getSolicitudTeletrabajo(int idSolicitante)
        {
            SolicitudTeletrabajo solicitudTeletrabajo = new SolicitudTeletrabajo();

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"SELECT *
                                             FROM dbo.SolicitudTeletrabajo
                                             WHERE id_solicitante = @id_solicitante and activo = @activo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_solicitante", idSolicitante);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                solicitudTeletrabajo.idSolicitud = Convert.ToInt16(reader["id_solicitante"].ToString());
                solicitudTeletrabajo.justificacion = reader["justificacion"].ToString();
                solicitudTeletrabajo.personalACargo = Convert.ToBoolean(reader["personal_cargo"].ToString());
                solicitudTeletrabajo.cantidadPersonal = Convert.ToInt16(reader["cantidad_personal_cargo"].ToString());
                solicitudTeletrabajo.supervisionRemotaPersonal = Convert.ToBoolean(reader["supervision_remota_personal"].ToString());
                solicitudTeletrabajo.hijos = Convert.ToBoolean(reader["hijos"].ToString());
                solicitudTeletrabajo.cantidadHijos = Convert.ToInt16(reader["cantidad_hijos"].ToString());
                solicitudTeletrabajo.edadesHijos = reader["edad_hijos"].ToString();
                solicitudTeletrabajo.acuerdoInstrumentalizacion = Convert.ToBoolean(reader["acuerdo_instrumentalizacion"].ToString());
                solicitudTeletrabajo.acuerdoInspecciones = Convert.ToBoolean(reader["acuerdo_inpecciones"].ToString());
                solicitudTeletrabajo.acuerdoEspacioFisico = Convert.ToBoolean(reader["acuerdo_espacio_fisico"].ToString());
                solicitudTeletrabajo.acuerdoMetas = Convert.ToBoolean(reader["acuerdo_metas"].ToString());
                solicitudTeletrabajo.acuerdoContrato = Convert.ToBoolean(reader["acuerdo_contrato"].ToString());
                solicitudTeletrabajo.comentarios = reader["comentarios"].ToString();
                solicitudTeletrabajo.descripcionEspacio = reader["descripcion_espacio"].ToString();
                solicitudTeletrabajo.aprobacionJefe = Convert.ToBoolean(reader["aprobacion_jefe"].ToString());
                solicitudTeletrabajo.aprobacionRRHH = Convert.ToBoolean(reader["aprobacion_rrhh"].ToString());

                solicitudTeletrabajo.horario.idHorario = Convert.ToInt16(reader["id_horario"].ToString());
                solicitudTeletrabajo.tipoDesplazamiento.idTipoDesplazamiento = Convert.ToInt16(reader["id_desplazamiento"].ToString());
                solicitudTeletrabajo.tipoTeletrabajador.idTipoTeletrabajador = Convert.ToInt16(reader["id_tipo_teletrabajador"].ToString());

            }

            sqlConnection.Close();

            return solicitudTeletrabajo;
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 07/10/2018
        /// Efecto: ingresa la información de un instrumento a la bd
        /// Requiere: SolicitudTeletrabajo, id Solicitud
        /// Modifica: -
        /// Devuelve: Id SolicitudTeletrabajo
        /// </summary>
        /// <returns> int </returns>
        public int insertarSolicitudTeletrabajo(SolicitudTeletrabajo solicitud, int idSolicitante)
        {

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();


            String consulta = @"INSERT INTO dbo.SolicitudTeletrabajo
                                                   (id_desplazamiento,id_horario,id_solicitante,id_tipo_teletrabajador,justificacion,personal_cargo
                                                   ,cantidad_personal_cargo,supervision_remota_personal,hijos,cantidad_hijos,edad_hijos
                                                   ,acuerdo_instrumentalizacion,acuerdo_inpecciones,acuerdo_espacio_fisico,acuerdo_metas,acuerdo_contrato
                                                   ,comentarios,descripcion_espacio,activo)

                                             VALUES(@id_desplazamiento,@id_horario,@id_solicitante,@id_tipo_teletrabajador,@justificacion,@personal_cargo
		                                            ,@cantidad_personal_cargo,@supervision_remota_personal,@hijos,@cantidad_hijos,@edad_hijos
		                                            ,@acuerdo_instrumentalizacion,@acuerdo_inpecciones,@acuerdo_espacio_fisico,@acuerdo_metas
		                                            ,@acuerdo_contrato,@comentarios,@descripcion_espacio, @activo)
                                             SELECT SCOPE_IDENTITY();";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_desplazamiento", solicitud.tipoDesplazamiento.idTipoDesplazamiento);
            sqlCommand.Parameters.AddWithValue("@id_horario", solicitud.horario.idHorario);
            sqlCommand.Parameters.AddWithValue("@id_solicitante", idSolicitante);
            sqlCommand.Parameters.AddWithValue("@id_tipo_teletrabajador", solicitud.tipoTeletrabajador.idTipoTeletrabajador);
            sqlCommand.Parameters.AddWithValue("@justificacion", solicitud.justificacion);
            sqlCommand.Parameters.AddWithValue("@personal_cargo", solicitud.personalACargo);
            sqlCommand.Parameters.AddWithValue("@cantidad_personal_cargo", solicitud.cantidadPersonal);
            sqlCommand.Parameters.AddWithValue("@supervision_remota_personal", solicitud.supervisionRemotaPersonal);
            sqlCommand.Parameters.AddWithValue("@hijos", solicitud.hijos);
            sqlCommand.Parameters.AddWithValue("@edad_hijos", solicitud.edadesHijos);
            sqlCommand.Parameters.AddWithValue("@acuerdo_instrumentalizacion", solicitud.acuerdoInstrumentalizacion);
            sqlCommand.Parameters.AddWithValue("@acuerdo_inpecciones", solicitud.acuerdoInspecciones);
            sqlCommand.Parameters.AddWithValue("@acuerdo_espacio_fisico", solicitud.acuerdoEspacioFisico);
            sqlCommand.Parameters.AddWithValue("@acuerdo_metas", solicitud.acuerdoMetas);
            sqlCommand.Parameters.AddWithValue("@acuerdo_contrato", solicitud.acuerdoContrato);
            sqlCommand.Parameters.AddWithValue("@comentarios", solicitud.comentarios);
            sqlCommand.Parameters.AddWithValue("@descripcion_espacio", solicitud.descripcionEspacio);          
            sqlCommand.Parameters.AddWithValue("@activo", true);

            sqlConnection.Open();
            int idInstrumento = Convert.ToInt16(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return idInstrumento;
        }


        /// <summary>
        /// Fabián Quirós Masís
        /// 07/10/2018
        /// Efecto: actualiza un equipoConexion asociado a una solicitud de teletrabajo
        /// Requiere: SolicitudTeletrabajo,  usuario
        /// Modifica: SolicitudTeletrabajo
        /// Devuelve: -
        /// </summary>
        /// <returns> - </returns>
        public void aprobacionSolicitudTeletrabajoJefe(SolicitudTeletrabajo solicitudTeletrabajo)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.SolicitudTeletrabajo
                                               SET aprobacion_jefe =@aprobacion_jefe
                                           WHERE id_solicitud = @id_solicitud";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_solicitud", solicitudTeletrabajo.idSolicitud);
            sqlCommand.Parameters.AddWithValue("@aprobacion_jefe", solicitudTeletrabajo.aprobacionJefe);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();
                      
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 07/10/2018
        /// Efecto: actualiza un equipoConexion asociado a una solicitud de teletrabajo
        /// Requiere: SolicitudTeletrabajo,  usuario
        /// Modifica: SolicitudTeletrabajo
        /// Devuelve: -
        /// </summary>
        /// <returns> - </returns>
        public void aprobacionSolicitudTeletrabajoRRHH(SolicitudTeletrabajo solicitudTeletrabajo)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.SolicitudTeletrabajo
                                               SET aprobacion_rrhh =@aprobacion_rrhh
                                           WHERE id_solicitud = @id_solicitud";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_solicitud", solicitudTeletrabajo.idSolicitud);
            sqlCommand.Parameters.AddWithValue("@aprobacion_rrhh", solicitudTeletrabajo.aprobacionRRHH);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 07/10/2018
        /// Efecto: elimina un instrumento asociado a una solicitud de teletrabajo
        /// Requiere: SolicitudTeletrabajo,  usuario
        /// Modifica: SolicitudTeletrabajo
        /// Devuelve: -
        /// </summary>
        /// <returns> - </returns>
        public void eliminarSolicitudTeletrabajo(SolicitudTeletrabajo solicitudTeletrabajo, String usuario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.SolicitudTeletrabajo
                                               SET activo = @activo
                                              WHERE id_solicitud = @id_solicitud";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_instrumento", solicitudTeletrabajo.idSolicitud);
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            bitacora.insertarBitacoraAccion("Eliminar", "SolicitudTeletrabajo", solicitudTeletrabajo.idSolicitud, 0, usuario);
        }

    }
}
