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

            //if (!string.IsNullOrEmpty(m_Comment.CommentText))
            //{
            //    txtComment.Text = m_Comment.CommentText;
            //}

        }

        public void loadCommentText(String commentText){
            txtComment.Text = commentText;
            txtComment.Select(commentText.Length, 0);

            btnAdd.Text = "Update";
            this.Text = "Edit Comment";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.m_Comment.CommentText = txtComment.Text.Trim();
        }

        public void clearText()
        {
            this.txtComment.Text = string.Empty;
        }
    }
}
