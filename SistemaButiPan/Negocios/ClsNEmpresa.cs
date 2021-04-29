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
    class ClsNEmpresa
    {
        SqlDataAdapter dsqlA = new SqlDataAdapter();
        SqlCommand dsqlC = new SqlCommand();
        DataTable dt = new DataTable();
        //METODO LISTAR
        public DataTable MtdListarTodoEmpresa()
        {
            DataTable dtEmpresa = new DataTable("tbEmpresa");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                ClsNConexion objNcon = new ClsNConexion();
                objNcon.conectar();
                sqlCon.ConnectionString = ClsNConexion.conexDBcadena;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_S_ListarEmpresa";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtEmpresa);
            }
            catch (Exception exec)
            {
                dtEmpresa = null;
            }
            return dtEmpresa;
        }
        //METODO BUSCAR
        public DataTable MtdBuscarporEmpresaSQL(ClsEEmpresa objEEmp)
        {
            DataTable dtEmpresa = new DataTable("tbEmpresa");
            SqlConnection sqlCon = new SqlConnection();
            string rpta = "";
            try
            {
                ClsNConexion objcon = new ClsNConexion();
                objcon.conectar();
                sqlCon.ConnectionString = ClsNConexion.conexDBcadena;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_S_BuscarEmpresa";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqldnicliente = new SqlParameter();
                sqldnicliente.ParameterName = "@Ruc";
                sqldnicliente.Value = objEEmp.Ruc;
                sqlCmd.Parameters.Add(sqldnicliente);
                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtEmpresa);
            }
            catch (Exception ex)
            {
                dtEmpresa = null;
            }
            return dtEmpresa;
        }
        //METODO AGREGAR
        public string MtdAgregarEmpresaSQL(ClsEEmpresa objEEmp)
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
                sqlCmd.CommandText = "USP_I_AgregarEmpresa";
                sqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter sqldnicliente = new SqlParameter();
                sqldnicliente.ParameterName = "@RucEmp";
                sqldnicliente.SqlDbType = SqlDbType.VarChar;

                sqldnicliente.Size = 8;
                sqldnicliente.Value = objEEmp.Ruc;
                sqlCmd.Parameters.Add(sqldnicliente);
                SqlParameter sqlParnombre = new SqlParameter();
                sqlParnombre.ParameterName = "@NombreEmp";
                sqlParnombre.SqlDbType = SqlDbType.VarChar;
                sqlParnombre.Size = 100;
                sqlParnombre.Value = objEEmp.Nombre;
                sqlCmd.Parameters.Add(sqlParnombre);
                SqlParameter sqlParApellido = new SqlParameter();
                sqlParApellido.ParameterName = "@DireccionEmp";
                sqlParApellido.SqlDbType = SqlDbType.VarChar;
                sqlParApellido.Size = 100;
                sqlParApellido.Value = objEEmp.Direccion;
                sqlCmd.Parameters.Add(sqlParApellido);
                SqlParameter sqlParEmail = new SqlParameter();
                sqlParEmail.ParameterName = "@TelefonoEmp";
                sqlParEmail.SqlDbType = SqlDbType.VarChar;
                sqlParEmail.Size = 100;
                sqlParEmail.Value = objEEmp.Telefono;
                sqlCmd.Parameters.Add(sqlParEmail);


                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Empresa de forma correcta";

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
        //METODO MODIFICAR
        public string MtdEditarEmpresaSQL(ClsEEmpresa objEEmp)
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
                sqlCmd.CommandText = "USP_U_ActualizarEmpresa";
                sqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter sqldnicliente = new SqlParameter();
                sqldnicliente.ParameterName = "@RucEmp";
                sqldnicliente.SqlDbType = SqlDbType.VarChar;

                sqldnicliente.Size = 8;
                sqldnicliente.Value = objEEmp.Ruc;
                sqlCmd.Parameters.Add(sqldnicliente);
                SqlParameter sqlParnombre = new SqlParameter();
                sqlParnombre.ParameterName = "@NombreEmp";
                sqlParnombre.SqlDbType = SqlDbType.VarChar;
                sqlParnombre.Size = 100;
                sqlParnombre.Value = objEEmp.Nombre;
                sqlCmd.Parameters.Add(sqlParnombre);
                SqlParameter sqlParApellido = new SqlParameter();
                sqlParApellido.ParameterName = "@DireccionEmp";
                sqlParApellido.SqlDbType = SqlDbType.VarChar;
                sqlParApellido.Size = 100;
                sqlParApellido.Value = objEEmp.Direccion;
                sqlCmd.Parameters.Add(sqlParApellido);
                SqlParameter sqlParEmail = new SqlParameter();
                sqlParEmail.ParameterName = "@TelefonoEmp";
                sqlParEmail.SqlDbType = SqlDbType.VarChar;
                sqlParEmail.Size = 100;
                sqlParEmail.Value = objEEmp.Telefono;
                sqlCmd.Parameters.Add(sqlParEmail);

                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Empresa de forma correcta";

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
