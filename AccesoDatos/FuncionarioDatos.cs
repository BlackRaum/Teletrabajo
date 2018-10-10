using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class FuncionarioDatos
    {
        #region Variables globales
        private ConexionDatos conexion = new ConexionDatos();
        private BitacoraAccionesDatos bitacora = new BitacoraAccionesDatos();
        #endregion

        /// <summary>
        /// Fabián Quirós Masís
        /// 24/09/2018
        /// Efecto: devuelve un funcionario 
        /// Requiere: idFuncionario
        /// Modifica: -
        /// Devuelve: Funcionario
        /// </summary>
        /// <returns> Funcionario </returns>
        public Funcionario getFuncionario(int idFuncionario)
        {
            Funcionario funcionario = new Funcionario();           

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"SELECT *
                                            FROM dbo.Funcionario
                                            WHERE id_funcionario = @id_funcionario and activo = @activo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_funcionario", idFuncionario);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                funcionario.jefe.idFuncionario = Convert.ToInt16(reader["id_jefe"].ToString());
                funcionario.numeroIdentificacion = reader["numero_identificacion"].ToString();
                funcionario.nombreCompleto = reader["nombre_completo"].ToString();
                funcionario.nombramiento = reader["nombramiento"].ToString();
                funcionario.cargo = reader["cargo"].ToString();
                funcionario.telefonoFijo = reader["telefono_fijo"].ToString();
                funcionario.telefonoCelular = reader["telefono_celular"].ToString();
                funcionario.correoElectronico = reader["correo_electronico"].ToString();
                funcionario.provincia = reader["provincia"].ToString();
                funcionario.canton = reader["canton"].ToString();
                funcionario.distrito = reader["distrito"].ToString();
                funcionario.direccion = reader["direccion"].ToString();
                funcionario.unidadTrabajo.idUnidad = Convert.ToInt16(reader["id_unidad"].ToString());
                funcionario.datosCompletos = Convert.ToBoolean(reader["datos_completos"].ToString());                
                funcionario.isJefe = Convert.ToBoolean(reader["jefe"].ToString());

            }

            sqlConnection.Close();

            return funcionario;            
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 24/09/2018
        /// Efecto: devuelve un funcionario 
        /// Requiere: idFuncionario
        /// Modifica: -
        /// Devuelve: Funcionario
        /// </summary>
        /// <returns> Funcionario </returns>
        public List<Funcionario> getFuncionarios()
        {
            List<Funcionario> listaFuncionarios = new List<Funcionario>();

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"SELECT *
                                            FROM dbo.Funcionario
                                            WHERE  activo = @activo";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            SqlDataReader reader;
            sqlConnection.Open();
            reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Funcionario funcionario = new Funcionario();
                funcionario.jefe.idFuncionario = Convert.ToInt16(reader["id_jefe"].ToString());
                funcionario.numeroIdentificacion = reader["numero_identificacion"].ToString();
                funcionario.nombreCompleto = reader["nombre_completo"].ToString();
                funcionario.nombramiento = reader["nombramiento"].ToString();
                funcionario.cargo = reader["cargo"].ToString();
                funcionario.telefonoFijo = reader["telefono_fijo"].ToString();
                funcionario.telefonoCelular = reader["telefono_celular"].ToString();
                funcionario.correoElectronico = reader["correo_electronico"].ToString();
                funcionario.provincia = reader["provincia"].ToString();
                funcionario.canton = reader["canton"].ToString();
                funcionario.distrito = reader["distrito"].ToString();
                funcionario.direccion = reader["direccion"].ToString();
                funcionario.unidadTrabajo.idUnidad = Convert.ToInt16(reader["id_unidad"].ToString());
                funcionario.datosCompletos = Convert.ToBoolean(reader["datos_completos"].ToString());
                funcionario.isJefe = Convert.ToBoolean(reader["jefe"].ToString());

                listaFuncionarios.Add(funcionario);
            }

            sqlConnection.Close();

            return listaFuncionarios;
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 24/09/2018
        /// Efecto: inserta un funcionario en la bd
        /// Requiere: funcionario
        /// Modifica: -
        /// Devuelve: id del funcionario
        /// </summary>
        /// <returns> int </returns>
        public int insertarFuncionario(Funcionario funcionario)
        {

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"INSERT INTO dbo.Funcionario
                                               (id_jefe,correo_electronico,jefe,usuario,contrasena,activo)
                                            VALUES(@id_jefe,@correo_electronico,@jefe,@usuario,@contrasena,@activo)";
            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_jefe", funcionario.jefe.idFuncionario);
            sqlCommand.Parameters.AddWithValue("@correo_electronico", funcionario.correoElectronico);
            sqlCommand.Parameters.AddWithValue("@jefe", funcionario.jefe);
            sqlCommand.Parameters.AddWithValue("@usuario", funcionario.usuario);
            sqlCommand.Parameters.AddWithValue("@contrasena", funcionario.password);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            sqlConnection.Open();
            int idFuncionario = Convert.ToInt32(sqlCommand.ExecuteScalar());
            sqlConnection.Close();

            return idFuncionario;
        }

        /// <summary>
        /// Fabián Quirós Masís
        /// 24/09/2018
        /// Efecto: actualiza la información un funcionario en la bd
        /// Requiere: funcionario
        /// Modifica: -
        /// Devuelve: -
        /// </summary>
        /// <returns> - </returns>
        public void actualizarFuncionario(Funcionario funcionario)
        {

            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.Funcionario
                                           SET numero_identificacion = @numero_identificacion
                                              ,nombre_completo = @nombre_completo
                                              ,nombramiento = @nombramiento
                                              ,cargo = @cargo
                                              ,telefono_fijo = @telefono_fijo
                                              ,telefono_celular = @telefono_celular                                                                                          
                                              ,provincia = @provincia
                                              ,canton = @canton
                                              ,distrito = @distrito
                                              ,direccion = @direccion
                                              ,id_unidad = @id_unidad
                                              ,datos_completos = @datos_completos     
                                              ,activo = @activo
                                         WHERE id_funcionario = @id_funcionario";

            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id_funcionario", funcionario.idFuncionario);
            sqlCommand.Parameters.AddWithValue("@numero_identificacion", funcionario.numeroIdentificacion);
            sqlCommand.Parameters.AddWithValue("@nombre_completo", funcionario.nombreCompleto);
            sqlCommand.Parameters.AddWithValue("@nombramiento", funcionario.nombramiento);
            sqlCommand.Parameters.AddWithValue("@cargo", funcionario.cargo);
            sqlCommand.Parameters.AddWithValue("@telefono_fijo", funcionario.telefonoFijo);
            sqlCommand.Parameters.AddWithValue("@telefono_celular", funcionario.telefonoCelular);
            sqlCommand.Parameters.AddWithValue("@provincia", funcionario.provincia);
            sqlCommand.Parameters.AddWithValue("@canton", funcionario.canton);
            sqlCommand.Parameters.AddWithValue("@distrito", funcionario.distrito);
            sqlCommand.Parameters.AddWithValue("@direccion", funcionario.direccion);
            sqlCommand.Parameters.AddWithValue("@id_unidad", funcionario.unidadTrabajo.idUnidad);
            sqlCommand.Parameters.AddWithValue("@datos_completos", funcionario.datosCompletos);
            sqlCommand.Parameters.AddWithValue("@activo", true);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();
            
        }

        /// Fabián Quirós Masís
        /// 26/09/2018
        /// Efecto: elimina la información de un aspecto de seguridad laboral
        /// Requiere: AspectoSeguridadLaboral, Funcionario     
        /// Modifica:-
        /// Devuelve:int idContactoEmergencia
        /// </summary>
        /// <returns>-</returns>
        public void eliminarFuncionario( Funcionario funcionario, String  usuario)
        {
            SqlConnection sqlConnection = conexion.conexionTeletrabajo();

            String consulta = @"UPDATE dbo.Funcionario
                                                SET activo = @
                                             WHERE id_funcionario = @id_funcionario";
            SqlCommand sqlCommand = new SqlCommand(consulta, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@id_funcionario", funcionario.idFuncionario);
            sqlCommand.Parameters.AddWithValue("@activo", false);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
            sqlConnection.Close();

            bitacora.insertarBitacoraAccion("Eliminar", "Funcionario", funcionario.idFuncionario, 0, funcionario.nombreCompleto);
        }

    }
}
