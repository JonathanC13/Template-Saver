namespace TemplateSaver2
{
    partial class StartUp
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
            this.lblStartStatus = new System.Windows.Forms.TextBox();
            this.btnFactoryRst = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDump = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblStartStatus
            // 
            this.lblStartStatus.BackColor = System.Drawing.SystemColors.Menu;
            this.lblStartStatus.Location = new System.Drawing.Point(135, 130);
            this.lblStartStatus.Multiline = true;
            this.lblStartStatus.Name = "lblStartStatus";
            this.lblStartStatus.ReadOnly = true;
            this.lblStartStatus.Size = new System.Drawing.Size(542, 20);
            this.lblStartStatus.TabIndex = 0;
            this.lblStartStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lblStartStatus.TextChanged += new System.EventHandler(this.lblStartStatus_TextChanged);
            // 
            // btnFactoryRst
            // 
            this.btnFactoryRst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnFactoryRst.Location = new System.Drawing.Point(475, 256);
            this.btnFactoryRst.Name = "btnFactoryRst";
            this.btnFactoryRst.Size = new System.Drawing.Size(123, 38);
            this.btnFactoryRst.TabIndex = 1;
            this.btnFactoryRst.Text = "Factory Reset";
            this.btnFactoryRst.UseVisualStyleBackColor = false;
            this.btnFactoryRst.Visible = false;
            this.btnFactoryRst.Click += new System.EventHandler(this.btnFactoryRst_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(217, 256);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(123, 38);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDump
            // 
            this.btnDump.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnDump.Location = new System.Drawing.Point(346, 256);
            this.btnDump.Name = "btnDump";
            this.btnDump.Size = new System.Drawing.Size(123, 38);
            this.btnDump.TabIndex = 3;
            this.btnDump.Text = "Template export";
            this.btnDump.UseVisualStyleBackColor = false;
            this.btnDump.Visible = false;
            this.btnDump.Click += new System.EventHandler(this.btnDump_Click);
            // 
            // StartUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDump);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnFactoryRst);
            this.Controls.Add(this.lblStartStatus);
            this.Name = "StartUp";
            this.Text = "Application Error";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox lblStartStatus;
        private System.Windows.Forms.Button btnFactoryRst;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDump;
    }
}

