using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SistemaButiPan.Entidades;

namespace SistemaButiPan.Negocios
{
    class ClsNDetalles
    {
        public string MtdagregarDetalle(ClsEDetalles objECli)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                ClsNConexion objNcon = new ClsNConexion();
                objNcon.conectar();
                sqlCon.ConnectionString = ClsNConexion.conexDBcadena;
                //2. Abrir la conexion de la BD
                sqlCon.Open();
                //3. Establecer el comando
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_I_AgregarDetalle";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                //4. Agregar los parametros al comando
                //Establecemos los valores para el parametro @codigoProducto del Procedimiento Almacenado
                SqlParameter sqlSerie= new SqlParameter();
                sqlSerie.ParameterName = "@Serie";
                sqlSerie.SqlDbType = SqlDbType.VarChar;
                //sqldnicliente.Direction = ParameterDirection.InputOutput;
                sqlSerie.Size = 3;
                sqlSerie.Value = objECli.Serie;
                sqlCmd.Parameters.Add(sqlSerie); //Agregamos el parametro al comando
                                                      //Establecemos los valores para el parametro @nombre del Procedimiento Almacenado
                SqlParameter sqlParnumero = new SqlParameter();
                sqlParnumero.ParameterName = "@Numero";
                sqlParnumero.SqlDbType = SqlDbType.VarChar;
                sqlParnumero.Size = 6;
                sqlParnumero.Value = objECli.Numero;
                sqlCmd.Parameters.Add(sqlParnumero); //Agregamos el parametro al comando
                                                     //Establecemos los valores para el parametro @precio del Procedimiento Almacenado
                SqlParameter sqlParCantidad = new SqlParameter();
                sqlParCantidad.ParameterName = "@CantCompra";
                sqlParCantidad.SqlDbType = SqlDbType.Int;
                sqlParCantidad.Size = 100;
                sqlParCantidad.Value = objECli.Cantidad;
                sqlCmd.Parameters.Add(sqlParCantidad); //Agregamos el parametro al comando

                SqlParameter sqlParImporte = new SqlParameter();
                sqlParImporte.ParameterName = "@Importe";
                sqlParImporte.SqlDbType = SqlDbType.Decimal;
                sqlParImporte.Size = 20;
                sqlParImporte.Value = objECli.Importe;
                sqlCmd.Parameters.Add(sqlParImporte); //Agregamos el parametro al comando

                SqlParameter sqlParProducto = new SqlParameter();
                sqlParProducto.ParameterName = "@FCodProducto";
                sqlParProducto.SqlDbType = SqlDbType.VarChar;
                sqlParProducto.Size = 6;
                sqlParProducto.Value = objECli.Codigo;
                sqlCmd.Parameters.Add(sqlParProducto); //Agregamos el parametro al comando



                //5. Ejecutamos el commando
                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "#";
                //MessageBox.Show(rpta);

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                //6. Cerramos la conexion con la BD
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return rpta;

        }

        public DataTable MtdListarDetalle()
        {
            DataTable dt = new DataTable("tbDetalle");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                ClsNConexion objNcon = new ClsNConexion();
                objNcon.conectar();
                sqlCon.ConnectionString = ClsNConexion.conexDBcadena;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_S_ListarDetalle";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dt);
            }
            catch (Exception exec)
            {
                dt = null;
            }
            return dt;
        }
    }
}
