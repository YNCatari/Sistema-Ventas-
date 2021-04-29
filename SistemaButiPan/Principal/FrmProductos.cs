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
    public partial class FrmProductos : MaterialSkin.Controls.MaterialForm
    {
        int serie;
        public FrmProductos()
        {
            InitializeComponent();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
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
            txtPrecioUnit.Text = "";
            textBuscar.Text = "";
            textCodigo.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (textCodigo.Text != "" && txtDescripcion.Text != "" && txtCantidad.Text != "" && txtPrecioUnit.Text != "" && txtProveedor.Text != "")
            {
                ClsEProductos objEPro = new ClsEProductos();
                ClsNProductos ojbNpro = new ClsNProductos();
                objEPro.Codigo = textCodigo.Text;
                objEPro.Descripcion = txtDescripcion.Text;
                objEPro.Cantidad = Convert.ToInt32(txtCantidad.Text);
                objEPro.Precio = Convert.ToDouble(txtPrecioUnit.Text);
                objEPro.Proveedor = txtProveedor.Text;
                ojbNpro.MtdAgregarProductoSQL(objEPro);

                MtdLimpiarCajas();
                ClsNProductos objNPr = new ClsNProductos();
                dgvProducto.DataSource = objNPr.MtdListarTodoProducto();
                MessageBox.Show("Producto Guardado");
                MtdLimpiarCajas();
                
            }
            else
            {
                MessageBox.Show("Ingrese datos de Producto");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            if (textCodigo.Text != "" && txtDescripcion.Text != "" && txtCantidad.Text != "" && txtPrecioUnit.Text != "" && txtProveedor.Text != "")
            {
                ClsEProductos objEPro = new ClsEProductos();
                ClsNProductos ojbNpro = new ClsNProductos();
                objEPro.Codigo = textCodigo.Text;
                objEPro.Descripcion = txtDescripcion.Text;
                objEPro.Cantidad = Convert.ToInt32(txtCantidad.Text);
                objEPro.Precio = Convert.ToDouble(txtPrecioUnit.Text);
                objEPro.Proveedor = txtProveedor.Text;
                ojbNpro.MtdEditarProductoSQL(objEPro);
                MessageBox.Show("Producto Modificado");
                MtdLimpiarCajas();
                ClsNProductos objNPr = new ClsNProductos();
                dgvProducto.DataSource = objNPr.MtdListarTodoProducto();
            }
            else
            {
                MessageBox.Show("Ingrese datos Productos");
            }
        }



        private void btnListar_Click(object sender, EventArgs e)
        {
            ClsNProductos objNPr = new ClsNProductos();
            dgvProducto.DataSource = objNPr.MtdListarTodoProducto();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            ClsEProductos objEPro = new ClsEProductos();
            ClsNProductos objNPro = new ClsNProductos();
            objEPro.Codigo = textBuscar.Text;
            dgvProducto.DataSource = objNPro.MtdBuscarProductoSQL(objEPro);
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

        private void txtPrecioUnit_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
