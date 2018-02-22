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

        public IEnumerable<ProveedorItem> GET()
        {
            using (var conn = new SqlConnection(Connection.ConectionString))
            {
                var query = $@"SELECT [ID]
                                      ,[NOMBRE]
                                      ,[RAZON_SOCIAL]
                                      ,[DIRECCION]
                                      ,[TELEFONO_FIJO]
                                      ,[TELEFONO_CELULAR]
                                      ,[ESTADO]
                                      ,[USUARIO_CREACION]
                                      ,[FECHA_CREACION]
                                      ,[USUARIO_MODIFICACION]
                                      ,[FECHA_MODIFICACION]
                                  FROM [solucionsmart_ggamarra].[sport.TPROVEEDORES]
                           WHERE [ESTADO]='1'";

                var listquery =  conn.Query<ProveedorItem>(query);
                return listquery;
            }
        }

        public int ADD(ProveedorItem product)
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
                                [FECHA_CREACION])
                                VALUES
                                (@ID
                                ,@CODIGO
                                ,@NOMBRE
                                ,@DESCRIPCION
                                ,@CODIGO_PROVEEDOR
                                ,@ESTADO
                                ,@USUARIO_CREACION
                                ,@FECHA_CREACION)";
                var c = new SqlCommand(query, conn);
               /* c.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = product.ID;
                c.Parameters.Add("@CODIGO", SqlDbType.VarChar, 200).Value = product.CODIGO;
                c.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 500).Value = product.NOMBRE;
                c.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar, 500).Value = product.DESCRIPCION;
                c.Parameters.Add("@CODIGO_PROVEEDOR", SqlDbType.VarChar, 200).Value = product.CODIGO_PROVEEDOR;
                c.Parameters.Add("@ESTADO", SqlDbType.Bit).Value = product.ESTADO;
                c.Parameters.Add("@USUARIO_CREACION", SqlDbType.VarChar, 50).Value = product.USUARIO_CREACION;
                c.Parameters.Add("@FECHA_CREACION", SqlDbType.DateTime).Value = product.FECHA_CREACION;*/

                return c.ExecuteNonQuery();
            }
        }

        public int UPDATE(ProveedorItem product)
        {
                  using (var conn = new SqlConnection(Connection.ConectionString))
                {
                    conn.OpenAsync();
                    var query = $@"UPDATE [solucionsmart_ggamarra].[sport.TPRODUCTOS]
                           SET [CODIGO] = @CODIGO
                              ,[NOMBRE] = @NOMBRE
                              ,[DESCRIPCION] = @DESCRIPCION
                              ,[CODIGO_PROVEEDOR] = @CODIGO_PROVEEDOR
                              ,[USUARIO_MODIFICACION] = @USUARIO_MODIFICACION
                              ,[FECHA_MODIFICACION] = @FECHA_MODIFICACION
                         WHERE [ID]='{product.ID}'";
                    var c = new SqlCommand(query, conn);

                   /* c.Parameters.Add("@CODIGO", SqlDbType.VarChar, 200).Value = product.CODIGO;
                    c.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 500).Value = product.NOMBRE;
                    c.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar, 500).Value = product.DESCRIPCION;
                    c.Parameters.Add("@CODIGO_PROVEEDOR", SqlDbType.VarChar, 200).Value = product.CODIGO_PROVEEDOR;
                    c.Parameters.Add("@USUARIO_MODIFICACION", SqlDbType.VarChar, 50).Value = product.USUARIO_MODIFICACION;
                    c.Parameters.Add("@FECHA_MODIFICACION", SqlDbType.DateTime).Value = DateTime.Now;*/

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
