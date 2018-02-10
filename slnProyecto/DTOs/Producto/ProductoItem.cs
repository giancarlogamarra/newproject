using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Proveedor
{
   public class ProductoItem
    {
        public Guid ID { get; set; }
        public string CODIGO { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public string CODIGO_PROVEEDOR { get; set; }
    }
}
