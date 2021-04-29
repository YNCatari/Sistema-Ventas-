using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SistemaButiPan.Principal
{

    public partial class FrmPrincipal : Form
    {
        Button Activo;
        Color dark = Color.FromArgb(189, 151, 47);
        public FrmPrincipal()
        {
            InitializeComponent();
        }
        public static ArrayList ArrProductos = new ArrayList();//crea un objeto de arraylista
        public static int ayuda = 0;
        public static string codEmp = "";
        public static string nombreEmp = "";
        public static string apelliEmp = "";
        public static string ruc = "";
        public static string cargoEmp="";
        public static int contEmp = 1;
        public void loadForm(Form form)
        {
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            group.Controls.Clear();
            group.Controls.Add(form);
            form.Show();
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

           

            if (cargoEmp.Equals("1"))
                {
                    btnempresa.Enabled = true;
                    btnclientes.Enabled = true;
                    btnempleados.Enabled = true;
                    btnProveedor.Enabled = true;
                    btnProducto.Enabled = true;
                    btnBoletas.Enabled = true;
                    btnInventario.Enabled = true;
                    btnPedidos.Enabled = true;
                    btnReportes.Enabled = true;
                    btnReportdetalle.Enabled = true;
                    btncargo.Enabled = true;
                }

           

            if (cargoEmp.Equals("2"))
                {
                    btnempresa.Enabled =false;
                    btnclientes.Enabled = false;
                    btnempleados.Enabled = false;
                    btnProveedor.Enabled = false;
                    btnProducto.Enabled = true;
                    btnBoletas.Enabled = false;
                    btnInventario.Enabled = true;
                    btnPedidos.Enabled = true;
                    btnReportes.Enabled = true;
                    btnReportdetalle.Enabled = true;
                    btncargo.Enabled = false;
                }

                if (cargoEmp.Equals("3"))
                {
                    btnempresa.Enabled = false;
                    btnclientes.Enabled = true;
                    btnempleados.Enabled = false;
                    btnProveedor.Enabled = false;
                    btnProducto.Enabled = true;
                    btnBoletas.Enabled = true;
                    btnInventario.Enabled = true;
                    btnPedidos.Enabled = true;
                    btnReportes.Enabled = true;
                    btnReportdetalle.Enabled = true;
                    btncargo.Enabled = false;

                }
            

            //
            btnempresa.BackColor = dark;
            btnclientes.BackColor = dark;
            btnempleados.BackColor = dark;
            btnProveedor.BackColor = dark;
            btncargo.BackColor = dark;
            btnProducto.BackColor = dark;
            btnBoletas.BackColor = dark;
            btnInventario.BackColor = dark;
            btnPedidos.BackColor = dark;
            btnReportes.BackColor = dark;
            btncerrar.BackColor = dark;
            btnReportdetalle.BackColor = dark;
            panelIzquierdo.BackColor = Color.FromArgb(189, 151, 47);
        }
        public void setActiveForm(Button btn)
        {
            if (btn != Activo)
            {
                btn.BackColor = Color.FromArgb(105, 84, 26);
                if (Activo != null) { Activo.BackColor = Color.FromArgb(189, 151, 47); }
                Activo = btn;
            }
        }

        private void btnclientes_Click(object sender, EventArgs e)
        {
            setActiveForm(btnclientes);
            loadForm(new FrmClientes());
        }

        private void btnempleados_Click(object sender, EventArgs e)
        {
            setActiveForm(btnempleados);
            loadForm(new FrmEmpleados());
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            setActiveForm(btnProveedor);
            loadForm(new FrmProveedores());
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            setActiveForm(btnProducto);
            loadForm(new FrmProductos());
        }

        private void btnBoletas_Click(object sender, EventArgs e)
        {
            setActiveForm(btnBoletas);
            loadForm(new FrmBoletas());
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            setActiveForm(btnInventario);
            loadForm(new FrmInventario());
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            setActiveForm(btnPedidos);
            loadForm(new FrmPedidos());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            setActiveForm(btnReportes);
            loadForm(new FrmRBoleta());
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void btncargo_Click(object sender, EventArgs e)
        {
            setActiveForm(btncargo);
            loadForm(new FrmCargos());
        }

        private void btnReportdetalle_Click(object sender, EventArgs e)
        {
            setActiveForm(btnReportdetalle);
            loadForm(new FrmDetalles());
        }

        private void btnempresa_Click(object sender, EventArgs e)
        {
            setActiveForm(btnempresa);
            loadForm(new FrmEmpresa());
        }
    }
}





