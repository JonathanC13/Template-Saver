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
    public partial class TransferToGroup : Form
    {

        MainTemplate frmMainModule;

        private TemplateModule templateInfo;

        private Point ptLocation;

        List<TemplateGroupInfo> lstTemplateGrp = new List<TemplateGroupInfo>(); // original
        List<TemplateGroupInfo> lstValidTransferGrps = new List<TemplateGroupInfo>();// list for current template group removed

        public TransferToGroup()
        {
            InitializeComponent();
        }
        public TransferToGroup(MainTemplate frmMainTemplate,TemplateModule parentTemplateModule) : this()
        {
            //lblHeader.TabIndex = 0;
            lblHeader.TabStop = false; // stop highlight of text

            this.frmMainModule = frmMainTemplate;
            templateInfo = parentTemplateModule;
            
            lstTemplateGrp = frmMainModule.getTemplateGroups();


            // show all other groups except current group it belongs
            foreach (TemplateGroupInfo e in lstTemplateGrp)
            {
                
                if (e.nTemplateGroupID != frmMainTemplate.getCurrTemplateGroupID())
                {
                    ddTemplateGroups.Items.Add(e.strTemplateGroupName);
                    lstValidTransferGrps.Add(e);
                }
                
            }

            if (ddTemplateGroups.Items.Count > 0)
            {

                ddTemplateGroups.SelectedIndex = 0;

            }
            
            
        }

        public TransferToGroup(MainTemplate frmMainTemplate, TemplateModule parentTemplateModule, Point location) : this()
        {
            ptLocation = location;

            //lblHeader.TabIndex = 0;
            lblHeader.TabStop = false; // stop highlight of text

            this.frmMainModule = frmMainTemplate;
            templateInfo = parentTemplateModule;

            lstTemplateGrp = frmMainModule.getTemplateGroups();


            // show all other groups except current group it belongs
            foreach (TemplateGroupInfo e in lstTemplateGrp)
            {

                if (e.nTemplateGroupID != frmMainTemplate.getCurrTemplateGroupID())
                {
                    ddTemplateGroups.Items.Add(e.strTemplateGroupName);
                    lstValidTransferGrps.Add(e);
                }

            }

            if (ddTemplateGroups.Items.Count > 0)
            {

                ddTemplateGroups.SelectedIndex = 0;

            }


        }


        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Transfer_Click(object sender, EventArgs e)
        {
            /* 1. need to get Main Template. cs to update SQL to move template to the new group, at the same time placing the moved template with nOrder at the end
             * 2. refresh current group templates in the List
             * 3. Reload templates for the current group  
            */

            frmMainModule.transferTemplateToAnotherGroup(lstValidTransferGrps[ddTemplateGroups.SelectedIndex].nTemplateGroupID, templateInfo.getTemplateID());
        }

        private void lblHeader_TextChanged(object sender, EventArgs e)
        {
            //
        }

        private void TransferToGroup_Load(object sender, EventArgs e)
        {
            this.SetDesktopLocation(ptLocation.X, ptLocation.Y);
        }
    }
}
