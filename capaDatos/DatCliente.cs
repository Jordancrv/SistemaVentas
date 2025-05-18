using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using capaEntidad;

namespace capaDatos
{
    public class DatCliente
    {
        #region Singleton


        private static readonly DatCliente UnicaInstancia = new DatCliente();
        public static DatCliente Instancia
        {
            get
            {
                return DatCliente.UnicaInstancia;
            }
        }


        #endregion Singleton


        #region Metodos


        public List<EntCliente> ListarCliente()
        {
            SqlCommand cmd = null;
            List<EntCliente> lista = new List<EntCliente>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EntCliente c = new EntCliente();
                    c.idCliente = Convert.ToInt32(dr["idCliente"]);
                    c.rucCliente = Convert.ToString(dr["rucCliente"]);
                    c.razonSocial = Convert.ToString(dr["razonSocial"]);
                    c.dirCliente = Convert.ToString(dr["dirCliente"]);
                    c.idCiudad = Convert.ToInt32(dr["idCiudad"]);
                    c.idTipoCliente = Convert.ToInt32(dr["idTipoCliente"]);
                    c.idEstCliente = Convert.ToInt32(dr["idEstCliente"]);
                    lista.Add(c);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { 
                cmd.Connection.Close();
            }
            return lista;
        }

        public bool InsertarCliente(EntCliente ec)
        {
            SqlCommand cmd = null;
            bool insertar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarCliente",cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rucCliente",ec.rucCliente);
                cmd.Parameters.AddWithValue("@razonSocial", ec.razonSocial);
                cmd.Parameters.AddWithValue("@dirCliente", ec.dirCliente);
                cmd.Parameters.AddWithValue("@idCiudad", ec.idCiudad);
                cmd.Parameters.AddWithValue("@idTipoCliente", ec.idTipoCliente);
                cmd.Parameters.AddWithValue("@idEstCliente", ec.idEstCliente);
                cn.Open();
                int filasAfectadas = Convert.ToInt32(cmd.ExecuteScalar());
                if(filasAfectadas > 0)
                {
                    insertar = true;
                }
            }
            catch (Exception ex)
            { throw ex; }
            return insertar;
        }

        public EntCliente BuscarCliente(int idcliente)
        {
            SqlCommand cmd = null;
            SqlConnection cn = Conexion.Instancia.Conectar();
            EntCliente cliente = null;
            try
            {
                cmd = new SqlCommand("spBuscarClientePorId", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", idcliente);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    cliente = new EntCliente()
                    {
                        idCliente = Convert.ToInt32(dr["idCliente"]),                  
                        rucCliente = dr["rucCliente"].ToString(),
                        razonSocial = dr["razonSocial"].ToString(),
                        dirCliente = dr["dirCliente"].ToString(),
                        idCiudad = Convert.ToInt32(dr["idCiudad"]),
                        idTipoCliente = Convert.ToInt32(dr["idTipoCliente"]),
                        idEstCliente = Convert.ToInt32(dr["idEstCliente"]),
                        fecCreacion = Convert.ToDateTime(dr["fecCreacion"])
                    };
                }
                dr.Close();
            }
            catch (Exception ex) { throw ex; }
            finally 
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();

                cmd?.Dispose();
            }
            return cliente;
        }

        public bool EditarCliente(EntCliente ec)
        {
            SqlCommand cmd = null;
            bool editado = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idCliente", ec.idCliente);
                cmd.Parameters.AddWithValue("@rucCliente", ec.rucCliente);
                cmd.Parameters.AddWithValue("@razonSocial", ec.razonSocial);
                cmd.Parameters.AddWithValue("@dirCliente", ec.dirCliente);
                cmd.Parameters.AddWithValue("@idCiudad", ec.idCiudad);
                cmd.Parameters.AddWithValue("@idTipoCliente", ec.idTipoCliente);
                cmd.Parameters.AddWithValue("@idEstCliente", ec.idEstCliente);

                cn.Open();
                int filas = cmd.ExecuteNonQuery();
                editado = filas > 0;

            }
            catch (Exception ex) { throw ex; }
            finally
            {
                if (cmd != null && cmd.Connection.State == ConnectionState.Open)
                    cmd.Connection.Close();
            }
            return editado;
        }

        #endregion Metodos
    }
}
