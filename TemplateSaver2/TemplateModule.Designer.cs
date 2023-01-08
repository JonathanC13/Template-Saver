namespace TemplateSaver2
{
    partial class TemplateModule
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
            this.TM_lblTemplateName = new System.Windows.Forms.TextBox();
            this.TM_txtTemplateName = new System.Windows.Forms.TextBox();
            this.TM_lblOrder = new System.Windows.Forms.TextBox();
            this.TM_lblNotes = new System.Windows.Forms.TextBox();
            this.TM_richTextNotes = new System.Windows.Forms.RichTextBox();
            this.TM_btnDelete = new System.Windows.Forms.Button();
            this.TM_btnDiscardChanges = new System.Windows.Forms.Button();
            this.TM_btnTransfer = new System.Windows.Forms.Button();
            this.TM_btnSave = new System.Windows.Forms.Button();
            this.TM_TemplateMessage = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.Border = new System.Windows.Forms.Button();
            this.TM_numUpDwn = new System.Windows.Forms.NumericUpDown();
            this.TM_btnIncNotesH = new System.Windows.Forms.Button();
            this.TM_btnDecNotesH = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TM_numUpDwn)).BeginInit();
            this.SuspendLayout();
            // 
            // TM_lblTemplateName
            // 
            this.TM_lblTemplateName.Location = new System.Drawing.Point(9, 10);
            this.TM_lblTemplateName.Name = "TM_lblTemplateName";
            this.TM_lblTemplateName.ReadOnly = true;
            this.TM_lblTemplateName.Size = new System.Drawing.Size(53, 20);
            this.TM_lblTemplateName.TabIndex = 0;
            this.TM_lblTemplateName.Text = "Template";
            // 
            // TM_txtTemplateName
            // 
            this.TM_txtTemplateName.Location = new System.Drawing.Point(68, 10);
            this.TM_txtTemplateName.Name = "TM_txtTemplateName";
            this.TM_txtTemplateName.Size = new System.Drawing.Size(100, 20);
            this.TM_txtTemplateName.TabIndex = 1;
            this.TM_txtTemplateName.TextChanged += new System.EventHandler(this.TM_txtTemplateName_TextChanged);
            // 
            // TM_lblOrder
            // 
            this.TM_lblOrder.Location = new System.Drawing.Point(598, 10);
            this.TM_lblOrder.Name = "TM_lblOrder";
            this.TM_lblOrder.ReadOnly = true;
            this.TM_lblOrder.Size = new System.Drawing.Size(34, 20);
            this.TM_lblOrder.TabIndex = 12;
            this.TM_lblOrder.Text = "Order";
            // 
            // TM_lblNotes
            // 
            this.TM_lblNotes.Location = new System.Drawing.Point(8, 372);
            this.TM_lblNotes.Name = "TM_lblNotes";
            this.TM_lblNotes.ReadOnly = true;
            this.TM_lblNotes.Size = new System.Drawing.Size(77, 20);
            this.TM_lblNotes.TabIndex = 14;
            this.TM_lblNotes.Text = "General Notes";
            // 
            // TM_richTextNotes
            // 
            this.TM_richTextNotes.Location = new System.Drawing.Point(9, 399);
            this.TM_richTextNotes.MaxLength = 1024;
            this.TM_richTextNotes.Name = "TM_richTextNotes";
            this.TM_richTextNotes.Size = new System.Drawing.Size(662, 111);
            this.TM_richTextNotes.TabIndex = 15;
            this.TM_richTextNotes.Text = "";
            this.TM_richTextNotes.TextChanged += new System.EventHandler(this.TM_richTextNotes_TextChanged);
            // 
            // TM_btnDelete
            // 
            this.TM_btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.TM_btnDelete.Location = new System.Drawing.Point(35, 516);
            this.TM_btnDelete.Name = "TM_btnDelete";
            this.TM_btnDelete.Size = new System.Drawing.Size(109, 23);
            this.TM_btnDelete.TabIndex = 16;
            this.TM_btnDelete.Text = "Delete Template";
            this.TM_btnDelete.UseVisualStyleBackColor = false;
            this.TM_btnDelete.Click += new System.EventHandler(this.TM_btnDelete_Click);
            // 
            // TM_btnDiscardChanges
            // 
            this.TM_btnDiscardChanges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.TM_btnDiscardChanges.Location = new System.Drawing.Point(150, 516);
            this.TM_btnDiscardChanges.Name = "TM_btnDiscardChanges";
            this.TM_btnDiscardChanges.Size = new System.Drawing.Size(109, 23);
            this.TM_btnDiscardChanges.TabIndex = 17;
            this.TM_btnDiscardChanges.Text = "Discard Changes";
            this.TM_btnDiscardChanges.UseVisualStyleBackColor = false;
            this.TM_btnDiscardChanges.Click += new System.EventHandler(this.TM_btnDiscardChanges_Click);
            // 
            // TM_btnTransfer
            // 
            this.TM_btnTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TM_btnTransfer.Location = new System.Drawing.Point(426, 516);
            this.TM_btnTransfer.Name = "TM_btnTransfer";
            this.TM_btnTransfer.Size = new System.Drawing.Size(109, 23);
            this.TM_btnTransfer.TabIndex = 18;
            this.TM_btnTransfer.Text = "Transfer To Group";
            this.TM_btnTransfer.UseVisualStyleBackColor = false;
            this.TM_btnTransfer.Click += new System.EventHandler(this.TM_btnTransfer_Click);
            // 
            // TM_btnSave
            // 
            this.TM_btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.TM_btnSave.Location = new System.Drawing.Point(541, 516);
            this.TM_btnSave.Name = "TM_btnSave";
            this.TM_btnSave.Size = new System.Drawing.Size(109, 23);
            this.TM_btnSave.TabIndex = 19;
            this.TM_btnSave.Text = "Save Changes";
            this.TM_btnSave.UseVisualStyleBackColor = false;
            this.TM_btnSave.Click += new System.EventHandler(this.TM_btnSave_Click);
            // 
            // TM_TemplateMessage
            // 
            this.TM_TemplateMessage.Location = new System.Drawing.Point(174, 10);
            this.TM_TemplateMessage.Name = "TM_TemplateMessage";
            this.TM_TemplateMessage.ReadOnly = true;
            this.TM_TemplateMessage.Size = new System.Drawing.Size(418, 20);
            this.TM_TemplateMessage.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(68, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(99, 100);
            this.panel1.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(174, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(99, 100);
            this.panel2.TabIndex = 23;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(280, 47);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(99, 100);
            this.panel3.TabIndex = 24;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(385, 47);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(99, 100);
            this.panel4.TabIndex = 25;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(92, 153);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(99, 100);
            this.panel5.TabIndex = 26;
            // 
            // panel6
            // 
            this.panel6.Location = new System.Drawing.Point(197, 153);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(99, 100);
            this.panel6.TabIndex = 23;
            // 
            // panel7
            // 
            this.panel7.Location = new System.Drawing.Point(304, 153);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(99, 100);
            this.panel7.TabIndex = 27;
            // 
            // panel8
            // 
            this.panel8.Location = new System.Drawing.Point(409, 153);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(99, 100);
            this.panel8.TabIndex = 23;
            // 
            // panel9
            // 
            this.panel9.Location = new System.Drawing.Point(122, 259);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(99, 100);
            this.panel9.TabIndex = 28;
            // 
            // panel10
            // 
            this.panel10.Location = new System.Drawing.Point(227, 259);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(99, 100);
            this.panel10.TabIndex = 23;
            // 
            // panel11
            // 
            this.panel11.Location = new System.Drawing.Point(432, 259);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(99, 100);
            this.panel11.TabIndex = 29;
            // 
            // Border
            // 
            this.Border.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Border.Enabled = false;
            this.Border.Location = new System.Drawing.Point(0, 543);
            this.Border.Name = "Border";
            this.Border.Size = new System.Drawing.Size(680, 10);
            this.Border.TabIndex = 30;
            this.Border.UseVisualStyleBackColor = false;
            // 
            // TM_numUpDwn
            // 
            this.TM_numUpDwn.Location = new System.Drawing.Point(637, 10);
            this.TM_numUpDwn.Name = "TM_numUpDwn";
            this.TM_numUpDwn.Size = new System.Drawing.Size(35, 20);
            this.TM_numUpDwn.TabIndex = 31;
            this.TM_numUpDwn.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // TM_btnIncNotesH
            // 
            this.TM_btnIncNotesH.Location = new System.Drawing.Point(265, 372);
            this.TM_btnIncNotesH.Name = "TM_btnIncNotesH";
            this.TM_btnIncNotesH.Size = new System.Drawing.Size(166, 23);
            this.TM_btnIncNotesH.TabIndex = 32;
            this.TM_btnIncNotesH.Text = "Increase height of notes";
            this.TM_btnIncNotesH.UseVisualStyleBackColor = true;
            this.TM_btnIncNotesH.Click += new System.EventHandler(this.TM_btnIncNotesH_Click);
            // 
            // TM_btnDecNotesH
            // 
            this.TM_btnDecNotesH.Location = new System.Drawing.Point(93, 372);
            this.TM_btnDecNotesH.Name = "TM_btnDecNotesH";
            this.TM_btnDecNotesH.Size = new System.Drawing.Size(166, 23);
            this.TM_btnDecNotesH.TabIndex = 33;
            this.TM_btnDecNotesH.Text = "Decrease height of notes";
            this.TM_btnDecNotesH.UseVisualStyleBackColor = true;
            this.TM_btnDecNotesH.Click += new System.EventHandler(this.TM_btnDecNotesH_Click);
            // 
            // TemplateModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TM_btnDecNotesH);
            this.Controls.Add(this.TM_btnIncNotesH);
            this.Controls.Add(this.TM_numUpDwn);
            this.Controls.Add(this.Border);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TM_TemplateMessage);
            this.Controls.Add(this.TM_btnSave);
            this.Controls.Add(this.TM_btnTransfer);
            this.Controls.Add(this.TM_btnDiscardChanges);
            this.Controls.Add(this.TM_btnDelete);
            this.Controls.Add(this.TM_richTextNotes);
            this.Controls.Add(this.TM_lblNotes);
            this.Controls.Add(this.TM_lblOrder);
            this.Controls.Add(this.TM_txtTemplateName);
            this.Controls.Add(this.TM_lblTemplateName);
            this.Name = "TemplateModule";
            this.Size = new System.Drawing.Size(680, 553);
            ((System.ComponentModel.ISupportInitialize)(this.TM_numUpDwn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TM_lblTemplateName;
        private System.Windows.Forms.TextBox TM_txtTemplateName;
        private System.Windows.Forms.TextBox TM_lblOrder;
        private System.Windows.Forms.TextBox TM_lblNotes;
        private System.Windows.Forms.RichTextBox TM_richTextNotes;
        private System.Windows.Forms.Button TM_btnDelete;
        private System.Windows.Forms.Button TM_btnDiscardChanges;
        private System.Windows.Forms.Button TM_btnTransfer;
        private System.Windows.Forms.Button TM_btnSave;
        private System.Windows.Forms.TextBox TM_TemplateMessage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button Border;
        private System.Windows.Forms.NumericUpDown TM_numUpDwn;
        private System.Windows.Forms.Button TM_btnIncNotesH;
        private System.Windows.Forms.Button TM_btnDecNotesH;
    }
}
