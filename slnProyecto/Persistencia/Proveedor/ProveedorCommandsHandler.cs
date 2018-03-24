using Dapper;
using DTOs.Proveedor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Persistencia.Proveedor
{
    public class ProveedorCommandsHandler : IProveedorCommandsHandler
    {
       
        public ProveedorCommandsHandler() { }

        public async Task<IEnumerable<ProveedorItem>> GET(string search)
        {

            string whereclause = "";
            if (search != "")
                whereclause = $@" AND ([NOMBRE] like '%{search}%' or [RAZON_SOCIAL] like '%{search}%' or [RUC] like '%{search}%')";


            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                var query = $@"SELECT [ID]
                                      ,[NOMBRE]
                                      ,[RAZON_SOCIAL]
                                      ,[RUC]
                                      ,[DIRECCION]
                                      ,[TELEFONO_FIJO]
                                      ,[TELEFONO_CELULAR]
                                      ,[ESTADO]
                                      ,[EMAIL]
                                      ,[USUARIO_CREACION]
                                      ,[FECHA_CREACION]
                                      ,[USUARIO_MODIFICACION]
                                      ,[FECHA_MODIFICACION]
                                  FROM [solucionsmart_ggamarra].[sport.TPROVEEDORES]
                           WHERE [ESTADO]='1' {whereclause}";

                var listquery =  await conn.QueryAsync<ProveedorItem>(query);
                conn.Close();
                return listquery;
            }
        }

        public int ADD(ProveedorItem proveedor)
        {
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                conn.OpenAsync();
                var query = $@"INSERT INTO [solucionsmart_ggamarra].[sport.TPROVEEDORES]
                               ([ID]
                               ,[NOMBRE]
                               ,[RAZON_SOCIAL]
                               ,[RUC]
                               ,[DIRECCION]
                               ,[TELEFONO_FIJO]
                               ,[TELEFONO_CELULAR]
                               ,[EMAIL]
                               ,[ESTADO]
                               ,[USUARIO_CREACION]
                               ,[FECHA_CREACION])
                                VALUES
                                (@ID
                                 ,@NOMBRE
                                 ,@RAZON_SOCIAL
                                 ,@RUC
                                 ,@DIRECCION
                                 ,@TELEFONO_FIJO
                                 ,@TELEFONO_CELULAR
                                 ,@EMAIL
                                 ,@ESTADO
                                 ,@USUARIO_CREACION
                                 ,@FECHA_CREACION)";
                var c = new SqlCommand(query, conn);
                c.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = proveedor.ID;
                c.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 500).Value = proveedor.NOMBRE;
                c.Parameters.Add("@RAZON_SOCIAL", SqlDbType.VarChar, 500).Value = proveedor.RAZON_SOCIAL;
                c.Parameters.Add("@RUC", SqlDbType.VarChar, 500).Value = proveedor.RUC;
                c.Parameters.Add("@DIRECCION", SqlDbType.VarChar, 500).Value = proveedor.DIRECCION;
                c.Parameters.Add("@TELEFONO_FIJO", SqlDbType.VarChar, 50).Value = proveedor.TELEFONO_FIJO;
                c.Parameters.Add("@TELEFONO_CELULAR", SqlDbType.VarChar, 50).Value = proveedor.TELEFONO_CELULAR;
                c.Parameters.Add("@EMAIL", SqlDbType.VarChar, 200).Value = proveedor.EMAIL;
                c.Parameters.Add("@ESTADO", SqlDbType.Bit).Value = proveedor.ESTADO;
                c.Parameters.Add("@USUARIO_CREACION", SqlDbType.VarChar, 20).Value = proveedor.USUARIO_CREACION;
                c.Parameters.Add("@FECHA_CREACION", SqlDbType.DateTime).Value = proveedor.FECHA_CREACION;

                return c.ExecuteNonQuery();
            }
        }

        public int UPDATE(ProveedorItem proveedor)
        {
                  using (var conn = new SqlConnection(Connection.ConectionString))
                {
                    conn.OpenAsync();
                var query = $@"UPDATE [solucionsmart_ggamarra].[sport.TPROVEEDORES]
                                   SET 
                                      [NOMBRE] = @NOMBRE
                                      ,[RAZON_SOCIAL] = @RAZON_SOCIAL
                                      ,[RUC] = @RUC
                                      ,[DIRECCION] = @DIRECCION
                                      ,[TELEFONO_FIJO] = @TELEFONO_FIJO
                                      ,[TELEFONO_CELULAR] = @TELEFONO_CELULAR
                                      ,[EMAIL] = @EMAIL
                                      ,[ESTADO] = @ESTADO
                                      ,[USUARIO_MODIFICACION] = @USUARIO_MODIFICACION
                                      ,[FECHA_MODIFICACION] = @FECHA_MODIFICACION
                                 WHERE [ID] = @ID";
                    var c = new SqlCommand(query, conn);

                    c.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = proveedor.ID;
                    c.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 500).Value = proveedor.NOMBRE;
                    c.Parameters.Add("@RAZON_SOCIAL", SqlDbType.VarChar, 500).Value = proveedor.RAZON_SOCIAL;
                    c.Parameters.Add("@RUC", SqlDbType.VarChar, 500).Value = proveedor.RUC;
                    c.Parameters.Add("@DIRECCION", SqlDbType.VarChar, 500).Value = proveedor.DIRECCION;
                    c.Parameters.Add("@TELEFONO_FIJO", SqlDbType.VarChar, 50).Value =proveedor.TELEFONO_FIJO;
                    c.Parameters.Add("@TELEFONO_CELULAR", SqlDbType.VarChar, 50).Value = proveedor.TELEFONO_CELULAR;
                    c.Parameters.Add("@EMAIL", SqlDbType.VarChar, 200).Value = proveedor.EMAIL;
                    c.Parameters.Add("@ESTADO", SqlDbType.Bit).Value = proveedor.ESTADO;
                    c.Parameters.Add("@USUARIO_MODIFICACION", SqlDbType.VarChar, 50).Value = proveedor.USUARIO_MODIFICACION;
                    c.Parameters.Add("@FECHA_MODIFICACION", SqlDbType.DateTime).Value = proveedor.FECHA_MODIFICACION;

                return c.ExecuteNonQuery();
                }
 
          
        }

        public int DELETE(Guid ID)
        {

            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                conn.OpenAsync();
                var query = $@"UPDATE [solucionsmart_ggamarra].[sport.TPROVEEDORES]
                           SET [ESTADO] = '0'
                         WHERE [ID]='{ID}'";
                var c = new SqlCommand(query, conn);
                return c.ExecuteNonQuery();
            }
        }


    }
}
