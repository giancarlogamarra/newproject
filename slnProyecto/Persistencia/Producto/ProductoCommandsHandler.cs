using Dapper;
using DTOs.Producto;
using DTOs.Proveedor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Persistencia.Producto
{
    public class ProductoCommandsHandler : IProductoCommandsHandler
    {
       
        public ProductoCommandsHandler() { }


        public async Task<ProductoItem> GETPRODUCTO(string CODIGO)
        {
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                string whereclause = "";
                whereclause = $@" AND [CODIGO] = '{CODIGO}'";

                var query = $@"SELECT [ID] ,[CODIGO],[NOMBRE] ,[DESCRIPCION],
                                [CODIGO_PROVEEDOR],[PROVEEDOR_ID],[PRECIO_VENTA],[DSCTO_MAX],[ESTADO],
                                [ALERTA_STOCK_MIN_TIENDA],[USUARIO_CREACION],
                                [FECHA_CREACION],[USUARIO_MODIFICACION],[FECHA_MODIFICACION]
                           FROM [solucionsmart_ggamarra].[sport.TPRODUCTOS] 
                           WHERE [ESTADO]='1' {whereclause}";

                var product = await conn.QueryFirstOrDefaultAsync<ProductoItem>(query);
                conn.Close();
                return product;
            }
        }

        public async Task<IEnumerable<ProductoItem>> GET(string search)
        {
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                string whereclause = "";
                if (search != "")
                    whereclause = $@" AND [NOMBRE] like '%{search}%'";

                var query = $@"SELECT [ID] ,[CODIGO],[NOMBRE] ,[DESCRIPCION],
                                [CODIGO_PROVEEDOR],[PROVEEDOR_ID],[PRECIO_VENTA],[DSCTO_MAX],[ESTADO],
                                [ALERTA_STOCK_MIN_TIENDA],[USUARIO_CREACION],
                                [FECHA_CREACION],[USUARIO_MODIFICACION],[FECHA_MODIFICACION]
                           FROM [solucionsmart_ggamarra].[sport.TPRODUCTOS] 
                           WHERE [ESTADO]='1' {whereclause}";

                var listquery = await conn.QueryAsync<ProductoItem>(query);
                conn.Close();
                return listquery;
            }
        }

        public int ADD(ProductoItem product)
        {
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                conn.OpenAsync();
                var query = $@"INSERT INTO [solucionsmart_ggamarra].[sport.TPRODUCTOS]
                                ([ID],
                                [CODIGO],
                                [NOMBRE],
                                [DESCRIPCION],
                                [CODIGO_PROVEEDOR],
                                [ESTADO],
                                [USUARIO_CREACION],
                                [FECHA_CREACION],
                                [PROVEEDOR_ID],
                                [PRECIO_VENTA],
                                [DSCTO_MAX],
                                [ALERTA_STOCK_MIN_TIENDA])
                                VALUES
                                (@ID
                                ,@CODIGO
                                ,@NOMBRE
                                ,@DESCRIPCION
                                ,@CODIGO_PROVEEDOR
                                ,@ESTADO
                                ,@USUARIO_CREACION
                                ,@FECHA_CREACION
                                ,@PROVEEDOR_ID
                                ,@PRECIO_VENTA
                                ,@DSCTO_MAX
                                ,@ALERTA_STOCK_MIN_TIENDA)";
                var c = new SqlCommand(query, conn);
                c.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = product.ID;
                c.Parameters.Add("@CODIGO", SqlDbType.VarChar, 200).Value = product.CODIGO;
                c.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 500).Value = product.NOMBRE;
                c.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar, 500).Value = product.DESCRIPCION;
                c.Parameters.Add("@CODIGO_PROVEEDOR", SqlDbType.VarChar, 200).Value = product.CODIGO_PROVEEDOR;
                c.Parameters.Add("@ESTADO", SqlDbType.Bit).Value = product.ESTADO;
                c.Parameters.Add("@USUARIO_CREACION", SqlDbType.VarChar, 50).Value = product.USUARIO_CREACION;
                c.Parameters.Add("@FECHA_CREACION", SqlDbType.DateTime).Value = product.FECHA_CREACION;
                c.Parameters.Add("@PROVEEDOR_ID", SqlDbType.UniqueIdentifier).Value = product.PROVEEDOR_ID;
                c.Parameters.Add("@PRECIO_VENTA", SqlDbType.Decimal).Value = product.PRECIO_VENTA;
                c.Parameters.Add("@DSCTO_MAX", SqlDbType.Decimal).Value = product.DSCTO_MAX;
                c.Parameters.Add("@ALERTA_STOCK_MIN_TIENDA", SqlDbType.Int).Value = product.ALERTA_STOCK_MIN_TIENDA;
                return c.ExecuteNonQuery();
            }
        }

        public int UPDATE(ProductoItem product)
        {
                  using (var conn = new SqlConnection(Connection.ConectionString))
                {
                    conn.OpenAsync();
                    var query = $@"UPDATE [solucionsmart_ggamarra].[sport.TPRODUCTOS]
                           SET [CODIGO] = @CODIGO
                              ,[NOMBRE] = @NOMBRE
                              ,[DESCRIPCION] = @DESCRIPCION
                              ,[CODIGO_PROVEEDOR] = @CODIGO_PROVEEDOR
                              ,[PROVEEDOR_ID] = @PROVEEDOR_ID
                              ,[PRECIO_VENTA]=@PRECIO_VENTA
                              ,[DSCTO_MAX]=@DSCTO_MAX
                              ,[ALERTA_STOCK_MIN_TIENDA]=@ALERTA_STOCK_MIN_TIENDA
                              ,[USUARIO_MODIFICACION] = @USUARIO_MODIFICACION
                              ,[FECHA_MODIFICACION] = @FECHA_MODIFICACION
                         WHERE [ID]='{product.ID}'";
                    var c = new SqlCommand(query, conn);

                    c.Parameters.Add("@CODIGO", SqlDbType.VarChar, 200).Value = product.CODIGO;
                    c.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 500).Value = product.NOMBRE;
                    c.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar, 500).Value = product.DESCRIPCION;
                    c.Parameters.Add("@CODIGO_PROVEEDOR", SqlDbType.VarChar, 200).Value = product.CODIGO_PROVEEDOR;
                    c.Parameters.Add("@PROVEEDOR_ID", SqlDbType.UniqueIdentifier).Value = product.PROVEEDOR_ID;
                    c.Parameters.Add("@PRECIO_VENTA", SqlDbType.Decimal).Value = product.PRECIO_VENTA;
                    c.Parameters.Add("@DSCTO_MAX", SqlDbType.Decimal).Value = product.DSCTO_MAX;
                    c.Parameters.Add("@USUARIO_MODIFICACION", SqlDbType.VarChar, 50).Value = product.USUARIO_MODIFICACION;
                    c.Parameters.Add("@FECHA_MODIFICACION", SqlDbType.DateTime).Value = DateTime.Now;
                    c.Parameters.Add("@ALERTA_STOCK_MIN_TIENDA", SqlDbType.Int).Value =product.ALERTA_STOCK_MIN_TIENDA;
                
                    return c.ExecuteNonQuery();
                }
 
          
        }

        public int DELETE(Guid ID)
        {

            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                conn.OpenAsync();
                var query = $@"UPDATE [solucionsmart_ggamarra].[sport.TPRODUCTOS]
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
