using Dapper;
using DTOs.Usuario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Usuario
{
    public class UsuarioCommandsHandler : IUsuarioCommandsHandler
    {
        public int ADD(UsuarioItem product)
        {
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                conn.OpenAsync();
                var query = $@"INSERT INTO [solucionsmart_ggamarra].[sport.TUSUARIOS]
                                   ([ID]
                                   ,[USUARIO]
                                   ,[PASSWORD]
                                   ,[NOMBRE_COMPLETO]
                                   ,[ROL]
                                   ,[ESTADO])
                             VALUES
                                   (@ID 
                                   ,@USUARIO 
                                   ,@PASSWORD 
                                   ,@NOMBRE_COMPLETO 
                                   ,@ROL 
                                   ,@ESTADO)";
                var c = new SqlCommand(query, conn);
                c.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = product.ID;
                c.Parameters.Add("@USUARIO", SqlDbType.VarChar, 20).Value = product.USUARIO;
                c.Parameters.Add("@PASSWORD", SqlDbType.VarChar, 50).Value = product.PASSWORD;
                c.Parameters.Add("@NOMBRE_COMPLETO", SqlDbType.VarChar, 50).Value = product.NOMBRE_COMPLETO;
                c.Parameters.Add("@ROL", SqlDbType.VarChar, 10).Value = product.ROL;
                c.Parameters.Add("@ESTADO", SqlDbType.Bit).Value = product.ESTADO;
                return c.ExecuteNonQuery();
            }
        }

        public int DELETE(Guid ID)
        {
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                conn.OpenAsync();
                var query = $@"UPDATE [solucionsmart_ggamarra].[sport.TUSUARIOS]
                           SET [ESTADO] = '0'
                         WHERE [ID]='{ID}'";
                var c = new SqlCommand(query, conn);
                return c.ExecuteNonQuery();
            }
        }

        public async Task<IEnumerable<UsuarioItem>> GET(string search)
        {
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                string whereclause = "";
                if (search != "")
                    whereclause = $@" AND ([USUARIO] like '%{search}%' or [NOMBRE_COMPLETO] like '%{search}%')";

                var query = $@"SELECT  [ID]
                                      ,[USUARIO]
                                      ,[PASSWORD]
                                      ,[NOMBRE_COMPLETO]
                                      ,[ROL]
                                      ,[ESTADO]
                                  FROM [solucionsmart_ggamarra].[sport.TUSUARIOS]
                           WHERE [ESTADO]='1' {whereclause}";

                var listquery = await conn.QueryAsync<UsuarioItem>(query);
                conn.Close();
                return listquery;
            }
        }

        public int UPDATE(UsuarioItem usuario)
        {
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                conn.OpenAsync();
                var query = $@"UPDATE [solucionsmart_ggamarra].[sport.TUSUARIOS]
                               SET [USUARIO] = @USUARIO
                                  ,[PASSWORD] = @PASSWORD
                                  ,[NOMBRE_COMPLETO] = @NOMBRE_COMPLETO
                                  ,[ROL] = @ROL
                         WHERE [ID]='{usuario.ID}'";
                var c = new SqlCommand(query, conn);

                c.Parameters.Add("@USUARIO", SqlDbType.VarChar, 200).Value = usuario.USUARIO;
                c.Parameters.Add("@PASSWORD", SqlDbType.VarChar, 500).Value = usuario.PASSWORD;
                c.Parameters.Add("@NOMBRE_COMPLETO", SqlDbType.VarChar, 500).Value = usuario.NOMBRE_COMPLETO;
                c.Parameters.Add("@ROL", SqlDbType.VarChar, 200).Value = usuario.ROL;

                return c.ExecuteNonQuery();
            }
        }

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
