using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using capaEntidad;

namespace capaLogica
{
    public class LogCliente
    {
        #region Singleton


        private static readonly LogCliente UnicaInstancia = new LogCliente();
        public static LogCliente Instancia
        {
            get
            {
                return LogCliente.UnicaInstancia;
            }
        }


        #endregion Singleton


        #region Metodos


        public List<EntCliente> ListarCliente(){

            List<EntCliente> lista = DatCliente.Instancia.ListarCliente();
            return lista;
        }

        public bool InsertarCliente(EntCliente ec)
        {
            return DatCliente.Instancia.InsertarCliente(ec);
        }

        public EntCliente BuscarCliente (int idCliente)
        {
            return DatCliente.Instancia.BuscarCliente(idCliente);
        }

        public bool EditarCliente(EntCliente entCliente)
        {
            return DatCliente.Instancia.EditarCliente(entCliente);
        }

        #endregion Metodos

    }
}
