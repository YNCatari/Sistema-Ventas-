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
    class ClsNProveedor
    {
        SqlDataAdapter dsqlA = new SqlDataAdapter();
        SqlCommand dsqlC = new SqlCommand();
        DataTable dt = new DataTable();
        //Metodo Listar
        public DataTable MtdListarTodoProveedor()
        {
            DataTable dtEmpleado = new DataTable("tbProveedor");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                ClsNConexion objNcon = new ClsNConexion();
                objNcon.conectar();
                sqlCon.ConnectionString = ClsNConexion.conexDBcadena;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_S_ListarProveedor";
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
        public DataTable MtdBuscarProveedorSQL(ClsEProveedor objProv)
        {
            DataTable dtEmpleado = new DataTable("tbProveedor");
            SqlConnection sqlCon = new SqlConnection();
            string rpta = "";
            try
            {
                ClsNConexion objcon = new ClsNConexion();
                objcon.conectar();
                sqlCon.ConnectionString = ClsNConexion.conexDBcadena;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_S_BuscarProveedor";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlcodigoempleado = new SqlParameter();
                sqlcodigoempleado.ParameterName = "@Cod";
                sqlcodigoempleado.Value = objProv.Dni;
                sqlCmd.Parameters.Add(sqlcodigoempleado);
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
        public string MtdAgregarProveedor(ClsEProveedor objProv)
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
                sqlCmd.CommandText = "USP_I_AgregarProveedor";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                //4. Agregar los parametros al comando
                //Establecemos los valores para el parametro @codigoProducto del Procedimiento Almacenado
                SqlParameter sqlcodigoProveedor = new SqlParameter();
                sqlcodigoProveedor.ParameterName = "@CodigoPro ";
                sqlcodigoProveedor.SqlDbType = SqlDbType.VarChar;
                //sqldnicliente.Direction = ParameterDirection.InputOutput;
                sqlcodigoProveedor.Size = 8;
                sqlcodigoProveedor.Value = objProv.Dni;
                sqlCmd.Parameters.Add(sqlcodigoProveedor); //Agregamos el parametro al comando
                                                          //Establecemos los valores para el parametro @nombre del Procedimiento Almacenado
                SqlParameter sqlParRuc = new SqlParameter();
                sqlParRuc.ParameterName = "@RucPro";
                sqlParRuc.SqlDbType = SqlDbType.VarChar;
                sqlParRuc.Size = 100;
                sqlParRuc.Value = objProv.Ruc;
                sqlCmd.Parameters.Add(sqlParRuc); //Agregamos el parametro al comando
                                                             //Establecemos los valores para el parametro @precio del Procedimiento Almacenado
                SqlParameter sqlParDescripcion= new SqlParameter();
                sqlParDescripcion.ParameterName = "@DescripcionPro";
                sqlParDescripcion.SqlDbType = SqlDbType.VarChar;
                sqlParDescripcion.Size = 100;
                sqlParDescripcion.Value = objProv.Descripcion;
                sqlCmd.Parameters.Add(sqlParDescripcion); //Agregamos el parametro al comando

                SqlParameter sqlParRubro = new SqlParameter();
                sqlParRubro.ParameterName = "@RubroPro";
                sqlParRubro.SqlDbType = SqlDbType.VarChar;
                sqlParRubro.Size = 100;
                sqlParRubro.Value = objProv.Telefono;
                sqlCmd.Parameters.Add(sqlParRubro); //Agregamos el parametro al comando

                SqlParameter sqlParDireccion = new SqlParameter();
                sqlParDireccion.ParameterName = "@DireccionPro";
                sqlParDireccion.SqlDbType = SqlDbType.VarChar;
                sqlParDireccion.Size = 100;
                sqlParDireccion.Value = objProv.Rubro;
                sqlCmd.Parameters.Add(sqlParDireccion); //Agregamos el parametro al comando

                SqlParameter sqlParTelefono = new SqlParameter();
                sqlParTelefono.ParameterName = "@TelefonoPro";
                sqlParTelefono.SqlDbType = SqlDbType.VarChar;
                sqlParTelefono.Size = 100;
                sqlParTelefono.Value = objProv.Telefono;
                sqlCmd.Parameters.Add(sqlParTelefono); //Agregamos el parametro al comando

                SqlParameter sqlParEstado = new SqlParameter();
                sqlParEstado.ParameterName = "@EstadoPro";
                sqlParEstado.SqlDbType = SqlDbType.VarChar;
                sqlParEstado.Size = 100;
                sqlParEstado.Value = objProv.Estado;
                sqlCmd.Parameters.Add(sqlParEstado); //Agregamos el parametro al comando



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
        public string MtdModificarProveedor(ClsEProveedor objProv)
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
                sqlCmd.CommandText = "USP_U_ActualizarProveedor";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                //4. Agregar los parametros al comando
                //Establecemos los valores para el parametro @codigoProducto del Procedimiento Almacenado
                SqlParameter sqlcodigoProveedor = new SqlParameter();
                sqlcodigoProveedor.ParameterName = "@CodigoPro ";
                sqlcodigoProveedor.SqlDbType = SqlDbType.VarChar;
                //sqldnicliente.Direction = ParameterDirection.InputOutput;
                sqlcodigoProveedor.Size = 8;
                sqlcodigoProveedor.Value = objProv.Dni;
                sqlCmd.Parameters.Add(sqlcodigoProveedor); //Agregamos el parametro al comando
                                                           //Establecemos los valores para el parametro @nombre del Procedimiento Almacenado
                SqlParameter sqlParRuc = new SqlParameter();
                sqlParRuc.ParameterName = "@RucPro";
                sqlParRuc.SqlDbType = SqlDbType.VarChar;
                sqlParRuc.Size = 100;
                sqlParRuc.Value = objProv.Ruc;
                sqlCmd.Parameters.Add(sqlParRuc); //Agregamos el parametro al comando
                                                  //Establecemos los valores para el parametro @precio del Procedimiento Almacenado
                SqlParameter sqlParDescripcion = new SqlParameter();
                sqlParDescripcion.ParameterName = "@DescripcionPro";
                sqlParDescripcion.SqlDbType = SqlDbType.VarChar;
                sqlParDescripcion.Size = 100;
                sqlParDescripcion.Value = objProv.Descripcion;
                sqlCmd.Parameters.Add(sqlParDescripcion); //Agregamos el parametro al comando

                SqlParameter sqlParRubro = new SqlParameter();
                sqlParRubro.ParameterName = "@RubroPro";
                sqlParRubro.SqlDbType = SqlDbType.VarChar;
                sqlParRubro.Size = 100;
                sqlParRubro.Value = objProv.Rubro;
                sqlCmd.Parameters.Add(sqlParRubro); //Agregamos el parametro al comando

                SqlParameter sqlParDireccion = new SqlParameter();
                sqlParDireccion.ParameterName = "@DireccionPro";
                sqlParDireccion.SqlDbType = SqlDbType.VarChar;
                sqlParDireccion.Size = 100;
                sqlParDireccion.Value = objProv.Direccion;
                sqlCmd.Parameters.Add(sqlParDireccion); //Agregamos el parametro al comando

                SqlParameter sqlParTelefono = new SqlParameter();
                sqlParTelefono.ParameterName = "@TelefonoPro";
                sqlParTelefono.SqlDbType = SqlDbType.VarChar;
                sqlParTelefono.Size = 100;
                sqlParTelefono.Value = objProv.Telefono;
                sqlCmd.Parameters.Add(sqlParTelefono); //Agregamos el parametro al comando

                SqlParameter sqlParEstado = new SqlParameter();
                sqlParEstado.ParameterName = "@EstadoPro ";
                sqlParEstado.SqlDbType = SqlDbType.VarChar;
                sqlParEstado.Size = 100;
                sqlParEstado.Value = objProv.Estado;
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
