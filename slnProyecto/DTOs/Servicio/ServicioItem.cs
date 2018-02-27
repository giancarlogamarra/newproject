using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Servicio
{
    public class ServicioItem
    {


        public Guid ID { get; set; }
        public string DESCRIPCION { get; set; }
        public Guid TIPO_ID { get; set; }
        public DateTime FECHA_SOLICITUD { get; set; }
        public DateTime FECHA_ENTREGA { get; set; }
        public int CANTIDAD { get; set; }
        public decimal COSTO_TOTAL { get; set; }
        public string USUARIO { get; set; }
        public decimal ADELANTO { get; set; }
        public bool CANCELADO { get; set; }
    }
}
