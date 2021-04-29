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
    public partial class FrmInventario : MaterialSkin.Controls.MaterialForm
    {
        int serie;
        public FrmInventario()
        {
            InitializeComponent();
        }

        private void FrmCatalogo_Load(object sender, EventArgs e)
        {

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
            txtDescripcion.Text = "";
            txtCantidad.Text = "";
            textPrecio.Text = "";
            cmdEstado.Text = "";
            textProducto.Text = "";
            txtProveedor.Text = "";
            textBuscar.Text = "";
            textCodigo.Focus();
        
    }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (textCodigo.Text != "" && txtDescripcion.Text != "" && txtCantidad.Text != "" && textPrecio.Text != "" && cmdEstado.Text != "" && textProducto.Text != "" && txtProveedor.Text != "")
            {
                ClsEInventario objEInven = new ClsEInventario();
                ClsNInventarios ojbjNInven = new ClsNInventarios();
                objEInven.Codigo = textCodigo.Text;
                objEInven.Descripcion = txtDescripcion.Text;
                objEInven.Cantidad = txtCantidad.Text;
                objEInven.Precio = textPrecio.Text;
                objEInven.Estado = cmdEstado.Text;
                objEInven.Producto = textProducto.Text;
                objEInven.Proveedor = txtProveedor.Text;

                ojbjNInven.MtdAgregarInventarioSQL(objEInven);
                MessageBox.Show("Inventario registrado");
                MtdLimpiarCajas();
                ClsNInventarios objNcli = new ClsNInventarios();
                dgvInventario.DataSource = objNcli.MtdListarTodoInventario();
                MtdLimpiarCajas();

            }
            else
            {
                MessageBox.Show("Faltan datos");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (textCodigo.Text != "" && txtDescripcion.Text != "" && txtCantidad.Text != "" && textPrecio.Text != "" && cmdEstado.Text != "" && textProducto.Text!=""&& txtProveedor.Text != "")
            {
                ClsEInventario objEInven = new ClsEInventario();
                ClsNInventarios ojbjNInven = new ClsNInventarios();
                objEInven.Codigo = textCodigo.Text;
                objEInven.Descripcion = txtDescripcion.Text;
                objEInven.Cantidad = txtCantidad.Text;
                objEInven.Precio = textPrecio.Text;
                objEInven.Estado = cmdEstado.Text;
                objEInven.Producto = textProducto.Text;
                objEInven.Proveedor = txtProveedor.Text;
                ojbjNInven.MtdEditarInventarioSQL(objEInven);
                MessageBox.Show("Inventario Modificado");
                MtdLimpiarCajas();
                ClsNInventarios objNcli = new ClsNInventarios();
                dgvInventario.DataSource = objNcli.MtdListarTodoInventario();
            }
            else
            {
                MessageBox.Show("Ingrese datos del Cliente");
            }
        }

       

        private void btnListar_Click(object sender, EventArgs e)
        {

            ClsNInventarios ojbjNcli = new ClsNInventarios();
            dgvInventario.DataSource = ojbjNcli.MtdListarTodoInventario();
        }

        private void bntBuscar_Click(object sender, EventArgs e)
        {
            ClsEInventario objEInven = new ClsEInventario();
            ClsNInventarios ojbjNInven = new ClsNInventarios();
            objEInven.Codigo= textBuscar.Text;
            dgvInventario.DataSource = ojbjNInven.MtdBuscarInventarioSQL(objEInven);
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

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textProducto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtProveedor_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textPrecio_KeyPress(object sender, KeyPressEventArgs e)
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
