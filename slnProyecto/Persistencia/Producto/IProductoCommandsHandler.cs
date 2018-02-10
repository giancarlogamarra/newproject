using DTOs.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Producto
{
    public interface IProductoCommandsHandler
    {
        IEnumerable<ProductoItem> GET();
        Task<int> UPDATE(ProductoItem product);
        Task<int> ADD(ProductoItem product);
        Task<int> DELETE(Guid ID);
    }
}
