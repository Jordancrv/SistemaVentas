using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidad
{
    public class EntCliente
    {
        public int idCliente { get; set; }
        public string rucCliente { get; set; }
        public string razonSocial { get; set; }
        public string dirCliente { get; set; }
        public int idCiudad { get; set; }
        public int idTipoCliente { get; set; }
        public int idEstCliente { get; set; }
        public DateTime fecCreacion { get; set; }

    }
}
