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

namespace SistemaButiPan.Principal
{
    public partial class FrmEmpresa : MaterialSkin.Controls.MaterialForm
    {
        public FrmEmpresa()
        {
            InitializeComponent();
        }
        public static string ruc = "";
        private void FrmEmpresa_Load(object sender, EventArgs e)
        {

        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            MtdLimpiarCajas();
        }
        private void MtdLimpiarCajas()
        {

            txtRuc.Text = "";
            txtNombres.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtBuscar.Text = "";
            txtRuc.Focus();
        
    }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (txtRuc.Text != "" && txtNombres.Text != "" && txtDireccion.Text != "" && txtTelefono.Text != "")
            {
                ClsEEmpresa objEEmp = new ClsEEmpresa();
                ClsNEmpresa ojbjNEmp = new ClsNEmpresa();
                objEEmp.Ruc = txtRuc.Text;
                objEEmp.Nombre = txtNombres.Text;
                objEEmp.Direccion = txtDireccion.Text;
                objEEmp.Telefono = txtTelefono.Text;
                ojbjNEmp.MtdAgregarEmpresaSQL(objEEmp);

                MtdLimpiarCajas();
                ClsNEmpresa objNcli = new ClsNEmpresa();
                dgvEmpresa.DataSource = objNcli.MtdListarTodoEmpresa();
                MtdLimpiarCajas();
               
            }
            else
            {
                MessageBox.Show("Ingrese datos de Empresa");
            }
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            if (txtRuc.Text != "" && txtNombres.Text != "" && txtDireccion.Text != "" && txtTelefono.Text != "")
            {
                ClsEEmpresa objEEmp = new ClsEEmpresa();
                ClsNEmpresa ojbjNEmp = new ClsNEmpresa();
                objEEmp.Ruc = txtRuc.Text;
                objEEmp.Nombre = txtNombres.Text;
                objEEmp.Direccion = txtDireccion.Text;
                objEEmp.Telefono = txtTelefono.Text;
                ojbjNEmp.MtdEditarEmpresaSQL(objEEmp);
                MessageBox.Show("Empresa Modificado");
                MtdLimpiarCajas();
                ClsNEmpresa objNcli = new ClsNEmpresa();
                dgvEmpresa.DataSource = objNcli.MtdListarTodoEmpresa();
            }
            else
            {
                MessageBox.Show("Ingrese datos de La Empresa");
            }
        }

        private void btnlistar_Click(object sender, EventArgs e)
        {
            ClsNEmpresa objN = new ClsNEmpresa();
            dgvEmpresa.DataSource = objN.MtdListarTodoEmpresa();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            ClsEEmpresa objEEmp = new ClsEEmpresa();
            txtRuc.Text = FrmPrincipal.ruc;
            ClsNEmpresa objNEmp = new ClsNEmpresa();
            objEEmp.Ruc = txtBuscar.Text;
            dgvEmpresa.DataSource = objNEmp.MtdBuscarporEmpresaSQL(objEEmp);
        }

        private void txtRuc_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
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
