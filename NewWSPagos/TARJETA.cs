using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewWSPagos
{
    class TARJETA
    {
        public int cod_seguridad { get; set; }
        public int num_tarjeta { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public int mes { get; set; }
        public int anyo { get; set; }
        public int monto { get; set; }
    }
}
