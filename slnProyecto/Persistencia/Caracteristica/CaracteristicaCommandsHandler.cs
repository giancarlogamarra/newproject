using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.Caracteristicas;
using System.Data.SqlClient;
using Dapper;
using System.Data;

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
                             WHERE CARACTERISTICA like '%{CARACTERISTICA}%'";

                var listquery = await conn.QueryAsync<CaracteristicaItem>(query);
                conn.Close();
                return listquery;
            }
        }

        public int ADD(CaracteristicaItem caracteristica)
        {
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                conn.OpenAsync();
                var query = $@"INSERT INTO [solucionsmart_ggamarra].[sport.CARACTERISTICAS]
                                   ([ID]
                                   ,[CARACTERISTICA]
                                   ,[VALOR]
                                   ,[ESTADO])
                             VALUES
                                   (@ID
                                   ,@CARACTERISTICA
                                   ,@VALOR
                                   ,@ESTADO)";
                var c = new SqlCommand(query, conn);
                c.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = caracteristica.ID;
                c.Parameters.Add("@CARACTERISTICA", SqlDbType.VarChar, 50).Value = caracteristica.CARACTERISTICA;
                c.Parameters.Add("@VALOR", SqlDbType.VarChar, 500).Value = caracteristica.VALOR;
                c.Parameters.Add("@ESTADO", SqlDbType.Bit).Value = caracteristica.ESTADO;
                return c.ExecuteNonQuery();
            }
        }

        public int UPDATE(CaracteristicaItem caracteristica)
        {
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                conn.OpenAsync();
                var query = $@"UPDATE [solucionsmart_ggamarra].[sport.CARACTERISTICAS]
                               SET [CARACTERISTICA] = @CARACTERISTICA 
                                  ,[VALOR] = @VALOR 
                             WHERE [ID]='{caracteristica.ID}'";
                var c = new SqlCommand(query, conn);

                c.Parameters.Add("@CARACTERISTICA", SqlDbType.VarChar, 200).Value = caracteristica.CARACTERISTICA;
                c.Parameters.Add("@VALOR", SqlDbType.VarChar, 500).Value = caracteristica.VALOR;
              
                return c.ExecuteNonQuery();
            }


        }

        public int DELETE(Guid ID)
        {

            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                conn.OpenAsync();
                var query = $@"UPDATE [solucionsmart_ggamarra].[sport.CARACTERISTICAS]
                           SET [ESTADO] = '0'
                         WHERE [ID]='{ID}'";
                var c = new SqlCommand(query, conn);
                return c.ExecuteNonQuery();
            }
        }
    }
}
