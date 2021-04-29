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
    class ClsNProductos
    {
        SqlDataAdapter dsqlA = new SqlDataAdapter();
        SqlCommand dsqlC = new SqlCommand();
        DataTable dt = new DataTable();
        //METODO LISTAR
        public DataTable MtdListarTodoProducto()
        {
            DataTable dtProducto = new DataTable("tbProducto");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                ClsNConexion objNcon = new ClsNConexion();
                objNcon.conectar();
                sqlCon.ConnectionString = ClsNConexion.conexDBcadena;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_S_ListarProducto";
                sqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtProducto);
            }
            catch (Exception exec)
            {
                dtProducto = null;
            }
            return dtProducto;
        }
        //METODO AGREGAR
        public string MtdAgregarProductoSQL(ClsEProductos objEPro)
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
                sqlCmd.CommandText = "USP_I_AgregarProducto";
                sqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter sqlcodigo = new SqlParameter();
                sqlcodigo.ParameterName = "@CodigoPro";
                sqlcodigo.SqlDbType = SqlDbType.VarChar;

                sqlcodigo.Size = 8;
                sqlcodigo.Value = objEPro.Codigo;
                sqlCmd.Parameters.Add(sqlcodigo);
                SqlParameter sqlPardescripcion = new SqlParameter();
                sqlPardescripcion.ParameterName = "@DescripcionPro";
                sqlPardescripcion.SqlDbType = SqlDbType.VarChar;
                sqlPardescripcion.Size = 100;
                sqlPardescripcion.Value = objEPro.Descripcion;
                sqlCmd.Parameters.Add(sqlPardescripcion);
                SqlParameter sqlParcantidad = new SqlParameter();
                sqlParcantidad.ParameterName = "@CantidadPro";
                sqlParcantidad.SqlDbType = SqlDbType.VarChar;
                sqlParcantidad.Size = 100;
                sqlParcantidad.Value = objEPro.Cantidad;
                sqlCmd.Parameters.Add(sqlParcantidad);
                SqlParameter sqlParprecio = new SqlParameter();
                sqlParprecio.ParameterName = "@PrecioUnitarioPro";
                sqlParprecio.SqlDbType = SqlDbType.VarChar;
                sqlParprecio.Size = 100;
                sqlParprecio.Value = objEPro.Precio;
                sqlCmd.Parameters.Add(sqlParprecio);
                SqlParameter sqlParproveedor = new SqlParameter();
                sqlParproveedor.ParameterName = "@FCodProveedor";
                sqlParproveedor.SqlDbType = SqlDbType.VarChar;
                sqlParproveedor.Size = 100;
                sqlParproveedor.Value = objEPro.Proveedor;
                sqlCmd.Parameters.Add(sqlParproveedor);


                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Producto de forma correcta";

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
        //METODO BUSCAR
        public DataTable MtdBuscarProductoSQL(ClsEProductos objEPro)
        {
            DataTable dtProdcuto = new DataTable("tbProducto");
            SqlConnection sqlCon = new SqlConnection();
            string rpta = "";
            try
            {
                ClsNConexion objcon = new ClsNConexion();
                objcon.conectar();
                sqlCon.ConnectionString = ClsNConexion.conexDBcadena;
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = sqlCon;
                sqlCmd.CommandText = "USP_S_BuscarProducto";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlcodigo = new SqlParameter();
                sqlcodigo.ParameterName = "@Cod";
                sqlcodigo.Value = objEPro.Codigo;
                sqlCmd.Parameters.Add(sqlcodigo);
                SqlDataAdapter sqlDat = new SqlDataAdapter(sqlCmd);
                sqlDat.Fill(dtProdcuto);
            }
            catch (Exception ex)
            {
                dtProdcuto = null;
            }
            return dtProdcuto;
        }
        //METODO MODIFICAR
        public string MtdEditarProductoSQL(ClsEProductos objEPro)
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
                sqlCmd.CommandText = "USP_U_ActualizarProducto";
                sqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter sqlcodigo = new SqlParameter();
                sqlcodigo.ParameterName = "@CodigoPro";
                sqlcodigo.SqlDbType = SqlDbType.VarChar;

                sqlcodigo.Size = 8;
                sqlcodigo.Value = objEPro.Codigo;
                sqlCmd.Parameters.Add(sqlcodigo);
                SqlParameter sqlPardescripcion = new SqlParameter();
                sqlPardescripcion.ParameterName = "@DescripcionPro";
                sqlPardescripcion.SqlDbType = SqlDbType.VarChar;
                sqlPardescripcion.Size = 100;
                sqlPardescripcion.Value = objEPro.Descripcion;
                sqlCmd.Parameters.Add(sqlPardescripcion);
                SqlParameter sqlParcantidad = new SqlParameter();
                sqlParcantidad.ParameterName = "@CantidadPro";
                sqlParcantidad.SqlDbType = SqlDbType.VarChar;
                sqlParcantidad.Size = 100;
                sqlParcantidad.Value = objEPro.Cantidad;
                sqlCmd.Parameters.Add(sqlParcantidad);
                SqlParameter sqlParprecio = new SqlParameter();
                sqlParprecio.ParameterName = "@PrecioUnitarioPro";
                sqlParprecio.SqlDbType = SqlDbType.VarChar;
                sqlParprecio.Size = 100;
                sqlParprecio.Value = objEPro.Precio;
                sqlCmd.Parameters.Add(sqlParprecio);
                SqlParameter sqlParproveedor = new SqlParameter();
                sqlParproveedor.ParameterName = "@FCodProveedor";
                sqlParproveedor.SqlDbType = SqlDbType.VarChar;
                sqlParproveedor.Size = 100;
                sqlParproveedor.Value = objEPro.Proveedor;
                sqlCmd.Parameters.Add(sqlParproveedor);
                rpta = sqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se inserto el Producto de forma correcta";

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
