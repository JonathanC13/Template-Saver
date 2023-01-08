namespace TemplateSaver2
{
    partial class TransferToGroup
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
            this.lblHeader = new System.Windows.Forms.TextBox();
            this.ddTemplateGroups = new System.Windows.Forms.ComboBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Transfer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.SystemColors.Menu;
            this.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblHeader.Location = new System.Drawing.Point(12, 12);
            this.lblHeader.Multiline = true;
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.ReadOnly = true;
            this.lblHeader.Size = new System.Drawing.Size(205, 39);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "Please select the template group you wish to transfer the template to:\r\n";
            this.lblHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lblHeader.TextChanged += new System.EventHandler(this.lblHeader_TextChanged);
            // 
            // ddTemplateGroups
            // 
            this.ddTemplateGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddTemplateGroups.FormattingEnabled = true;
            this.ddTemplateGroups.Location = new System.Drawing.Point(12, 57);
            this.ddTemplateGroups.Name = "ddTemplateGroups";
            this.ddTemplateGroups.Size = new System.Drawing.Size(205, 21);
            this.ddTemplateGroups.TabIndex = 2;
            this.ddTemplateGroups.TabStop = false;
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(12, 92);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(97, 23);
            this.btn_Close.TabIndex = 3;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Transfer
            // 
            this.btn_Transfer.Location = new System.Drawing.Point(120, 92);
            this.btn_Transfer.Name = "btn_Transfer";
            this.btn_Transfer.Size = new System.Drawing.Size(97, 23);
            this.btn_Transfer.TabIndex = 4;
            this.btn_Transfer.Text = "Transfer";
            this.btn_Transfer.UseVisualStyleBackColor = true;
            this.btn_Transfer.Click += new System.EventHandler(this.btn_Transfer_Click);
            // 
            // TransferToGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 127);
            this.Controls.Add(this.btn_Transfer);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.ddTemplateGroups);
            this.Controls.Add(this.lblHeader);
            this.Name = "TransferToGroup";
            this.Text = "Transfer To Group";
            this.Load += new System.EventHandler(this.TransferToGroup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox lblHeader;
        private System.Windows.Forms.ComboBox ddTemplateGroups;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Transfer;
    }
}