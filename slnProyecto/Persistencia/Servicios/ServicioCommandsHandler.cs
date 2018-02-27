using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Servicio;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia.Servicios
{
    public class ServicioCommandsHandler : IServicioCommandsHandler
    {
        public int ADD(ServicioItem product)
        {
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                conn.OpenAsync();
                var query = $@"INSERT INTO [solucionsmart_ggamarra].[sport.TSERVICIOS]
                               ([ID]
                               ,[DESCRIPCION]
                               ,[TIPO_ID]
                               ,[FECHA_SOLICITUD]
                               ,[FECHA_ENTREGA]
                               ,[CANTIDAD]
                               ,[COSTO_TOTAL]
                               ,[ADELANTO]
                               ,[CANCELADO]
                               ,[ESTADO]
                               ,[USUARIO_CREACION]
                               ,[FECHA_CREACION])
                         VALUES
                               (@ID
                               ,@DESCRIPCION
                               ,@TIPO_ID
                               ,@FECHA_SOLICITUD
                               ,@FECHA_ENTREGA
                               ,@CANTIDAD
                               ,@COSTO_TOTAL
                               ,@ADELANTO
                               ,@CANCELADO
                               ,@ESTADO
                               ,@USUARIO_CREACION
                               ,@FECHA_CREACION)";
                var c = new SqlCommand(query, conn);
                c.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = Guid.NewGuid();
                c.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = product.DESCRIPCION;
                c.Parameters.Add("@TIPO_ID", SqlDbType.UniqueIdentifier).Value = product.TIPO_ID;
                c.Parameters.Add("@FECHA_SOLICITUD", SqlDbType.DateTime).Value = product.FECHA_SOLICITUD;
                c.Parameters.Add("@FECHA_ENTREGA", SqlDbType.DateTime).Value = product.FECHA_ENTREGA;
                c.Parameters.Add("@CANTIDAD", SqlDbType.Int).Value = product.CANTIDAD;
                c.Parameters.Add("@COSTO_TOTAL", SqlDbType.Decimal).Value = product.COSTO_TOTAL;
                c.Parameters.Add("@ADELANTO", SqlDbType.Decimal).Value = product.ADELANTO;
                c.Parameters.Add("@CANCELADO", SqlDbType.Bit).Value = product.CANCELADO;
                c.Parameters.Add("@ESTADO", SqlDbType.Bit).Value = true;
                c.Parameters.Add("@USUARIO_CREACION", SqlDbType.VarChar,50).Value = product.USUARIO;
                c.Parameters.Add("@FECHA_CREACION", SqlDbType.DateTime).Value = DateTime.Now;

                return c.ExecuteNonQuery();
            }
        }
    }
}
