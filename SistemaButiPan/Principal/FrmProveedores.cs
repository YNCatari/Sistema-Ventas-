using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaButiPan.Entidades;
using SistemaButiPan.Negocios;

namespace SistemaButiPan.Principal
{
    public partial class FrmProveedores : MaterialSkin.Controls.MaterialForm
    {
        int serie;
        public FrmProveedores()
        {
            InitializeComponent();
        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtDni.Text = string.Format("{0:000000}", serie + 1);
            serie++;
            if (serie == 100000)
                MtdLimpiarCajas();
        }
        private void MtdLimpiarCajas()
        {

            txtDni.Text = "";
            txtRuc.Text = "";
            txtDescripcion.Text = "";
            cmbRubro.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";


            textBuscar.Text = "";
            txtDni.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ClsEProveedor objEProve = new ClsEProveedor();
            ClsNProveedor ojbjNProve= new ClsNProveedor();
            objEProve.Dni = txtDni.Text;
            objEProve.Ruc = txtRuc.Text;
            objEProve.Descripcion =txtDescripcion.Text;
            objEProve.Rubro = cmbRubro.Text;
            objEProve.Direccion = txtDireccion.Text;
            objEProve.Telefono = txtTelefono.Text;
            string estado = null;
            if (rdbActivo.Checked == true)
            {
                estado = "TRUE";
            }
            if (rdbInactivo.Checked == true)
            {
                estado = "FALSE";
            }
            objEProve.Estado = estado;
            ojbjNProve.MtdAgregarProveedor(objEProve);
            MessageBox.Show("Proveedor Agregado");
            MtdLimpiarCajas();
            ClsNProveedor objN = new ClsNProveedor();
            dgvEmpleado.DataSource = objN.MtdListarTodoProveedor();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ClsEProveedor objEProve = new ClsEProveedor();
            ClsNProveedor ojbjNProve = new ClsNProveedor();
            objEProve.Dni = txtDni.Text;
            objEProve.Ruc = txtRuc.Text;
            objEProve.Descripcion = txtDescripcion.Text;
            objEProve.Rubro = cmbRubro.Text;
            objEProve.Direccion = txtDireccion.Text;
            objEProve.Telefono = txtTelefono.Text;
            string estado = null;
            if (rdbActivo.Checked == true)
            {
                estado = "TRUE";
            }
            if (rdbInactivo.Checked == true)
            {
                estado = "FALSE";
            }
            objEProve.Estado = estado;
            ojbjNProve.MtdModificarProveedor(objEProve);
            MessageBox.Show("Proveedor Modificado");
            MtdLimpiarCajas();
            ClsNProveedor objN = new ClsNProveedor();
            dgvEmpleado.DataSource = objN.MtdListarTodoProveedor();
        }



        private void btnListar_Click(object sender, EventArgs e)
        {
            ClsNProveedor objN = new ClsNProveedor();
            dgvEmpleado.DataSource = objN.MtdListarTodoProveedor();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            ClsEProveedor objEProve = new ClsEProveedor();
            ClsNProveedor ojbjNProve = new ClsNProveedor();
            objEProve.Dni = textBuscar.Text;
            dgvEmpleado.DataSource = ojbjNProve.MtdBuscarProveedorSQL(objEProve);
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBuscar_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
