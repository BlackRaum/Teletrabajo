using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class HorarioDatos
    {
        #region Variables globales
        private ConexionDatos conexion = new ConexionDatos();
        private BitacoraAccionesDatos bitacora = new BitacoraAccionesDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 07/10/2018
        /// Efecto: devuelve una lista de Horario según solictud de teletrabajo
        /// Requiere: id Solicitud
        /// Modifica: -
        /// Devuelve: Lista de Horario 
        /// </summary>
        /// <returns> List<Horario> </returns>
        public List<Horario> getHorarios(int idSolicitud)
        {
            List<Horario> listaHorarios = new List<Horario>();

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"SELECT HO.id_horario,HO.hora_entrada,HO.hora_salidad,HO.tipo_jornada,HO.otros_senalamientos
                                                  ,HO.lunes,HO.martes,HO.miercoles,HO.jueves,HO.viernes,HO.sabado,HO.domingo      
                                            FROM Teletrabajo.dbo.Horario HO INNER JOIN SolicitudTeletrabajo ST ON HO.id_horario = ST.id_horario
                                            WHERE ST.id_solicitud = @id_solicitud and HO.activo = @activo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_solicitud", idSolicitud);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Horario horario = new Horario
                {
                    idHorario = Convert.ToInt16(reader["id_horario"].ToString()),
                    lunes = Convert.ToBoolean(reader["lunes"].ToString()),
                    martes = Convert.ToBoolean(reader["martes"].ToString()),
                    miercoles = Convert.ToBoolean(reader["miercoles"].ToString()),
                    jueves = Convert.ToBoolean(reader["jueves"].ToString()),
                    viernes = Convert.ToBoolean(reader["viernes"].ToString()),
                    sabado = Convert.ToBoolean(reader["sabado"].ToString()),
                    domingo = Convert.ToBoolean(reader["domingo"].ToString()),
                    tipoJornada = reader["tipo_jornada"].ToString(),
                    horaEntrada = reader["hora_entrada"].ToString(),
                    horaSalidad = reader["hora_salidad"].ToString(),
                    otrosSenalamientos = reader["otros_senalamientos"].ToString(),
                };

                listaHorarios.Add(horario);
            }

            sqlConnection.Close();

            return listaHorarios;
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 07/10/2018
        /// Efecto: ingresa la información de un horario a la bd
        /// Requiere: Entregable, id Meta
        /// Modifica: -
        /// Devuelve: Id Entregable
        /// </summary>
        /// <returns> int </returns>
        public int insertarHorario(Horario horario)
        {

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();


            String consulta = @"INSERT INTO dbo.Horario(hora_entrada,hora_salidad,tipo_jornada,otros_senalamientos
                                                                                    ,lunes,martes,miercoles,jueves,viernes,sabado,domingo,activo)
                                            VALUES(@hora_entrada,@hora_salidad,@tipo_jornada,@otros_senalamientos,
                                                        @lunes,@martes,@miercoles,@jueves,@viernes,@sabado,@domingo,@activo)
                                            SELECT SCOPE_IDENTITY();";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@hora_entrada", horario.horaEntrada);
            sqlCommand.Parameters.AddWithValue("@hora_salidad", horario.horaSalidad);
            sqlCommand.Parameters.AddWithValue("@tipo_jornada", horario.tipoJornada);
            sqlCommand.Parameters.AddWithValue("@otros_senalamientos", horario.otrosSenalamientos);
            sqlCommand.Parameters.AddWithValue("@lunes", horario.lunes);
            sqlCommand.Parameters.AddWithValue("@martes", horario.martes);
            sqlCommand.Parameters.AddWithValue("@miercoles", horario.miercoles);
            sqlCommand.Parameters.AddWithValue("@jueves", horario.jueves);
            sqlCommand.Parameters.AddWithValue("@viernes", horario.viernes);
            sqlCommand.Parameters.AddWithValue("@sabado", horario.sabado);
            sqlCommand.Parameters.AddWithValue("@domingo", horario.domingo);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            sqlConnection.Open();
            int idHorario = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return idHorario;
        }


        /// <summary>
        /// Fabián Quirós Masís
        /// 03/10/2018
        /// Efecto: actualiza un horario asociado a una solicitud de teletrabajo
        /// Requiere: Horario,  idSolicitud,  usuario
        /// Modifica: Horario
        /// Devuelve: idEquipo
        /// </summary>
        /// <returns> int </returns>
        public int actualizarHorario(Horario horario, String usuario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.Horario
                                               SET activo = @activo
                                            WHERE id_horario = @id_horario";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_horario", horario.idHorario);
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            int idHorario = insertarHorario(horario);

            bitacora.insertarBitacoraAccion("Actualizar", "Horario", horario.idHorario, idHorario, usuario);

            return idHorario;
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 07/10/2018
        /// Efecto: elimina un horario asociado a una solicitud de teletrabajo
        /// Requiere: Horario,  usuario
        /// Modifica: Horario
        /// Devuelve: -
        /// </summary>
        /// <returns> - </returns>
        public void eliminarHorario(Horario horario, String usuario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.Horario
                                               SET activo = @activo
                                            WHERE id_horario = @id_horario";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_horario", horario.idHorario);
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            bitacora.insertarBitacoraAccion("Eliminar", "Horario", horario.idHorario, 0, usuario);
        }
    }
}
