namespace TemplateSaver2
{
    partial class ButtonCustomizationForm
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
            this.BC_lblHotkey = new System.Windows.Forms.TextBox();
            this.BC_txtHotkeyLabel = new System.Windows.Forms.TextBox();
            this.BC_lblHotkeyText = new System.Windows.Forms.TextBox();
            this.BC_richHotkeyText = new System.Windows.Forms.RichTextBox();
            this.BC_colorDialog_buttonColour = new System.Windows.Forms.ColorDialog();
            this.BC_btnColour = new System.Windows.Forms.Button();
            this.BC_colourShow = new System.Windows.Forms.TextBox();
            this.BC_btnDiscard = new System.Windows.Forms.Button();
            this.BC_btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BC_lblHotkey
            // 
            this.BC_lblHotkey.Location = new System.Drawing.Point(12, 12);
            this.BC_lblHotkey.Multiline = true;
            this.BC_lblHotkey.Name = "BC_lblHotkey";
            this.BC_lblHotkey.ReadOnly = true;
            this.BC_lblHotkey.Size = new System.Drawing.Size(96, 35);
            this.BC_lblHotkey.TabIndex = 0;
            this.BC_lblHotkey.Text = "Hotkey label\r\nMax 8 characters\r\n";
            // 
            // BC_txtHotkeyLabel
            // 
            this.BC_txtHotkeyLabel.Location = new System.Drawing.Point(114, 12);
            this.BC_txtHotkeyLabel.MaxLength = 8;
            this.BC_txtHotkeyLabel.Name = "BC_txtHotkeyLabel";
            this.BC_txtHotkeyLabel.Size = new System.Drawing.Size(171, 20);
            this.BC_txtHotkeyLabel.TabIndex = 1;
            // 
            // BC_lblHotkeyText
            // 
            this.BC_lblHotkeyText.Location = new System.Drawing.Point(12, 53);
            this.BC_lblHotkeyText.MaxLength = 70;
            this.BC_lblHotkeyText.Multiline = true;
            this.BC_lblHotkeyText.Name = "BC_lblHotkeyText";
            this.BC_lblHotkeyText.ReadOnly = true;
            this.BC_lblHotkeyText.Size = new System.Drawing.Size(96, 49);
            this.BC_lblHotkeyText.TabIndex = 2;
            this.BC_lblHotkeyText.Text = "Hotkey Text\r\nMax 70 characters\r\n or 5 lines";
            // 
            // BC_richHotkeyText
            // 
            this.BC_richHotkeyText.Location = new System.Drawing.Point(114, 53);
            this.BC_richHotkeyText.MaxLength = 70;
            this.BC_richHotkeyText.Name = "BC_richHotkeyText";
            this.BC_richHotkeyText.Size = new System.Drawing.Size(171, 92);
            this.BC_richHotkeyText.TabIndex = 3;
            this.BC_richHotkeyText.Text = "";
            // 
            // BC_btnColour
            // 
            this.BC_btnColour.Location = new System.Drawing.Point(82, 151);
            this.BC_btnColour.Name = "BC_btnColour";
            this.BC_btnColour.Size = new System.Drawing.Size(117, 23);
            this.BC_btnColour.TabIndex = 5;
            this.BC_btnColour.Text = "Button Colour Picker";
            this.BC_btnColour.UseVisualStyleBackColor = true;
            this.BC_btnColour.Click += new System.EventHandler(this.BC_btnColour_Click);
            // 
            // BC_colourShow
            // 
            this.BC_colourShow.BackColor = System.Drawing.SystemColors.Menu;
            this.BC_colourShow.ForeColor = System.Drawing.SystemColors.Highlight;
            this.BC_colourShow.Location = new System.Drawing.Point(205, 152);
            this.BC_colourShow.Multiline = true;
            this.BC_colourShow.Name = "BC_colourShow";
            this.BC_colourShow.ReadOnly = true;
            this.BC_colourShow.Size = new System.Drawing.Size(21, 21);
            this.BC_colourShow.TabIndex = 6;
            this.BC_colourShow.TextChanged += new System.EventHandler(this.BC_colourShow_TextChanged);
            // 
            // BC_btnDiscard
            // 
            this.BC_btnDiscard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BC_btnDiscard.Location = new System.Drawing.Point(12, 221);
            this.BC_btnDiscard.Name = "BC_btnDiscard";
            this.BC_btnDiscard.Size = new System.Drawing.Size(117, 23);
            this.BC_btnDiscard.TabIndex = 7;
            this.BC_btnDiscard.Text = "Discard";
            this.BC_btnDiscard.UseVisualStyleBackColor = false;
            this.BC_btnDiscard.Click += new System.EventHandler(this.BC_btnDiscard_Click);
            // 
            // BC_btnSave
            // 
            this.BC_btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BC_btnSave.Location = new System.Drawing.Point(168, 221);
            this.BC_btnSave.Name = "BC_btnSave";
            this.BC_btnSave.Size = new System.Drawing.Size(117, 23);
            this.BC_btnSave.TabIndex = 8;
            this.BC_btnSave.Text = "Save";
            this.BC_btnSave.UseVisualStyleBackColor = false;
            this.BC_btnSave.Click += new System.EventHandler(this.BC_btnSave_Click);
            // 
            // ButtonCustomizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 257);
            this.Controls.Add(this.BC_btnSave);
            this.Controls.Add(this.BC_btnDiscard);
            this.Controls.Add(this.BC_colourShow);
            this.Controls.Add(this.BC_btnColour);
            this.Controls.Add(this.BC_richHotkeyText);
            this.Controls.Add(this.BC_lblHotkeyText);
            this.Controls.Add(this.BC_txtHotkeyLabel);
            this.Controls.Add(this.BC_lblHotkey);
            this.Name = "ButtonCustomizationForm";
            this.Text = "Button Customization";
            this.Load += new System.EventHandler(this.ButtonCustomizationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox BC_lblHotkey;
        private System.Windows.Forms.TextBox BC_txtHotkeyLabel;
        private System.Windows.Forms.TextBox BC_lblHotkeyText;
        private System.Windows.Forms.RichTextBox BC_richHotkeyText;
        private System.Windows.Forms.ColorDialog BC_colorDialog_buttonColour;
        private System.Windows.Forms.Button BC_btnColour;
        private System.Windows.Forms.TextBox BC_colourShow;
        private System.Windows.Forms.Button BC_btnDiscard;
        private System.Windows.Forms.Button BC_btnSave;
    }
}