using Dapper;
using DTOs.Usuario;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Usuario
{
    public class UsuarioCommandsHandler : IUsuarioCommandsHandler
    {
        public async Task<UsuarioItem> VALIDAR_ACCESO(string usuario, string password)
        {
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                var query = $@"SELECT [ID]
                                  ,[USUARIO]
                                  ,[PASSWORD]
                                  ,[NOMBRE_COMPLETO]
                                  ,[ROL]
                                  ,[ESTADO]
                              FROM [solucionsmart_ggamarra].[sport.TUSUARIOS]
                                WHERE [USUARIO]='{usuario}' AND [PASSWORD]='{password}'";
                UsuarioItem Usuario = await conn.QueryFirstOrDefaultAsync<UsuarioItem>(query);
                conn.Close();
                return Usuario;
            }
        }
    }
}
