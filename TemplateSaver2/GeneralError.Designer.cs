namespace TemplateSaver2
{
    partial class GeneralError
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
            this.lblGnrlErrHeader = new System.Windows.Forms.TextBox();
            this.lblErrMsg = new System.Windows.Forms.TextBox();
            this.btnGnrlErrClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGnrlErrHeader
            // 
            this.lblGnrlErrHeader.BackColor = System.Drawing.SystemColors.Menu;
            this.lblGnrlErrHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblGnrlErrHeader.Location = new System.Drawing.Point(349, 128);
            this.lblGnrlErrHeader.Name = "lblGnrlErrHeader";
            this.lblGnrlErrHeader.ReadOnly = true;
            this.lblGnrlErrHeader.Size = new System.Drawing.Size(100, 13);
            this.lblGnrlErrHeader.TabIndex = 0;
            this.lblGnrlErrHeader.Text = "Detected Error";
            this.lblGnrlErrHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblErrMsg
            // 
            this.lblErrMsg.BackColor = System.Drawing.SystemColors.Menu;
            this.lblErrMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblErrMsg.Location = new System.Drawing.Point(212, 178);
            this.lblErrMsg.Multiline = true;
            this.lblErrMsg.Name = "lblErrMsg";
            this.lblErrMsg.ReadOnly = true;
            this.lblErrMsg.Size = new System.Drawing.Size(374, 20);
            this.lblErrMsg.TabIndex = 1;
            this.lblErrMsg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lblErrMsg.TextChanged += new System.EventHandler(this.lblErrMsg_TextChanged);
            // 
            // btnGnrlErrClose
            // 
            this.btnGnrlErrClose.Location = new System.Drawing.Point(349, 235);
            this.btnGnrlErrClose.Name = "btnGnrlErrClose";
            this.btnGnrlErrClose.Size = new System.Drawing.Size(100, 23);
            this.btnGnrlErrClose.TabIndex = 2;
            this.btnGnrlErrClose.Text = "Close";
            this.btnGnrlErrClose.UseVisualStyleBackColor = true;
            this.btnGnrlErrClose.Click += new System.EventHandler(this.btnGnrlErrClose_Click);
            // 
            // GeneralError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGnrlErrClose);
            this.Controls.Add(this.lblErrMsg);
            this.Controls.Add(this.lblGnrlErrHeader);
            this.Name = "GeneralError";
            this.Text = "General Error";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox lblGnrlErrHeader;
        private System.Windows.Forms.TextBox lblErrMsg;
        private System.Windows.Forms.Button btnGnrlErrClose;
    }
}