using DTOs.Venta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Ventas
{
    public interface IVentasCommandsHandler
    {
        int ADD(List<VentaItem> ventas);
    }
}
