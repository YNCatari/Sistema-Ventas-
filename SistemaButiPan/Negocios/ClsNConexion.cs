using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SistemaButiPan.Negocios
{
    class ClsNConexion
    {
        public string Servidor = "YN";
        public string Basedatos = "DBVentas";
        public string usuario = "";
        public string clave = "";

        public static SqlConnection conex;
        public static string conexDBcadena;

        public void conectar()
        {
            try
            {
                conexDBcadena = "server=" + Servidor + ";database=" + Basedatos + ";User Id=" + usuario + ";password=" + clave + ";Trusted_Connection=True;";
                conex = new SqlConnection(conexDBcadena);
                conex.Open();
            }
            catch (Exception exec)
            {
                throw exec;
            }
        }
        public void desconectar()
        {
            conex.Close();
        }
    }
}
