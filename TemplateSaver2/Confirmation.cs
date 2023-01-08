using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateSaver2
{
    public partial class Confirmation : Form
    {
        TemplateModule frmTemplateModule;
        private int tempMod = 1; // template Module

        MainTemplate frmMainTemplate;
        private int mainTemp = 1; // for Template group in mainTemplate.cs

        private Point ptLocation;

        public Confirmation()
        {
            InitializeComponent();

            
        }

        public Confirmation(TemplateModule csTemplateModule, string strMessage, string strHeader) : this()
        {
            lblMessage.TabStop = false; // stop highlight of text
            lblMessage.Text = strMessage;

            lblHeader.TabStop = false;
            lblHeader.Text = strHeader;
            //lblMessage.MaximumSize = new Size(200, 0);

            frmTemplateModule = csTemplateModule;
            tempMod = 0;

            
        }

        public Confirmation(TemplateModule csTemplateModule, string strMessage, string strHeader, Point location) : this()
        {

            ptLocation = location;
            lblMessage.TabStop = false; // stop highlight of text
            lblMessage.Text = strMessage;

            lblHeader.TabStop = false;
            lblHeader.Text = strHeader;
            //lblMessage.MaximumSize = new Size(200, 0);

            frmTemplateModule = csTemplateModule;
            tempMod = 0;


        }

        public Confirmation(MainTemplate csMainTemplate, string strMessage, string strHeader) : this()
        {
            lblMessage.TabStop = false; // stop highlight of text
            lblMessage.Text = strMessage;

            lblHeader.TabStop = false;
            lblHeader.Text = strHeader;

            //lblMessage.MaximumSize = new Size(200, 0);

            frmMainTemplate = csMainTemplate;
            mainTemp = 0;
        }

        public Confirmation(MainTemplate csMainTemplate, string strMessage, string strHeader, Point location) : this()
        {

            ptLocation = location;
            lblMessage.TabStop = false; // stop highlight of text
            lblMessage.Text = strMessage;

            lblHeader.TabStop = false;
            lblHeader.Text = strHeader;

            //lblMessage.MaximumSize = new Size(200, 0);

            frmMainTemplate = csMainTemplate;
            mainTemp = 0;


        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (tempMod == 0)
            {
                frmTemplateModule.deleteThisTemplate();
            } else if (mainTemp == 0)
            {
                frmMainTemplate.deleteTemplateGroupAndContentFromDB();
            }

            this.Close();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }

        private void Confirmation_Load(object sender, EventArgs e)
        {
            this.SetDesktopLocation(ptLocation.X, ptLocation.Y);
        }
    }
}
