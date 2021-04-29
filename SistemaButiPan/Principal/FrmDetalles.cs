using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaButiPan.Principal
{
    public partial class FrmDetalles : Form
    {
        public FrmDetalles()
        {
            InitializeComponent();
        }

        private void FrmDetalles_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dBVENTAS.tbDetalle' Puede moverla o quitarla según sea necesario.
            this.tbDetalleTableAdapter.Fill(this.dBVENTAS.tbDetalle);

            this.reportViewer1.RefreshReport();
        }
    }
}
