using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Producto
{
   public class ProductoItem
    {
        public Guid ID { get; set; }
        public int CODIGO { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public string CODIGO_PROVEEDOR { get; set; }
        public bool ESTADO { get; set; }
        public string USUARIO_CREACION { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public string USUARIO_MODIFICACION { get; set; }
        public DateTime FECHA_MODIFICACION { get; set; }
        public Guid PROVEEDOR_ID { get; set; }
        public decimal PRECIO_VENTA { get; set; }
        public decimal DSCTO_MAX { get; set; }
        public int ALERTA_STOCK_MIN_TIENDA { get; set; }
        public int STOCK_ACTUAL_TIENDA { get; set; }

    }
}
