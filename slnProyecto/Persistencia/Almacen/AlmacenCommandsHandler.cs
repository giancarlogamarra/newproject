using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Almacen
{
    public class AlmacenCommandsHandler : IAlmacenCommandsHandler
    {
        async Task<int> IAlmacenCommandsHandler.MOVER_ALMACEN_A_TIENDA(Guid ID_PRODUCTO, string USUARIO)
        {
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                await conn.OpenAsync();
                var query = $@"UPDATE [solucionsmart_ggamarra].[sport.TPRODUCTOS]
                           SET [STOCK_ACTUAL_TIENDA] = [STOCK_ACTUAL_TIENDA]+1
                              ,[USUARIO_MODIFICACION] = @USUARIO_MODIFICACION
                              ,[FECHA_MODIFICACION] = @FECHA_MODIFICACION
                         WHERE [ID]='{ID_PRODUCTO}'";
                var c = new SqlCommand(query, conn);
                c.Parameters.Add("@USUARIO_MODIFICACION", SqlDbType.VarChar, 500).Value = USUARIO;
                c.Parameters.Add("@FECHA_MODIFICACION", SqlDbType.DateTime).Value = DateTime.Now;


                return await c.ExecuteNonQueryAsync();
 
            }
        }
    }
}
