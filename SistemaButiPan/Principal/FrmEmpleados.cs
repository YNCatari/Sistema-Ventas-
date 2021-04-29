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
    public partial class FrmEmpleados : MaterialSkin.Controls.MaterialForm
    {
        int serie;
        public FrmEmpleados()
        {
            InitializeComponent();
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtDni.Text = string.Format("{0:00000000}", serie + 1);
            serie++;
            if (serie == 100000)
               
                MtdLimpiarCajas();
        }
        private void MtdLimpiarCajas()
        {

            txtDni.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtDireccion.Text = "";

            txtEmail.Text = "";
            cmbCargo.Text = "";
            txtClave.Text = "";
            textBuscar.Text = "";
            txtDni.Focus();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ClsEEmpleados objEEmp = new ClsEEmpleados();
            ClsNEmpleados ojbjNEmp = new ClsNEmpleados();
            objEEmp.Codigo = txtDni.Text;
            objEEmp.Nombre = txtNombres.Text;
            objEEmp.Apellido = txtApellidos.Text;
            objEEmp.Direccion = txtDireccion.Text;
            objEEmp.Correo = txtEmail.Text;
            objEEmp.Cargo = cmbCargo.Text;
            objEEmp.Clave = txtClave.Text;

            string estado = null;
            if (rdbActivo.Checked == true)
            {
                estado = "TRUE";
            }
            if (rdbInactivo.Checked == true)
            {
                estado = "FALSE";
            }
            objEEmp.Estado = estado;
            ojbjNEmp.MtdAgregarEmpleado(objEEmp);
            MessageBox.Show("Empleado Guardado");
            MtdLimpiarCajas();
            ClsNEmpleados objN = new ClsNEmpleados();
            dgvEmpleado.DataSource = objN.MtdListarTodoEmpleado();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ClsEEmpleados objEEmp = new ClsEEmpleados();
            ClsNEmpleados ojbjNEmp = new ClsNEmpleados();
            objEEmp.Codigo = txtDni.Text;
            objEEmp.Nombre = txtNombres.Text;
            objEEmp.Apellido = txtApellidos.Text;
            objEEmp.Direccion = txtDireccion.Text;
            objEEmp.Correo = txtEmail.Text;
            objEEmp.Cargo = cmbCargo.Text;
            objEEmp.Clave = txtClave.Text;

            //estado modificar
            string estado = null;
            if (rdbActivo.Checked == true)
            {
                estado = "TRUE";
            }
            if (rdbInactivo.Checked == true)
            {
                estado = "FALSE";
            }
            objEEmp.Estado = estado;    
            ojbjNEmp.MtdModificarEmpleado(objEEmp);
            MessageBox.Show("Empleado Modificado");
            MtdLimpiarCajas();
            ClsNEmpleados objN = new ClsNEmpleados();
            dgvEmpleado.DataSource = objN.MtdListarTodoEmpleado();
            
        }

       
        private void btnListar_Click(object sender, EventArgs e)
        {
            ClsNEmpleados objN = new ClsNEmpleados();
            dgvEmpleado.DataSource = objN.MtdListarTodoEmpleado();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ClsEEmpleados objEEmp = new ClsEEmpleados();
            ClsNEmpleados ojbjNEmp = new ClsNEmpleados();
            objEEmp.Codigo = textBuscar.Text;
            dgvEmpleado.DataSource = ojbjNEmp.MtdBuscarEmpleadoSQL(objEEmp);
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
