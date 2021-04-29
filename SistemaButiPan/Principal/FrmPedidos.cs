using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using SistemaButiPan.Entidades;
using SistemaButiPan.Negocios;

namespace SistemaButiPan.Principal
{
    public partial class FrmPedidos : MaterialSkin.Controls.MaterialForm
    {
        int serie;
        public FrmPedidos()
        {
            InitializeComponent();
        }

        private void FrmPedidos_Load(object sender, EventArgs e)
        {

        
          
                
            
            MtdFecha();
        }
        //fecha
        private void MtdFecha()
        {
            DateTime fecha = DateTime.Now;
            txtFecha.Text = fecha.ToShortDateString();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            textCodigo.Text = string.Format("{0:000000}", serie + 1);
            serie++;
            if (serie == 100000)
                MtdLimpiarCajas();
        }
        private void MtdLimpiarCajas()
        {

            textCodigo.Text = "";
            txtFecha.Text = "";
            textDescripcion.Text = "";
            txtTotal.Text = "";
            txtCliente.Text = "";
            textBuscar.Text = "";
            textCodigo.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ClsEPedidos objEPed = new ClsEPedidos();
            ClsNPedidos ojbjNPed = new ClsNPedidos();
            objEPed.Codigo = textCodigo.Text;
            objEPed.Fecha = txtFecha.Text;
            objEPed.Descripcion = textDescripcion.Text;
            objEPed.Total = txtTotal.Text;
            objEPed.Cliente = txtCliente.Text;
            objEPed.Empleado= textEmpleado.Text;
            objEPed.Estado = cmbEstado.Text;
            ojbjNPed.MtdAgregarPedido(objEPed);
            MessageBox.Show("Pedido Creado");
            MtdLimpiarCajas();
            ClsNPedidos objN = new ClsNPedidos();
            dgvEmpleado.DataSource = objN.MtdListarTodoPedido();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ClsEPedidos objEPed = new ClsEPedidos();
            ClsNPedidos ojbjNPed = new ClsNPedidos();
            objEPed.Codigo = textCodigo.Text;
            objEPed.Descripcion = textDescripcion.Text;
            objEPed.Total = txtTotal.Text;
            objEPed.Cliente = txtCliente.Text;
            objEPed.Empleado = textEmpleado.Text;
            objEPed.Estado = cmbEstado.Text;
            ojbjNPed.MtdModificarEmpleado(objEPed);
            MessageBox.Show("Pedido Actualizado");
            MtdLimpiarCajas();
            ClsNPedidos objN = new ClsNPedidos();
            dgvEmpleado.DataSource = objN.MtdListarTodoPedido();
        }

       

        private void btnListar_Click(object sender, EventArgs e)
        {
            ClsNPedidos objN = new ClsNPedidos();
            dgvEmpleado.DataSource = objN.MtdListarTodoPedido();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ClsEPedidos objEPed = new ClsEPedidos();
            ClsNPedidos ojbjNPed = new ClsNPedidos();
            objEPed.Codigo = textBuscar.Text;
            dgvEmpleado.DataSource = ojbjNPed.MtdBuscarPedidoSQL(objEPed);
        }

        private void textCodigo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textEmpleado_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textDescripcion_KeyPress(object sender, KeyPressEventArgs e)
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
