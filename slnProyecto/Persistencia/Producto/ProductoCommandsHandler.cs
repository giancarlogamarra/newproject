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
       
        public ProductoCommandsHandler() { }

        public IEnumerable<ProductoItem> GET()
        {
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                var query = $@"SELECT [ID] ,[CODIGO],[NOMBRE] ,[DESCRIPCION],
                                [CODIGO_PROVEEDOR]
                           FROM [solucionsmart_ggamarra].[sport.TPRODUCTOS] ";

                var listquery = conn.Query<ProductoItem>(query);
                return listquery;
            }
        }

        public async Task<int> ADD(ProductoItem product)
        {
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                await conn.OpenAsync();
                var query = $@"INSERT INTO [solucionsmart_ggamarra].[sport.TPRODUCTOS]
                                ([ID],
                                [CODIGO],
                                [NOMBRE],
                                [DESCRIPCION],
                                [CODIGO_PROVEEDOR])
                                VALUES
                                (@ID
                                ,@CODIGO
                                ,@NOMBRE
                                ,@DESCRIPCION
                                ,@CODIGO_PROVEEDOR)";
                var c = new SqlCommand(query, conn);
                c.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = product.ID;
                c.Parameters.Add("@CODIGO", SqlDbType.VarChar, 200).Value = product.CODIGO;
                c.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 500).Value = product.NOMBRE;
                c.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar, 500).Value = product.DESCRIPCION;
                c.Parameters.Add("@CODIGO_PROVEEDOR", SqlDbType.VarChar, 200).Value = product.CODIGO_PROVEEDOR;

                return await c.ExecuteNonQueryAsync();
            }
        }

        public async Task<int> UPDATE(ProductoItem product)
        {
            try
            {
                using (var conn = new SqlConnection(Connection.ConectionString))
                {
                    await conn.OpenAsync();
                    var query = $@"UPDATE [solucionsmart_ggamarra].[sport.TPRODUCTOS]
                           SET [CODIGO] = @CODIGO
                              ,[NOMBRE] = @NOMBRE
                              ,[DESCRIPCION] = @DESCRIPCION
                              ,[CODIGO_PROVEEDOR] = @CODIGO_PROVEEDOR
                         WHERE [ID]='{product.ID}'";
                    var c = new SqlCommand(query, conn);

                    c.Parameters.Add("@CODIGO", SqlDbType.VarChar, 200).Value = product.CODIGO;
                    c.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 500).Value = product.DESCRIPCION;
                    c.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar, 500).Value = product.DESCRIPCION;
                    c.Parameters.Add("@CODIGO_PROVEEDOR", SqlDbType.VarChar, 200).Value = product.CODIGO_PROVEEDOR;

                    return await c.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex) {
                string mmm = ex.Message;
                return 0;
            }
        }

        public async Task<int> DELETE(Guid ID)
        {

            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                await conn.OpenAsync();
                var query = $@"DELETE FROM [solucionsmart_ggamarra].[sport.TPRODUCTOS]
                                 WHERE ID = '{ID}'";
                var c = new SqlCommand(query, conn);
                return await c.ExecuteNonQueryAsync();
            }
        }


    }
}
