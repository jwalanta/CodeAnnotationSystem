using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NppPluginNET
{
    public class CommentFile
    {
        private List<Comment> m_Comments = new List<Comment>();

        public List<Comment> Comments
        {
            get { return m_Comments; }
            set { m_Comments = value; }
        }

        public Comment AddComment(int startLine, int endLine, int startColumn, int endColumn, string text)
        {
            Comment comment = new Comment();

            int newID = m_Comments.Count + 1;

            comment.ID = newID;
            comment.StartLine = startLine;
            comment.EndLine = endLine;
            comment.StartColumn = startColumn;
            comment.EndColumn = endColumn;
            comment.CommentText = text.Trim();

            m_Comments.Add(comment);

            //ToDo: Add Comment/Save file

            return comment;
        }

        public void UpdateComment(Comment comment)
        {
            m_Comments[comment.ID - 1] = comment;
        }

        public void DeleteComment(Comment comment)
        {
            m_Comments.Remove(comment);

            //ToDo: Add Comment/Save file
        }
    }
}
