using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateSaver2
{
    public partial class MainTemplate : Form
    {
        StartUp frmStartUp;
        GeneralError frmGeneralError;
        private string parentdir = Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath);
        private string dbName = "/TemplateDb.db";

        private string tblTemplateGroup = "tblTemplateGroup";
        private string tblTemplate = "tblTemplate";
        private string relTemplateGroupTemplate = "relTemplateGroupTemplate";
        private string tblButtonAttribute = "tblButtonAttribute";
        private string relTemplateButtonAttribute = "relTemplateButtonAttribute";

        private int iMaxTemplateNameLen;
        private int iMaxTemplateGroupNameLen;

        private string strErrVagueGeneralMsg; //= "General error message";
        private string strErrBlankGrpNameMsg;//= "Template Group name cannot be blank. Please enter a name for the Template Group you wish to add.";
        private string strErrTooLongGrpNameMsg; //= "Template Group name too long (max " + iMaxTemplateNameLen.ToString()  + " characters). Please enter a shorter name for the Template Group you wish to add.";
        private string strErrBlankTemplateNameMsg; //= "Template name cannot be blank. Please enter a name for the Template you wish to add.";
        private string strErrTooLongTemplateNameMsg; //= "Template name too long (max 128 characters). Please enter a shorter name for the Template you wish to add.";

        


        // Data
        

        // object to hold Template group info
        public class TemplateGroupInfo
        {
            public int nTemplateGroupID { get; set; }
            public string strTemplateGroupName { get; set; }

            public TemplateModule templateModule {get; set;} // holds reference to the control panel the template belongs to

        }

        List<TemplateGroupInfo> lstTemplateGrp = new List<TemplateGroupInfo>();


        // Data
       
        // object to hold Templates info
        public class TemplateInfo
        {
            public int nTemplateID { get; set; } // recID
            public string strTemplateName { get; set; }

            public int nOrder { get; set; }

            public string strNotes { get; set; }

            public int nNotesHeight { get; set; }

            public Dictionary<int, ButtonAttribute> dctButtonAttribute { get; set; } // Each template has a dictionary for the Buttons

            public string strTemplateMsg { get; set; }
        }

        List<TemplateInfo> lstTemplate = new List<TemplateInfo>();

        Dictionary<int, TemplateInfo> dctTempInfo = new Dictionary<int, TemplateInfo>();


        // Button attribute object
        public class ButtonAttribute
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

        //Dictionary<int, ButtonAttribute> dctButtonAttribute;// = new Dictionary<int, ButtonAttribute>();



        // current control list

        // object to hold Template's control info
        public class TemplateControl
        {
            public Control control { get; set; }

            public TemplateModule module { get; set; }

        }

        List<TemplateControl> lstControl = new List<TemplateControl>();

        public MainTemplate(StartUp parent)
        {
            InitializeComponent();

            ddTemplate.Visible = false;

            frmStartUp = parent;

            

            iMaxTemplateNameLen = 64;
            iMaxTemplateGroupNameLen = 64;

            strErrVagueGeneralMsg = "General error message";
            strErrBlankGrpNameMsg = "Template Group name cannot be blank. Please enter a name for the Template Group you wish to add.";
            strErrTooLongGrpNameMsg = "Template Group name too long (max " + iMaxTemplateGroupNameLen.ToString() + " characters). Please enter a shorter name for the Template Group you wish to add.";
            strErrBlankTemplateNameMsg = "Template name cannot be blank. Please enter a name for the Template you wish to add.";
            strErrTooLongTemplateNameMsg = "Template name too long (max " + iMaxTemplateNameLen.ToString() + " characters). Please enter a shorter name for the Template you wish to add.";

            // Should have made a user control for header at the beginning, but now just add to the panel
            panel1.Controls.Add(lblTempateGrp);
            panel1.Controls.Add(ddTemplateGroup);
            panel1.Controls.Add(btnAddGroup);
            panel1.Controls.Add(txtBTemplateGrp);
            panel1.Controls.Add(btnRenameGrp);
            panel1.Controls.Add(txtBRenameGrp);
            panel1.Controls.Add(btnDeleteGroup);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(btnAddTemplate);
            panel1.Controls.Add(txtBAddTemplate);
            panel1.Controls.Add(ddTemplate);

            //ddTemplate.Visible = true;

            panel1.Controls.Add(btnDump);
            panel1.Controls.Add(txtFileDir);

            panel1.MaximumSize = new Size(800, 176);

            txtFileDir.Multiline = true;

            var curDir = Directory.GetCurrentDirectory();
            //txtFileDir.Text = curDir;
            //txtFileDir.Text = parentdir; // SQLite db location

            panelTemplates.MaximumSize = new Size(776, this.ClientSize.Height);

            // Template panel scroll bars
            //panelTemplates.AutoScroll = true;
            //panelTemplates.VerticalScroll.Visible = true;
            //panelTemplates.HorizontalScroll.Visible = true;

            

            // Load Template groups
            loadTemplateGroups(-1);
        }

        // Event Handlers

        private void btnAddTemplate_Click(object sender, EventArgs e)
        {
            if (!(txtBAddTemplate.Text == "") && txtBAddTemplate.Text.Length <= iMaxTemplateNameLen)
            {
                addTemplate();

                // Refresh list
                loadTemplateList();

                txtBAddTemplate.Text = "";

                // Build Template Modules
                reloadTemplateLayouts();
            }
            else
            {
                if (txtBAddTemplate.Text == "")
                {
                    setGeneralErrorMessage(strErrBlankTemplateNameMsg);
                }
                else if (txtBAddTemplate.Text.Length > iMaxTemplateNameLen)
                {
                    setGeneralErrorMessage(strErrTooLongTemplateNameMsg);
                }
                else
                {
                    setGeneralErrorMessage("btnAddGroup_Click: " + strErrVagueGeneralMsg);
                }

            }
        }



        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            //Debug.WriteLine("btnAddTemplate_Click: " + getTemplateGroupCount().ToString());
            if (!(txtBTemplateGrp.Text == "") && txtBTemplateGrp.Text.Length <= iMaxTemplateGroupNameLen)
            {
                addTemplateGroup();
                
                // Refresh list 
                loadTemplateGroups(-1);

                txtBTemplateGrp.Text = "";
            } else
            {
                if (txtBTemplateGrp.Text == "")
                {
                    setGeneralErrorMessage(strErrBlankGrpNameMsg);
                } else if (txtBTemplateGrp.Text.Length > iMaxTemplateGroupNameLen)
                {
                    setGeneralErrorMessage(strErrTooLongGrpNameMsg);
                }
                else
                {
                    setGeneralErrorMessage("btnAddGroup_Click: " + strErrVagueGeneralMsg);
                }

            }
            
        }

        private void MainTemplate_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ddTemplateGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("ddTemplateGroup_SelectedIndexChanged");
            // Queries the database 
            loadTemplateList();

            //Debug.Write("ddTemplateGroup_SelectedIndexChanged");
            // Build Template Modules
            reloadTemplateLayouts();

        }

        private void btnRenameGrp_Click(object sender, EventArgs e)
        {
            //setGeneralErrorMessage("test click");
            //setGeneralErrorMessage("test click2");
                  //Debug.WriteLine("btnAddTemplate_Click: " + getTemplateGroupCount().ToString());
         if (!(txtBRenameGrp.Text == "") && txtBRenameGrp.Text.Length <= iMaxTemplateGroupNameLen)
         {
             updateTemplateGroupName();

             // Refresh list
             loadTemplateGroups(ddTemplateGroup.SelectedIndex);

             txtBRenameGrp.Text = "";
         }
         else
         {
             if (txtBRenameGrp.Text == "")
             {
                 setGeneralErrorMessage(strErrBlankGrpNameMsg);
             }
             else if (txtBRenameGrp.Text.Length > iMaxTemplateGroupNameLen)
             {
                 setGeneralErrorMessage(strErrTooLongGrpNameMsg);
             } else
             {
                 setGeneralErrorMessage("btnRenameGrp_Click: " + strErrVagueGeneralMsg);
             }

         }
            
        }
        
        private void MainTemplate_Resize(object sender, EventArgs e)
        {

            // ** Note snapping doesn't trigger this event, so need to manually initiate resize after snapping window to trigger resizing in this function

            panelTemplates.Height = this.ClientSize.Height - 225;



            // keep headers centered
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;

            // scroll bars in view when resizing
            panel1.Width = ((this.ClientSize.Width));
            //panel1.MaximumSize = new Size(800, 176);

            // if panel size becomes smaller than the components it contains, the auto scroll bar will appear
            if(this.ClientSize.Height < 176)
            {
                panel1.Height = this.ClientSize.Height;
            } else
            {
                panel1.Height = 176;

            }

            // reposition all components to center
                /*
                lblTempateGrp.Left = (panel1.Width - lblTempateGrp.Width) / 2;
                ddTemplateGroup.Left = (panel1.Width - ddTemplateGroup.Width) / 2;
                */
                /*

                panel1.Controls.Add(btnAddGroup);
                panel1.Controls.Add(txtBTemplateGrp);
                panel1.Controls.Add(btnRenameGrp);
                panel1.Controls.Add(txtBRenameGrp);
                panel1.Controls.Add(btnDeleteGroup);
                panel1.Controls.Add(textBox1);
                panel1.Controls.Add(btnAddTemplate);
                panel1.Controls.Add(txtBAddTemplate);
                panel1.Controls.Add(ddTemplate);
                panel1.Controls.Add(btnDump);
                panel1.Controls.Add(txtFileDir);
                */



                // keep template panel centered
                panelTemplates.Left = (this.ClientSize.Width - panelTemplates.Width) / 2;

            // scroll bars in view when resizing
            panelTemplates.Width = ((this.ClientSize.Width));

            // Resize to expand or shrink panel
            panelTemplates.MaximumSize = new Size(776, this.ClientSize.Height);



        }




        // /Event handlers

        // functions
        /*
        private void loadTemplateList_nonSQL()
        {

        }
        */
        // public

        public int getCurrTemplateGroupID()
        {
            int intCurrentGroupIndex = ddTemplateGroup.SelectedIndex;

            int intTemplateGroupID = lstTemplateGrp[intCurrentGroupIndex].nTemplateGroupID;

            return intTemplateGroupID;
        }

        // transfer the template to the specified template group
        public void transferTemplateToAnotherGroup(int intTemplateGroupID, int intTemplateToTransferID) 
        {
            // get order so the template being transferred is assigned the last position
            int iOrder = 0;
            iOrder = getTemplateGroupHighestOrder(intTemplateGroupID);
            iOrder++;

            
            using (SqliteConnection conn = new SqliteConnection("data source=" + parentdir + dbName + ";foreign keys=true;"))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {

                    // transfer template to new group
                    String sql = "UPDATE " + relTemplateGroupTemplate + " SET nTemplateGroupID = @intTemplateGroupID " +
                        "WHERE nTemplateID = @intTemplateID; " +
                        "";

                    // Update the order of the template
                    sql += "UPDATE " + tblTemplate + " SET nOrder = @iOrder " +
                        "WHERE nTemplateID = @intTemplateID1; " +
                        "";

                    cmd.CommandText += sql;

                    cmd.Parameters.AddWithValue("@intTemplateGroupID", intTemplateGroupID);
                    cmd.Parameters.AddWithValue("@intTemplateID", intTemplateToTransferID);
                    cmd.Parameters.AddWithValue("@iOrder", iOrder);
                    cmd.Parameters.AddWithValue("@intTemplateID1", intTemplateToTransferID);

                    cmd.Connection = conn;

                   // Debug.WriteLine("saveNewOrder: " + cmd.CommandText);

                    try
                    {
                        conn.Open();

                        var result = cmd.ExecuteNonQuery();
                        if (result != 2)
                        {
                            Debug.WriteLine("transferTemplateToAnotherGroup: Update anomoly return " + result.ToString());
                        }

                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        //Debug.WriteLine("transferTemplateToAnotherGroup: " + ex.ToString());

                        setGeneralErrorMessage("transferTemplateToAnotherGroup: " + ex.ToString());
                        throw ex;
                    }

                    conn.Close();
                }
            }


            // reload current template group, so the transfer template is removed
            // Refresh list
            loadTemplateList();

            // Build Template Modules
            reloadTemplateLayouts();

        }
        
        public List<TemplateGroupInfo> getTemplateGroups()
        {
            return lstTemplateGrp;
        }

        public void printAllTemplateInfo()
        {
            foreach (KeyValuePair<int, TemplateInfo> entry in dctTempInfo)
            {
                Debug.Write("Key: " + entry.Key + ". Val: " + entry.Value.nTemplateID + ": " + entry.Value.strTemplateName + ". order: " + entry.Value.nOrder + '\n');

            }

        }

        /*
         * public int nTemplateID { get; set; }
            public string strTemplateName { get; set; }
         * */
        public void printTargetTemplateInfo(int iTemplateID)
        {

            Debug.Write(dctTempInfo[iTemplateID].nTemplateID + "\n");
            Debug.Write("Name: " + dctTempInfo[iTemplateID].strTemplateName + "\n");
            Debug.Write("Notes: " + dctTempInfo[iTemplateID].strNotes + "\n");
            Debug.Write("Notes Height: " + dctTempInfo[iTemplateID].nNotesHeight.ToString() + "\n");
            Debug.Write("Order: " + dctTempInfo[iTemplateID].nOrder.ToString() + "\n");
            Debug.Write("Message: " + dctTempInfo[iTemplateID].strTemplateMsg + "\n");

            foreach (KeyValuePair<int, ButtonAttribute> entry in dctTempInfo[iTemplateID].dctButtonAttribute)
            {
                Debug.Write("strHotKeyLabel " + entry.Value.strHotKeyLabel + "\n");
                Debug.Write("strHotKeyDesc " + entry.Value.strHotKeyDesc + "\n");
                Debug.Write("nColorR " + entry.Value.nColorR.ToString() + "\n");
                Debug.Write("nColorG " + entry.Value.nColorG.ToString() + "\n");
                Debug.Write("nColorB " + entry.Value.nColorB.ToString() + "\n");

                

                Debug.Write("\n\n");
            }

        }

        public void saveTemplateDB(int iTemplateID, string strOrderChanged)
        {

            // Note, line breaks i text box saved in DB as is.


            // write update to commit changes to the template to the database
            updateSpecifiedTemplate(iTemplateID);


            dctTempInfo[iTemplateID].strTemplateMsg = "";

            //Debug.WriteLine("Save: " + strOrderChanged);

            // if strOrderChanged = 'Y' then update all templates' order
            if (strOrderChanged == "Y")
            {
                updateOrderOfTemplateInCurGroup(iTemplateID);
            }

            
            foreach (TemplateControl e in lstControl)
            {
                if (e.module.getTemplateID() == iTemplateID)
                {
                    e.module.setTM_TemplateMessage(""); // clear message box
                    
                }


            }
            
        }

        public void deleteTemplate(int iTemplate)
        {
            /*
             * 1. delete from DB
             * 2. delete from templateInfo dict
             * 3. delete specific control from the panel
             * 4. Re-shift controls in the panel so no gap from deleted control
             */

            // 1. delete from DB
            deleteTemplateFromDB(iTemplate);

            // 2. delete from templateInfo dict
            dctTempInfo.Remove(iTemplate);

            // 3. delete specific control from the panel because the user may have pending changes on other templates
            foreach (TemplateControl e in lstControl)
            {
                if (e.module.getTemplateID() == iTemplate)
                {

                    if (panelTemplates.Controls.Contains(e.control))
                    {

                        panelTemplates.Controls.Remove(e.control);
                        //panelTemplates.Dispose();

                    }

                    break;
                }


            }

            // 4. Re-shift controls in the panel so no gap from deleted control. Just reload
            reloadTemplateLayouts();
        }

        public void discardTemplateChanges(int iTemplate)
        {
            // reload only the elements for the specified template

            dctTempInfo[iTemplate].strTemplateMsg = "";

            // look for the control that contains the template
            foreach (TemplateControl e in lstControl)
            {
                if (e.module.getTemplateID() == iTemplate)
                {

                    // reload all original elements by quering the database

                    //1. Re - save in templateInfo object
                    //2. Reload that specific template
                    repopSpecifiedTemplate(iTemplate, e);

                    


                    e.module.setTM_TemplateMessage(""); // clear message box
                }


            }

            // re-align if note height is different
            reloadTemplateLayouts();

        }

        public void adjustAllControlsHeights(TemplateModule currTemplateModule, int iHeightChange)
        {
            int x = 0;
            int y = 0;

            //int count = 0;

            //Debug.WriteLine("adjustAllControlsHeights11111111: " + panelTemplates.Height.ToString());
            //panelTemplates.Location = new Point(x, y);

            // bug: cannot solve, Blank space created when increase,decrease clicked for templates other than 1
            foreach (TemplateControl e in lstControl)
            {
                //Debug.WriteLine("Y2: " + e.module.getTemplateName() + " : " + y.ToString() + "\n\n ==============");
             
                /*
                if (e.module == currTemplateModule)
                {

                    e.module.Height += iHeightChange;
                    e.module.setNotesSectionPos(iHeightChange);

                }*/
                
                


                // works, but creates empty space above first control if this function is invoked by any template other than template 1
                //e.module.Location = new Point(x, y);
                //y += e.module.Height;

                Point point = new Point(x, y);

                e.module.Location = point;
                y = y + e.module.Height;

                e.module.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                // center control in the panel
                e.module.Left = (panelTemplates.Width - e.module.Width) / 2;

                

                

                //count++;
            }
            
           // panelTemplates.Size = new Size(panelTemplates.Width, panelTemplates.Height + iHeightChange);
            
            //Debug.WriteLine("adjustAllControlsHeights: " + panelTemplates.Padding.ToString());
            //Debug.WriteLine("adjustAllControlsHeights: " + panelTemplates.Margin.ToString());
            //Debug.WriteLine("!==============!");
        }

        // private to public
        public void reloadTemplateLayouts()
        {
            int x = 0;
            int y = 0;

            int iDefaultNotesH = 111;
            int iDiff = 0;

            System.Drawing.Point CurrentPoint;
            CurrentPoint = panelTemplates.AutoScrollPosition;
            Debug.WriteLine(CurrentPoint.Y.ToString());
            //Debug.WriteLine("CurrentPoint1111: " + CurrentPoint.ToString());

            //panelTemplates.AutoScrollPosition = new Point(Math.Abs(panel1.AutoScrollPosition.X), Math.Abs(CurrentPoint.Y));



            // delete all previous layouts
            foreach (TemplateControl e in lstControl)
            {
                if (panelTemplates.Controls.Contains(e.control))
                {

                    panelTemplates.Controls.Remove(e.control);

                }


            }
            lstControl.Clear();

            

            // build template layouts
            //foreach (TemplateInfo e in lstTemplate)
            foreach (KeyValuePair<int, TemplateInfo> entry in dctTempInfo)

            {
                //Debug.Write("aa: " + e.strTemplateName);
                /*  
                 * 1. This creates the user control for the panel holding the template layouts
                 * 2. var control = new TemplateModule(entry.Value, this); should create 11 more userControls for the buttons. 
                 * 3. Those button UserControls should display the button's attributes
                 * */

                // get difference from default Notes height
                iDiff = entry.Value.nNotesHeight - iDefaultNotesH;


                var control = new TemplateModule(entry.Value, this, iDiff); // 
                control.Location = new Point(x, y);


                TemplateControl tempControl = new TemplateControl();
                tempControl.control = control;
                tempControl.module = control;
                lstControl.Add(tempControl);

                control.Height += iDiff;

                panelTemplates.Controls.Add(control);

                y += control.Height;


                // center control in the panel
                control.Left = (panelTemplates.Width - control.Width) / 2;




                //panelTemplates.Height = y; // comment out to allow auto scroll
                //Debug.Write(e.strTemplateName);
            }

            panelTemplates.AutoScrollPosition = new Point(Math.Abs(panel1.AutoScrollPosition.X), Math.Abs(CurrentPoint.Y));
        }
        public void deleteTemplateGroupAndContentFromDB()
        {
            int iCurrTemplateGroupRecID = getCurrTemplateGroupID();
            // delete all templates in the current group
            foreach (KeyValuePair<int, TemplateInfo> e in dctTempInfo)
            {
                deleteTemplateFromDB(e.Key);
            }

            // delete the group
            deleteTemplateGroup(iCurrTemplateGroupRecID);

            // Refresh template groups
            loadTemplateGroups(-1);

            // Refresh list
            loadTemplateList();

            // Build Template Modules
            reloadTemplateLayouts();
        }

        // private


        private void deleteTemplateGroup(int iTemplateGroup)
        {
            using (SqliteConnection conn = new SqliteConnection("data source=" + parentdir + dbName + ";foreign keys=true;"))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {


                    String sql = "DELETE FROM " + tblTemplateGroup + " WHERE nTemplateGroupID = @nTemplateGroupID; ";
                        
                    cmd.CommandText = sql;

                    cmd.Parameters.AddWithValue("@nTemplateGroupID", iTemplateGroup);

                    cmd.Connection = conn;


                    //Debug.WriteLine("deleteTemplateGroup: " + cmd.CommandText);
                    try
                    {
                        conn.Open();

                        var result = cmd.ExecuteNonQuery();

                        
                        if (result != 1) 
                        {
                            Debug.WriteLine("deleteTemplateGroup: " + result.ToString());
                        }

                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        // Debug.WriteLine("deleteTemplateGroup: " + ex.ToString());

                        setGeneralErrorMessage("deleteTemplateGroup: " + ex.ToString());
                        throw ex;
                    }

                    conn.Close();
                }
            }
        }

        private void deleteTemplateFromDB(int iTemplateID)
        {
            using (SqliteConnection conn = new SqliteConnection("data source=" + parentdir + dbName + ";foreign keys=true;"))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {

                    
                    String sql = "DELETE FROM " + relTemplateButtonAttribute + " WHERE nTemplateID = @nTemplateID; " +
                        "DELETE FROM " + tblButtonAttribute + " " +
                        "WHERE nRecID NOT IN (SELECT nButtonRecID from relTemplateButtonAttribute); " + // just delete all that don't belong to a template
                        "DELETE FROM " + relTemplateGroupTemplate + " WHERE nTemplateID = @nTemplateID2; " +
                        "DELETE FROM " + tblTemplate + " WHERE nTemplateID = @nTemplateID3;";
                        
                        
                    cmd.CommandText = sql;

                    cmd.Parameters.AddWithValue("@nTemplateID", iTemplateID);
                    cmd.Parameters.AddWithValue("@nTemplateID1", iTemplateID);
                    cmd.Parameters.AddWithValue("@nTemplateID2", iTemplateID);
                    cmd.Parameters.AddWithValue("@nTemplateID3", iTemplateID);

                    cmd.Connection = conn;


                    Debug.WriteLine("deleteTemplateFromDB: " + cmd.CommandText);
                    try
                    {
                        conn.Open();

                        var result = cmd.ExecuteNonQuery();

                        /*
                         * 1 from relTemplateButtonAttribute
                         * 11 from tblButtonAttribute
                         * 1 from relTemplateGroupTemplate
                         * 1 from tblTemplate
                         * 
                         * Not sure why 13, sometimes 24
                         */ 
                        //if (result != 13) 
                        //{
                            Debug.WriteLine("deleteTemplateFromDB: " + result.ToString());
                        //}

                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        //Debug.WriteLine("deleteTemplateFromDB: " + ex.ToString());
                        setGeneralErrorMessage("deleteTemplateFromDB: " + ex.ToString());
                        throw ex;
                    }

                    conn.Close();
                }
            }
        }

        // iTemplate is the template's order that changed and is initiating the re-order
        private void updateOrderOfTemplateInCurGroup(int iTemplate)
        {
            //Debug.Write("==========="+ "\n\n");
            /* 1. re order in the TemplateInfo dictionary (sort, then shift if needed (if new order number already exists))
             * 2. save new order in the DB table
             * 3. reload all templates (from TemplateInfo dict, don't re pull since the user may have changes on the current templates in the dict.
             */

            // 1.
            int iCurrIndex = 0;
            int[,] arrOrdering = new int[dctTempInfo.Count, 2];
            // put nOrder and nTemplateID into a 2D array then just do bubble sort

            foreach (KeyValuePair<int, TemplateInfo> entry in dctTempInfo)
            {

                arrOrdering[iCurrIndex, 0] = entry.Value.nOrder;
                arrOrdering[iCurrIndex, 1] = entry.Key;

                iCurrIndex++;
            }



            int iSorted = 1;
            int j = 0;
            int temp0;
            int temp1;
            
            while (iSorted != 0)
            {
                
                iSorted = 0;
                for (int i = 0; i < arrOrdering.GetLength(0) - 1; i++)
                {
                    j = i + 1;
                    
                    if (arrOrdering[i,0] > arrOrdering[j, 0])
                    {
                        // swap
                        temp0 = arrOrdering[i, 0];
                        temp1 = arrOrdering[i, 1];

                        arrOrdering[i, 0] = arrOrdering[j, 0];
                        arrOrdering[i, 1] = arrOrdering[j, 1];

                        arrOrdering[j, 0] = temp0;
                        arrOrdering[j, 1] = temp1;

                        

                        iSorted++;
                    }
                }
                
            }

            // print array for debug
            /*
            for (int i = 0; i < arrOrdering.GetLength(0); i++)
            {
                Debug.Write("0: "  + arrOrdering[i,0] + "\n");
                Debug.Write("1: " + arrOrdering[i, 1] + "\n\n");
            }
            */
            //Debug.Write("==========="+ "\n\n");

            // Shift if needed
            int iShifts = 1;
            
            j = 0;
            while (iShifts != 0)
            {
                iShifts = 0;
                for (int i = 0; i < arrOrdering.GetLength(0) - 1; i++)
                {

                    j = (i + 1);

                    if (iTemplate == arrOrdering[i, 1] && arrOrdering[i, 0] == arrOrdering[j, 0])
                    {
                        // if moved template and element after has the same order, shift other element's order
                        arrOrdering[j, 0] = arrOrdering[j, 0] + 1;
                    } else if (iTemplate == arrOrdering[j, 1] && arrOrdering[i, 0] == arrOrdering[j, 0])
                    {
                        // if next element is the moved template and the current element has the same order, shift current
                        arrOrdering[i, 0] = arrOrdering[i, 0] + 1;

                        // need to swap
                        temp0 = arrOrdering[i, 0];
                        temp1 = arrOrdering[i, 1];

                        arrOrdering[i, 0] = arrOrdering[j, 0];
                        arrOrdering[i, 1] = arrOrdering[j, 1];

                        arrOrdering[j, 0] = temp0;
                        arrOrdering[j, 1] = temp1;
                    } else if (arrOrdering[i, 0] == arrOrdering[j, 0])
                    {
                        // if current and next element has the same order, shift next element's order
                        arrOrdering[j, 0] = arrOrdering[j, 0] + 1;
                    }

                    


                }
            }




            // after ordering, update ordering, then re-assign dict
            Dictionary<int, TemplateInfo> dctTempInfoTemp = new Dictionary<int, TemplateInfo>();
            for (int i = 0; i < arrOrdering.GetLength(0); i++)
            {
                dctTempInfoTemp.Add(arrOrdering[i, 1], dctTempInfo[arrOrdering[i, 1]]);
                dctTempInfoTemp[arrOrdering[i, 1]].nOrder = arrOrdering[i, 0];
            }

            dctTempInfo = dctTempInfoTemp;
            /*
            for (int i = 0; i < arrOrdering.GetLength(0); i++)
            {
                Debug.Write("0: " + arrOrdering[i, 0] + "\n");
                Debug.Write("1: " + arrOrdering[i, 1] + "\n\n");
            }
            */

            //printAllTemplateInfo();
            //Debug.Write("==========="+ "\n\n");

            // 2. save new order in the DB table
            saveNewOrder();


            // 3.reload all templates(from TemplateInfo dict, don't re pull since the user may have changes on the current templates in the dict.
            reloadTemplateLayouts();

        }

        private void saveNewOrder()
        {
            using (SqliteConnection conn = new SqliteConnection("data source=" + parentdir + dbName + ";foreign keys=true;"))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {

                    // Update new order
                    foreach (KeyValuePair<int, TemplateInfo> e in dctTempInfo)
                    {
                        String sql = "Update " + tblTemplate + " SET nOrder = @nNewOrder" + e.Key.ToString() + " where nTemplateID = @nTemplateID" + e.Key.ToString() + "; ";
                        cmd.CommandText += sql;

                        cmd.Parameters.AddWithValue("@nNewOrder" + e.Key.ToString(), e.Value.nOrder);
                        cmd.Parameters.AddWithValue("@nTemplateID" + e.Key.ToString(), e.Key);
                    }

                    cmd.Connection = conn;

                    Debug.WriteLine("saveNewOrder: " + cmd.CommandText);

                    try
                    {
                        conn.Open();

                        var result = cmd.ExecuteNonQuery();
                        if (result != dctTempInfo.Count)
                        {
                            Debug.WriteLine("saveNewOrder: Update anomoly return " + result.ToString());
                        }

                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        //Debug.WriteLine("saveNewOrder: " + ex.ToString());
                        setGeneralErrorMessage("saveNewOrder: " + ex.ToString());
                        throw ex;
                    }

                    conn.Close();
                }
            }
        }


        private void updateSpecifiedTemplate(int iTemplate)
        {
            // iTemplate unique
            using (SqliteConnection conn = new SqliteConnection("data source=" + parentdir + dbName + ";foreign keys=true;"))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {



                    // Update template base information
                    String sql = "Update " + tblTemplate + " SET " +
                        "strTemplateName = @strNewTemplateName, " +
                        "strNotes = @strNewNotes, " +
                        "nNotesHeight = @nNewHeight, " +
                        "nOrder = @nNewOrder " +
                        "where nTemplateID = @iTemplateID; ";
                    

                    cmd.Parameters.AddWithValue("@strNewTemplateName", dctTempInfo[iTemplate].strTemplateName);
                    cmd.Parameters.AddWithValue("@strNewNotes", dctTempInfo[iTemplate].strNotes);
                    cmd.Parameters.AddWithValue("@nNewHeight", dctTempInfo[iTemplate].nNotesHeight.ToString());
                    cmd.Parameters.AddWithValue("@nNewOrder", dctTempInfo[iTemplate].nOrder.ToString());
                    cmd.Parameters.AddWithValue("@iTemplateID", iTemplate.ToString());

                    foreach (KeyValuePair<int, ButtonAttribute> e in dctTempInfo[iTemplate].dctButtonAttribute)
                    {
                        /* SQLite can't use this format
                            sql += "Update a SET " +
                            "strHotKeyLabel = @strNewHotKeyLabel, " +
                            "strHotKeyDesc = @strNewHotKeyDesc, " +

                            "nColorR = @nNewColorR, " +
                            "nColorG = @nNewColorG, " +
                            "nColorB = @nNewColorB " +
                            "FROM " + tblButtonAttribute + " a " +
                            "inner join " + relTemplateButtonAttribute + " b on b.nButtonRecID = a.nRecID " +
                            "WHERE b.nTemplateID = @iTemplateID_2 AND a.nRecID = @nRecID; ";
                        */


                        // "+e.Key.ToString()+" to have unique parameters for SQLlite
                        sql += "Update " + tblButtonAttribute + " SET " +
                        "strHotKeyLabel = @strNewHotKeyLabel"+e.Key.ToString()+", " +
                        "strHotKeyDesc = @strNewHotKeyDesc" + e.Key.ToString() + ", " +

                        "nColorR = @nNewColorR" + e.Key.ToString() + ", " +
                        "nColorG = @nNewColorG" + e.Key.ToString() + ", " +
                        "nColorB = @nNewColorB" + e.Key.ToString() + " " +
                        "WHERE nRecID = @nRecID" + e.Key.ToString() + " AND nRecID IN (SELECT nButtonRecID FROM " + relTemplateButtonAttribute + " where nTemplateID = @iTemplateID" + e.Key.ToString() + " and nRecID = @nRecID" + e.Key.ToString() + "); ";
                    /*
                        cmd.Parameters.AddWithValue("@strNewHotKeyLabel", dctTempInfo[iTemplate].dctButtonAttribute[1].strHotKeyLabel);
                        cmd.Parameters.AddWithValue("@strNewHotKeyDesc", dctTempInfo[iTemplate].dctButtonAttribute[1].strHotKeyDesc);
                        cmd.Parameters.AddWithValue("@nNewColorR", dctTempInfo[iTemplate].dctButtonAttribute[1].nColorR.ToString());
                        cmd.Parameters.AddWithValue("@nNewColorG", dctTempInfo[iTemplate].dctButtonAttribute[1].nColorG.ToString());
                        cmd.Parameters.AddWithValue("@nNewColorB", dctTempInfo[iTemplate].dctButtonAttribute[1].nColorB.ToString());
                        cmd.Parameters.AddWithValue("@iTemplateID_2", iTemplate.ToString());
                        cmd.Parameters.AddWithValue("@nRecID", '1');
                    */
                    
                    
                        cmd.Parameters.AddWithValue("@strNewHotKeyLabel" + e.Key.ToString() + "", e.Value.strHotKeyLabel);
                        cmd.Parameters.AddWithValue("@strNewHotKeyDesc" + e.Key.ToString() + "", e.Value.strHotKeyDesc);
                        cmd.Parameters.AddWithValue("@nNewColorR" + e.Key.ToString() + "", e.Value.nColorR.ToString());
                        cmd.Parameters.AddWithValue("@nNewColorG" + e.Key.ToString() + "", e.Value.nColorG.ToString());
                        cmd.Parameters.AddWithValue("@nNewColorB" + e.Key.ToString() + "", e.Value.nColorB.ToString());
                        cmd.Parameters.AddWithValue("@iTemplateID" + e.Key.ToString() + "", iTemplate.ToString());
                        cmd.Parameters.AddWithValue("@nRecID" + e.Key.ToString() + "", e.Key.ToString());
                    
                    }



                    cmd.CommandText = sql;
                    cmd.Connection = conn;

                    //Debug.Write("SQL: " + cmd.CommandText);

                    try
                    {
                        conn.Open();

                        var result = cmd.ExecuteNonQuery();

                        /*
                        if (result != 1)
                        {
                            Debug.WriteLine("updateTemplateGroupName: Update anomoly return " + result.ToString());
                        }
                        */

                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        //Debug.WriteLine("updateSpecifiedTemplate: " + ex.ToString());

                        setGeneralErrorMessage("updateSpecifiedTemplate: " + ex.ToString());
                        throw ex;
                    }

                    conn.Close();
                }
            }
        }

        private void repopSpecifiedTemplate(int iTemplate, TemplateControl templateControl)
        {
            // dctTempInfo

            

            using (SqliteConnection conn = new SqliteConnection("data source=" + parentdir + dbName + ";foreign keys=true;"))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {

                    //Debug.WriteLine("1. " + strTargetTable);
                    String sql = "SELECT a.* from " + tblTemplate + 
                        " a where a.nTemplateID = @nTemplateID";

                    cmd.CommandText = sql;

                    //Debug.WriteLine("sql: " + cmd.CommandText);

                    cmd.Parameters.AddWithValue("@nTemplateID", iTemplate);

                    
                    cmd.Connection = conn;

                    try
                    {

                        conn.Open();

                        var result = cmd.ExecuteReader();

                        if (result.HasRows)
                        {

                            // if table does exist, extract rows
                            while (result.Read())
                            {
                                //Console.WriteLine("\t{0}{1}", result.GetString(1), result.GetInt32(1));

                                // update template info
                                dctTempInfo[iTemplate].strTemplateName = result.GetString(1);
                                dctTempInfo[iTemplate].strNotes = result.GetString(2);
                                dctTempInfo[iTemplate].nNotesHeight = result.GetInt32(3);
                                dctTempInfo[iTemplate].nOrder = result.GetByte(4);


                                // update the button attributes for the template
                                repopButtonsToTemplate(iTemplate, templateControl);

                            }


                        }
                        else
                        {
                            // if table does not exist
                            result.Close();

                        }

                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        //Debug.WriteLine("repopSpecifiedTemplate: " + ex.ToString());

                        setGeneralErrorMessage("repopSpecifiedTemplate: " + ex.ToString());
                        throw ex;
                    }

                    

                    conn.Close();

                }
            }
        }

        private void repopButtonsToTemplate(int iTemplateID, TemplateControl templateControl)
        {
            using (SqliteConnection conn = new SqliteConnection("data source=" + parentdir + dbName + ";foreign keys=true;"))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {
                    
                    

                    // Get the Button attributes associated with the TemplateID
                    String sql = "SELECT a.* from " + tblButtonAttribute + 
                        " a inner join "+ relTemplateButtonAttribute + " b on b.nRecID = a.nRecID " +
                        " where b.nTemplateID = @nTemplateID order by a.nRecID asc";
                    cmd.CommandText = sql;

                    cmd.Parameters.AddWithValue("@nTemplateID", iTemplateID);

                    cmd.Connection = conn;



                    try
                    {
                        conn.Open();

                        var result = cmd.ExecuteReader();
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                // update all button attributes for the specified template
                                dctTempInfo[iTemplateID].dctButtonAttribute[result.GetInt16(0)].strHotKeyLabel = result.GetString(2);
                                dctTempInfo[iTemplateID].dctButtonAttribute[result.GetInt16(0)].strHotKeyDesc = result.GetString(3);
                                dctTempInfo[iTemplateID].dctButtonAttribute[result.GetInt16(0)].nDescHeight = result.GetInt16(4);
                                dctTempInfo[iTemplateID].dctButtonAttribute[result.GetInt16(0)].nColorR = result.GetInt16(5);
                                dctTempInfo[iTemplateID].dctButtonAttribute[result.GetInt16(0)].nColorG = result.GetInt16(6);
                                dctTempInfo[iTemplateID].dctButtonAttribute[result.GetInt16(0)].nColorB = result.GetInt16(7);


                                // reload template in the respective control
                                templateControl.module.refreshTemplate();

                            }


                        }
                        


                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        //Debug.WriteLine("updatesButtonsToTemplate: " + ex.ToString());

                        setGeneralErrorMessage("updatesButtonsToTemplate: " + ex.ToString());
                        throw ex;
                    }

                    conn.Close();


                    
                }
            }
        }

        // get the highest order number for the specified template group ID 
        private int getTemplateGroupHighestOrder(int intTemplateGroupID)
        {
            
            int iOrder = 0;

            using (SqliteConnection conn = new SqliteConnection("data source=" + parentdir + dbName + ";foreign keys=true;"))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {

                    String sql = "SELECT a.nOrder " +
                        "FROM " + tblTemplate + " a " +
                        "INNER JOIN " +  relTemplateGroupTemplate + " b on b.nTemplateID = a.nTemplateID " +
                        "WHERE b.nTemplateGroupID = @intTemplateGroupID " +
                        "order by a.nOrder desc limit 1";
                    
                    cmd.CommandText = sql;

                    // cmd.Parameters.AddWithValue("@strNewTemplate", strNewTemplate);
                    cmd.Parameters.AddWithValue("@intTemplateGroupID", intTemplateGroupID);

                    cmd.Connection = conn;



                    try
                    {
                        conn.Open();
                        //Debug.WriteLine("getTemplateGroupCount: " + cmd.CommandText);

                        var result = cmd.ExecuteReader();
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                //Debug.WriteLine("getTemplateGroupCount: " + result[0].ToString());

                                iOrder = Convert.ToInt32(result[0].ToString());

                            }


                        }

                        conn.Close();
                        return iOrder;
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        //Debug.WriteLine("getTemplateGroupHighestOrder: " + ex.ToString());

                        setGeneralErrorMessage("getTemplateGroupHighestOrder: " + ex.ToString());
                        throw ex;
                    }

                    
                }
            }
        }

        private byte getTemplateCountInGroup(int intTemplateGroupID)
        {
            //int intCurrentGroupIndex = ddTemplateGroup.SelectedIndex;

            //int intTemplateGroupID = lstTemplateGrp[intCurrentGroupIndex].nTemplateGroupID;

            byte bCount = 0;

            using (SqliteConnection conn = new SqliteConnection("data source=" + parentdir + dbName + ";foreign keys=true;"))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {
                    //String strNewTemplate = txtBAddTemplate.Text;

                    
                    String sql = "SELECT count(*) from " +relTemplateGroupTemplate+ " where nTemplateGroupID = @intTemplateGroupID";
                    cmd.CommandText = sql;

                   // cmd.Parameters.AddWithValue("@strNewTemplate", strNewTemplate);
                    cmd.Parameters.AddWithValue("@intTemplateGroupID", intTemplateGroupID);

                    cmd.Connection = conn;



                    try
                    {
                        conn.Open();
                        //Debug.WriteLine("getTemplateGroupCount: " + cmd.CommandText);

                        var result = cmd.ExecuteReader();
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                //Debug.WriteLine("getTemplateGroupCount: " + result[0].ToString());

                                bCount = Convert.ToByte(result[0].ToString());

                            }


                        }

                        conn.Close();
                        return bCount;
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        //Debug.WriteLine("getTemplateCountInGroup: " + ex.ToString());

                        setGeneralErrorMessage("getTemplateCountInGroup: " + ex.ToString());
                        throw ex;
                    }

                    
                }
            }
        }

        private int getHighestOrder()
        {
            int iHigh = 0;

            foreach (KeyValuePair<int, TemplateInfo> entry in dctTempInfo)
            {
                if (entry.Value.nOrder > iHigh)
                {
                    iHigh = entry.Value.nOrder;
                }
            }
            return iHigh;
        }

        private void addTemplate()
        {
            using (SqliteConnection conn = new SqliteConnection("data source=" + parentdir + dbName + ";foreign keys=true;"))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {
                    String strNewTemplate = txtBAddTemplate.Text;


                    int nOrder = getHighestOrder() + 1;

                   

                    // Add template and 10 rels for its buttons
                    String sql = "INSERT INTO " + tblTemplate + " (strTemplateName, strNotes, nNotesHeight, nOrder) VALUES (@strNewTemplate,'',111, @nOrder);" +
                        "INSERT INTO " + tblButtonAttribute + " (lngButtonID, strHotkeyLabel) VALUES " +
                        "(1, 'Q')," +
                        "(2, 'W')," +
                        "(3, 'E')," +
                        "(4, 'R')," +
                        "(5, 'A')," +
                        "(6, 'S')," +
                        "(7, 'D')," +
                        "(8, 'F')," +
                        "(9, 'Z')," +
                        "(10, 'X')," +
                        "(11, 'V')";
                    cmd.CommandText = sql;

                    cmd.Parameters.AddWithValue("@strNewTemplate", strNewTemplate);
                    cmd.Parameters.AddWithValue("@nOrder", nOrder);

                    cmd.Connection = conn;



                    try
                    {
                        conn.Open();
                        
                        var result = cmd.ExecuteNonQuery();
                        
                        if (result != 12) // rows affected
                        {
                            Debug.WriteLine("addTemplate: Insert anomoly return " + result.ToString());
                            

                            
                        } else
                        {
                            // link the new Template to the currently selected group
                            conn.Close();
                            int nTemplateID = getNewlyAddedTemplateID();
                            //setGeneralErrorMessage(nTemplateID.ToString());
                            addTemplateToGroup(nTemplateID);

                            // link the new Template to the 11 New Buttons
                            addButtonsToTemplate(nTemplateID);
                        }
                        

                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        //Debug.WriteLine("addTemplate: " + ex.ToString());

                        setGeneralErrorMessage("addTemplate: " + ex.ToString());
                        throw ex;
                    }

                    conn.Close();
                }
            }
        }

        private void addButtonsToTemplate(int nTemplateID)
        {
            using (SqliteConnection conn = new SqliteConnection("data source=" + parentdir + dbName + ";foreign keys=true;"))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {
                    int[] iBtnRecID = new int[11];
                    int iCount = 0;

                    // Get the Button RecIDs
                    String sql = "SELECT a.nRecID from " +tblButtonAttribute+ " a " +
                        "where a.nRecID NOT IN (SELECT nRecID FROM " +relTemplateButtonAttribute+ ") order by a.nRecID asc";
                    cmd.CommandText = sql;


                    cmd.Connection = conn;



                    try
                    {
                        conn.Open();

                        var result = cmd.ExecuteReader();
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                //Debug.Write("iCount: " + iCount.ToString() + "\n");
                                iBtnRecID[iCount] = result.GetInt16(0);

                                iCount += 1;


                            }


                        }
                        



                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        //Debug.WriteLine("addButtonsToTemplate: " + ex.ToString());

                        setGeneralErrorMessage("addButtonsToTemplate1: " + ex.ToString());
                        throw ex;
                    }

                    conn.Close();

                    // Assign all the button nRecIDs in the relTemplateButtonAttribute to the template it should belong to

                    // Get the Button RecIDs
                    sql = "INSERT INTO " + relTemplateButtonAttribute + " (nTemplateID, nButtonRecID) " +
                        "VALUES " +
                        "(@nTemplateID, @btn1)," +
                        "(@nTemplateID, @btn2)," +
                        "(@nTemplateID, @btn3)," +
                        "(@nTemplateID, @btn4)," +
                        "(@nTemplateID, @btn5)," +
                        "(@nTemplateID, @btn6)," +
                        "(@nTemplateID, @btn7)," +
                        "(@nTemplateID, @btn8)," +
                        "(@nTemplateID, @btn9)," +
                        "(@nTemplateID, @btn10)," +
                        "(@nTemplateID, @btn11)" +
                        "";
                    cmd.CommandText = sql;

                    cmd.Parameters.AddWithValue("@nTemplateID", nTemplateID);

                    cmd.Parameters.AddWithValue("@btn1", iBtnRecID[0]);
                    cmd.Parameters.AddWithValue("@btn2", iBtnRecID[1]);
                    cmd.Parameters.AddWithValue("@btn3", iBtnRecID[2]);
                    cmd.Parameters.AddWithValue("@btn4", iBtnRecID[3]);
                    cmd.Parameters.AddWithValue("@btn5", iBtnRecID[4]);
                    cmd.Parameters.AddWithValue("@btn6", iBtnRecID[5]);
                    cmd.Parameters.AddWithValue("@btn7", iBtnRecID[6]);
                    cmd.Parameters.AddWithValue("@btn8", iBtnRecID[7]);
                    cmd.Parameters.AddWithValue("@btn9", iBtnRecID[8]);
                    cmd.Parameters.AddWithValue("@btn10", iBtnRecID[9]);
                    cmd.Parameters.AddWithValue("@btn11", iBtnRecID[10]);


                    cmd.Connection = conn;




                    try
                    {

                        conn.Open();

                        var result = cmd.ExecuteNonQuery();
                        if (result != 11)
                        {
                            Debug.WriteLine("addTemplateToGroup: Insert anomoly return: " + result.ToString());
                        }
                        // else // success
                        



                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        //Debug.WriteLine("addButtonsToTemplate2: " + ex.ToString());

                        setGeneralErrorMessage("addButtonsToTemplate2: " + ex.ToString());
                        throw ex;
                    }

                    conn.Close();
                }
            }
        }

        private int getNewlyAddedTemplateID()
        {
            using (SqliteConnection conn = new SqliteConnection("data source=" + parentdir + dbName + ";foreign keys=true;"))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {

                    // Update current group's name
                    String sql = "Select nTemplateID from " + tblTemplate + " order by nTemplateID desc LIMIT 1";
                    cmd.CommandText = sql;

                    cmd.Connection = conn;



                    try
                    {
                        conn.Open();

                        var result = cmd.ExecuteReader();
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                
                                return result.GetInt16(0);

                            }
                            

                        } else
                        {
                            return -1;
                        }
                        

                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        //Debug.WriteLine("getNewlyAddedTemplateID: " + ex.ToString());

                        setGeneralErrorMessage("getNewlyAddedTemplateID: " + ex.ToString());
                        throw ex;
                    }

                    
                    conn.Close();
                    return -1;
                }
            }
        }

        private void addTemplateToGroup(int nTemplateID)
        {
            using (SqliteConnection conn = new SqliteConnection("data source=" + parentdir + dbName + ";foreign keys=true;"))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {
                    int intCurrentGroupIndex = ddTemplateGroup.SelectedIndex;

                    int intTemplateGroupID = lstTemplateGrp[intCurrentGroupIndex].nTemplateGroupID;

                    // Update current group's name
                    String sql = "INSERT INTO " + relTemplateGroupTemplate + " (nTemplateGroupID, nTemplateID) VALUES (@intTemplateGroupID, @nTemplateID)";
                    cmd.CommandText = sql;

                    cmd.Parameters.AddWithValue("@intTemplateGroupID", intTemplateGroupID);
                    cmd.Parameters.AddWithValue("@nTemplateID", nTemplateID);

                    cmd.Connection = conn;



                    try
                    {
                        conn.Open();

                        var result = cmd.ExecuteNonQuery();
                        if(result != 1)
                        {
                            Debug.WriteLine("addTemplateToGroup: Insert anomoly return: " + result.ToString());
                        }
                        

                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        //Debug.WriteLine("addTemplateToGroup: " + ex.ToString());

                        setGeneralErrorMessage("addTemplateToGroup: " + ex.ToString());
                        throw ex;
                    }

                    conn.Close();
                }
            }

            
        }

        

        private void updateTemplateGroupName()
        {
            using (SqliteConnection conn = new SqliteConnection("data source=" + parentdir + dbName + ";foreign keys=true;"))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {
                    String strRenameTemplateGrp = txtBRenameGrp.Text;
                    int intCurrentGroupIndex = ddTemplateGroup.SelectedIndex;

                    int intTemplateGroupID = lstTemplateGrp[intCurrentGroupIndex].nTemplateGroupID;


                    Debug.WriteLine("updateTemplateGroupName: " + intCurrentGroupIndex);
                    Debug.WriteLine("updateTemplateGroupName: " + intTemplateGroupID);
                    // Update current group's name
                    String sql = "Update "+ tblTemplateGroup + " SET strTemplateGroupName = @strRenameTemplateGrp where nTemplateGroupID = @intTemplateGroupID";
                    cmd.CommandText = sql;

                    cmd.Parameters.AddWithValue("@strRenameTemplateGrp", strRenameTemplateGrp);
                    cmd.Parameters.AddWithValue("@intTemplateGroupID", intTemplateGroupID);

                    cmd.Connection = conn;



                    try
                    {
                        conn.Open();

                        var result = cmd.ExecuteNonQuery();
                        if(result != 1)
                        {
                            Debug.WriteLine("updateTemplateGroupName: Update anomoly return " + result.ToString());
                        } 

                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        //Debug.WriteLine("updateTemplateGroupName: " + ex.ToString());

                        setGeneralErrorMessage("updateTemplateGroupName: " + ex.ToString());
                        throw ex;
                    }

                    conn.Close();
                }
            }
        }



        private void setGeneralErrorMessage(string strMsg)
        {
            frmGeneralError = new GeneralError();
            frmGeneralError.Visible = true;
            frmGeneralError.setErrorMessage(strMsg);
            

            
        }

        private byte getTemplateGroupCount()
        {
            using (SqliteConnection conn = new SqliteConnection("data source=" + parentdir + dbName + ";foreign keys=true;"))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {
                    byte bCount = 0;
                    

                    // insert default general template group
                    String sql = "SELECT count (*) as 'cnt' from " + tblTemplateGroup; // ok since string not from an input
                    cmd.CommandText = sql;



                    cmd.Connection = conn;

                    

                    try
                    {
                        conn.Open();
                        //Debug.WriteLine("getTemplateGroupCount: " + cmd.CommandText);

                        var result = cmd.ExecuteReader();
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                //Debug.WriteLine("getTemplateGroupCount: " + result[0].ToString());

                                bCount = Convert.ToByte(result[0].ToString());

                            }
                            

                        }

                        conn.Close();
                        return bCount;
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        //Debug.WriteLine("getTemplateGroupCount: " + ex.ToString());

                        setGeneralErrorMessage("getTemplateGroupCount: " + ex.ToString());
                        throw ex;
                    }

                    
                }
            }
        }

        private void addTemplateGroup()
        {
            

            using (SqliteConnection conn = new SqliteConnection("data source=" + parentdir + dbName + ";foreign keys=true;"))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {
                    String strNewTemplateGrp = txtBTemplateGrp.Text;
                    Byte bCount = getTemplateGroupCount();

                    // insert default general template group
                    String sql = "INSERT INTO " + tblTemplateGroup + " (strTemplateGroupName, nOrder) values (@strNewTemplateGrp, @nOrder);";
                    cmd.CommandText = sql;

                    cmd.Parameters.AddWithValue("@strNewTemplateGrp", strNewTemplateGrp);
                    cmd.Parameters.AddWithValue("@nOrder", bCount + 1);

                    cmd.Connection = conn;

                    

                    try
                    {
                        conn.Open();

                        var result = cmd.ExecuteNonQuery();
                        if(result != 1)
                        {
                            //Debug.WriteLine("addTemplateGroup: Insert anomoly return " + result.ToString());
                            setGeneralErrorMessage("addTemplateGroup: Insert anomoly return " + result.ToString());
                        } 

                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        //Debug.WriteLine("addTemplateGroup: " + ex.ToString());

                        setGeneralErrorMessage("addTemplateGroup: " + ex.ToString());
                        throw ex;
                    }

                    conn.Close();
                }
            }
        }

        private void loadTemplateList()
        {

            
            // Dump all previous items
            ddTemplate.Items.Clear();
           // ddTemplate.Visible = false; // dont need a drop down for Templates

            // remove all elements
            //lstTemplate.Clear();
            dctTempInfo.Clear();

            TemplateInfo templateElem;


            using (SqliteConnection conn = new SqliteConnection("data source=" + parentdir + dbName + ";foreign keys=true;"))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {

                    // get current group nTemplateGroupID
                    int nTemplateGroupID = getCurrTemplateGroupID();

                    //Debug.WriteLine("1. " + strTargetTable);
                    String sql = "SELECT c.* from " + tblTemplateGroup + " a inner join " + relTemplateGroupTemplate + " b on b.nTemplateGroupID = a.nTemplateGroupID inner join " + tblTemplate + " c on c.nTemplateID = b.nTemplateID " +
                        "where b.nTemplateGroupID = @nTemplateGroupID order by c.nOrder asc";

                    cmd.CommandText = sql;

                    cmd.Parameters.AddWithValue("@nTemplateGroupID", nTemplateGroupID);

                    cmd.Connection = conn;


                    //Debug.WriteLine("loadTemplateGroups: " + cmd.CommandText);


                    //,'tblTemplate','relTemplateGroupTemplate','tblButtonAttribute','relTemplateButtonAttribute'

                    try
                    {

                        conn.Open();

                        var result = cmd.ExecuteReader();

                        if (result.HasRows)
                        {


                            // if table does exist, extract rows
                            while (result.Read())
                            {
                                //Console.WriteLine("\t{0}{1}", result.GetString(1), result.GetInt32(1));

                                templateElem = new TemplateInfo();
                                templateElem.nTemplateID = result.GetByte(0);
                                templateElem.strTemplateName = result.GetString(1);
                                templateElem.strNotes = result.GetString(2);
                                templateElem.nNotesHeight = result.GetInt32(3);
                                templateElem.nOrder = result.GetByte(4);

                                templateElem.strTemplateMsg = "";

                                dctTempInfo.Add(templateElem.nTemplateID, templateElem);

                                // add buttons to dictionary
                                getButtonsToTemplate(templateElem);

                                //lstTemplate.Add(templateElem); // keeps nTemplateID so that it can be updated accurately

                                //ddTemplate.Items.Add(result.GetString(1));

                            }




                            //ddTemplate.SelectedIndex = 0;

                        }
                        else
                        {
                            // if table does not exist
                            result.Close();

                        }





                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        //Debug.WriteLine("loadTemplateList: " + ex.ToString());

                        setGeneralErrorMessage("loadTemplateList: " + ex.ToString());
                        throw ex;
                    }


                    // debug show templates that belong to the group in ddTemplate



                    /*
                        foreach (TemplateInfo e in lstTemplate)
                    {
                        ddTemplate.Items.Add(e.nTemplateID + " : " + e.strTemplateName);
                    }
                    */

                    foreach (KeyValuePair<int, TemplateInfo> entry in dctTempInfo)
                    {
                        // do something with entry.Value or entry.Key

                        ddTemplate.Items.Add(entry.Value.nTemplateID + " : " + entry.Value.strTemplateName + ". " + entry.Value.nOrder);
                    }

                    //ddTemplate.Visible = true;




                    conn.Close();

                }
            }
        }

        private void getButtonsToTemplate(TemplateInfo templateElem)
        {
            // 
            /*  Get all buttons associated with the template
             *  Save the button attribute in the ButtonAttribute object
             *  Add the object to the btnAttr dictionary
             * Finally, add the dictionary to the Template info object. Key = nTemplateID
             * 
             * In private void reloadTemplateLayouts()
             * extract each button from the dictionary and set into the TemplateModule panel.
             */
            using (SqliteConnection conn = new SqliteConnection("data source=" + parentdir + dbName + ";foreign keys=true;"))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {

                    //Debug.WriteLine("1. " + strTargetTable);
                    String sql = "SELECT b.* from " + relTemplateButtonAttribute + " a " +
                        "INNER JOIN " + tblButtonAttribute + " b on b.nRecID = a.nButtonRecID " +
                        "WHERE a.nTemplateID = @nTemplateID " +
                        "order by a.nRecID asc";
                    cmd.CommandText = sql;

                    cmd.Parameters.AddWithValue("@nTemplateID", templateElem.nTemplateID);

                    cmd.Connection = conn;

                    conn.Open();


                    try
                    {
                        conn.Open();

                        var result = cmd.ExecuteReader();

                        if (result.HasRows)
                        {
                            Dictionary<int, ButtonAttribute> dctButtonAttribute = new Dictionary<int, ButtonAttribute>();
                            // if table does exist, extract rows. Button attributes in to ButtonAttribute object
                            while (result.Read())
                            {

                                ButtonAttribute btnAtr = new ButtonAttribute();
                                btnAtr.nRecID = result.GetInt16(0);
                                btnAtr.lngButtonID = result.GetInt16(1);
                                btnAtr.strHotKeyLabel = result.GetString(2);
                                btnAtr.strHotKeyDesc = result.GetString(3);
                                btnAtr.nDescHeight = result.GetInt16(4);
                                btnAtr.nColorR = result.GetInt16(5);
                                btnAtr.nColorG = result.GetInt16(6);
                                btnAtr.nColorB = result.GetInt16(7);


                                // store into ButtonAttribute Dict
                                dctButtonAttribute.Add(btnAtr.nRecID, btnAtr);



                            }

                            // finally store the button attribute dict into TemplateInfo
                            templateElem.dctButtonAttribute = dctButtonAttribute;

                        }
                        else
                        {
                            // if table does not exist
                            //Debug.WriteLine("getButtonsToTemplate: Else" );
                            //Debug.WriteLine("getButtonsToTemplate: " + sql + " , " + templateElem.nTemplateID.ToString());
                            setGeneralErrorMessage("getButtonsToTemplate: " + sql + " , " + templateElem.nTemplateID.ToString());

                            result.Close();

                        }




                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        //Debug.WriteLine("getButtonsToTemplate: " + ex.ToString());

                        setGeneralErrorMessage("getButtonsToTemplate: " + ex.ToString());
                        throw ex;
                    }

                    conn.Close();
                }
            }

        }


        private void loadTemplateGroups(int intSelectedIndex)
        {

            // Dump all previous items
            ddTemplateGroup.Items.Clear();

            // remove all elements
            lstTemplateGrp.Clear();

            TemplateGroupInfo templateGrpElem;


            using (SqliteConnection conn = new SqliteConnection("data source=" + parentdir + dbName + ";foreign keys=true;"))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {

                    // @tblTemplateGroup
                    //Debug.WriteLine("1. " + strTargetTable);
                    String sql = "SELECT * from "+ tblTemplateGroup + " order by nOrder asc";
                    cmd.CommandText = sql;

                    cmd.Connection = conn;


                    //Debug.WriteLine("**************loadTemplateGroups: " + cmd.CommandText);
                    //,'tblTemplate','relTemplateGroupTemplate','tblButtonAttribute','relTemplateButtonAttribute'

                    try
                    {
                        conn.Open();
                        
                        var result = cmd.ExecuteReader();
                       
                        if (result.HasRows)
                        {
                           
                            // if table does exist, extract rows
                            while (result.Read())
                            {
                                //Console.WriteLine("\t{0}{1}", result.GetString(1), result.GetInt32(1));
                                
                                templateGrpElem = new TemplateGroupInfo();
                                templateGrpElem.nTemplateGroupID = result.GetByte(0);
                                templateGrpElem.strTemplateGroupName = result.GetString(1);

                                
                                lstTemplateGrp.Add(templateGrpElem); // keeps nTemplateGroupID so that it can be updated accurately

                                ddTemplateGroup.Items.Add(result.GetString(1));



                            }

                            if (ddTemplateGroup.Items.Count > 0)
                            {
                                if (intSelectedIndex == -1)
                                {
                                    ddTemplateGroup.SelectedIndex = ddTemplateGroup.Items.Count - 1; // default to the last template group
                                } else
                                {
                                    ddTemplateGroup.SelectedIndex = intSelectedIndex;
                                }
                                
                               
                            }
                            



                        }
                        else
                        {
                            
                            // if table does not exist
                            result.Close();

                        }
                        

                        

                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        //Debug.WriteLine("loadTemplateGroups: " + ex.ToString());

                        setGeneralErrorMessage("loadTemplateGroups: " + ex.ToString());
                        throw ex;
                    }

                    conn.Close();                   
                }
            }

        }

        private void MainTemplate_Load(object sender, EventArgs e)
        {
            //
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            int intCurrentGroupIndex = ddTemplateGroup.SelectedIndex;

            string strTemplateGrpName = lstTemplateGrp[intCurrentGroupIndex].strTemplateGroupName;

            string strMessage = "Are you sure you want to delete template group: " + strTemplateGrpName + "." +
                System.Environment.NewLine +
                "It will delete all associated templates with the group.";

            string strHeader = "Template Group Deletion Confirmation";

            if (Application.OpenForms.OfType<Confirmation>().Count() == 1)
                Application.OpenForms.OfType<Confirmation>().First().Close();

            Point ptMouse = new Point(MousePosition.X, MousePosition.Y);
            Form frmConfirmation = new Confirmation(this, strMessage, strHeader, ptMouse);


            frmConfirmation.Show();
        }

        private void btnDump_Click(object sender, EventArgs e)
        {
            String strExportFileName = frmStartUp.dumpTemplateInformation(); // for all tables with joins
            //String strExportFileName = frmStartUp.dumpAllTableInformation(); // if table missing, dump all info. No joins

            txtFileDir.Text = "Template information exported to: " + strExportFileName;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<HelpForm>().Count() == 1)
                Application.OpenForms.OfType<HelpForm>().First().Close();

            Point ptMouse = new Point(MousePosition.X, MousePosition.Y);
            Form frmHelp = new HelpForm(ptMouse);


            frmHelp.Show();
        }
    }
}
