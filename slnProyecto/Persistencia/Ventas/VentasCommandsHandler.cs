using Dapper;
using DTOs.Venta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Ventas
{
    public class VentasCommandsHandler: IVentasCommandsHandler
    {
        public int ADD(List<VentaItem> ventas)
        {
            Guid IDVenta=Guid.NewGuid();
            DateTime fecha_venta = DateTime.Now;
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                conn.OpenAsync();
                foreach (var item in ventas)
                {

                    var queryGetStockTienda = $@"SELECT STOCK_ACTUAL_TIENDA
                              FROM [solucionsmart_solucionsmart2].[solucionsmart_ggamarra].[sport.TPRODUCTOS]
                            WHERE [ESTADO]='1'AND ID= '{item.PRODUCTO_ID}'";

                    int nroTienda = (int)conn.ExecuteScalar(queryGetStockTienda);

                    var updateStockTienda = $@"UPDATE [solucionsmart_solucionsmart2].[solucionsmart_ggamarra].[sport.TPRODUCTOS]
                             SET  STOCK_ACTUAL_TIENDA  = {nroTienda - item.CANTIDAD}
                            WHERE [ESTADO]='1'AND ID= '{item.PRODUCTO_ID}'";

                    conn.ExecuteScalar(updateStockTienda);

                    var query = $@"INSERT INTO [solucionsmart_ggamarra].[sport.VENTAS]
                                   ([ID]
                                   ,[PRODUCTO_ID]
                                   ,[FECHA_VENTA]
                                   ,[CANTIDAD]
                                   ,[PRECIO_VENTA]
                                   ,[PRECIO_VENTA_DSCTO]
                                   ,[TOTAL]
                                   ,[USUARIO_CREACION]
                                   ,[FECHA_CREACION]
                                   ,[ESTADO])
                             VALUES
                                   (@ID
                                   ,@PRODUCTO_ID
                                   ,@FECHA_VENTA
                                   ,@CANTIDAD
                                   ,@PRECIO_VENTA
                                   ,@PRECIO_VENTA_DSCTO
                                   ,@TOTAL
                                   ,@USUARIO_CREACION
                                   ,@FECHA_CREACION
                                   ,@ESTADO)";
                    var c = new SqlCommand(query, conn);
                    c.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = IDVenta;
                    c.Parameters.Add("@PRODUCTO_ID", SqlDbType.UniqueIdentifier).Value = item.PRODUCTO_ID;
                    c.Parameters.Add("@FECHA_VENTA", SqlDbType.Date).Value = item.FECHA_VENTA;
                    c.Parameters.Add("@CANTIDAD", SqlDbType.Int).Value = item.CANTIDAD;
                    c.Parameters.Add("@PRECIO_VENTA", SqlDbType.Decimal).Value = item.PRECIO_VENTA;
                    c.Parameters.Add("@PRECIO_VENTA_DSCTO", SqlDbType.Decimal).Value = item.PRECIO_VENTA_DSCTO;
                    c.Parameters.Add("@TOTAL", SqlDbType.Decimal).Value = item.TOTAL;
                    c.Parameters.Add("@USUARIO_CREACION", SqlDbType.VarChar, 50).Value = "usuario";
                    c.Parameters.Add("@FECHA_CREACION", SqlDbType.DateTime).Value = fecha_venta;
                    c.Parameters.Add("@ESTADO", SqlDbType.Bit).Value = true;                    
                    c.ExecuteNonQuery();

                }
                return 1;

            }
        }

    }
}
