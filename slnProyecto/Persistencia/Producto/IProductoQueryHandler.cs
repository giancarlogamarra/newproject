using DTOs.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Producto
{
    public interface IProductoQueryHandler
    {
        Task<IEnumerable<ProductoItem>> GET();
    }
}
