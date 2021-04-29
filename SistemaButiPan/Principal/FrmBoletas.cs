using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaButiPan.Entidades;
using SistemaButiPan.Negocios;
using System.Collections;
using System.Data.SqlClient;
using SistemaButiPan.Principal;



namespace SistemaButiPan.Principal
{
    public partial class FrmBoletas : MaterialSkin.Controls.MaterialForm
    {
        int serie = 1;
        int numero = 1;
      
        public FrmBoletas()
        {
            InitializeComponent();
        }
        ClsConvert c = new ClsConvert();
        private void FrmBoletas_Load(object sender, EventArgs e)
        {
            txtserie.Text = "00" + serie.ToString();
            txtnumero.Text = "0000" + numero.ToString();

            dgvBoleta.Enabled = true;
            dgvBoleta.Rows.Clear();
            txtCodigoEmp.Text = FrmPrincipal.codEmp;
            txtNombreEmp.Text = FrmPrincipal.nombreEmp;
            textApellido.Text = FrmPrincipal.apelliEmp;
            txtrucempresa.Text = FrmEmpresa.ruc;
            DateTime fe = DateTime.Now;
            
            txtFechaBoleta.Text = fe.ToShortDateString();
            dgvBoleta.ColumnCount = 10;
            for (int i = 0; i < FrmPrincipal.contEmp; i++)

            {
               
                
            }

            //visualizar ruc
            txtrucempresa.Text = "12345678";
            ClsEEmpresa objEEmp = new ClsEEmpresa();
            ClsNEmpresa objNEmpresa = new ClsNEmpresa();
            objEEmp.Ruc = txtrucempresa.Text;
            DataTable tbEmpresa = new DataTable();

            tbEmpresa = objNEmpresa.MtdBuscarporEmpresaSQL(objEEmp);

            if (tbEmpresa.Rows.Count > 0)
            {
                DataRow Fila = tbEmpresa.Rows[0];
                string ruc;
                ruc = Fila["Ruc"].ToString();
                txtrucempresa.Text = ruc;
                FrmPrincipal.ruc = ruc;
            }
        }
        //BOTTON NUEVO
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtnumero.Text = string.Format("{0:00000}", numero + 1);
            numero++;
            if (numero == 100000)
            {
                numero = 0;
                txtserie.Text = string.Format("{0:000}", serie + 1);



                serie++;
            }
            txtDNICli.Text = "";
            txtCodigoPro.Text = "";
            txtNombreCli.Text = "";
            txtApellidosCli.Text = "";
            txtTelefonoCli.Text = "";
            txtEmailCli.Text = "";
            txtLetraTotal.Text = "";
            txtTotalBoleta.Text = "";
            txtDNICli.Focus();
            txtCodigoPro.Text = "";
            txtDescripcionPro.Text = "";
            txtCantidadPro.Text = "";
            txtPrecioUnitPro.Text = "";
            txtCantCompraPro.Text = "";



        }
        //BOTTON BUSCAR CLIENTE
        private void btncli_Click(object sender, EventArgs e)
        {
            ClsEClientes objEcli = new ClsEClientes();

            ClsNClientes objNcli = new ClsNClientes();
            objEcli.Dni = txtDNICli.Text;
            DataTable dtCliente = new DataTable();
            dtCliente = objNcli.MtdBuscarporDniSQL(objEcli);
            if (dtCliente.Rows.Count > 0)
            {
                DataRow Fila = dtCliente.Rows[0];
                string nom, apelli, telecli, email;
                nom = Fila["Nombre"].ToString();
                apelli = Fila["Apellido"].ToString();
                telecli = Fila["Telefono"].ToString();
                email = Fila["Email"].ToString();

                txtNombreCli.Text = nom;
                txtApellidosCli.Text = apelli;
                txtTelefonoCli.Text = telecli;
                txtEmailCli.Text = email;
            }
        }
        //BOTTON BUSCAR PRODUCTO
        private void btnpro_Click(object sender, EventArgs e)
        {
            ClsEProductos objEPro = new ClsEProductos();
            ClsNProductos objNPro = new ClsNProductos();
            objEPro.Codigo = txtCodigoPro.Text;
            DataTable dtProducto = new DataTable();
            dtProducto = objNPro.MtdBuscarProductoSQL(objEPro);
            if (dtProducto.Rows.Count > 0)
            {
                DataRow Fila = dtProducto.Rows[0];
                string descripcion, cantidad, precio;
                descripcion = Fila["Descripcion"].ToString();
                cantidad = Fila["Cantidad"].ToString();
                precio = Fila["PrecioUnitario"].ToString();

                txtDescripcionPro.Text = descripcion;
                txtCantidadPro.Text = cantidad;
                txtPrecioUnitPro.Text = precio;

            }
        }

