using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Producto
{
    public class CompraItem
    {
        public Guid ID { get; set; }
        public string CODIGO { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public Guid PROVEEDOR_ID { get; set; }
        public DateTime FECHA_COMPRA { get; set; }
        public int CANTIDAD { get; set; }
        public decimal PRECIO_COMPRA { get; set; }


    }
}
