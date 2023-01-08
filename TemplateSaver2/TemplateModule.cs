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

    
    public partial class TemplateModule : UserControl
    {
        MainTemplate frmMainModule;

        private TemplateInfo templateInfo;

        private ButtonContentControl[] lstBtnControl = new ButtonContentControl[11];

        private string[] arrPanels = new string[11] { "panel1", "panel2", "panel3", "panel4", "panel5", "panel6", "panel7", "panel8", "panel9", "panel10", "panel11" };

        private int iMaxPanel = 10;

        public TemplateModule()
        {
            InitializeComponent();
        }


        // iDiff is the difference of default notes height and adjusted notes height
        public TemplateModule(TemplateInfo templateInfo, MainTemplate mainTemplate, int iDiff) : this() // the this will initialize the default constructor of the form
        {


            frmMainModule = mainTemplate;
            this.templateInfo = templateInfo;


            // with the template information from templateInfo, populate the attributes of each component in this User control form

            string prevMessage = templateInfo.strTemplateMsg;

            TM_txtTemplateName.Text = templateInfo.strTemplateName;
            TM_richTextNotes.Text = templateInfo.strNotes;

            TM_richTextNotes.Height = Convert.ToInt32(templateInfo.nNotesHeight);

            TM_numUpDwn.Value = templateInfo.nOrder;

            

            if (String.Compare(prevMessage, "") == 0)
            {
                templateInfo.strTemplateMsg = "";
                
            } 
            TM_TemplateMessage.Text = templateInfo.strTemplateMsg;

            //TM_TemplateMessage.Text = templateInfo.strTemplateMsg;
            //frmMainModule.printTargetTemplateInfo(templateInfo.nTemplateID);

            setNotesSectionPos(iDiff);

            if (TM_richTextNotes.Height <= 40)
            {

                TM_btnDecNotesH.Enabled = false;
            }

            if (TM_richTextNotes.Height >= 200)
            {

                TM_btnIncNotesH.Enabled = false;
            }

            

            TM_lblTemplateName.TabStop = false; // stop highlight of text
            TM_txtTemplateName.TabStop = false;
            TM_lblOrder.TabStop = false;
            TM_numUpDwn.TabStop = false;
            TM_lblNotes.TabStop = false;
            TM_richTextNotes.TabStop = false;
            TM_btnDelete.TabStop = false;
            TM_btnDiscardChanges.TabStop = false;
            TM_btnTransfer.TabStop = false;
            TM_btnSave.TabStop = false;

            // For each button need to create control



            var control1 = new ButtonContentControl(templateInfo, this, templateInfo.dctButtonAttribute.ElementAt(0).Key); // 
            //control1.Location = new Point(this.panel1.Location.X, this.panel1.Location.Y);
            control1.Width = this.panel1.Width;
            control1.Height = this.panel1.Height;
            control1.Dock = DockStyle.Left;
            this.panel1.Controls.Add(control1);
            lstBtnControl[0] = control1;

            //Debug.WriteLine("this.panel1.Location: " + this.panel1.Location);
            
            
            var control2 = new ButtonContentControl(templateInfo, this, templateInfo.dctButtonAttribute.ElementAt(1).Key);
            //control1.Location = new Point(this.panel1.Location.X, this.panel1.Location.Y);
            control2.Width = this.panel2.Width;
            control2.Height = this.panel2.Height;
            this.panel2.Controls.Add(control2);
            lstBtnControl[1] = control2;
            
            var control3 = new ButtonContentControl(templateInfo, this, templateInfo.dctButtonAttribute.ElementAt(2).Key);
            //control1.Location = new Point(this.panel1.Location.X, this.panel1.Location.Y);
            control3.Width = this.panel3.Width;
            control3.Height = this.panel3.Height;
            this.panel3.Controls.Add(control3);
            lstBtnControl[2] = control3;

            var control4 = new ButtonContentControl(templateInfo, this, templateInfo.dctButtonAttribute.ElementAt(3).Key);
            //control1.Location = new Point(this.panel1.Location.X, this.panel1.Location.Y);
            control4.Width = this.panel4.Width;
            control4.Height = this.panel4.Height;
            this.panel4.Controls.Add(control4);
            lstBtnControl[3] = control4;

            var control5 = new ButtonContentControl(templateInfo, this, templateInfo.dctButtonAttribute.ElementAt(4).Key);
            //control1.Location = new Point(this.panel1.Location.X, this.panel1.Location.Y);
            control5.Width = this.panel5.Width;
            control5.Height = this.panel5.Height;
            this.panel5.Controls.Add(control5);
            lstBtnControl[4] = control5;

            var control6 = new ButtonContentControl(templateInfo, this, templateInfo.dctButtonAttribute.ElementAt(5).Key);
            //control1.Location = new Point(this.panel1.Location.X, this.panel1.Location.Y);
            control6.Width = this.panel6.Width;
            control6.Height = this.panel6.Height;
            this.panel6.Controls.Add(control6);
            lstBtnControl[5] = control6;

            var control7 = new ButtonContentControl(templateInfo, this, templateInfo.dctButtonAttribute.ElementAt(6).Key);
            //control1.Location = new Point(this.panel1.Location.X, this.panel1.Location.Y);
            control7.Width = this.panel7.Width;
            control7.Height = this.panel7.Height;
            this.panel7.Controls.Add(control7);
            lstBtnControl[6] = control7;

            var control8 = new ButtonContentControl(templateInfo, this, templateInfo.dctButtonAttribute.ElementAt(7).Key);
            //control1.Location = new Point(this.panel1.Location.X, this.panel1.Location.Y);
            control8.Width = this.panel8.Width;
            control8.Height = this.panel8.Height;
            this.panel8.Controls.Add(control8);
            lstBtnControl[7] = control8;

            var control9 = new ButtonContentControl(templateInfo, this, templateInfo.dctButtonAttribute.ElementAt(8).Key);
            //control1.Location = new Point(this.panel1.Location.X, this.panel1.Location.Y);
            control9.Width = this.panel9.Width;
            control9.Height = this.panel9.Height;
            this.panel9.Controls.Add(control9);
            lstBtnControl[8] = control9;

            var control10 = new ButtonContentControl(templateInfo, this, templateInfo.dctButtonAttribute.ElementAt(9).Key);
            //control1.Location = new Point(this.panel1.Location.X, this.panel1.Location.Y);
            control10.Width = this.panel10.Width;
            control10.Height = this.panel10.Height;
            this.panel10.Controls.Add(control10);
            lstBtnControl[9] = control10;

            var control11 = new ButtonContentControl(templateInfo, this, templateInfo.dctButtonAttribute.ElementAt(10).Key);
            //control1.Location = new Point(this.panel1.Location.X, this.panel1.Location.Y);
            control11.Width = this.panel11.Width;
            control11.Height = this.panel11.Height;
            this.panel11.Controls.Add(control11);
            lstBtnControl[10] = control11;

            

            //TM_btn1.Text = templateInfo.nTemplateID.ToString();

            //TM_btn10.Text = templateInfo.strTemplateName;


        }



        // functions
        // public
        public void updateTemplate_test()
        {
            //TM_btn1.Text = templateInfo.strTemplateName;
        }

        public void reloadTemplate_test()
        {
            //TM_btn1.Text = templateInfo.nOrder.ToString();

            //TM_btn10.Text = templateInfo.strTemplateName;
        }

        public int getTemplateID()
        {
            return templateInfo.nTemplateID;
        }

        

        public void setTM_TemplateMessage(string msg)
        {
            TM_TemplateMessage.Text = msg;
            templateInfo.strTemplateMsg = msg;
        }

        public void refreshTemplate()
        {
            TM_txtTemplateName.Text = templateInfo.strTemplateName;
            TM_richTextNotes.Text = templateInfo.strNotes;
            TM_TemplateMessage.Text = templateInfo.strTemplateMsg;
            TM_richTextNotes.Height = templateInfo.nNotesHeight;

            

            // buttons
            for (int panel = 0; panel <= iMaxPanel ; panel++)
            {
                lstBtnControl[panel].refreshButtons();
            }

            
        }

        public void setNotesSectionPos(int iDiff)
        {
            int iYBtns = TM_btnDelete.Location.Y + iDiff;
            int iYBorder = Border.Location.Y + iDiff;
            TM_btnDelete.Location = new Point(TM_btnDelete.Location.X, iYBtns);
            TM_btnDiscardChanges.Location = new Point(TM_btnDiscardChanges.Location.X, iYBtns);
            TM_btnTransfer.Location = new Point(TM_btnTransfer.Location.X, iYBtns);
            TM_btnSave.Location = new Point(TM_btnSave.Location.X, iYBtns);
            Border.Location = new Point(Border.Location.X, iYBorder);
        }

        public string getTemplateName()
        {
            return templateInfo.strTemplateName;
        }

        // private

        private void printAllTemplatesInfo()
        {
            frmMainModule.printAllTemplateInfo();
        }

        private void printTargetTemplatesInfo()
        {
            frmMainModule.printTargetTemplateInfo(templateInfo.nTemplateID);
        }


        /*
         * 
         * public class ButtonAttribute
        {
            public int nRecID { get; set; }
            public int lngButtonID { get; set; }
            public string strHotKeyLabel { get; set; }

            public string strHotKeyDesc { get; set; }

            public int nDescHeight { get; set; }
            public int nColorR { get; set; }
            public int nColorG { get; set; }
            public int nColorB { get; set; }
        }
        */
        private void TM_btnSave_Click(object sender, EventArgs e)
        {
            //printAllTemplatesInfo();
            //printTargetTemplatesInfo();

            string strOrderChanged = "N";

            // Update TemplateInfo
            templateInfo.strTemplateName = TM_txtTemplateName.Text;  
            templateInfo.strNotes = TM_richTextNotes.Text;
            templateInfo.nNotesHeight = TM_richTextNotes.Height;

            
            if (templateInfo.nOrder != Convert.ToInt32(TM_numUpDwn.Value))
            {
                strOrderChanged = "Y";
            }
            templateInfo.nOrder = Convert.ToInt32(TM_numUpDwn.Value);


            // buttons
            for (int i = 0; i < 11; i++)
            {
                templateInfo.dctButtonAttribute.ElementAt(i).Value.strHotKeyLabel = lstBtnControl[i].getHeader();
                templateInfo.dctButtonAttribute.ElementAt(i).Value.strHotKeyDesc = lstBtnControl[i].getBody();
                templateInfo.dctButtonAttribute.ElementAt(i).Value.nColorR = lstBtnControl[i].getColorR();
                templateInfo.dctButtonAttribute.ElementAt(i).Value.nColorG = lstBtnControl[i].getColorG();
                templateInfo.dctButtonAttribute.ElementAt(i).Value.nColorB = lstBtnControl[i].getColorB();
            }


            setTM_TemplateMessage("Saved.");

            //printTargetTemplatesInfo();

            // update only the current template info in the database. Function 
            // Template info updated, now save.
            saveTemplateDB(strOrderChanged);

        }

        private void saveTemplateDB(string strOrderChanged)
        {
            frmMainModule.saveTemplateDB(templateInfo.nTemplateID, strOrderChanged);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
            setTM_TemplateMessage("Please click 'Save Changes' to commit changes");
        }

        private void TM_btnDiscardChanges_Click(object sender, EventArgs e)
        {
            frmMainModule.discardTemplateChanges(templateInfo.nTemplateID);
        }


        private void TM_btnDelete_Click(object sender, EventArgs e)
        {
            string strMessage = "Are you sure you want to delete template: " + templateInfo.strTemplateName + ", order #: " + templateInfo.nOrder.ToString();

            string strHeader = "Template Deletion Confirmation";

            if (Application.OpenForms.OfType<Confirmation>().Count() == 1)
                Application.OpenForms.OfType<Confirmation>().First().Close();

            Point ptMouse = new Point(frmMainModule.Location.X + (frmMainModule.Width / 2), frmMainModule.Location.Y + (frmMainModule.Height / 2));

            Form frmConfirmation = new Confirmation(this, strMessage, strHeader, ptMouse);
            frmConfirmation.Show();

            
        }

        public void deleteThisTemplate()
        {
            frmMainModule.deleteTemplate(templateInfo.nTemplateID);
        }

        private void TM_txtTemplateName_TextChanged(object sender, EventArgs e)
        {
            templateInfo.strTemplateName = TM_txtTemplateName.Text;
            
            setTM_TemplateMessage("Please click 'Save' to commit changes");
        }

        private void TM_richTextNotes_TextChanged(object sender, EventArgs e)
        {
            templateInfo.strNotes = TM_richTextNotes.Text;
            setTM_TemplateMessage("Please click 'Save' to commit changes");
            
        }

        private void TM_btnIncNotesH_Click(object sender, EventArgs e)
        {
            
            
            int iIncrease = 20;

            TM_richTextNotes.Height += iIncrease;

            
            if (TM_btnDecNotesH.Enabled == false)
            {
                TM_btnDecNotesH.Enabled = true;
            }


            if (TM_richTextNotes.Height >= 200)
            {

                TM_btnIncNotesH.Enabled = false;
            }



            templateInfo.nNotesHeight = TM_richTextNotes.Height;
            setTM_TemplateMessage("Please click 'Save' to commit changes");

            //setTM_TemplateMessage(TM_richTextNotes.Height.ToString());
            frmMainModule.reloadTemplateLayouts();
            //frmMainModule.adjustAllControlsHeights(this, iIncrease);

            //setTM_TemplateMessage(TM_richTextNotes.Height.ToString());
            
        }

        private void TM_btnDecNotesH_Click(object sender, EventArgs e)
        {
            int iDecrease = 20;

            TM_richTextNotes.Height -= iDecrease;

            if (TM_btnIncNotesH.Enabled == false)
            {
                TM_btnIncNotesH.Enabled = true;
            }

            if (TM_richTextNotes.Height <= 40)
            {
                
                TM_btnDecNotesH.Enabled = false;
            }
            
            templateInfo.nNotesHeight = TM_richTextNotes.Height;
            setTM_TemplateMessage("Please click 'Save' to commit changes");

            frmMainModule.reloadTemplateLayouts(); // to resize and shift, but don't like the refresh presentation. Have to use this. adjustAllControlsHeights is bugged

            //frmMainModule.adjustAllControlsHeights(this, (-1) * iDecrease); // bugged

            //setTM_TemplateMessage("Please click 'Save' to commit changes");

        }

        private void TM_btnTransfer_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<Confirmation>().Count() == 1)
                Application.OpenForms.OfType<Confirmation>().First().Close();


            Point ptMouse = new Point(frmMainModule.Location.X + (frmMainModule.Width / 2),frmMainModule.Location.Y + (frmMainModule.Height / 2));

            Form frmTransferToGroup = new TransferToGroup(frmMainModule, this, ptMouse);
            frmTransferToGroup.Show();
            
        }
    }
}
