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
    public partial class GeneralError : Form
    {
        private bool mGrowing;

        public GeneralError()
        {
            InitializeComponent();
            //set SelectionStart property to zero
            //This clears the selection and sets the cursor to the left of the 1st character in the textbox
            lblGnrlErrHeader.SelectionStart = 0;
            lblErrMsg.SelectionStart = 0;

            //This clears the selection and sets the cursor to the end of whatever is in the textbox
            //textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void btnGnrlErrClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void setErrorMessage(String strErrorMsg)
        {
            lblErrMsg.Text = strErrorMsg;
        }


        private void lblErrMsg_TextChanged(object sender, EventArgs e)
        {

            base.OnTextChanged(e);
            resizeLabel();

        }


        // functions

        private void resizeLabel()
        {
            if (mGrowing) return;
            try
            {

                mGrowing = true;
                Size sz = new Size(lblErrMsg.Width, Int32.MaxValue);
                sz = TextRenderer.MeasureText(lblErrMsg.Text, lblErrMsg.Font, sz, TextFormatFlags.WordBreak);
                lblErrMsg.Height = sz.Height;



            }
            finally
            {
                mGrowing = false;
            }
        }
    }
}
