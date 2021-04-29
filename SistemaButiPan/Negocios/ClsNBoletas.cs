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
    class ClsNBoletas
    {
        public string Mtdagregarboleta(ClsEBoletas objECli)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                ClsNConexion objNcon = new ClsNConexion();
                objNcon.conectar();
                sqlCon.ConnectionString = ClsNConexion.conexDBcadena;
                SqlCommand sqlCmd = new SqlCommand();
                //2. Abrir la conexion de la BD
                sqlCon.Open();
                //3. Establecer el comando
                SqlCommand sqlCm = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_I_AgregarBoleta";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                //4. Agregar los parametros al comando
                //Establecemos los valores para el parametro @codigoProducto del Procedimiento Almacenado
                SqlParameter sqlSerie = new SqlParameter();
                sqlSerie.ParameterName = "@SerieBo";
                sqlSerie.SqlDbType = SqlDbType.NVarChar;
                //sqldnicliente.Direction = ParameterDirection.InputOutput;
                sqlSerie.Size = 3;
                sqlSerie.Value = objECli.Serie;
                sqlCmd.Parameters.Add(sqlSerie); //Agregamos el parametro al comando
                                                      //Establecemos los valores para el parametro @nombre del Procedimiento Almacenado
                SqlParameter sqlParNumero = new SqlParameter();//y aca verifica si la fecha es la correcta 
                

                sqlParNumero.ParameterName = "@NumeroBo";
                sqlParNumero.SqlDbType = SqlDbType.VarChar;
                sqlParNumero.Size = 6;
                sqlParNumero.Value = objECli.Numero;
                sqlCmd.Parameters.Add(sqlParNumero); //Agregamos el parametro al comando
                                                     //Establecemos los valores para el parametro @precio del Procedimiento Almacenado
                SqlParameter sqlParFecha = new SqlParameter();
                sqlParFecha.ParameterName = "@FechaBo";
                sqlParFecha.SqlDbType = SqlDbType.VarChar;              
                sqlParFecha.Value = objECli.Fecha;
                sqlCmd.Parameters.Add(sqlParFecha); //Agregamos el parametro al comando
                SqlParameter sqlParTotal = new SqlParameter();
                sqlParTotal.ParameterName = "@TotalBo";
                sqlParTotal.SqlDbType = SqlDbType.Decimal;
                sqlParTotal.Size = 10;
                sqlParTotal.Value = objECli.Total;
                sqlCmd.Parameters.Add(sqlParTotal); //Agregamos el parametro al comando

                SqlParameter sqlPaESTADO = new SqlParameter();
                sqlPaESTADO.ParameterName = "@EstadoBo";
                sqlPaESTADO.SqlDbType = SqlDbType.VarChar;
                sqlPaESTADO.Size = 5;
                sqlPaESTADO.Value = objECli.Estado;
                sqlCmd.Parameters.Add(sqlPaESTADO); //Agregamos el parametro al comando

                SqlParameter sqlPRuc = new SqlParameter();//verifica este dato de donde biene porque ebes guard el ruc de la empresa 11111111111
                sqlPRuc.ParameterName = "@Fruc";
                sqlPRuc.SqlDbType = SqlDbType.VarChar;
                sqlPRuc.Size = 11;
                sqlPRuc.Value = objECli.Ruc;
                sqlCmd.Parameters.Add(sqlPRuc); //Agregamos el parametro al comando

                SqlParameter sqlPdnicliente = new SqlParameter();
                sqlPdnicliente.ParameterName = "@Fdnicliente";
                sqlPdnicliente.SqlDbType = SqlDbType.VarChar;
                sqlPdnicliente.Size = 8;
                sqlPdnicliente.Value = objECli.Dni;
                sqlCmd.Parameters.Add(sqlPdnicliente); //Agregamos el parametro al comando

                SqlParameter sqlPcodigoEmpleado = new SqlParameter();
                sqlPcodigoEmpleado.ParameterName = "@Fcodigoempleado";
                sqlPcodigoEmpleado.SqlDbType = SqlDbType.VarChar;
                sqlPcodigoEmpleado.Size = 8;
                sqlPcodigoEmpleado.Value = objECli.Codigo;
                sqlCmd.Parameters.Add(sqlPcodigoEmpleado); //Agregamos el parametro al comando

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
    }
}
