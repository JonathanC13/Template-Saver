namespace TemplateSaver2
{
    partial class MainTemplate
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
            this.ddTemplateGroup = new System.Windows.Forms.ComboBox();
            this.ddTemplate = new System.Windows.Forms.ComboBox();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.btnRenameGrp = new System.Windows.Forms.Button();
            this.btnAddTemplate = new System.Windows.Forms.Button();
            this.txtBTemplateGrp = new System.Windows.Forms.TextBox();
            this.txtBRenameGrp = new System.Windows.Forms.TextBox();
            this.txtBAddTemplate = new System.Windows.Forms.TextBox();
            this.btnDeleteGroup = new System.Windows.Forms.Button();
            this.lblTempateGrp = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panelTemplates = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDump = new System.Windows.Forms.Button();
            this.txtFileDir = new System.Windows.Forms.TextBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ddTemplateGroup
            // 
            this.ddTemplateGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddTemplateGroup.FormattingEnabled = true;
            this.ddTemplateGroup.Location = new System.Drawing.Point(50, 50);
            this.ddTemplateGroup.Name = "ddTemplateGroup";
            this.ddTemplateGroup.Size = new System.Drawing.Size(309, 21);
            this.ddTemplateGroup.TabIndex = 0;
            this.ddTemplateGroup.SelectedIndexChanged += new System.EventHandler(this.ddTemplateGroup_SelectedIndexChanged);
            // 
            // ddTemplate
            // 
            this.ddTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddTemplate.FormattingEnabled = true;
            this.ddTemplate.Location = new System.Drawing.Point(173, 136);
            this.ddTemplate.Name = "ddTemplate";
            this.ddTemplate.Size = new System.Drawing.Size(186, 21);
            this.ddTemplate.TabIndex = 1;
            this.ddTemplate.Visible = false;
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAddGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddGroup.Location = new System.Drawing.Point(50, 77);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(117, 23);
            this.btnAddGroup.TabIndex = 2;
            this.btnAddGroup.Text = "Add Template Group";
            this.btnAddGroup.UseVisualStyleBackColor = false;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // btnRenameGrp
            // 
            this.btnRenameGrp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRenameGrp.Location = new System.Drawing.Point(50, 106);
            this.btnRenameGrp.Name = "btnRenameGrp";
            this.btnRenameGrp.Size = new System.Drawing.Size(117, 23);
            this.btnRenameGrp.TabIndex = 3;
            this.btnRenameGrp.Text = "Rename Group";
            this.btnRenameGrp.UseVisualStyleBackColor = false;
            this.btnRenameGrp.Click += new System.EventHandler(this.btnRenameGrp_Click);
            // 
            // btnAddTemplate
            // 
            this.btnAddTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAddTemplate.Location = new System.Drawing.Point(440, 50);
            this.btnAddTemplate.Name = "btnAddTemplate";
            this.btnAddTemplate.Size = new System.Drawing.Size(117, 23);
            this.btnAddTemplate.TabIndex = 4;
            this.btnAddTemplate.Text = "Add Template";
            this.btnAddTemplate.UseVisualStyleBackColor = false;
            this.btnAddTemplate.Click += new System.EventHandler(this.btnAddTemplate_Click);
            // 
            // txtBTemplateGrp
            // 
            this.txtBTemplateGrp.Location = new System.Drawing.Point(173, 79);
            this.txtBTemplateGrp.Name = "txtBTemplateGrp";
            this.txtBTemplateGrp.Size = new System.Drawing.Size(186, 20);
            this.txtBTemplateGrp.TabIndex = 5;
            // 
            // txtBRenameGrp
            // 
            this.txtBRenameGrp.Location = new System.Drawing.Point(173, 107);
            this.txtBRenameGrp.Name = "txtBRenameGrp";
            this.txtBRenameGrp.Size = new System.Drawing.Size(186, 20);
            this.txtBRenameGrp.TabIndex = 6;
            // 
            // txtBAddTemplate
            // 
            this.txtBAddTemplate.Location = new System.Drawing.Point(563, 52);
            this.txtBAddTemplate.Name = "txtBAddTemplate";
            this.txtBAddTemplate.Size = new System.Drawing.Size(186, 20);
            this.txtBAddTemplate.TabIndex = 7;
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDeleteGroup.Location = new System.Drawing.Point(50, 135);
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(117, 23);
            this.btnDeleteGroup.TabIndex = 8;
            this.btnDeleteGroup.Text = "Delete Group";
            this.btnDeleteGroup.UseVisualStyleBackColor = false;
            this.btnDeleteGroup.Click += new System.EventHandler(this.btnDeleteGroup_Click);
            // 
            // lblTempateGrp
            // 
            this.lblTempateGrp.BackColor = System.Drawing.SystemColors.Menu;
            this.lblTempateGrp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblTempateGrp.Location = new System.Drawing.Point(50, 24);
            this.lblTempateGrp.Name = "lblTempateGrp";
            this.lblTempateGrp.Size = new System.Drawing.Size(100, 13);
            this.lblTempateGrp.TabIndex = 9;
            this.lblTempateGrp.Text = "Template Group";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(440, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 13);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "Template";
            // 
            // panelTemplates
            // 
            this.panelTemplates.AutoScroll = true;
            this.panelTemplates.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelTemplates.BackColor = System.Drawing.SystemColors.Control;
            this.panelTemplates.Location = new System.Drawing.Point(12, 182);
            this.panelTemplates.Name = "panelTemplates";
            this.panelTemplates.Size = new System.Drawing.Size(776, 273);
            this.panelTemplates.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.btnHelp);
            this.panel1.Controls.Add(this.btnDump);
            this.panel1.Controls.Add(this.txtFileDir);
            this.panel1.Controls.Add(this.ddTemplate);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 176);
            this.panel1.TabIndex = 12;
            // 
            // btnDump
            // 
            this.btnDump.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnDump.Location = new System.Drawing.Point(440, 77);
            this.btnDump.Name = "btnDump";
            this.btnDump.Size = new System.Drawing.Size(117, 23);
            this.btnDump.TabIndex = 13;
            this.btnDump.Text = "Template Export";
            this.btnDump.UseVisualStyleBackColor = false;
            this.btnDump.Click += new System.EventHandler(this.btnDump_Click);
            // 
            // txtFileDir
            // 
            this.txtFileDir.Location = new System.Drawing.Point(442, 106);
            this.txtFileDir.Multiline = true;
            this.txtFileDir.Name = "txtFileDir";
            this.txtFileDir.ReadOnly = true;
            this.txtFileDir.Size = new System.Drawing.Size(309, 51);
            this.txtFileDir.TabIndex = 14;
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnHelp.Location = new System.Drawing.Point(284, 21);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 15;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // MainTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 457);
            this.Controls.Add(this.panelTemplates);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblTempateGrp);
            this.Controls.Add(this.btnDeleteGroup);
            this.Controls.Add(this.txtBAddTemplate);
            this.Controls.Add(this.txtBRenameGrp);
            this.Controls.Add(this.txtBTemplateGrp);
            this.Controls.Add(this.btnAddTemplate);
            this.Controls.Add(this.btnRenameGrp);
            this.Controls.Add(this.btnAddGroup);
            this.Controls.Add(this.ddTemplateGroup);
            this.Controls.Add(this.panel1);
            this.Name = "MainTemplate";
            this.Text = "Templates";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainTemplate_FormClosed);
            this.Load += new System.EventHandler(this.MainTemplate_Load);
            this.Resize += new System.EventHandler(this.MainTemplate_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddTemplateGroup;
        private System.Windows.Forms.ComboBox ddTemplate;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.Button btnRenameGrp;
        private System.Windows.Forms.Button btnAddTemplate;
        private System.Windows.Forms.TextBox txtBTemplateGrp;
        private System.Windows.Forms.TextBox txtBRenameGrp;
        private System.Windows.Forms.TextBox txtBAddTemplate;
        private System.Windows.Forms.Button btnDeleteGroup;
        private System.Windows.Forms.TextBox lblTempateGrp;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panelTemplates;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtFileDir;
        private System.Windows.Forms.Button btnDump;
        private System.Windows.Forms.Button btnHelp;
    }
}