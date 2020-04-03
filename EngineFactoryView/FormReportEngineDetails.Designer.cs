using System;

namespace EngineFactoryView
{
    partial class FormReportEngineDetails
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnDateCreate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnforgeproduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonSaveToExcel = new System.Windows.Forms.Button();
            this.ButtonForm = new System.Windows.Forms.Button();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.labelFrom = new System.Windows.Forms.Label();
            this.labelTo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDateCreate,
            this.Columnforgeproduct,
            this.ColumnSum});
            this.dataGridView.Location = new System.Drawing.Point(1, 84);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(760, 338);
            this.dataGridView.TabIndex = 0;
            // 
            // ColumnDateCreate
            // 
            this.ColumnDateCreate.HeaderText = "DateCreate";
            this.ColumnDateCreate.MinimumWidth = 6;
            this.ColumnDateCreate.Name = "ColumnDateCreate";
            this.ColumnDateCreate.Width = 120;
            // 
            // Columnforgeproduct
            // 
            this.Columnforgeproduct.HeaderText = "Forge Product";
            this.Columnforgeproduct.MinimumWidth = 6;
            this.Columnforgeproduct.Name = "Columnforgeproduct";
            this.Columnforgeproduct.Width = 125;
            // 
            // ColumnSum
            // 
            this.ColumnSum.HeaderText = "Sum";
            this.ColumnSum.MinimumWidth = 6;
            this.ColumnSum.Name = "ColumnSum";
            this.ColumnSum.Width = 125;
            // 
            // ButtonSaveToExcel
            // 
            this.ButtonSaveToExcel.Location = new System.Drawing.Point(13, 10);
            this.ButtonSaveToExcel.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonSaveToExcel.Name = "ButtonSaveToExcel";
            this.ButtonSaveToExcel.Size = new System.Drawing.Size(163, 32);
            this.ButtonSaveToExcel.TabIndex = 1;
            this.ButtonSaveToExcel.Text = "Save to Excel";
            this.ButtonSaveToExcel.UseVisualStyleBackColor = true;
            this.ButtonSaveToExcel.Click += new System.EventHandler(this.ButtonSaveToExcel_Click);
            // 
            // ButtonForm
            // 
            this.ButtonForm.Location = new System.Drawing.Point(201, 10);
            this.ButtonForm.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonForm.Name = "ButtonForm";
            this.ButtonForm.Size = new System.Drawing.Size(135, 32);
            this.ButtonForm.TabIndex = 2;
            this.ButtonForm.Text = "Сформировать";
            this.ButtonForm.UseVisualStyleBackColor = true;
            this.ButtonForm.Click += new System.EventHandler(this.ButtonForm_Click);
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(69, 49);
            this.dateTimePickerFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(185, 22);
            this.dateTimePickerFrom.TabIndex = 3;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(319, 49);
            this.dateTimePickerTo.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(191, 22);
            this.dateTimePickerTo.TabIndex = 4;
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(15, 53);
            this.labelFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(17, 17);
            this.labelFrom.TabIndex = 5;
            this.labelFrom.Text = "С";
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(264, 53);
            this.labelTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(24, 17);
            this.labelTo.TabIndex = 6;
            this.labelTo.Text = "по";
            // 
            // FormReportEngineDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 422);
            this.Controls.Add(this.labelTo);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.ButtonForm);
            this.Controls.Add(this.ButtonSaveToExcel);
            this.Controls.Add(this.dataGridView);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormReportEngineDetails";
            this.Text = "Report Orders";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ButtonMake_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button ButtonSaveToExcel;
        private System.Windows.Forms.Button ButtonForm;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateCreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnforgeproduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSum;
    }
}