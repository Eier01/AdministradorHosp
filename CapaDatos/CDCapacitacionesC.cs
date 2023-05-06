using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public  class CD_CapacitacionesC
    {
        public List<CapacitacionesC> Listar()
        {
            List<CapacitacionesC> lista = new List<CapacitacionesC>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    string query = "select * from CAPACITACIONE_CURSOS";


                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    //SqlDataReader: nos ayuada a leer el resultado del query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new CapacitacionesC()
                                {
                                    idCapacitacionesCursos = Convert.ToInt32(dr["idCapacitacionesCursos"]),
                                    TipoFormacion = dr["TipoFormacion"].ToString(),
                                    Nombre = dr["Nombre"].ToString(),
                                    EstadoFormacion = dr["EstadoFormacion"].ToString(),
                                    FechaInicio = dr["FechaInicio"].ToString(),
                                    FechaFinalizacion = dr["FechaFinalizacion"].ToString(),
                                    Archivo = dr["Archivo"].ToString(),

                                }

                            );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<CapacitacionesC>();
            }


            return lista;
        }

        public int RegistrarCursos(CapacitacionesC obj, out string Mensaje)
        {

            int idautogenerado = 0;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("insertcapacitacionesocursos ", oconexion);

                    cmd.Parameters.AddWithValue("TipoFormacion", obj.TipoFormacion);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("EstadoFormacion", obj.EstadoFormacion);
                    cmd.Parameters.AddWithValue("FechaInicio", obj.FechaInicio);
                    cmd.Parameters.AddWithValue("FechaFinalizacion", obj.FechaFinalizacion);
                    cmd.Parameters.AddWithValue("Archivo", obj.Archivo); 


                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();


                }

            }
            catch (Exception ex)
            {
                idautogenerado = 0;
                Mensaje = ex.Message;


            }
            return idautogenerado;


        }

        public bool EditarCursos(CapacitacionesC obj, out String Mensaje)
        {

            bool resultado = false;
            Mensaje = String.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ActualizarCapacitacionesC", oconexion);

                    cmd.Parameters.AddWithValue("TipoFormacion", obj.TipoFormacion);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("EstadoFormacion", obj.EstadoFormacion);
                    cmd.Parameters.AddWithValue("FechaInicio", obj.FechaInicio);
                    cmd.Parameters.AddWithValue("FechaFinalizacion", obj.FechaFinalizacion);
                    cmd.Parameters.AddWithValue("Archivo", obj.Archivo);

                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;

            }
            return resultado;

        }
    }
}
