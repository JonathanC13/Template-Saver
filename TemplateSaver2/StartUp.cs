using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using System.Diagnostics;
using System.IO;
using System.Threading;



/*
 * TODO. 
 * 1.Add button for template groups > done
 *  1.1. Adding > done
 *  1.2. Blank name > done
 *  1.3. Length Check > done
 *  
 * 2. Rename Group
 *  2.1 Rename correct template grp >> Done
 *  2.2. Not blank >> Done
 *  2.3. Check Length  >> DOne
 *  2.4. Delete group -- *********do after Finished adding Templates to groups, button customizations to templates. 
 * 
 * Template
 * 3. Add Template. 
 *  3.1. Blank name > done
 *  3.2. Length check > done
 *  3.3. Assigns to currently selected group > done
 *  3.4. Set static header
 *  3.5. Set scrollable portion where bottom is always at bottom of the page
 *  3.6. On every template creation, reload page and build all template layouts that belong to the group. ie reloadTemplateLayouts.
 *      3.6.1. Add template, layout must reload with the other templates of that group and the new one at the end
 *  3.7. Delete Template -- ********** do after finished adding button customizations
 *      
 *  
 * Template drop down
 *  4. When group selected load all template associated with that group - need object to hold current templates for later > done
 *  5. When group selected build Templates in order ** ie reloadTemplateLayouts ** 3.6 > done
 *  
 *  DOC CHANGES *******************
 *  
 *  
 *  /DOC CHANGES *******************
 *  
 *  
 * 6. Button customizations
 *  6.1. When a template button is clicked, open a new form to show the button customization options > done
 *      6.1.1. Ensure the button customization is associated with the correct template and button > done
 *  6.2. When saved, it saves the customizations into the TemplateInfo object for that template. > then reload the info for that template only  > done
 *      > Message appears at the top of the template instructing the user if they desire the changes to be permanent then they must click save at the bottom of the template > done
 *  
 *  
 * 7. Saving Template
 * 
 * 
 * 
 * 
 * WHEN template sub component changed, like Template name, need it to update in the panel. ** OK
 * Now on Save in Button customization, call a function to update the elements within that TemplateModule 
 *  Button customization, with the button name, we can determine which button attribute to modify. 1 to 11
 *  1. On ButtomCustomization 'save' edit the correct Button Content Control *OK
 *  2. Go back and on template creation, auto create Button Customization Rels and save rows. *OK
 *  3. Change TemplateInfo class to hold DICTIONARY of ButtonAttribute classes *ok
 *  4. On 'Save' Click on TemplateModule save to TemplateInfo Object *OK
 *  5. Print only that template and button attributes to prove that we can update that template only. *OK
 *  5.1. Fix color wheel and update color RGB values in ButtonAttribute for the button *OK
 *  5.2. only 5 lines for button, so about 70 chars, limit it OK. On save stop user if more than 5 lines. *OK
 *  6 When #5 is correctly only getting the information from the specified Template, 
 *  6.1 Write process to discard changes *OK
 *  6.2 Write process to update only that Template's attributes in DB ** OK
 *      // if strOrderChanged = 'Y' then update all templates' order ** OK

        // then reload all templates in the group in new order ** OK
 * 
 * 6.3. Discard changes, reload elements for that template from DB ** OK
 * 6.4. Delete template * OK
 * 6.5. Increase and decrease notes size * OK
 * 6.6. Transfer group **OK
 * 6.7 Template deletion confirmation pop up ** OK
 * 7. Delete group > confirmation pop up ** OK
 * 8. On failure of verifing database, have option to print all of DB raw data for manual inspection or to review and can add back on new instance of application ** OK
 * 9. Adjust Design doc, to include/exculde features modified during development > done
 *  10. Set up Git for Visual studio ** HERE
 *  11. Button for Help to open documentation to direct the user how to use the application ** TODO
 */

