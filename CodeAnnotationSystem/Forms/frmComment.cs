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
        private Comment m_Comment = new Comment();

        public Comment Comment
        {
            get { return m_Comment; }
            set { m_Comment = value; }
        }

        public frmAddComment()
        {
            InitializeComponent();
        }

        private void frmAddComment_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(m_Comment.CommentText))
            {
                //ToDo: make edit form
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Comment.CommentText = txtComment.Text.Trim();
        }

        public void clearText()
        {
            this.txtComment.Text = string.Empty;
        }
    }
}
