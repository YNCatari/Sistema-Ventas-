using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SistemaButiPan.Entidades;
using SistemaButiPan.Negocios;
using SistemaButiPan.Principal;

namespace SistemaButiPan
{
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Brown500, MaterialSkin.Primary.Brown500, MaterialSkin.Primary.Cyan900, MaterialSkin.Accent.Pink100, MaterialSkin.TextShade.WHITE);
        }
        public static string codigoLogin;
        public static string nombreLogin;
        public static string ApellidosLogin;
  
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == null || txtClave.Text == "")
            {
                if (txtClave.Text == null || txtCodigo.Text == "")
                {
                    MessageBox.Show("Contraseñas Incorrectas Vuelve a Intentarlo");
                }
            }
            ClsEEmpleados objEemp = new ClsEEmpleados();
            ClsNEmpleados objEmp = new ClsNEmpleados();
            objEemp.Codigo = txtCodigo.Text;
            objEemp.Clave = txtClave.Text;
            objEemp.Estado = "TRUE";
            DataTable dtEmp = new DataTable();
            dtEmp = objEmp.MtdValidarLoginSQL(objEemp);
            if (dtEmp.Rows.Count > 0)
            {
                DataRow Fila = dtEmp.Rows[0];
                string Cod, Nom,Ape, Car;
                Cod = Fila["Codigo"].ToString();
                Nom = Fila["Nombre"].ToString();
                Ape = Fila["Apellido"].ToString();
                Car = Fila["Cargo"].ToString();

                FrmPrincipal.codEmp = Cod;
                FrmPrincipal.nombreEmp = Nom;
                FrmPrincipal.apelliEmp = Ape;
                FrmPrincipal.cargoEmp = Car;


                MessageBox.Show("Bienvenidos Sr(a): " + Nom + " Con Cargo de : " + Car);
                FrmPrincipal Frm = new FrmPrincipal();
                Frm.Show();
                this.Hide();

            }
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))//Si es número
            {
                e.Handled = false;
            }
            else if (e.KeyChar == (char)Keys.Back)//si es tecla borrar
            {
                e.Handled = false;
            }
            else //Si es otra tecla cancelamos
            {
                e.Handled = true;
            }
        }
    }
}
