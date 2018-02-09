using Dapper;
using DTOs.Proveedor;
using System;
using System.Collections.Generic;

using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Persistencia.Producto
{
    public class ProductoQueryHandler : IProductoQueryHandler
    {
        SqlConnection conn;
        public ProductoQueryHandler() {}

        public async Task<IEnumerable<ProductoItem>> GET ()
        {
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                var query = $@"SELECT [ID] ,[NOMBRE] ,[DESCRIPCION]
                           FROM [solucionsmart_ggamarra].[sport.TPRODUCTOS] ";

                var listquery = await conn.QueryAsync<ProductoItem>(query);
                return listquery;
            }
        }
 

     
    }
}
