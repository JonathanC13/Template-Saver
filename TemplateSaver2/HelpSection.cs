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
    public partial class HelpSection : UserControl
    {

        HelpForm frmHelp;
        public HelpSection()
        {
            InitializeComponent();
        }

        public HelpSection(HelpForm frmHelp) : this()
        {
            this.frmHelp = frmHelp;
        }

        private void HelpSection_Load(object sender, EventArgs e)
        {
            //
        }

        /*
        private void button1_Click(object sender, EventArgs e)
        {

            String CurrentPointY = frmHelp.getYPos();

            Debug.WriteLine(CurrentPointY);
        }
        */
    }
}