namespace TemplateSaver2
{
    public partial class StartUp : Form
    {
        private string strExportFileName;
        private bool mGrowing;
        private bool boolFormVisible;
        private string parentdir = Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath);
        private string dbName = "/TemplateDb.db";

        // project tables
        private string[] arrProjTables = { "relTemplateButtonAttribute", "relTemplateGroupTemplate", "tblTemplateGroup", "tblTemplate", "tblButtonAttribute", };

        private string[] arrProjTablesDumpOrder = { "tblTemplateGroup", "relTemplateGroupTemplate", "tblTemplate", "relTemplateButtonAttribute", "tblButtonAttribute", };

        public StartUp()
        {
            

            InitializeComponent();
            boolFormVisible = true;

            lblStartStatus.BorderStyle = BorderStyle.None;

            verifyTablesProcess();

            

            //var parentdir = Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath);

            //lblStartStatus.Text = parentdir;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            this.Visible = boolFormVisible;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Resize text box

        private void lblStartStatus_TextChanged(object sender, EventArgs e)
        {
            
            
            base.OnTextChanged(e);
            resizeLabel();


            
        }
        
        private void resizeLabel()
        {
            if (mGrowing) return;
            try
            {

                mGrowing = true;
                Size sz = new Size(lblStartStatus.Width, Int32.MaxValue);
                sz = TextRenderer.MeasureText(lblStartStatus.Text, lblStartStatus.Font, sz, TextFormatFlags.WordBreak);
                lblStartStatus.Height = sz.Height;

                

            }
            finally
            {
                mGrowing = false;
            }
        }
        
        // /Resize text box


        private void btnFactoryRst_Click(object sender, EventArgs e)
        {
            factoryResetTables(arrProjTables);
            
        }

        private Boolean verifyTables(Array arrPrjTables)
        {
            
            // check if all tables exists
            foreach (string element in arrPrjTables)
            {
                
                if (!verifyTablesSQL(element)){
                    return false;
                }
            }
            return true;
        }

        private void verifyTablesProcess()
        {

            // Initial text
            lblStartStatus.Text = "Verifying database";

            // Verify all required project tables
            if (!verifyTables(arrProjTables))
            {
                boolFormVisible = true;
                // failed, a table does not exist
                lblStartStatus.Text = "Error: Database malformed, factory reset is the only option to rebuild the database tables from scratch. You may use Template export to dump all existing tables' contents to a text file. Sorry for the inconvenience.";
                btnClose.Visible = true;
                btnFactoryRst.Visible = true;
                btnDump.Visible = true;
            }
            else
            {
                // open Main template window and close this one

                


                lblStartStatus.Text = "Verified";


                Form MainTemplate = new MainTemplate(this);
                MainTemplate.Show();

                //Debug.WriteLine("1: " + boolFormVisible);
                // Hide for now, do not know how to correct dispose error
                // MainTempalte on close will also close this hidden form
                boolFormVisible = false;
                this.Visible = false;
                //Debug.WriteLine("1: " + boolFormVisible);
                //Debug.WriteLine("1: " + this.Visible);


                // create new thread for Form so that closing the StartUp form does not close both.
                /*
                var th = new Thread(() => Application.Run(new MainTemplate()));
                th.SetApartmentState(ApartmentState.STA); // Deprecation Fix
                th.Start();
                */


            }
        }


        private Boolean verifyTablesSQL(string strTargetTable)
        {
            //var parentdir = Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath);

            using (SqliteConnection conn = new SqliteConnection("data source=" + parentdir + dbName + ";foreign keys=true;"))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {

                    //Debug.WriteLine("1. " + strTargetTable);

                    //cmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name ='" + strTargetTable + "';";
                    cmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name =@strTargetTable;";
                    cmd.Parameters.AddWithValue("@strTargetTable", strTargetTable);
                    cmd.Connection = conn;


                    //,'tblTemplate','relTemplateGroupTemplate','tblButtonAttribute','relTemplateButtonAttribute'

                    try
                    {
                        conn.Open();



                        var result = cmd.ExecuteReader();

                        if (result.HasRows)
                        {
                            // if table does exist
                            result.Close();
                            conn.Close();
                            return true;

                        }
                        else
                        {
                            // if table does not exist
                            result.Close();
                            conn.Close();
                            return false;
                        }

                        


                    }
                    catch (Exception ex)
                    {
                        
                        conn.Close();
                        Debug.WriteLine("verifyTablesSQL: " + ex.ToString());
                        throw ex;
                    }

                    

                }
            }
        }




