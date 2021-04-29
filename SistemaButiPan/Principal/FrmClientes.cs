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
using System.Text.RegularExpressions;

namespace SistemaButiPan.Principal
{
    public partial class FrmClientes : MaterialSkin.Controls.MaterialForm
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MtdLimpiarCajas();
        }
        private void MtdLimpiarCajas()
        {

            textDni.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            textTelefono.Text = "";
            txtEmail.Text = "";
            textBuscar.Text = "";
            textDni.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (textDni.Text != "" && txtNombres.Text != "" && txtApellidos.Text != ""&& textTelefono.Text!="" && txtEmail.Text != "")
            {
                ClsEClientes objEcli = new ClsEClientes();
                ClsNClientes ojbjNcli = new ClsNClientes();
                objEcli.Dni = textDni.Text;
                objEcli.Nombre = txtNombres.Text;
                objEcli.Apellidos = txtApellidos.Text;
                objEcli.Correo = txtEmail.Text;
                objEcli.Telefono = textTelefono.Text;
                ojbjNcli.MtdAgregarClienteSQL(objEcli);
                MessageBox.Show("Cliente Agregado");
                MtdLimpiarCajas();
                ClsNClientes objNcli = new ClsNClientes();
                dgvCliente.DataSource = objNcli.MtdListarTodoCliente();
                MtdLimpiarCajas();
                
            }
            else
            {
                MessageBox.Show("Ingrese Un Cliente");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (textDni.Text != "" && txtNombres.Text != "" && txtApellidos.Text != "" && textTelefono.Text != "" && txtEmail.Text != "")
            {
                ClsEClientes objEcli = new ClsEClientes();
                ClsNClientes ojbjNcli = new ClsNClientes();
                objEcli.Dni = textDni.Text;
                objEcli.Nombre = txtNombres.Text;
                objEcli.Apellidos = txtApellidos.Text;
                objEcli.Correo = txtEmail.Text;
                objEcli.Telefono = textTelefono.Text;
                ojbjNcli.MtdEditarClienteSQL(objEcli);
                MessageBox.Show("Cliente Modificado");
                MtdLimpiarCajas();
                ClsNClientes objNcli = new ClsNClientes();
                dgvCliente.DataSource = objNcli.MtdListarTodoCliente();
            }
            else
            {
                MessageBox.Show("Ingrese datos del Cliente");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (textDni.Text != "")
            {
                ClsEClientes objEcli = new ClsEClientes();
                ClsNClientes ojbjNcli = new ClsNClientes();
                objEcli.Dni = textDni.Text;
                dgvCliente.DataSource = ojbjNcli.MtdEliminarClienteSQL(objEcli);
                dgvCliente.DataSource = ojbjNcli.MtdListarTodoCliente();
                MessageBox.Show("Cliente Eliminado");
                MtdLimpiarCajas();
            }
            else
            {
                MessageBox.Show("Ingrese el DNI del Cliente a eliminar");
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            ClsNClientes ojbjNcli = new ClsNClientes();
            dgvCliente.DataSource = ojbjNcli.MtdListarTodoCliente();
        }

        private void bntBuscar_Click(object sender, EventArgs e)
        {
            ClsEClientes objEcli = new ClsEClientes();
            ClsNClientes ojbjNcli = new ClsNClientes();
            objEcli.Dni = textBuscar.Text;
            dgvCliente.DataSource = ojbjNcli.MtdBuscarporDniSQL(objEcli);
        }

        private void textTelefono_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textDni_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
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
