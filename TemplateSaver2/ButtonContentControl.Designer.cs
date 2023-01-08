namespace TemplateSaver2
{
    partial class ButtonContentControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnHeader = new System.Windows.Forms.Button();
            this.btnContent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHeader
            // 
            this.btnHeader.BackColor = System.Drawing.SystemColors.Control;
            this.btnHeader.Location = new System.Drawing.Point(0, 0);
            this.btnHeader.Name = "btnHeader";
            this.btnHeader.Size = new System.Drawing.Size(100, 23);
            this.btnHeader.TabIndex = 0;
            this.btnHeader.Text = "button1";
            this.btnHeader.UseVisualStyleBackColor = false;
            this.btnHeader.Click += new System.EventHandler(this.btnHeader_Click);
            // 
            // btnContent
            // 
            this.btnContent.BackColor = System.Drawing.SystemColors.Control;
            this.btnContent.Location = new System.Drawing.Point(0, 21);
            this.btnContent.Name = "btnContent";
            this.btnContent.Size = new System.Drawing.Size(100, 79);
            this.btnContent.TabIndex = 1;
            this.btnContent.Text = "button2\r\ntest\r\n";
            this.btnContent.UseVisualStyleBackColor = false;
            this.btnContent.Click += new System.EventHandler(this.btnContent_Click);
            // 
            // ButtonContentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnContent);
            this.Controls.Add(this.btnHeader);
            this.Name = "ButtonContentControl";
            this.Size = new System.Drawing.Size(100, 100);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHeader;
        private System.Windows.Forms.Button btnContent;
    }
}
