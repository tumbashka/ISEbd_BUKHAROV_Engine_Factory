namespace EngineFactoryView
{
    partial class FormReportOrders
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
            this.ButtonMake = new System.Windows.Forms.Button();
            this.ButtonToPdf = new System.Windows.Forms.Button();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // ButtonMake
            // 
            this.ButtonMake.Location = new System.Drawing.Point(16, 16);
            this.ButtonMake.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonMake.Name = "ButtonMake";
            this.ButtonMake.Size = new System.Drawing.Size(156, 33);
            this.ButtonMake.TabIndex = 4;
            this.ButtonMake.Text = "Сформировать";
            this.ButtonMake.UseVisualStyleBackColor = true;
            this.ButtonMake.Click += new System.EventHandler(this.ButtonMake_Click);
            // 
            // ButtonToPdf
            // 
            this.ButtonToPdf.Location = new System.Drawing.Point(180, 16);
            this.ButtonToPdf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ButtonToPdf.Name = "ButtonToPdf";
            this.ButtonToPdf.Size = new System.Drawing.Size(156, 34);
            this.ButtonToPdf.TabIndex = 5;
            this.ButtonToPdf.Text = "В Pdf";
            this.ButtonToPdf.UseVisualStyleBackColor = true;
            this.ButtonToPdf.Click += new System.EventHandler(this.ButtonToPdf_Click);
            // 
            // reportViewer
            // 
            this.reportViewer.LocalReport.ReportEmbeddedResource = "EngineFactoryView.Report.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(3, 55);
            this.reportViewer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(1059, 496);
            this.reportViewer.TabIndex = 6;
            // 
            // FormReportOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.ButtonToPdf);
            this.Controls.Add(this.ButtonMake);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormReportOrders";
            this.Text = "Report ForgeProducts with Billets";
            this.Load += new System.EventHandler(this.FormReportOrders_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ButtonMake;
        private System.Windows.Forms.Button ButtonToPdf;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
    }
}