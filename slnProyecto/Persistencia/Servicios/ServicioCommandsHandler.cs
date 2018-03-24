using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Servicio;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace Persistencia.Servicios
{
    public class ServicioCommandsHandler : IServicioCommandsHandler
    {
        public async Task<int> GET_SERVICIOS_EN_PROCESO()
        {
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                var queryStock = $@"SELECT count(*)
                                        FROM [solucionsmart_ggamarra].[sport.TSERVICIOS] 
                                    WHERE [ESTADO]='1' and [CANCELADO]=0";
                int productos_con_alarma = await conn.QueryFirstAsync<int>(queryStock);
                conn.Close();
                return productos_con_alarma;
            }
        }

        public async Task<IEnumerable<ServicioItem>> GET(string search)
        {
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                string whereclause = "";
                if (search != "")
                    whereclause = $@" AND (s.[DESCRIPCION] like '%{search}%' or s.[CLIENTE_NOMBRE] like '%{search}%')";

                var query = $@"SELECT s.[ID]
                                  ,s.[CLIENTE_NOMBRE]
                                  ,s.[CLIENTE_TELEFONO]
                                  ,s.[DESCRIPCION]
                                  ,s.[TIPO_ID]
	                              ,c.[VALOR] as TIPOSERVICIO
                                  ,s.[FECHA_SOLICITUD]
                                  ,s.[FECHA_ENTREGA]
                                  ,s.[CANTIDAD]
                                  ,s.[COSTO_TOTAL]
                                  ,s.[ADELANTO]
                                  ,s.[CANCELADO]
                                  ,s.[ESTADO]
                                  ,s.[USUARIO_CREACION]
                                  ,s.[FECHA_CREACION]
                              FROM [solucionsmart_ggamarra].[sport.TSERVICIOS] s
                              INNER JOIN  [solucionsmart_ggamarra].[sport.CARACTERISTICAS] c ON s.[TIPO_ID]=c.[ID]
                           WHERE s.[ESTADO]='1' {whereclause}";

                var listquery = await conn.QueryAsync<ServicioItem>(query);
                conn.Close();
                return listquery;
            }
        }

        public int ADD(ServicioItem product)
        {
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                conn.OpenAsync();
                var query = $@"INSERT INTO [solucionsmart_ggamarra].[sport.TSERVICIOS]
                               ([ID]
                               ,[CLIENTE_NOMBRE]
                               ,[CLIENTE_TELEFONO]
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
                               ,@CLIENTE_NOMBRE
                               ,@CLIENTE_TELEFONO
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
                c.Parameters.Add("@CLIENTE_NOMBRE", SqlDbType.VarChar,100).Value = product.CLIENTE_NOMBRE;
                c.Parameters.Add("@CLIENTE_TELEFONO", SqlDbType.VarChar,50).Value = product.CLIENTE_TELEFONO;
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

        public int UPDATE(ServicioItem servicio)
        {
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                conn.OpenAsync();
                var query = $@"UPDATE [solucionsmart_ggamarra].[sport.TSERVICIOS]
                               SET
                                  [CLIENTE_NOMBRE] = @CLIENTE_NOMBRE
                                  ,[CLIENTE_TELEFONO] = @CLIENTE_TELEFONO
                                  ,[DESCRIPCION] =  @DESCRIPCION
                                  ,[TIPO_ID] = @TIPO_ID
                                  ,[FECHA_SOLICITUD] = @FECHA_SOLICITUD
                                  ,[FECHA_ENTREGA] = @FECHA_ENTREGA
                                  ,[CANTIDAD] = @CANTIDAD
                                  ,[COSTO_TOTAL] = @COSTO_TOTAL
                                  ,[ADELANTO] = @ADELANTO
                                  ,[CANCELADO] = @CANCELADO
                         WHERE [ID]='{servicio.ID}'";
                var c = new SqlCommand(query, conn);

                c.Parameters.Add("@CLIENTE_NOMBRE", SqlDbType.VarChar, 100).Value = servicio.CLIENTE_NOMBRE;
                c.Parameters.Add("@CLIENTE_TELEFONO", SqlDbType.VarChar, 50).Value = servicio.CLIENTE_TELEFONO;
                c.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = servicio.DESCRIPCION;
                c.Parameters.Add("@TIPO_ID", SqlDbType.UniqueIdentifier).Value = servicio.TIPO_ID;
                c.Parameters.Add("@FECHA_SOLICITUD", SqlDbType.DateTime).Value = servicio.FECHA_SOLICITUD;
                c.Parameters.Add("@FECHA_ENTREGA", SqlDbType.DateTime).Value = servicio.FECHA_ENTREGA;
                c.Parameters.Add("@CANTIDAD", SqlDbType.Int).Value = servicio.CANTIDAD;
                c.Parameters.Add("@COSTO_TOTAL", SqlDbType.Decimal).Value = servicio.COSTO_TOTAL;
                c.Parameters.Add("@ADELANTO", SqlDbType.Decimal).Value = servicio.ADELANTO;
                c.Parameters.Add("@CANCELADO", SqlDbType.Bit).Value = servicio.CANCELADO;
                return c.ExecuteNonQuery();
            }


        }

        public int DELETE(Guid ID)
        {

            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                conn.OpenAsync();
                var query = $@"UPDATE [solucionsmart_ggamarra].[sport.TSERVICIOS]
                           SET [ESTADO] = '0'
                         WHERE [ID]='{ID}'";
                /*var query = $@"DELETE FROM [solucionsmart_ggamarra].[sport.TPRODUCTOS]
                                 WHERE ID = '{ID}'";*/
                var c = new SqlCommand(query, conn);
                return c.ExecuteNonQuery();
            }
        }
    }
}
