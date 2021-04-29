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
    public partial class FrmRBoleta : Form
    {
        public FrmRBoleta()
        {
            InitializeComponent();
        }

        private void FrmRBoleta_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dBVENTAS.tbBoleta' Puede moverla o quitarla según sea necesario.
            this.tbBoletaTableAdapter.Fill(this.dBVENTAS.tbBoleta);

            this.reportViewer1.RefreshReport();
        }
    }
}
