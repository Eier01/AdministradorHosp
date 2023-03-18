//todas estas son bibliotecas
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Procesos
    {
        public List<Procesos> Listar()
        {
            List<Procesos> lista = new List<Procesos>();

            try
            {
                using(SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "select * from PROCESOS";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    //SqlDataReader: nos ayuada a leer el resultado del query
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Procesos()
                                {
                                    IdProceso = Convert.ToInt32(dr["IdProceso"]),
                                    NombreProceso = dr["NombreProceso"].ToString(),
                                }
                            );  
                        }
                    }
                }



            }
            catch
            {
                lista = new List<Procesos>();
            }


            return lista;
        }
    }
}
