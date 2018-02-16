using DTOs.Producto;
using DTOs.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Compras
{
    public interface IComprasCommandsHandler
    {
        int ADD(List<CompraItem> compras,string nrocomprobante);
        bool COMPRA_EXISTE(string nrocomprobante);
    }
}
