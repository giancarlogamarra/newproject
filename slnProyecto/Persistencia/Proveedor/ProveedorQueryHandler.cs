using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Proveedor
{
    public class ProveedorQueryHandler : IProveedorQueryHandler
    {
        SqlConnection conn;
        public ProveedorQueryHandler() {
            string dsfds = "";
          /*  using (var conn = new SqlConnection(""))
            {
                IEnumerable<HouseGetResultItem> listquery = null;
                listquery = await conn.QueryAsync<HouseGetResultItem>(query);

                return listquery.FirstOrDefault();
            }*/
        }
        public string GET()
        {
          /*  using (var conn = new SqlConnection(_connectionString))
            {
                IEnumerable<HouseGetResultItem> listquery = null;
                listquery = await conn.QueryAsync<HouseGetResultItem>(query);

                return listquery.FirstOrDefault();
            }*/
            return "HOLA";
        }
    }
}
