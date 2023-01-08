using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TemplateSaver2.MainTemplate;

namespace TemplateSaver2
{
    public partial class ButtonContentControl : UserControl
    {

        private TemplateInfo templateInfo;
        TemplateModule frmTemplateModule;

        private int iHotKeyBtn;
        public ButtonContentControl()
        {
            InitializeComponent();
        }

        public ButtonContentControl(TemplateInfo tempInfo, TemplateModule tempModule, int iBtnKey) : this()
        {
            iHotKeyBtn = iBtnKey; // key for the button dictionary in the TemplateInfo object
            frmTemplateModule = tempModule;
            this.templateInfo = tempInfo;
            btnHeader.Text = templateInfo.dctButtonAttribute[iHotKeyBtn].strHotKeyLabel;//templateInfo.nTemplateID.ToString();
            btnContent.Text = templateInfo.dctButtonAttribute[iHotKeyBtn].strHotKeyDesc;//templateInfo.strTemplateName;

            int red = templateInfo.dctButtonAttribute[iHotKeyBtn].nColorR;
            int grn = templateInfo.dctButtonAttribute[iHotKeyBtn].nColorG;
            int blue = templateInfo.dctButtonAttribute[iHotKeyBtn].nColorB;

            if (red >= 0 && red <= 255
                && grn >= 0 && grn <= 255
                && blue >= 0 && blue <= 255
                )
            {
                Color newColor = Color.FromArgb(red, grn, blue);
                btnHeader.BackColor = newColor;
                btnContent.BackColor = newColor;
            } else // default
            {
                red = 240;
                grn = 240;
                blue = 240;

                Color newColor = Color.FromArgb(red, grn, blue);
                btnHeader.BackColor = newColor;
                btnContent.BackColor = newColor;
            }
        }

        private void btnHeader_Click(object sender, EventArgs e)
        {


            if (Application.OpenForms.OfType<ButtonCustomizationForm>().Count() == 1)
                Application.OpenForms.OfType<ButtonCustomizationForm>().First().Close();


            Point ptMouse = new Point(MousePosition.X, MousePosition.Y);
            Form buttomCustomization = new ButtonCustomizationForm(this, templateInfo, sender, iHotKeyBtn, ptMouse);

            buttomCustomization.Show();
        }

        private void btnContent_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<ButtonCustomizationForm>().Count() == 1)
                Application.OpenForms.OfType<ButtonCustomizationForm>().First().Close();


            Point ptMouse = new Point(MousePosition.X, MousePosition.Y);
            Form buttomCustomization = new ButtonCustomizationForm(this, templateInfo, sender, iHotKeyBtn, ptMouse);
            buttomCustomization.Show();
        }

        public void refreshButtons()
        {
            btnHeader.Text = templateInfo.dctButtonAttribute[iHotKeyBtn].strHotKeyLabel;//templateInfo.nTemplateID.ToString();
            btnContent.Text = templateInfo.dctButtonAttribute[iHotKeyBtn].strHotKeyDesc;//templateInfo.strTemplateName;

            int red = templateInfo.dctButtonAttribute[iHotKeyBtn].nColorR;
            int grn = templateInfo.dctButtonAttribute[iHotKeyBtn].nColorG;
            int blue = templateInfo.dctButtonAttribute[iHotKeyBtn].nColorB;

            if (red >= 0 && red <= 255
                && grn >= 0 && grn <= 255
                && blue >= 0 && blue <= 255
                )
            {
                Color newColor = Color.FromArgb(red, grn, blue);
                btnHeader.BackColor = newColor;
                btnContent.BackColor = newColor;
            } else
            {
                red = 240;
                grn = 240;
                blue = 240;
                
                Color newColor = Color.FromArgb(red, grn, blue);
                btnHeader.BackColor = newColor;
                btnContent.BackColor = newColor;
            }
        }

        public void SetButtonContent(string strHeader, string strBody)
        {
            btnHeader.Text = strHeader;
            btnContent.Text = strBody;


        }

        public void SetButtonsColour(Color setColor)
        {
            btnHeader.BackColor = setColor;
            btnContent.BackColor = setColor;
        }

        public string getHeader()
        {
            return btnHeader.Text;

        }

        public string getBody()
        {
            return btnContent.Text;
        }

        public Color getColor()
        {
            return btnContent.BackColor;
        }

        public int getColorR()
        {
            return (int)btnHeader.BackColor.R;
        }

        public int getColorG()
        {
            return (int)btnHeader.BackColor.G;
        }

        public int getColorB()
        {
            return (int)btnHeader.BackColor.B;
        }

        public void setTM_TemplateMessage_BCC(string msg)
        {
            frmTemplateModule.setTM_TemplateMessage(msg);
        }

    }
}
