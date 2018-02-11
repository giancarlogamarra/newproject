using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Proveedor
{
   public class ProveedorItem
    {
        public Guid ID { get; set; }
        public string NOMBRE { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO_FIJO { get; set; }
        public string TELEFONO_CELULAR { get; set; }
        public bool  ESTADO { get; set; }
        public string USUARIO_CREACION { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public string USUARIO_MODIFICACION { get; set; }
        public DateTime FECHA_MODIFICACION{ get; set; }
        
    }
}
