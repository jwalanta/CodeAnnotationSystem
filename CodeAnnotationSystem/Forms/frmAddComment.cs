using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NppPluginNET
{
    public partial class frmAddComment : Form
    {

        public String comment;

        public frmAddComment()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.comment = this.txtComment.Text;
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtComment.Text = "";
            this.comment = "";
        }

        public void clearText()
        {
            this.txtComment.Text = "";
            this.Hide();
        }
    }
}
