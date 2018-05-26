using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Almacen
{
    public  interface IAlmacenCommandsHandler
    {
        int MOVER_ALMACEN_A_TIENDA(Guid ID_PRODUCTO,string USUARIO);
    }
}
