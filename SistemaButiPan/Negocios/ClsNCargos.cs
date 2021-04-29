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
    class ClsNCargos
    {
        //metodo listar
        SqlDataAdapter dsqlA = new SqlDataAdapter();
        SqlCommand dsqlC = new SqlCommand();
        DataTable dt = new DataTable();
        public DataTable MtdListarTodoCargoSQL()
        {
            DataTable dtCargo = new DataTable("tbCargo");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                ClsNConexion objNcon = new ClsNConexion();
                objNcon.conectar();
                sqlCon.ConnectionString = ClsNConexion.conexDBcadena;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_S_ListarCargo";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtCargo);
            }
            catch (Exception exec)
            {
                dtCargo = null;
            }
            return dtCargo;
        }
        // metodo Agregar
        public string MtdAgregarCargoSQL( ClsECargos objECargo)
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
                sqlCmd.CommandText = "USP_I_AgregarCargo";
                sqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter sqldniCargo = new SqlParameter();
                sqldniCargo.ParameterName = "@IDCargo ";
                sqldniCargo.SqlDbType = SqlDbType.VarChar;

                sqldniCargo.Size = 8;
                sqldniCargo.Value = objECargo.Cargo;
                sqlCmd.Parameters.Add(sqldniCargo);
                SqlParameter sqlParDescripcion = new SqlParameter();
                sqlParDescripcion.ParameterName = "@DESCargo";
                sqlParDescripcion.SqlDbType = SqlDbType.VarChar;
                sqlParDescripcion.Size = 100;
                sqlParDescripcion.Value = objECargo.Descripcion;
                sqlCmd.Parameters.Add(sqlParDescripcion);



                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Cargo de forma correcta";

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
        //metodo Buscar 
        public DataTable MtdBuscarporCargoSQL(ClsECargos objECargo)
        {
            DataTable dtCargo = new DataTable("tbCargo");
            SqlConnection sqlCon = new SqlConnection();
            string rpta = "";
            try
            {
                ClsNConexion objcon = new ClsNConexion();
                objcon.conectar();
                sqlCon.ConnectionString = ClsNConexion.conexDBcadena;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_S_BuscarCargo";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlidcargo = new SqlParameter();
                sqlidcargo.ParameterName = "@Idcargo";
                sqlidcargo.Value = objECargo.Cargo;
                sqlCmd.Parameters.Add(sqlidcargo);
                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtCargo);
            }
            catch (Exception ex)
            {
                dtCargo = null;
            }
            return dtCargo;
        }
        //Metodo Modificar
        public string MtdEditarProdcutoSQL(ClsECargos objECargo)
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
                sqlCmd.CommandText = "USP_U_ActualizarCargo";
                sqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter sqldnicliente = new SqlParameter();
                sqldnicliente.ParameterName = "@idcargo ";
                sqldnicliente.SqlDbType = SqlDbType.VarChar;

                sqldnicliente.Size = 8;
                sqldnicliente.Value = objECargo.Cargo;
                sqlCmd.Parameters.Add(sqldnicliente);
                SqlParameter sqlPardiscripcion = new SqlParameter();
                sqlPardiscripcion.ParameterName = "@Desc";
                sqlPardiscripcion.SqlDbType = SqlDbType.VarChar;
                sqlPardiscripcion.Size = 100;
                sqlPardiscripcion.Value = objECargo.Descripcion;
                sqlCmd.Parameters.Add(sqlPardiscripcion);



                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Cargo de forma correcta";

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