        private void txtCantCompraPro_TextChanged(object sender, EventArgs e)
        {
            double total;
            if (txtCantCompraPro.Text == "")
            {
                total = 0;
                txtImportePro.Text = "";
            }
            else
            {
                total = Convert.ToDouble(txtPrecioUnitPro.Text) * Convert.ToDouble(txtCantCompraPro.Text);
                txtImportePro.Text = total.ToString();
            }
        }

       public void Listardetalle()
        {
            ClsNDetalles ojbjN = new ClsNDetalles();
            dgvBoleta.DataSource = ojbjN.MtdListarDetalle();
        }
        public void Suma()
        {
            double Suma = 0;
            foreach (DataGridViewRow row in dgvBoleta.Rows)
            {

                Suma += Convert.ToDouble(row.Cells["Column5"].Value);
            }
            txtTotalBoleta.Text = Suma.ToString("#,0.00");
            txtLetraTotal.Text = c.enletras(txtTotalBoleta.Text).ToLower();

            txtCantCompraPro.Text = "";
            txtImportePro.Text = "";
        }
        //BOTTON AGREGAR
        int continicial = 0;
        int sumacantv = 10000000;
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (continicial >= 1)
            {
                foreach (ClsEProductos objen in FrmPrincipal.ArrProductos)
                {
                    if (txtCodigoPro.Text.Equals(objen.Codigo))
                    {
                        int canttotal2 = objen.Cantidad;


                        if (Convert.ToInt32(txtCantidadPro.Text) < canttotal2)

                            MessageBox.Show("Stock Insuficiente");
                        break;
                    }


                    else
                    {
                        sumacantv = Convert.ToInt32(dgvBoleta.Rows[0].Cells[4].Value.ToString()) + Convert.ToInt32(txtCantCompraPro.Text);
                        double ImporteNuev = Convert.ToDouble(sumacantv) * Convert.ToDouble(dgvBoleta.Rows[0].Cells[5].Value.ToString());
                        dgvBoleta.Rows[0].Cells[4].Value = sumacantv;
                        dgvBoleta.Rows[0].Cells[6].Value = ImporteNuev;

                        txtTotalBoleta.Text = ImporteNuev.ToString();


                        continicial++;
                        break;
                    }
                }

            }
            else
            {
                dgvBoleta.Rows.Add(txtserie.Text, txtnumero.Text, txtFechaBoleta.Text, txtrucempresa.Text, txtCodigoPro.Text, txtDescripcionPro.Text, txtCantidadPro.Text, txtPrecioUnitPro.Text, txtImportePro.Text, txtDNICli.Text, txtCodigoEmp.Text);

                txtTotalBoleta.Text = txtImportePro.Text;
                continicial++;
            }
            ClsConvert objne = new ClsConvert();
            txtLetraTotal.Text = objne.enletras(txtTotalBoleta.Text).ToLower();
            btnAgregar.Enabled = true;
        }
        private void dgvcomprovante_CellcontentClick(object sender, DataGridViewCellEventArgs e)
        {
            int Fila = 0;
            int cantAc = 0;
            Double impoAc = 0;
            Fila = dgvBoleta.CurrentRow.Index;
            cantAc = Convert.ToInt32(dgvBoleta.Rows[Fila].Cells[2].Value.ToString());
            impoAc = Convert.ToDouble(dgvBoleta.Rows[Fila].Cells[4].Value.ToString());
        }

        //BOTTON GUARDAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ClsEBoletas ObjE = new ClsEBoletas();
            ClsNBoletas ObjN = new ClsNBoletas();
            ObjE.Serie = txtserie.Text;
            ObjE.Numero = txtnumero.Text;
            ObjE.Fecha = txtFechaBoleta.Text;
            ObjE.Total = Convert.ToDouble(txtImportePro.Text);
            ObjE.Estado = "TRUE";
            ObjE.Ruc = txtrucempresa.Text;
            ObjE.Dni = txtDNICli.Text;
            ObjE.Codigo= txtCodigoEmp.Text;
            ObjN.Mtdagregarboleta(ObjE);

            
            ClsEDetalles Objedet = new ClsEDetalles();
            ClsNDetalles ObjNEdet = new ClsNDetalles();
            Objedet.Serie = txtserie.Text;
            Objedet.Numero = txtnumero.Text;
            Objedet.Codigo = txtCodigoPro.Text;
            Objedet.Cantidad = Convert.ToInt32(txtCantCompraPro.Text);
            Objedet.Importe = Convert.ToInt32(txtImportePro.Text);
            ObjNEdet.MtdagregarDetalle(Objedet);
            MessageBox.Show("guardado Comprobante");

         
        }
        //BOTON ANULAR
        private void btnAnular_Click(object sender, EventArgs e)
        {

            dgvBoleta.Rows.Remove(dgvBoleta.CurrentRow);
            txtDNICli.Text = "";
            txtCodigoPro.Text = "";
            txtNombreCli.Text = "";
            txtApellidosCli.Text = "";
            txtTelefonoCli.Text = "";
            txtEmailCli.Text = "";
            txtLetraTotal.Text = "";
            txtTotalBoleta.Text = "";
            txtDNICli.Focus();
            txtCodigoPro.Text = "";
            txtDescripcionPro.Text = "";
            txtCantidadPro.Text = "";
            txtPrecioUnitPro.Text = "";
            txtCantCompraPro.Text = "";

        }

        private void btnImp_Click(object sender, EventArgs e)
        {
           
        }

        private void pDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //e.Graphics.DrawString("Prueba de Impresion",
            //    new Font("Arial", 12, FontStyle.Bold),
            //    Brushes.Blue, new Point(800, 1080));

            //RectangleF rImage = new RectangleF(10, 10, 300, 80);
            //Image imagen = Image.FromFile(@"D:\Adnner\UPT\2017-II\poo\Ventas Abarrotes\img logo.png");
            //e.Graphics.DrawImage(imagen, rImage);

            e.Graphics.DrawString("Nombre :" + txtNombreEmp.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(15, 90));
            e.Graphics.DrawString("Direccion :" + label10.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(15, 110));
            e.Graphics.DrawString("Telefono :" + label10.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(15, 130));

            e.Graphics.DrawString("RUC :" + txtrucempresa.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(500, 20));
            RectangleF rImage1 = new RectangleF(500, 40, 300, 50);
            //Image imagen1 = Image.FromFile(@"C:\img\boleta.png");
            //e.Graphics.DrawImage(imagen1, rImage1);

            e.Graphics.DrawString("Serie :" + txtserie.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(500, 90));
            e.Graphics.DrawString("Num :" + txtNombreEmp.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(600, 90));
            e.Graphics.DrawString("Fecha :" + txtFechaBoleta.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(560, 110));

            e.Graphics.DrawString("Empleado", new Font("Arial", 14, FontStyle.Bold), Brushes.Blue, new Point(0, 170));
            e.Graphics.DrawString("Codigo :", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(15, 190));
            e.Graphics.DrawString("Nombre :" + txtNombreEmp.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(300, 190));

            e.Graphics.DrawString("Cliente", new Font("Arial", 14, FontStyle.Bold), Brushes.Blue, new Point(0, 220));
            e.Graphics.DrawString("DNI :" + txtDNICli.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(15, 240));
            e.Graphics.DrawString("Nombres :" + txtNombreCli.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(200, 240));
            e.Graphics.DrawString("Apellidos :" + txtApellidosCli.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(500, 240));
           
            e.Graphics.DrawString("Telefono :" + txtTelefonoCli.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(300, 260));
            e.Graphics.DrawString("Email :" + txtEmailCli.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(510, 260));

            e.Graphics.DrawString("Producto", new Font("Arial", 14, FontStyle.Bold), Brushes.Blue, new Point(0, 300));
            e.Graphics.DrawString("Codigo :" + txtEmailCli.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(15, 320));
            e.Graphics.DrawString("Descripcion:" + txtDescripcionPro.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(200, 320));
            e.Graphics.DrawString("Cantidad:" + txtCantidadPro.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(450, 320));
            e.Graphics.DrawString("Precio Unitario:" + txtPrecioUnitPro.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(600, 320));
            e.Graphics.DrawString("Cantidad Compra:" + txtCantCompraPro.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(200, 340));
            e.Graphics.DrawString("Importe: S/." + txtImportePro.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(450, 340));
        }

            private void txtDNICli_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCodigoPro_KeyPress(object sender, KeyPressEventArgs e)
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
