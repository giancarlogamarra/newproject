using DTOs.Proveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Proveedor
{
    public interface IProveedorCommandsHandler
    {
        Task< IEnumerable<ProveedorItem>> GET();
        int UPDATE(ProveedorItem product);
        int ADD(ProveedorItem product);
        int DELETE(Guid ID);
    }
}
