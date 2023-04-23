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
    public class CD_Facademica
    {
        public List<Formacion_academica> Listar()
        {
            List<Formacion_academica> lista = new List<Formacion_academica>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    string query = "select * from FORMACION_ACADEMICA";


                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    //SqlDataReader: nos ayuada a leer el resultado del query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Formacion_academica()
                                {
                                    IdFormacionAcademica = Convert.ToInt32(dr["IdFormacionAcademica"]),
                                    CargoAspira = dr["CargoAspira"].ToString(),
                                    EducacionBasica = dr["EducacionBasica"].ToString(),
                                    TituloObtenido = dr["TituloObtenido"].ToString(),
                                    MesGrado = dr["MesGrado"].ToString(),
                                    AnoGrado = dr["AnoGrado"].ToString(),
                                    InstituEducativa = dr["InstituEducativa"].ToString(),
                                    ModalidadAcademica = dr["ModalidadAcademica"].ToString(),
                                    SemestresAprobados = Convert.ToInt32(dr["SemestresAprobados"]),
                                    Graduado = dr["Graduado"].ToString(),
                                    NombreTitulo = dr["NombreTitulo"].ToString(),
                                    MesTermino = dr["MesTermino"].ToString(),
                                    Ano = dr["Ano"].ToString(),                     
                                    NTarjetaProfecional = dr["NTarjetaProfecional"].ToString(),
                                    NombreInstitucion = dr["NombreInstitucion"].ToString(),                                  
                                }
                            );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Formacion_academica>();
            }
            return lista;
        }

        public int RegistrarFormacion(Formacion_academica obj, out string Mensaje)
        {

            int idautogenerado = 0;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("insertformacionacademica", oconexion);

                    cmd.Parameters.AddWithValue("CargoAspira", obj.CargoAspira);
                    cmd.Parameters.AddWithValue("EducacionBasica", obj.EducacionBasica);
                    cmd.Parameters.AddWithValue("TituloObtenido", obj.TituloObtenido);
                    cmd.Parameters.AddWithValue("MesGrado", obj.MesGrado);
                    cmd.Parameters.AddWithValue("AnoGrado", obj.AnoGrado);
                    cmd.Parameters.AddWithValue("InstituEducativa", obj.InstituEducativa);
                    cmd.Parameters.AddWithValue("ModalidadAcademica", obj.ModalidadAcademica);
                    cmd.Parameters.AddWithValue("SemestresAprobados", obj.SemestresAprobados);
                    cmd.Parameters.AddWithValue("Graduado", obj.Graduado);
                    cmd.Parameters.AddWithValue("NombreTitulo", obj.NombreTitulo);
                    cmd.Parameters.AddWithValue("MesTermino", obj.MesTermino);
                    cmd.Parameters.AddWithValue("Ano", obj.Ano);
                    cmd.Parameters.AddWithValue("NTarjetaProfecional", obj.NTarjetaProfecional);
                    cmd.Parameters.AddWithValue("NombreInstitucion", obj.NombreInstitucion);
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

        public bool EditarFormacion(Formacion_academica obj , out String Mensaje)
        {

            bool resultado = false;
            Mensaje = String.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ActualizarF_Academica", oconexion);

                    cmd.Parameters.AddWithValue("IdFormacionAcademica", obj.IdFormacionAcademica);
                    cmd.Parameters.AddWithValue("CargoAspira", obj.CargoAspira);
                    cmd.Parameters.AddWithValue("EducacionBasica", obj.EducacionBasica);
                    cmd.Parameters.AddWithValue("TituloObtenido", obj.TituloObtenido);
                    cmd.Parameters.AddWithValue("MesGrado", obj.MesGrado);
                    cmd.Parameters.AddWithValue("AnoGrado", obj.AnoGrado);
                    cmd.Parameters.AddWithValue("InstituEducativa", obj.InstituEducativa);
                    cmd.Parameters.AddWithValue("ModalidadAcademica", obj.ModalidadAcademica);
                    cmd.Parameters.AddWithValue("SemestresAprobados", obj.SemestresAprobados);
                    cmd.Parameters.AddWithValue("Graduado", obj.Graduado);
                    cmd.Parameters.AddWithValue("NombreTitulo", obj.NombreTitulo);
                    cmd.Parameters.AddWithValue("MesTermino", obj.MesTermino);
                    cmd.Parameters.AddWithValue("Ano", obj.Ano);
                    cmd.Parameters.AddWithValue("NTarjetaProfecional", obj.NTarjetaProfecional);
                    cmd.Parameters.AddWithValue("NombreInstitucion", obj.NombreInstitucion);
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;

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
