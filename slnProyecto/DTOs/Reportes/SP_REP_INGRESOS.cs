using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Reportes
{
    public class SP_REP_INGRESOS
    {
        public string CODIGO { get; set; }
        public string NOMBRE { get; set; }
        public DateTime FECHA_VENTA { get; set; }
        public int CANTIDAD { get; set; }
        public decimal PRECIO_VENTA_DSCTO { get; set; }

    }
}
