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
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                conn.OpenAsync();
                foreach (var item in ventas)
                {
                    var query = $@"INSERT INTO [solucionsmart_ggamarra].[sport.TCOMPRAS]
                                           ([ID]
                                           ,[NRO_COMPROBANTE]
                                           ,[PRODUCTO_ID]
                                           ,[PROVEEDOR_ID]
                                           ,[CANTIDAD]
                                           ,[PRECIO_COMPRA]
                                           ,[FECHA_COMPRA]
                                           ,[USUARIO_CREACION]
                                           ,[FECHA_CREACION]
                                           ,[ESTADO])
                                     VALUES
                                           (@ID
                                           ,@NRO_COMPROBANTE
                                           ,@PRODUCTO_ID
                                           ,@PROVEEDOR_ID
                                           ,@CANTIDAD
                                           ,@PRECIO_COMPRA
                                           ,@FECHA_COMPRA
                                           ,@USUARIO_CREACION
                                           ,@FECHA_CREACION
                                           ,@ESTADO)";
                    var c = new SqlCommand(query, conn);
                    c.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = Guid.NewGuid();
                    c.Parameters.Add("@PRODUCTO_ID", SqlDbType.UniqueIdentifier).Value = item.PRODUCTO_ID;
                    c.Parameters.Add("@PROVEEDOR_ID", SqlDbType.UniqueIdentifier).Value = item.PROVEEDOR_ID;
                    c.Parameters.Add("@CANTIDAD", SqlDbType.Int).Value = item.CANTIDAD;
                    c.Parameters.Add("@PRECIO_COMPRA", SqlDbType.Decimal).Value = item.PRECIO_VENTA;
                    c.Parameters.Add("@FECHA_COMPRA", SqlDbType.Date).Value = item.FECHA_VENTA;
                    c.Parameters.Add("@USUARIO_CREACION", SqlDbType.VarChar, 50).Value = "usuario";
                    c.Parameters.Add("@FECHA_CREACION", SqlDbType.DateTime).Value = DateTime.Now;
                    c.Parameters.Add("@ESTADO", SqlDbType.Bit).Value = true;
                    c.ExecuteNonQuery();

                }
                return 1;

            }
        }

    }
}