        private void factoryResetTables(Array arrPrjTables)
        {

            // drop all tables

            foreach (string element in arrPrjTables)
            {
                dropAllExistingTables(element);
            }
            // /drop all tables

            // Newly create tables
            freshCreateTables();
            // /Newly create tables

            // recheck tables
            verifyTablesProcess();
            // /recheck tables

        }
        private void dropAllExistingTables(string strTargetTable)
        {
           
            //var parentdir = Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath);

            using (SqliteConnection conn = new SqliteConnection("data source="+ parentdir + dbName + ";foreign keys=true;"))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {

                    //Debug.WriteLine("1. " + strTargetTable);

                    //cmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name ='" + strTargetTable + "';";
                    cmd.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name =@strTargetTable;";
                    cmd.Parameters.AddWithValue("@strTargetTable", strTargetTable);

                    cmd.Connection = conn;

                    
                    //,'tblTemplate','relTemplateGroupTemplate','tblButtonAttribute','relTemplateButtonAttribute'

                    try
                    {
                        conn.Open();

 

                        var result = cmd.ExecuteReader();

                        if (result.HasRows)
                        {
                            result.Close();
                            
                            // drop table
                            string strDropTable = "Drop table " + strTargetTable +";";
                            //Debug.WriteLine("2. " + strDropTable);
                            cmd.CommandText = strDropTable;
                            cmd.ExecuteNonQuery();

                        }
                        else
                        {
                            result.Close();

                        }

                        result.Close();

                       
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("dropAllExistingTables: " + ex.ToString());
                        throw ex;
                    }

                    conn.Close();
                    
                }
            }
        }

        private void freshCreateTables()
        {
            //var parentdir = Path.GetDirectoryName(System.Windows.Forms.Application.StartupPath);


            using (SqliteConnection conn = new SqliteConnection("data source=" + parentdir + dbName + ";foreign keys=true;"))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {
                    // Create tblTemplateGroup
                    string strSql = "CREATE TABLE[tblTemplateGroup](" +
                                    " [nTemplateGroupID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL" +
                                    ", [strTemplateGroupName] text NOT NULL" +
                                    ", [nOrder] INTEGER NOT NULL" +
                                    ");";


                    // Create tblTemplate
                    strSql = strSql + "CREATE TABLE [tblTemplate] (" +
                                      "[nTemplateID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL" +
                                        ", [strTemplateName] text NOT NULL" +
                                        ", [strNotes] text NOT NULL" +
                                        ", [nNotesHeight] INTEGER NOT NULL" +
                                        ", [nOrder] INTEGER NOT NULL" +
                                        "); ";

                    // Create relTemplateGroupTemplate
                    strSql = strSql + "CREATE TABLE [relTemplateGroupTemplate] (" +
                                        "  [nRecID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL" +
                                        ", [nTemplateGroupID] INTEGER NOT NULL" +
                                        ", [nTemplateID] INTEGER NOT NULL" +
                                        ", CONSTRAINT FK_nTemplateGroupID FOREIGN KEY(nTemplateGroupID) REFERENCES tblTemplateGroup(nTemplateGroupID)" +
                                        ", CONSTRAINT FK_nTemplateID FOREIGN KEY(nTemplateID) REFERENCES tblTemplate(nTemplateID)" +
                                        "); ";

                    // insert default general template group
                    strSql = strSql + "insert into tblTemplateGroup (strTemplateGroupName,nOrder) Values ('General','1');";

                    // Create tblButtonAttribute 
                    strSql = strSql + "CREATE TABLE[tblButtonAttribute](" +
                                        "[nRecID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL" +
                                        ", [lngButtonID] INTEGER NOT NULL" +
                                        ", [strHotKeyLabel] TEXT DEFAULT ''" +
                                        ", [strHotKeyDesc] TEXT DEFAULT ''" +
                                        ", [nDescHeight] INTEGER DEFAULT -1" +
                                        ", [nColorR] INTEGER DEFAULT -1" +
                                        ", [nColorG] INTEGER DEFAULT -1" +
                                        ", [nColorB] INTEGER DEFAULT -1" +
                                        "); ";

                    // Create relTemplateButtonAttribute
                    
                    strSql = strSql + "CREATE TABLE [relTemplateButtonAttribute] (" +
                                        "  [nRecID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL" +
                                        ", [nTemplateID] INTEGER NOT NULL" +
                                        ", [nButtonRecID] INTEGER NOT NULL" +
                                        ", CONSTRAINT FK_nTemplateID FOREIGN KEY(nTemplateID) REFERENCES tblTemplate(nTemplateID)" +
                                        ", CONSTRAINT FK_nButtonRecID FOREIGN KEY(nButtonRecID) REFERENCES tblButtonAttribute(nRecID)" +
                                        "); ";
                    

                    // test insert bad foreign key
                    //strSql = strSql + "insert into relTemplateGroupTemplate (nTemplateGroupID,nTemplateID) Values (4,5);"; // thrown 'FOREIGN KEY constraint failed'.' GOOD

                    cmd.CommandText = strSql;
                    cmd.Connection = conn;

                  
                    try
                    {
                        conn.Open();

                        cmd.ExecuteNonQuery();
                        lblStartStatus.Text = "Created";

                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        Debug.WriteLine("freshCreateTables: " + ex.ToString());
                        throw ex;
                    }

                    conn.Close();
                }
            }
        }

        public String dumpAllTableInformation()
        {
            strExportFileName = "";
            var curDir = Directory.GetCurrentDirectory();
            DateTime dt = new DateTime();
            dt = DateTime.Now;

            String strTemplateGroupName;
            int nOrder;
            String strTemplateName;
            String strNotes;
            int nNotesHeight;
            int nOrder1;
            String strHotKeyLabel;
            String strHotKeyDesc;
            String nDescHeight;
            String nColorR;
            String nColorG;
            String nColorB;

            int nTemplateGroupPrim;
            int nTemplateGroup;
            int nTemplateID;
            int nButtonRecID;
            int nButtonID;

            String strDump;
            strDump = "";

            String strNewFileName;
            strNewFileName = "";


            strNewFileName += dt.Year.ToString() + "_" + dt.Month.ToString() + "_" + dt.Day.ToString() + "_" + dt.Hour.ToString() + "_" + dt.Minute.ToString() + "_" + dt.Second.ToString() + "_TableInfoDump";

            //Debug.WriteLine("1");

            /* Dump Template information to a text file.
             * Format like:
             *  Template group info
             *      Associated Templates info
             *      <br>
             *      
             *      
             * set message in lblStartStatus.Text
             * */
            string table = "";

            using (SqliteConnection conn = new SqliteConnection("data source=" + parentdir + dbName + ";foreign keys=true;"))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {
                    String sql = "";


                    cmd.Connection = conn;
                    int rowCount = 0;
                    //Debug.WriteLine("1. " + strTargetTable);
                    foreach (string element in arrProjTablesDumpOrder)
                    {
                        rowCount = 0;
                        if (verifyTablesSQL(element))
                        {
                            // if table exists, get all the info
                            table = element;
                            sql = "SELECT * FROM " + table + "";

                            //cmd.Parameters.AddWithValue("@element", element);

                            cmd.CommandText = sql;
                            
                            try
                            {

                                conn.Open();

                                var result = cmd.ExecuteReader();

                                

                                if (result.HasRows)
                                {
                                    strDump += "Table: " + element.ToString() + System.Environment.NewLine;
                                    // if table does exist, extract rows
                                    while (result.Read())
                                    {
                                        /*
                                         * { "", "", "", "", "", };
                                         */
                                        switch (element)
                                        {
                                            case "tblTemplateGroup":
                                                if (rowCount == 0)
                                                {
                                                    strDump += "nTemplateGroupID, strTemplateGroupName, nOrder" + System.Environment.NewLine;
                                                }
                                                nTemplateGroupPrim = result.GetInt16(0);
                                                strTemplateGroupName = result.GetString(1);
                                                nOrder = result.GetInt16(2);

                                                strDump += nTemplateGroupPrim.ToString() + ", " + strTemplateGroupName + ", " + nOrder.ToString() + System.Environment.NewLine;
                                                break;

                                            case "relTemplateGroupTemplate":
                                                if (rowCount == 0)
                                                {
                                                    strDump += "nTemplateGroupID, nTemplateID" + System.Environment.NewLine;
                                                }
                                                nTemplateGroup = result.GetInt16(1);
                                                nTemplateID = result.GetInt16(2);

                                                strDump += nTemplateGroup.ToString() + ", " + nTemplateID.ToString() + System.Environment.NewLine;
                                                break;
                                            case "tblTemplate":
                                                if (rowCount == 0)
                                                {
                                                    strDump += "nTemplateID, strTemplateName, strNotes, nNotesHeight, nOrder" + System.Environment.NewLine;
                                                }
                                                nTemplateID = result.GetInt16(0);
                                                strTemplateName = result.GetString(1);
                                                strNotes = result.GetString(2);
                                                nNotesHeight = result.GetInt16(3);
                                                nOrder1 = result.GetInt16(4);

                                                strDump += nTemplateID.ToString() + ", " + strTemplateName + ", " + strNotes + ", " + nNotesHeight.ToString() + ", " + nOrder1.ToString() + System.Environment.NewLine;
                                                break;
                                            case "relTemplateButtonAttribute":
                                                if (rowCount == 0)
                                                {
                                                    strDump += "nTemplateID, nButtonRecID" + System.Environment.NewLine;
                                                }
                                                nTemplateID = result.GetInt16(1);
                                                nButtonRecID = result.GetInt16(2);

                                                strDump += nTemplateID.ToString() + ", " + nButtonRecID.ToString() + System.Environment.NewLine;

                                                break;
                                            case "tblButtonAttribute":
                                                if (rowCount == 0)
                                                {
                                                    strDump += "nRecID, lngButtonID, strHotKeyLabel, strHotKeyDesc, nDescHeight, nColorR, nColorG, nColorB" + System.Environment.NewLine;
                                                }
                                                nButtonRecID = result.GetInt16(0);
                                                nButtonID = result.GetInt16(1);
                                                strHotKeyLabel = result.GetString(2);
                                                strHotKeyDesc = result.GetString(3);
                                                nDescHeight = result.GetInt16(4).ToString();
                                                nColorR = result.GetInt16(5).ToString();
                                                nColorG = result.GetInt16(6).ToString();
                                                nColorB = result.GetInt16(7).ToString();

                                                strDump += nButtonRecID + ", " + nButtonID + ", " + strHotKeyLabel + ", " + strHotKeyDesc + ", " + nDescHeight + ", " + nColorR + ", " + nColorG + ", " + nColorB + System.Environment.NewLine;

                                                break;
                                            default:
                                                strDump += " == Break == ";
                                                break;
                                        }
                                        // update template info

                                        
                                        strDump += "--------------------------------" +  System.Environment.NewLine;
                                                   
                                        rowCount++;
                                    }
                                    

                                }

                                result.Close();
                            }
                            catch (Exception ex)
                            {
                                conn.Close();
                                Debug.WriteLine("dumpAllTableInformation: " + ex);
                                throw ex;
                            }

                            




                        }

                        strDump += "================================" + System.Environment.NewLine;
                    }

                   

                    conn.Close();

                }
            }

            // Debug.WriteLine(strDump);
            //Debug.WriteLine("\n");


            // create new file with date and time. If exists, postfix _X (some number) keep looping until non exist file name
            var path = curDir + "\\" + strNewFileName;


            return writeToFile(strDump, path);
        }

        public String dumpTemplateInformation()
        {
            strExportFileName = "";
            var curDir = Directory.GetCurrentDirectory();
            DateTime dt = new DateTime();
            dt = DateTime.Now;

            String strTemplateGroupName;
            String nOrder;
            String strTemplateName;
            String strNotes;
            String nNotesHeight;
            String nOrder1;
            String strHotKeyLabel;
            String strHotKeyDesc;
            String nDescHeight;
            String nColorR;
            String nColorG;
            String nColorB;

            String strDump;
            strDump = "";

            String strNewFileName;
            strNewFileName = "";


            strNewFileName += dt.Year.ToString() + "_" + dt.Month.ToString() + "_" + dt.Day.ToString() + "_" + dt.Hour.ToString() + "_" + dt.Minute.ToString() + "_" + dt.Second.ToString() + "_TemplateInfoDump";

            //Debug.WriteLine("1");

            /* Dump Template information to a text file.
             * Format like:
             *  Template group info
             *      Associated Templates info
             *      <br>
             *      
             *      
             * set message in lblStartStatus.Text
             * */

            using (SqliteConnection conn = new SqliteConnection("data source=" + parentdir + dbName + ";foreign keys=true;"))
            {
                using (SqliteCommand cmd = new SqliteCommand())
                {

                    //Debug.WriteLine("1. " + strTargetTable);
                    String sql = "SELECT * from tblTemplateGroup a " +
                        "inner join relTemplateGroupTemplate b on b.nTemplateGroupID = a.nTemplateGroupID " +
                        "inner join tblTemplate c on c.nTemplateID = b.nTemplateID " +
                        "inner join relTemplateButtonAttribute d on d.nTemplateID = c.nTemplateID " +
                        "inner join tblButtonAttribute e on e.nRecID = d.nButtonRecID " +
                        "order by a.nOrder asc, c.nOrder asc, e.nRecID asc";

                    cmd.CommandText = sql;

                    //Debug.WriteLine("sql: " + cmd.CommandText);

                    //cmd.Parameters.AddWithValue("@nTemplateID", iTemplate);


                    cmd.Connection = conn;

                    try
                    {

                        conn.Open();

                        var result = cmd.ExecuteReader();

                        if (result.HasRows)
                        {
                            strDump += "strTemplateGroupName, nOrder, strTemplateName, strNotes, nNotesHeight, nOrder1, strHotKeyLabel, strHotKeyDesc, nDescHeight, nColorR, nColorG, nColorB" + System.Environment.NewLine;
                            // if table does exist, extract rows
                            while (result.Read())
                            {
                                //Console.WriteLine("\t{0}{1}", result.GetString(1), result.GetInt32(1));

                                // update template info
                                strTemplateGroupName = result.GetString(1);
                                nOrder = result.GetInt16(2).ToString();
                                strTemplateName = result.GetString(7);
                                strNotes = result.GetString(8);
                                nNotesHeight = result.GetInt16(9).ToString();
                                nOrder1 = result.GetInt16(10).ToString();
                                strHotKeyLabel = result.GetString(16);
                                strHotKeyDesc = result.GetString(17);
                                nDescHeight = result.GetInt16(18).ToString();
                                nColorR = result.GetInt16(19).ToString();
                                nColorG = result.GetInt16(20).ToString();
                                nColorB = result.GetInt16(21).ToString();

                                strDump += strTemplateGroupName + ", " + nOrder + ", " + strTemplateName + ", " + strNotes + ", " + nNotesHeight + ", " + nOrder1 + ", " + strHotKeyLabel + ", " + strHotKeyDesc + ", " + nDescHeight + ", " + nColorR + ", " + nColorG + ", " + nColorB + System.Environment.NewLine;
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
                        Debug.WriteLine("dumpTemplateInformation: " + ex);
                        throw ex;
                    }



                    conn.Close();

                }
            }

           // Debug.WriteLine(strDump);
            //Debug.WriteLine("\n");


            // create new file with date and time. If exists, postfix _X (some number) keep looping until non exist file name
            var path = curDir + "\\" + strNewFileName;


            return writeToFile(strDump, path);
        }

        private String writeToFile(String content, String path)
        {
            if (File.Exists(path))
            {
                //Debug.WriteLine(path + " : exists");
                //Debug.WriteLine("\n");
            }
            else
            {
                //Debug.WriteLine(path + " : not exists");
                //Debug.WriteLine("\n");
                var path_new = path;
                int count = 0;
                while (File.Exists(path_new))
                {
                    path_new = path + "_" + count.ToString();
                    count++;

                }
                path = path_new;
                //Debug.WriteLine(path + " : New");
                //Debug.WriteLine("\n");
            }
            String strExportFileName = path + ".txt";

            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(strExportFileName))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(content);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                // Open the stream and read it back.
                /*
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
                */
            }

            catch (Exception ex)
            {
                Console.WriteLine("writeToFile: " + ex.ToString());
            }

            return strExportFileName;
        }

        private void btnDump_Click(object sender, EventArgs e)
        {
            //dumpTemplateInformation(); // if tables are actually missing, then this work dump properly

            dumpAllTableInformation();

            lblStartStatus.Text = "Template information exported to: " + strExportFileName;
        }









        // example
        //private void verifyTables()
        //{
        //    using (SqliteConnection conn = new SqliteConnection("data source=TemplateDb.db"))
        //    {
        //        using (SqliteCommand cmd = new SqliteCommand())
        //        {
        //            //Debug.WriteLine("CreateTable");
        //            string strTestTable = "'tblTemplateGroup','tblTemplate','relTemplateGroupTemplate','tblButtonAttribute','relTemplateButtonAttribute'";
        //            string strSql = "SELECT name FROM sqlite_master WHERE type='table' AND name IN (" + strTestTable + ");";

        //            cmd.CommandText = strSql;
        //            cmd.Connection = conn;

        //            try
        //            {
        //                conn.Open();


        //                var result = cmd.ExecuteReader();

        //                if (result.HasRows)
        //                {
        //                    result.Close();
        //                    // INSERT statement here
        //                    //Debug.WriteLine("exists");

        //                    lblStartStatus.Text = "Exists";

        //                    /*
        //                    string strSqlIns = "Insert into tblTest (testID) VALUES (1),(2),(3)";
        //                    cmd.CommandText = strSqlIns;
        //                    cmd.ExecuteNonQuery();

        //                    try
        //                    {
        //                        string strSqlChk = "select * from tblTest";
        //                        cmd.CommandText = strSqlChk;
        //                        var resultIns = cmd.ExecuteReader();

        //                        if (!resultIns.HasRows)
        //                        {
        //                            Debug.WriteLine("aaaaaaaa");
        //                        }
        //                        else
        //                        {
        //                            Debug.WriteLine(String.Format("{0}", resultIns[0]));
        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        throw ex;
        //                    }
        //                    */
        //                }
        //                else
        //                {
        //                    result.Close();
        //                    //Debug.WriteLine("Does not");

        //                    lblStartStatus.Text = "Does not";

        //                    /*
        //                    string strSqlCreate = "CREATE TABLE[tblTest] (" +
        //                        "[Id] INTEGER NOT NULL" +
        //                        ", [testID] INTEGER NOT NULL" +
        //                        ", CONSTRAINT[PK_tblTest] PRIMARY KEY([Id])" +
        //                        ");";
        //                    cmd.CommandText = strSqlCreate;
        //                    cmd.ExecuteNonQuery();
        //                    */


        //                }

        //                result.Close();


        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }




        //            try
        //            {
        //                conn.Close();
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }

        //        }
        //    }
        //}
    }
}
