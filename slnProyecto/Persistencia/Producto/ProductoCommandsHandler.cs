using Dapper;
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
        SqlConnection conn;
        public ProductoCommandsHandler() { }

        public async Task<IEnumerable<ProductoItem>> GET()
        {
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                var query = $@"SELECT [ID] ,[CODIGO],[NOMBRE] ,[DESCRIPCION]
                           FROM [solucionsmart_ggamarra].[sport.TPRODUCTOS] ";

                var listquery = await conn.QueryAsync<ProductoItem>(query);
                return listquery;
            }
        }

        public async Task<int> ADD(ProductoItem product)
        {
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                await conn.OpenAsync();
                var query = $@"INSERT INTO [solucionsmart_ggamarra].[sport.TPRODUCTOS]
                                ([ID]
                                ,[CODIGO]
                                ,[NOMBRE]
                                ,[DESCRIPCION])
                                VALUES
                                (@ID
                                ,@CODIGO
                                ,@NOMBRE
                                ,@DESCRIPCION)";
                var c = new SqlCommand(query, conn);
                c.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = product.ID;
                c.Parameters.Add("@CODIGO", SqlDbType.VarChar, 200).Value = product.CODIGO;
                c.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 500).Value = product.NOMBRE;
                c.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar, 500).Value = product.DESCRIPCION;

                return await c.ExecuteNonQueryAsync();
            }
        }

        public async Task<int> UPDATE(ProductoItem product)
        {

            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                await conn.OpenAsync();
                var query = $@"UPDATE [solucionsmart_ggamarra].[sport.TPRODUCTOS]
                           SET [CODIGO] = @CODIGO
                              ,[NOMBRE] = @NOMBRE
                              ,[DESCRIPCION] = @DESCRIPCION
                         WHERE [ID]='{product.ID}'";
                var c = new SqlCommand(query, conn);

                c.Parameters.Add("@CODIGO", SqlDbType.VarChar,200).Value = product.CODIGO;
                c.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 500).Value = product.DESCRIPCION;
                c.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar, 500).Value = product.DESCRIPCION;


                return await c.ExecuteNonQueryAsync();
            }
        }
 
    }
}
