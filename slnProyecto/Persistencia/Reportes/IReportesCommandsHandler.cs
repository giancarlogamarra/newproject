using DTOs.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Reportes
{
    public interface IReportesCommandsHandler
    {
        IEnumerable<SP_REP_INGRESOS> GET_REP_INGRESOS();

    }
}
