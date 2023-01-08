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

namespace TemplateSaver2
{
    public partial class HelpForm : Form
    {
        //private int scrollPositionY = 0;

        private Point ptLocation;
        public HelpForm()
        {
            InitializeComponent();

           
        }

        public HelpForm(Point location) : this()
        {

            ptLocation = location;

            HelpSection cntrlHelp = new HelpSection(this);
            panel1.Controls.Add(cntrlHelp);
            
            //panel1.Location = new System.Drawing.Point(panel1.Location.X, panel1.Location.Y);
            panel1.MaximumSize = new Size(900, this.ClientSize.Height);

            panel1.HorizontalScroll.Maximum = 0;
            panel1.AutoScroll = false;
            panel1.VerticalScroll.Visible = false;
            panel1.AutoScroll = true;


            panel1.AutoSize = true;
            

        }

        



        private void HelpForm_Resize(object sender, EventArgs e)
        {
            
           

            // ** Note snapping doesn't trigger this event, so need to manually initiate resize after snapping window to trigger resizing in this function

            panel1.Height = this.ClientSize.Height - 20;


            // keep template panel centered
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;

            // scroll bars in view when resizing
            panel1.Width = ((this.ClientSize.Width));

            // Resize to expand or shrink panel
            panel1.MaximumSize = new Size(900, this.ClientSize.Height);

            
            //panel1.AutoScrollPosition = new Point(Math.Abs(panel1.AutoScrollPosition.X), Math.Abs(scrollPositionY));

        }

        public String getYPos()
        {
            System.Drawing.Point CurrentPoint;
            CurrentPoint = panel1.AutoScrollPosition;

            return CurrentPoint.Y.ToString();
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            this.SetDesktopLocation(ptLocation.X, ptLocation.Y);
        }
    }
}
