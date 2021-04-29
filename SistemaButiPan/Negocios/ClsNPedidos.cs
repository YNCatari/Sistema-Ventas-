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
    class ClsNPedidos
    {
        SqlDataAdapter dsqlA = new SqlDataAdapter();
        SqlCommand dsqlC = new SqlCommand();
        DataTable dt = new DataTable();
        //Metodo Listar
        public DataTable MtdListarTodoPedido()
        {
            DataTable dtEmpleado = new DataTable("tbPedido");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                ClsNConexion objNcon = new ClsNConexion();
                objNcon.conectar();
                sqlCon.ConnectionString = ClsNConexion.conexDBcadena;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_S_ListarPedido";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtEmpleado);
            }
            catch (Exception exec)
            {
                dtEmpleado = null;
            }
            return dtEmpleado;
        }
        
        //Metodo Buscar
        public DataTable MtdBuscarPedidoSQL(ClsEPedidos objPed)
        {
            DataTable dtEmpleado = new DataTable("tbPedido");
            SqlConnection sqlCon = new SqlConnection();
            string rpta = "";
            try
            {
                ClsNConexion objcon = new ClsNConexion();
                objcon.conectar();
                sqlCon.ConnectionString = ClsNConexion.conexDBcadena;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_S_BuscarPedido";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlcodigopedido = new SqlParameter();
                sqlcodigopedido.ParameterName = "@CodigoPe";
                sqlcodigopedido.Value = objPed.Codigo;
                sqlCmd.Parameters.Add(sqlcodigopedido);
                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtEmpleado);
            }
            catch (Exception ex)
            {
                dtEmpleado = null;
            }
            return dtEmpleado;
        }
        //Metodo Agregar 
        public string MtdAgregarPedido(ClsEPedidos objPed)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                ClsNConexion objcon = new ClsNConexion();
                objcon.conectar();
                sqlCon.ConnectionString = ClsNConexion.conexDBcadena;
                //2. Abrir la conexion de la BD
                sqlCon.Open();
                //3. Establecer el comando
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_I_AgregarPedido";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                //4. Agregar los parametros al comando
                //Establecemos los valores para el parametro @codigoProducto del Procedimiento Almacenado
                SqlParameter sqlcodigopedido = new SqlParameter();
                sqlcodigopedido.ParameterName = "@CodigoPe";
                sqlcodigopedido.SqlDbType = SqlDbType.VarChar;
                //sqldnicliente.Direction = ParameterDirection.InputOutput;
                sqlcodigopedido.Size = 8;
                sqlcodigopedido.Value = objPed.Codigo;
                sqlCmd.Parameters.Add(sqlcodigopedido); //Agregamos el parametro al comando
                                                          //Establecemos los valores para el parametro @nombre del Procedimiento Almacenado
                SqlParameter sqlParFecha = new SqlParameter();
                sqlParFecha.ParameterName = "@FechaPe";
                sqlParFecha.SqlDbType = SqlDbType.VarChar;
                sqlParFecha.Size = 100;
                sqlParFecha.Value = objPed.Fecha;
                sqlCmd.Parameters.Add(sqlParFecha); //Agregamos el parametro al comando
                                                             //Establecemos los valores para el parametro @precio del Procedimiento Almacenado
                SqlParameter sqlParDescripcion = new SqlParameter();
                sqlParDescripcion.ParameterName = "@DescripcionPe ";
                sqlParDescripcion.SqlDbType = SqlDbType.VarChar;
                sqlParDescripcion.Size = 100;
                sqlParDescripcion.Value = objPed.Descripcion;
                sqlCmd.Parameters.Add(sqlParDescripcion); //Agregamos el parametro al comando

                SqlParameter sqlParTotal = new SqlParameter();
                sqlParTotal.ParameterName = "@TotalPe";
                sqlParTotal.SqlDbType = SqlDbType.VarChar;
                sqlParTotal.Size = 100;
                sqlParTotal.Value = objPed.Total;
                sqlCmd.Parameters.Add(sqlParTotal); //Agregamos el parametro al comando

                SqlParameter sqlParDni = new SqlParameter();
                sqlParDni.ParameterName = "@FDniCli";
                sqlParDni.SqlDbType = SqlDbType.VarChar;
                sqlParDni.Size = 100;
                sqlParDni.Value = objPed.Cliente;
                sqlCmd.Parameters.Add(sqlParDni); //Agregamos el parametro al comando

                SqlParameter sqlParCodigo = new SqlParameter();
                sqlParCodigo.ParameterName = "@FCodEmp";
                sqlParCodigo.SqlDbType = SqlDbType.VarChar;
                sqlParCodigo.Size = 100;
                sqlParCodigo.Value = objPed.Empleado;
                sqlCmd.Parameters.Add(sqlParCodigo); //Agregamos el parametro al comando

                SqlParameter sqlParEstado = new SqlParameter();
                sqlParEstado.ParameterName = "@Estado";
                sqlParEstado.SqlDbType = SqlDbType.VarChar;
                sqlParEstado.Size = 100;
                sqlParEstado.Value = objPed.Estado;
                sqlCmd.Parameters.Add(sqlParEstado); //Agregamos el parametro al comando







                //5. Ejecutamos el commando
                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Pedido de forma correcta";

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
        //METODO MODIFICAR
        public string MtdModificarEmpleado(ClsEPedidos objPed)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                ClsNConexion objcon = new ClsNConexion();
                objcon.conectar();
                sqlCon.ConnectionString = ClsNConexion.conexDBcadena;
                //2. Abrir la conexion de la BD
                sqlCon.Open();
                //3. Establecer el comando
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_U_ActualizarPedido";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                //4. Agregar los parametros al comando
                //Establecemos los valores para el parametro @codigoProducto del Procedimiento Almacenado
                SqlParameter sqlcodigopedido = new SqlParameter();
                sqlcodigopedido.ParameterName = "@CodigoPe";
                sqlcodigopedido.SqlDbType = SqlDbType.VarChar;
                //sqldnicliente.Direction = ParameterDirection.InputOutput;
                sqlcodigopedido.Size = 8;
                sqlcodigopedido.Value = objPed.Codigo;
                sqlCmd.Parameters.Add(sqlcodigopedido); //Agregamos el parametro al comando
                                                        //Establecemos los valores para el parametro @nombre del Procedimiento Almacenado
                SqlParameter sqlParFecha = new SqlParameter();
                sqlParFecha.ParameterName = "@FechaPe";
                sqlParFecha.SqlDbType = SqlDbType.VarChar;
                sqlParFecha.Size = 100;
                sqlParFecha.Value = objPed.Fecha;
                sqlCmd.Parameters.Add(sqlParFecha); //Agregamos el parametro al comando
                                                    //Establecemos los valores para el parametro @precio del Procedimiento Almacenado
                SqlParameter sqlParDescripcion = new SqlParameter();
                sqlParDescripcion.ParameterName = "@DescripcionPe ";
                sqlParDescripcion.SqlDbType = SqlDbType.VarChar;
                sqlParDescripcion.Size = 100;
                sqlParDescripcion.Value = objPed.Descripcion;
                sqlCmd.Parameters.Add(sqlParDescripcion); //Agregamos el parametro al comando

                SqlParameter sqlParTotal = new SqlParameter();
                sqlParTotal.ParameterName = "@TotalPe";
                sqlParTotal.SqlDbType = SqlDbType.VarChar;
                sqlParTotal.Size = 100;
                sqlParTotal.Value = objPed.Total;
                sqlCmd.Parameters.Add(sqlParTotal); //Agregamos el parametro al comando

                SqlParameter sqlParDni = new SqlParameter();
                sqlParDni.ParameterName = "@FDniCli";
                sqlParDni.SqlDbType = SqlDbType.VarChar;
                sqlParDni.Size = 100;
                sqlParDni.Value = objPed.Cliente;
                sqlCmd.Parameters.Add(sqlParDni); //Agregamos el parametro al comando

                SqlParameter sqlParCodigo = new SqlParameter();
                sqlParCodigo.ParameterName = "@FCodEmp";
                sqlParCodigo.SqlDbType = SqlDbType.VarChar;
                sqlParCodigo.Size = 100;
                sqlParCodigo.Value = objPed.Empleado;
                sqlCmd.Parameters.Add(sqlParCodigo); //Agregamos el parametro al comando

                SqlParameter sqlParEstado = new SqlParameter();
                sqlParEstado.ParameterName = "@Estado";
                sqlParEstado.SqlDbType = SqlDbType.VarChar;
                sqlParEstado.Size = 100;
                sqlParEstado.Value = objPed.Estado;
                sqlCmd.Parameters.Add(sqlParEstado); //Agregamos el parametro al comando






                //5. Ejecutamos el commando
                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Empleado de forma correcta";

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
