using DTOs.Caracteristicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Caracteristica
{
    public interface ICaracteristicaCommandsHandler
    {
        Task<IEnumerable<CaracteristicaItem>> GET(string search);
        int UPDATE(CaracteristicaItem caracteristica);
        int ADD(CaracteristicaItem caracteristica);
        int DELETE(Guid ID);
    }
}
