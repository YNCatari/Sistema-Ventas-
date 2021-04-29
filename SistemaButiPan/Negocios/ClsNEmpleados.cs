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
    class ClsNEmpleados
    {
        SqlDataAdapter dsqlA = new SqlDataAdapter();
        SqlCommand dsqlC = new SqlCommand();
        DataTable dt = new DataTable();
        //Metodo Listar
        public DataTable MtdListarTodoEmpleado()
        {
            DataTable dtEmpleado = new DataTable("tbEmpleado");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                ClsNConexion objNcon = new ClsNConexion();
                objNcon.conectar();
                sqlCon.ConnectionString = ClsNConexion.conexDBcadena;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_S_ListarEmpleado";
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
        //VALIDAR LOGIN
        public DataTable MtdValidarLoginSQL(ClsEEmpleados objEmp)
        {
            DataTable dtEmpleado = new DataTable("tbEmpleado");
            SqlConnection sqlCon = new SqlConnection();
            string rpta = "";
            try
            {
                ClsNConexion objcon = new ClsNConexion();
                objcon.conectar();
                sqlCon.ConnectionString = ClsNConexion.conexDBcadena;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_S_Login";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlcodemp = new SqlParameter();
                sqlcodemp.ParameterName = "@CodigoEmp";
                sqlcodemp.Value = objEmp.Codigo;
                sqlCmd.Parameters.Add(sqlcodemp);
                SqlParameter sqlclaveemp = new SqlParameter();
                sqlclaveemp.ParameterName = "@ClaveEmp";
                sqlclaveemp.Value = objEmp.Clave;
                sqlCmd.Parameters.Add(sqlclaveemp);
                SqlParameter sqlestadoemp = new SqlParameter();
                sqlestadoemp.ParameterName = "@EstadoEmp";
                sqlestadoemp.Value = objEmp.Estado;
                sqlCmd.Parameters.Add(sqlestadoemp);
                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtEmpleado);
            }
            catch (Exception ex)
            {
                dtEmpleado = null;
            }
            return dtEmpleado;
        }
        //Metodo Buscar
        public DataTable MtdBuscarEmpleadoSQL(ClsEEmpleados objEmp)
        {
            DataTable dtEmpleado = new DataTable("tbEmpleado");
            SqlConnection sqlCon = new SqlConnection();
            string rpta = "";
            try
            {
                ClsNConexion objcon = new ClsNConexion();
                objcon.conectar();
                sqlCon.ConnectionString = ClsNConexion.conexDBcadena;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_S_BuscarEmpleado";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlcodigoempleado = new SqlParameter();
                sqlcodigoempleado.ParameterName = "@Codigo";
                sqlcodigoempleado.Value = objEmp.Codigo;
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
        public string MtdAgregarEmpleado(ClsEEmpleados objEEmpleado)
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
                sqlCmd.CommandText = "USP_I_AgregarEmpleado";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                //4. Agregar los parametros al comando
                //Establecemos los valores para el parametro @codigoProducto del Procedimiento Almacenado
                SqlParameter sqlcodigoEmpleado = new SqlParameter();
                sqlcodigoEmpleado.ParameterName = "@CodigoEmp";
                sqlcodigoEmpleado.SqlDbType = SqlDbType.VarChar;
                //sqldnicliente.Direction = ParameterDirection.InputOutput;
                sqlcodigoEmpleado.Size = 8;
                sqlcodigoEmpleado.Value = objEEmpleado.Codigo;
                sqlCmd.Parameters.Add(sqlcodigoEmpleado); //Agregamos el parametro al comando
                                                          //Establecemos los valores para el parametro @nombre del Procedimiento Almacenado
                SqlParameter sqlParNombreEmpleado = new SqlParameter();
                sqlParNombreEmpleado.ParameterName = "@NombreEmp";
                sqlParNombreEmpleado.SqlDbType = SqlDbType.VarChar;
                sqlParNombreEmpleado.Size = 100;
                sqlParNombreEmpleado.Value = objEEmpleado.Nombre;
                sqlCmd.Parameters.Add(sqlParNombreEmpleado); //Agregamos el parametro al comando
                                                             //Establecemos los valores para el parametro @precio del Procedimiento Almacenado
                SqlParameter sqlParApellidoEmpleado = new SqlParameter();
                sqlParApellidoEmpleado.ParameterName = "@ApellidoEmp";
                sqlParApellidoEmpleado.SqlDbType = SqlDbType.VarChar;
                sqlParApellidoEmpleado.Size = 100;
                sqlParApellidoEmpleado.Value = objEEmpleado.Apellido;
                sqlCmd.Parameters.Add(sqlParApellidoEmpleado); //Agregamos el parametro al comando

                SqlParameter sqlParDireccEmpleado = new SqlParameter();
                sqlParDireccEmpleado.ParameterName = "@DireccionEmp";
                sqlParDireccEmpleado.SqlDbType = SqlDbType.VarChar;
                sqlParDireccEmpleado.Size = 100;
                sqlParDireccEmpleado.Value = objEEmpleado.Direccion;
                sqlCmd.Parameters.Add(sqlParDireccEmpleado); //Agregamos el parametro al comando

                SqlParameter sqlParEmailEmpleado = new SqlParameter();
                sqlParEmailEmpleado.ParameterName = "@EmailEmp";
                sqlParEmailEmpleado.SqlDbType = SqlDbType.VarChar;
                sqlParEmailEmpleado.Size = 100;
                sqlParEmailEmpleado.Value = objEEmpleado.Correo;
                sqlCmd.Parameters.Add(sqlParEmailEmpleado); //Agregamos el parametro al comando

                SqlParameter sqlParCargoEmpleado = new SqlParameter();
                sqlParCargoEmpleado.ParameterName = "@CargoEmp";
                sqlParCargoEmpleado.SqlDbType = SqlDbType.VarChar;
                sqlParCargoEmpleado.Size = 100;
                sqlParCargoEmpleado.Value = objEEmpleado.Cargo;
                sqlCmd.Parameters.Add(sqlParCargoEmpleado); //Agregamos el parametro al comando

                SqlParameter sqlParClaveEmpleado = new SqlParameter();
                sqlParClaveEmpleado.ParameterName = "@ClaveEmp";
                sqlParClaveEmpleado.SqlDbType = SqlDbType.VarChar;
                sqlParClaveEmpleado.Size = 100;
                sqlParClaveEmpleado.Value = objEEmpleado.Clave;
                sqlCmd.Parameters.Add(sqlParClaveEmpleado); //Agregamos el parametro al comando

                SqlParameter sqlParEstadoEmpleado = new SqlParameter();
                sqlParEstadoEmpleado.ParameterName = "@EstadoEmp";
                sqlParEstadoEmpleado.SqlDbType = SqlDbType.VarChar;
                sqlParEstadoEmpleado.Size = 100;
                sqlParEstadoEmpleado.Value = objEEmpleado.Estado;
                sqlCmd.Parameters.Add(sqlParEstadoEmpleado); //Agregamos el parametro al comando

               

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
        public string MtdModificarEmpleado(ClsEEmpleados objEEmpleado)
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
                sqlCmd.CommandText = "USP_U_ActualizarEmpleado";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                //4. Agregar los parametros al comando
                //Establecemos los valores para el parametro @codigoProducto del Procedimiento Almacenado
                SqlParameter sqlcodigoEmpleado = new SqlParameter();
                sqlcodigoEmpleado.ParameterName = "@CodigoEmp";
                sqlcodigoEmpleado.SqlDbType = SqlDbType.VarChar;
                //sqldnicliente.Direction = ParameterDirection.InputOutput;
                sqlcodigoEmpleado.Size = 8;
                sqlcodigoEmpleado.Value = objEEmpleado.Codigo;
                sqlCmd.Parameters.Add(sqlcodigoEmpleado); //Agregamos el parametro al comando
                                                          //Establecemos los valores para el parametro @nombre del Procedimiento Almacenado
                SqlParameter sqlParNombreEmpleado = new SqlParameter();
                sqlParNombreEmpleado.ParameterName = "@NombreEmp";
                sqlParNombreEmpleado.SqlDbType = SqlDbType.VarChar;
                sqlParNombreEmpleado.Size = 100;
                sqlParNombreEmpleado.Value = objEEmpleado.Nombre;
                sqlCmd.Parameters.Add(sqlParNombreEmpleado); //Agregamos el parametro al comando
                                                             //Establecemos los valores para el parametro @precio del Procedimiento Almacenado
                SqlParameter sqlParApellidoEmpleado = new SqlParameter();
                sqlParApellidoEmpleado.ParameterName = "@ApellidoEmp";
                sqlParApellidoEmpleado.SqlDbType = SqlDbType.VarChar;
                sqlParApellidoEmpleado.Size = 100;
                sqlParApellidoEmpleado.Value = objEEmpleado.Apellido;
                sqlCmd.Parameters.Add(sqlParApellidoEmpleado); //Agregamos el parametro al comando

                SqlParameter sqlParDireccEmpleado = new SqlParameter();
                sqlParDireccEmpleado.ParameterName = "@DireccionEmp";
                sqlParDireccEmpleado.SqlDbType = SqlDbType.VarChar;
                sqlParDireccEmpleado.Size = 100;
                sqlParDireccEmpleado.Value = objEEmpleado.Direccion;
                sqlCmd.Parameters.Add(sqlParDireccEmpleado); //Agregamos el parametro al comando

                SqlParameter sqlParEmailEmpleado = new SqlParameter();
                sqlParEmailEmpleado.ParameterName = "@EmailEmp";
                sqlParEmailEmpleado.SqlDbType = SqlDbType.VarChar;
                sqlParEmailEmpleado.Size = 100;
                sqlParEmailEmpleado.Value = objEEmpleado.Correo;
                sqlCmd.Parameters.Add(sqlParEmailEmpleado); //Agregamos el parametro al comando

                SqlParameter sqlParCargoEmpleado = new SqlParameter();
                sqlParCargoEmpleado.ParameterName = "@CargoEmp";
                sqlParCargoEmpleado.SqlDbType = SqlDbType.VarChar;
                sqlParCargoEmpleado.Size = 100;
                sqlParCargoEmpleado.Value = objEEmpleado.Cargo;
                sqlCmd.Parameters.Add(sqlParCargoEmpleado); //Agregamos el parametro al comando

                SqlParameter sqlParClaveEmpleado = new SqlParameter();
                sqlParClaveEmpleado.ParameterName = "@ClaveEmp";
                sqlParClaveEmpleado.SqlDbType = SqlDbType.VarChar;
                sqlParClaveEmpleado.Size = 100;
                sqlParClaveEmpleado.Value = objEEmpleado.Clave;
                sqlCmd.Parameters.Add(sqlParClaveEmpleado); //Agregamos el parametro al comando

                SqlParameter sqlParEstadoEmpleado = new SqlParameter();
                sqlParEstadoEmpleado.ParameterName = "@EstadoEmp";
                sqlParEstadoEmpleado.SqlDbType = SqlDbType.VarChar;
                sqlParEstadoEmpleado.Size = 100;
                sqlParEstadoEmpleado.Value = objEEmpleado.Estado;
                sqlCmd.Parameters.Add(sqlParEstadoEmpleado); //Agregamos el parametro al comando


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
        public DataTable MtdEliminarEmpleadoSQL(ClsEEmpleados objEEmp)
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
