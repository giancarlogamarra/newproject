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

        int ADD(ServicioItem product);
    }
}
