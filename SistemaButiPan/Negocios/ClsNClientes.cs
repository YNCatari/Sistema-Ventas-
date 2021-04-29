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
    class ClsNClientes
    {
        SqlDataAdapter dsqlA = new SqlDataAdapter();
        SqlCommand dsqlC = new SqlCommand();
        DataTable dt = new DataTable();
        //Metodo Listar
        public DataTable MtdListarTodoCliente()
        {
            DataTable dtCliente = new DataTable("tbCliente");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                ClsNConexion objNcon = new ClsNConexion();
                objNcon.conectar();
                sqlCon.ConnectionString = ClsNConexion.conexDBcadena;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_S_ListarCliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtCliente);
            }
            catch (Exception exec)
            {
                dtCliente = null;
            }
            return dtCliente;
        }
        //Metodo Agregar 
        public string MtdAgregarClienteSQL(ClsEClientes objECli)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                ClsNConexion objcon = new ClsNConexion();
                objcon.conectar();

                sqlCon.ConnectionString = ClsNConexion.conexDBcadena;

                sqlCon.Open();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_I_AgregarCliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter sqldnicliente = new SqlParameter();
                sqldnicliente.ParameterName = "@DniCli";
                sqldnicliente.SqlDbType = SqlDbType.VarChar;

                sqldnicliente.Size = 8;
                sqldnicliente.Value = objECli.Dni;
                sqlCmd.Parameters.Add(sqldnicliente);
                SqlParameter sqlParnombre = new SqlParameter();
                sqlParnombre.ParameterName = "@NombreCli ";
                sqlParnombre.SqlDbType = SqlDbType.VarChar;
                sqlParnombre.Size = 100;
                sqlParnombre.Value = objECli.Nombre;
                sqlCmd.Parameters.Add(sqlParnombre);
                SqlParameter sqlParApellido = new SqlParameter();
                sqlParApellido.ParameterName = "@ApellidoCli";
                sqlParApellido.SqlDbType = SqlDbType.VarChar;
                sqlParApellido.Size = 100;
                sqlParApellido.Value = objECli.Apellidos;
                sqlCmd.Parameters.Add(sqlParApellido);
                SqlParameter sqlParTelefono = new SqlParameter();
                sqlParTelefono.ParameterName = "@TelefonoCli";
                sqlParTelefono.SqlDbType = SqlDbType.VarChar;
                sqlParTelefono.Size = 100;
                sqlParTelefono.Value = objECli.Telefono;
                sqlCmd.Parameters.Add(sqlParTelefono);
                SqlParameter sqlParEmail = new SqlParameter();
                sqlParEmail.ParameterName = "@EmailCli";
                sqlParEmail.SqlDbType = SqlDbType.VarChar;
                sqlParEmail.Size = 100;
                sqlParEmail.Value = objECli.Correo;
                sqlCmd.Parameters.Add(sqlParEmail);


                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Cliente de forma correcta";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {

                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return rpta;
        }
        //Metodo Buscar
        public DataTable MtdBuscarporDniSQL(ClsEClientes objECli)
        {
            DataTable dtCliente = new DataTable("tbCliente");
            SqlConnection sqlCon = new SqlConnection();
            string rpta = "";
            try
            {
                ClsNConexion objcon = new ClsNConexion();
                objcon.conectar();
                sqlCon.ConnectionString = ClsNConexion.conexDBcadena;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_S_BuscarCliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqldnicliente = new SqlParameter();
                sqldnicliente.ParameterName = "@DniCli";
                sqldnicliente.Value = objECli.Dni;
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
        //Metodo Eliminar
        public DataTable MtdEliminarClienteSQL(ClsEClientes objEcli)
        {
            DataTable dtCliente = new DataTable("tbCliente");
            SqlConnection sqlCon = new SqlConnection();
            string rpta = "";
            try
            {
                ClsNConexion objcon = new ClsNConexion();
                objcon.conectar();
                sqlCon.ConnectionString = ClsNConexion.conexDBcadena;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_D_EliminarCliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqldnicliente = new SqlParameter();
                sqldnicliente.ParameterName = "@DniCli";
                sqldnicliente.Value = objEcli.Dni;
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
        //Metodo Modificar
        public string MtdEditarClienteSQL(ClsEClientes objECli)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                ClsNConexion objcon = new ClsNConexion();
                objcon.conectar();

                sqlCon.ConnectionString = ClsNConexion.conexDBcadena;

                sqlCon.Open();

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_U_ActualizarCliente";
                sqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter sqldnicliente = new SqlParameter();
                sqldnicliente.ParameterName = "@DniCli";
                sqldnicliente.SqlDbType = SqlDbType.VarChar;

                sqldnicliente.Size = 8;
                sqldnicliente.Value = objECli.Dni;
                sqlCmd.Parameters.Add(sqldnicliente);
                SqlParameter sqlParnombre = new SqlParameter();
                sqlParnombre.ParameterName = "@NombreCli";
                sqlParnombre.SqlDbType = SqlDbType.VarChar;
                sqlParnombre.Size = 100;
                sqlParnombre.Value = objECli.Nombre;
                sqlCmd.Parameters.Add(sqlParnombre);
                SqlParameter sqlParApellido = new SqlParameter();
                sqlParApellido.ParameterName = "@ApellidoCli";
                sqlParApellido.SqlDbType = SqlDbType.VarChar;
                sqlParApellido.Size = 100;
                sqlParApellido.Value = objECli.Apellidos;
                sqlCmd.Parameters.Add(sqlParApellido);
                SqlParameter sqlParTelefono = new SqlParameter();
                sqlParTelefono.ParameterName = "@TelefonoCli";
                sqlParTelefono.SqlDbType = SqlDbType.VarChar;
                sqlParTelefono.Size = 100;
                sqlParTelefono.Value = objECli.Telefono;
                sqlCmd.Parameters.Add(sqlParTelefono);
                SqlParameter sqlParEmail = new SqlParameter();
                sqlParEmail.ParameterName = "@EmailCli";
                sqlParEmail.SqlDbType = SqlDbType.VarChar;
                sqlParEmail.Size = 100;
                sqlParEmail.Value = objECli.Correo;
                sqlCmd.Parameters.Add(sqlParEmail);


                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Cliente de forma correcta";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {

                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
            return rpta;
        }
    }
}
