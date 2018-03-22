using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Reportes;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace Persistencia.Reportes
{
    public class ReportesCommandsHandler : IReportesCommandsHandler
    {
        public IEnumerable<SP_REP_INGRESOS> GET_REP_INGRESOS(int anio, int mes,string fecha_reporte)
        {
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
              
               /* var query = $@"SELECT p.CODIGO, p.NOMBRE ,v.FECHA_VENTA,sum(v.CANTIDAD) AS CANTIDAD, SUM(v.PRECIO_VENTA_DSCTO) AS PRECIO_VENTA_DSCTO
	                            from [solucionsmart_ggamarra].[sport.TPRODUCTOS] p
	                            inner join [solucionsmart_ggamarra].[sport.VENTAS] v on p.ID=v.PRODUCTO_ID
	                            GROUP BY p.CODIGO, p.NOMBRE,v.FECHA_VENTA";*/
                var query = conn.Query<SP_REP_INGRESOS>("[solucionsmart_ggamarra].[SP_REP_INGRESOS]", new { ANIO = anio, MES= mes, FECHA_REPORTE=fecha_reporte },
                commandType: CommandType.StoredProcedure);

                conn.Close();
                return query;
            }
        }

        public IEnumerable<SP_REP_INGRESOS> GET_REP_INGRESOS_DIARIO(DateTime fecha, string fecha_reporte)
        {
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                var query = conn.Query<SP_REP_INGRESOS>("[solucionsmart_ggamarra].[SP_REP_INGRESOS_DIARIO]", new { FECHA_CONSULTA = fecha, FECHA_REPORTE = fecha_reporte },
                commandType: CommandType.StoredProcedure);

                conn.Close();
                return query;
            }
        }
    }
}
