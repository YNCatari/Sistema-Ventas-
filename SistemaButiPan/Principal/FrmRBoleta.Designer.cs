namespace SistemaButiPan.Principal
{
    partial class FrmRBoleta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tbBoletaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBVENTAS = new SistemaButiPan.DBVENTAS();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbBoletaTableAdapter = new SistemaButiPan.DBVENTASTableAdapters.tbBoletaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tbBoletaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBVENTAS)).BeginInit();
            this.SuspendLayout();
            // 
            // tbBoletaBindingSource
            // 
            this.tbBoletaBindingSource.DataMember = "tbBoleta";
            this.tbBoletaBindingSource.DataSource = this.dBVENTAS;
            // 
            // dBVENTAS
            // 
            this.dBVENTAS.DataSetName = "DBVENTAS";
            this.dBVENTAS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DBVentas";
            reportDataSource1.Value = this.tbBoletaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaButiPan.Informe.ReporteBoletas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1046, 658);
            this.reportViewer1.TabIndex = 0;
            // 
            // tbBoletaTableAdapter
            // 
            this.tbBoletaTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRBoleta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 658);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmRBoleta";
            this.Text = "FrmRBoleta";
            this.Load += new System.EventHandler(this.FrmRBoleta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbBoletaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBVENTAS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DBVENTAS dBVENTAS;
        private System.Windows.Forms.BindingSource tbBoletaBindingSource;
        private DBVENTASTableAdapters.tbBoletaTableAdapter tbBoletaTableAdapter;
    }
}