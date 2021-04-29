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
    public partial class FrmCargos : MaterialSkin.Controls.MaterialForm
    {
        public FrmCargos()
        {
            InitializeComponent();
        }

        private void FrmCargos_Load(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {


            MtdLimpiarCajas();
        }
        private void MtdLimpiarCajas()
        {

            textCargo.Text = "";
            txtDescripcion.Text = "";
            textCargo.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (textCargo.Text != "" && txtDescripcion.Text != "")
            {
                ClsECargos objECargo = new ClsECargos();
                ClsNCargos ojbjNCargo = new ClsNCargos();
                objECargo.Cargo = textCargo.Text;
                objECargo.Descripcion = txtDescripcion.Text;
                ojbjNCargo.MtdAgregarCargoSQL(objECargo);
                MessageBox.Show("Guardar Cargo");
                MtdLimpiarCajas();
                ClsNCargos objN = new ClsNCargos();
                dgvCargo.DataSource = objN.MtdListarTodoCargoSQL();
                
               
            }
            else
            {
                MessageBox.Show("Ingrese Un  datos");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (textCargo.Text != "" && txtDescripcion.Text != "")
            {
                ClsECargos objECargo = new ClsECargos();
                ClsNCargos ojbjNCargo = new ClsNCargos();
                objECargo.Cargo = textCargo.Text;
                objECargo.Descripcion = txtDescripcion.Text;
                ojbjNCargo.MtdEditarProdcutoSQL(objECargo);
                MessageBox.Show("Cargo Modificado");
                MtdLimpiarCajas();
                ClsNCargos objN = new ClsNCargos();
                dgvCargo.DataSource = objN.MtdListarTodoCargoSQL();
            }
            else
            {
                MessageBox.Show("Ingrese Un Cargo");
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            ClsNCargos objN = new ClsNCargos();
            dgvCargo.DataSource = objN.MtdListarTodoCargoSQL();
        }

        private void bntBuscar_Click(object sender, EventArgs e)
        {
            ClsECargos objECargo = new ClsECargos();

            ClsNCargos objN = new ClsNCargos();
            objECargo.Cargo = textBuscar.Text;
            dgvCargo.DataSource = objN.MtdBuscarporCargoSQL(objECargo);
        }

        private void textCargo_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
