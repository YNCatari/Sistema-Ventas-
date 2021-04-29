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
    class ClsNInventarios
    {
        SqlDataAdapter dsqlA = new SqlDataAdapter();
        SqlCommand dsqlC = new SqlCommand();
        DataTable dt = new DataTable();
        //Metodo Listar
        public DataTable MtdListarTodoInventario()
        {
            DataTable dtEmpleado = new DataTable("tbInventario");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                ClsNConexion objNcon = new ClsNConexion();
                objNcon.conectar();
                sqlCon.ConnectionString = ClsNConexion.conexDBcadena;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_S_ListarInventario";
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
        public DataTable MtdBuscarInventarioSQL(ClsEInventario objInv)
        {
            DataTable dtEmpleado = new DataTable("tbInventario");
            SqlConnection sqlCon = new SqlConnection();
            string rpta = "";
            try
            {
                ClsNConexion objcon = new ClsNConexion();
                objcon.conectar();
                sqlCon.ConnectionString = ClsNConexion.conexDBcadena;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_S_BuscarInventario";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlcodigoinventario = new SqlParameter();
                sqlcodigoinventario.ParameterName = "@Cod";
                sqlcodigoinventario.Value = objInv.Codigo;
                sqlCmd.Parameters.Add(sqlcodigoinventario);
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
        public string MtdAgregarInventarioSQL(ClsEInventario objInv)
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
                sqlCmd.CommandText = "USP_I_AgregarInventario";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                //4. Agregar los parametros al comando
                //Establecemos los valores para el parametro @codigoProducto del Procedimiento Almacenado
                SqlParameter sqlcodigoinventario = new SqlParameter();
                sqlcodigoinventario.ParameterName = "@CodigoIn";
                sqlcodigoinventario.SqlDbType = SqlDbType.VarChar;
                //sqldnicliente.Direction = ParameterDirection.InputOutput;
                sqlcodigoinventario.Size = 8;
                sqlcodigoinventario.Value = objInv.Codigo;
                sqlCmd.Parameters.Add(sqlcodigoinventario); //Agregamos el parametro al comando
                                                          //Establecemos los valores para el parametro @nombre del Procedimiento Almacenado
                SqlParameter sqlPardiscripcion = new SqlParameter();
                sqlPardiscripcion.ParameterName = "@DescripcionIn";
                sqlPardiscripcion.SqlDbType = SqlDbType.VarChar;
                sqlPardiscripcion.Size = 100;
                sqlPardiscripcion.Value = objInv.Descripcion;
                sqlCmd.Parameters.Add(sqlPardiscripcion); //Agregamos el parametro al comando
                                                             //Establecemos los valores para el parametro @precio del Procedimiento Almacenado
                SqlParameter sqlParcantidad = new SqlParameter();
                sqlParcantidad.ParameterName = "@CantidadIn";
                sqlParcantidad.SqlDbType = SqlDbType.VarChar;
                sqlParcantidad.Size = 100;
                sqlParcantidad.Value = objInv.Cantidad;
                sqlCmd.Parameters.Add(sqlParcantidad); //Agregamos el parametro al comando

                SqlParameter sqlParprecio = new SqlParameter();
                sqlParprecio.ParameterName = "@PrecioUnitario";
                sqlParprecio.SqlDbType = SqlDbType.VarChar;
                sqlParprecio.Size = 100;
                sqlParprecio.Value = objInv.Precio;
                sqlCmd.Parameters.Add(sqlParprecio); //Agregamos el parametro al comando

                SqlParameter sqlParestado = new SqlParameter();
                sqlParestado.ParameterName = "@Condicion";
                sqlParestado.SqlDbType = SqlDbType.VarChar;
                sqlParestado.Size = 100;
                sqlParestado.Value = objInv.Estado;
                sqlCmd.Parameters.Add(sqlParestado); //Agregamos el parametro al comando

                SqlParameter sqlParproducto = new SqlParameter();
                sqlParproducto.ParameterName = "@FCodProducto";
                sqlParproducto.SqlDbType = SqlDbType.VarChar;
                sqlParproducto.Size = 100;
                sqlParproducto.Value = objInv.Producto;
                sqlCmd.Parameters.Add(sqlParproducto); //Agregamos el parametro al comando

                SqlParameter sqlParproveedor = new SqlParameter();
                sqlParproveedor.ParameterName = "@FCodProveedor";
                sqlParproveedor.SqlDbType = SqlDbType.VarChar;
                sqlParproveedor.Size = 100;
                sqlParproveedor.Value = objInv.Proveedor;
                sqlCmd.Parameters.Add(sqlParproveedor); //Agregamos el parametro al comando

                //5. Ejecutamos el commando
                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Cliente de forma correcta";

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
        public string MtdEditarInventarioSQL(ClsEInventario objInv)
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
                sqlCmd.CommandText = "USP_U_ActualizarInventario";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                //4. Agregar los parametros al comando
                //Establecemos los valores para el parametro @codigoProducto del Procedimiento Almacenado
                SqlParameter sqlcodigoinventario = new SqlParameter();
                sqlcodigoinventario.ParameterName = "@CodigoIn";
                sqlcodigoinventario.SqlDbType = SqlDbType.VarChar;
                //sqldnicliente.Direction = ParameterDirection.InputOutput;
                sqlcodigoinventario.Size = 8;
                sqlcodigoinventario.Value = objInv.Codigo;
                sqlCmd.Parameters.Add(sqlcodigoinventario); //Agregamos el parametro al comando
                                                            //Establecemos los valores para el parametro @nombre del Procedimiento Almacenado
                SqlParameter sqlPardiscripcion = new SqlParameter();
                sqlPardiscripcion.ParameterName = "@DescripcionIn";
                sqlPardiscripcion.SqlDbType = SqlDbType.VarChar;
                sqlPardiscripcion.Size = 100;
                sqlPardiscripcion.Value = objInv.Descripcion;
                sqlCmd.Parameters.Add(sqlPardiscripcion); //Agregamos el parametro al comando
                                                          //Establecemos los valores para el parametro @precio del Procedimiento Almacenado
                SqlParameter sqlParcantidad = new SqlParameter();
                sqlParcantidad.ParameterName = "@CantidadIn";
                sqlParcantidad.SqlDbType = SqlDbType.VarChar;
                sqlParcantidad.Size = 100;
                sqlParcantidad.Value = objInv.Cantidad;
                sqlCmd.Parameters.Add(sqlParcantidad); //Agregamos el parametro al comando

                SqlParameter sqlParprecio = new SqlParameter();
                sqlParprecio.ParameterName = "@PrecioUnitario";
                sqlParprecio.SqlDbType = SqlDbType.VarChar;
                sqlParprecio.Size = 100;
                sqlParprecio.Value = objInv.Precio;
                sqlCmd.Parameters.Add(sqlParprecio); //Agregamos el parametro al comando

                SqlParameter sqlParestado = new SqlParameter();
                sqlParestado.ParameterName = "@Condicion";
                sqlParestado.SqlDbType = SqlDbType.VarChar;
                sqlParestado.Size = 100;
                sqlParestado.Value = objInv.Estado;
                sqlCmd.Parameters.Add(sqlParestado); //Agregamos el parametro al comando

                SqlParameter sqlParproducto = new SqlParameter();
                sqlParproducto.ParameterName = "@FCodProducto";
                sqlParproducto.SqlDbType = SqlDbType.VarChar;
                sqlParproducto.Size = 100;
                sqlParproducto.Value = objInv.Proveedor;
                sqlCmd.Parameters.Add(sqlParproducto); //Agregamos el parametro al comando

                SqlParameter sqlParproveedor = new SqlParameter();
                sqlParproveedor.ParameterName = "@FCodProveedor";
                sqlParproveedor.SqlDbType = SqlDbType.VarChar;
                sqlParproveedor.Size = 100;
                sqlParproveedor.Value = objInv.Proveedor;
                sqlCmd.Parameters.Add(sqlParproveedor); //Agregamos el parametro al comando


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
        //Metodo Eliminar
        public DataTable MtdEliminarInventarioSQL(ClsEInventario objEEmp)
        {
            DataTable dtCliente = new DataTable("tbCLIENTE");
            SqlConnection sqlCon = new SqlConnection();
            string rpta = "";
            try
            {
                ClsNConexion objcon = new ClsNConexion();
                objcon.conectar();
                sqlCon.ConnectionString = ClsNConexion.conexDBcadena;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_D_ELIMINARCLIENTE";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqldnicliente = new SqlParameter();
                sqldnicliente.ParameterName = "@DNIcli";
                sqldnicliente.Value = objEEmp.Codigo;
                sqlCmd.Parameters.Add(sqldnicliente);
                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtCliente);
            }
            catch (Exception ex)
            {
                dtCliente = null;
            }
            return dtCliente;
        }
    }
}
