namespace SistemaButiPan.Principal
{
    partial class FrmDetalles
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
            this.tbDetalleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBVENTAS = new SistemaButiPan.DBVENTAS();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tbDetalleTableAdapter = new SistemaButiPan.DBVENTASTableAdapters.tbDetalleTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tbDetalleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBVENTAS)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDetalleBindingSource
            // 
            this.tbDetalleBindingSource.DataMember = "tbDetalle";
            this.tbDetalleBindingSource.DataSource = this.dBVENTAS;
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
            reportDataSource1.Value = this.tbDetalleBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaButiPan.Informe.ReporteDetalle.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(966, 630);
            this.reportViewer1.TabIndex = 0;
            // 
            // tbDetalleTableAdapter
            // 
            this.tbDetalleTableAdapter.ClearBeforeFill = true;
            // 
            // FrmDetalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 630);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmDetalles";
            this.Text = "FrmDetalles";
            this.Load += new System.EventHandler(this.FrmDetalles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbDetalleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBVENTAS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DBVENTAS dBVENTAS;
        private System.Windows.Forms.BindingSource tbDetalleBindingSource;
        private DBVENTASTableAdapters.tbDetalleTableAdapter tbDetalleTableAdapter;
    }
}