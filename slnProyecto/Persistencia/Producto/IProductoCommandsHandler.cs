using DTOs.Producto;
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
        Task<IEnumerable<ProductoItem>> GET(string search);
        int UPDATE(ProductoItem product);
        int ADD(ProductoItem product);
        int DELETE(Guid ID);
        Task<ProductoItem> GETPRODUCTO(string CODIGO);
        Task<int> GET_STOCK_ALMACEN(Guid PRODUCTO_ID);
        Task<int> GET_STOCK_TIENDA(Guid PRODUCTO_ID);
        Task<int> GET_VERIFICAR_STOCKS_TIENDA_ALARMA();
 
    }
}
