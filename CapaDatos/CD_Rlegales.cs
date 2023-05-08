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
    public class CD_Rlegales
    {
        public List<Rlegales> Listar()
        {
            List<Rlegales> lista = new List<Rlegales>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    string query = "select * from REQUISITOS_LEGALES";


                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    //SqlDataReader: nos ayuada a leer el resultado del query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Rlegales()
                                {
                                    IdRequisitosLegales = Convert.ToInt32(dr["IdRequisitosLegales"]),
                                    FechaExpedicion = dr["FechaExpedicion"].ToString(),
                                    Archivo = dr["Archivo"].ToString(),
                                }

                            );
                        }
                    }
                }



            }
            catch
            {
                lista = new List<Rlegales>();
            }


            return lista;
        }
        //REGISTRAR REQUISITOS LEGALES
        public int RegistrarRlegales(Rlegales obj, out string Mensaje)
        {

            int idautogenerado = 0;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("insertrequisitoslegales", oconexion);

                   
                    cmd.Parameters.AddWithValue("FechaExpedicion", obj.FechaExpedicion);
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
        //Editar Requisitos legales
        public bool EditarRlegales(Rlegales obj, out String Mensaje)
        {

            bool resultado = false;
            Mensaje = String.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ActualizarRlegales", oconexion);

                    cmd.Parameters.AddWithValue("IdRequisitosLegales", obj.IdRequisitosLegales);
                    cmd.Parameters.AddWithValue("FechaExpedicion", obj.FechaExpedicion);
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
