using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Caracteristicas;
using System.Data.SqlClient;
using Dapper;

namespace Persistencia.Caracteristica
{
    public class CaracteristicaCommandsHandler : ICaracteristicaCommandsHandler
    {
        public async Task<IEnumerable<CaracteristicaItem>> GET(string CARACTERISTICA)
        {
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
               
                var query = $@"SELECT [ID] ,[CARACTERISTICA] ,[VALOR]
                              FROM [solucionsmart_ggamarra].[sport.CARACTERISTICAS]
                             WHERE CARACTERISTICA='{CARACTERISTICA}'";

                var listquery = await conn.QueryAsync<CaracteristicaItem>(query);
                conn.Close();
                return listquery;
            }
        }
    }
}
