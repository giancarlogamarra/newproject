using DTOs.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Servicios
{
    public interface IServicioCommandsHandler
    {
        Task<IEnumerable<ServicioItem>> GET(string search);
        int ADD(ServicioItem product);
        int UPDATE(ServicioItem product);
    }
}
