using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TemplateSaver2.MainTemplate;

namespace TemplateSaver2
{
    public partial class ButtonCustomizationForm : Form
    {
        private GeneralError frmGeneralError;
        private TemplateInfo mytemplateInfo;
        private ButtonContentControl buttonUserControl;
        private int iHotKeyBtn;

        //private Color colourBtn;

        private Point ptLocation;
        public ButtonCustomizationForm()
        {
            frmGeneralError = new GeneralError();

            
            InitializeComponent();
            
        }

        public ButtonCustomizationForm(ButtonContentControl parent, TemplateInfo templateInfo, object sender, int iBtnKey) : this() // the this will initialize the default constructor of the form
        {

            BC_lblHotkey.TabStop = false;
            BC_lblHotkeyText.TabStop = false;

            iHotKeyBtn = iBtnKey;
            buttonUserControl = parent;

            BC_colourShow.BackColor = buttonUserControl.getColor();

            mytemplateInfo = templateInfo;
            BC_txtHotkeyLabel.Text = parent.getHeader();//mytemplateInfo.dctButtonAttribute[iHotKeyBtn].strHotKeyLabel;
            BC_richHotkeyText.Text = parent.getBody();//mytemplateInfo.dctButtonAttribute[iHotKeyBtn].strHotKeyDesc;

            var button = sender as Button;

            // Test that change in the object is the same object (passed by reference)\
            //Debug.WriteLine("sender: " + button.Name);
            //templateInfo.strTemplateName = "PASSED BY REFERENCE";
        }

        public ButtonCustomizationForm(ButtonContentControl parent, TemplateInfo templateInfo, object sender, int iBtnKey, Point location) : this() // the this will initialize the default constructor of the form
        {

            

            ptLocation = location;
            BC_lblHotkey.TabStop = false;
            BC_lblHotkeyText.TabStop = false;

            iHotKeyBtn = iBtnKey;
            buttonUserControl = parent;


            BC_colourShow.BackColor = buttonUserControl.getColor();

            mytemplateInfo = templateInfo;
            BC_txtHotkeyLabel.Text = parent.getHeader();//mytemplateInfo.dctButtonAttribute[iHotKeyBtn].strHotKeyLabel;
            BC_richHotkeyText.Text = parent.getBody();//mytemplateInfo.dctButtonAttribute[iHotKeyBtn].strHotKeyDesc;

            var button = sender as Button;

            // Test that change in the object is the same object (passed by reference)\
            //Debug.WriteLine("sender: " + button.Name);
            //templateInfo.strTemplateName = "PASSED BY REFERENCE";
        }


        private void BC_btnColour_Click(object sender, EventArgs e)
        {
            if(BC_colorDialog_buttonColour.ShowDialog() == DialogResult.OK)
            {
                Color color = BC_colorDialog_buttonColour.Color; // assign color
                //Debug.Write("BC_btnColour_Click: " + color.R);
                BC_colourShow.BackColor = color; // change colour of label
            }
        }

        
        private void BC_btnSave_Click(object sender, EventArgs e)
        {

            // Just update the text in the button of the TemplateModule, do not update the button attribute dictionary object in the TemplateInfo because the user needs to decide to commit or discard. When discard, that specific template is reloaded and if saved the TemplateInfo updated, changes committed to db, and that template is rebuilt

            // Check max lines in Button content
            var lines = BC_richHotkeyText.Lines.Count();
            if(BC_richHotkeyText.TextLength > 0)
            {
                lines -= String.IsNullOrWhiteSpace(BC_richHotkeyText.Lines.Last()) ? 1 : 0;
            }
            

            //Debug.Write("lines: " + lines.ToString());
            // If lines > 5 then display error
            if (lines > 5)
            {
                setGeneralErrorMessage("Sorry, too many lines in the Hotkey text. Please keep it to 5.");
            } else
            {
                buttonUserControl.SetButtonContent(BC_txtHotkeyLabel.Text, BC_richHotkeyText.Text);
                buttonUserControl.SetButtonsColour(BC_colourShow.BackColor);

                buttonUserControl.setTM_TemplateMessage_BCC("Please click 'Save Changes' to commit changes");

                this.Close();
            }


            
        }
        private void setGeneralErrorMessage(string strMsg)
        {

            frmGeneralError.Visible = true;
            frmGeneralError.setErrorMessage(strMsg);



        }

        private void BC_colourShow_TextChanged(object sender, EventArgs e)
        {
            //
        }

        private void BC_btnDiscard_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonCustomizationForm_Load(object sender, EventArgs e)
        {
 
            this.SetDesktopLocation(ptLocation.X, ptLocation.Y);
            
        }
    }
}
