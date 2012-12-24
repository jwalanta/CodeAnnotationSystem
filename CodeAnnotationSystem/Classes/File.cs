using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace NppPluginNET
{
    public class File
    {
        private string m_FileName = "";

        public string FileName
        {
            get { return m_FileName; }
            set { m_FileName = value; }
        }

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

            SaveComments();

            LoadComments();

            return comment;
        }

        public Comment AddComment(Comment comment)
        {
            int newID = m_Comments.Count + 1;

            comment.ID = newID;

            m_Comments.Add(comment);

            SaveComments();

            LoadComments();

            return comment;
        }

        public void UpdateComment(Comment comment)
        {
            m_Comments[comment.ID - 1] = comment;

            SaveComments();

            LoadComments();
        }

        public void DeleteComment(Comment comment)
        {
            m_Comments.Remove(comment);

            SaveComments();

            LoadComments();
        }

        public void SaveComments()
        {
            int count = 1;

            XDocument document = new XDocument
            (
                new XElement
                (
                    "Comments",
                    from c in m_Comments
                    select
                    new XElement
                    (
                        "Comment",
                        new XElement("ID", count++),
                        new XElement("StartLine", c.StartLine),
                        new XElement("EndLine", c.EndLine),
                        new XElement("StartColumn", c.StartColumn),
                        new XElement("EndColumn", c.EndColumn),
                        new XElement("CommentText", c.CommentText)
                    )
                )
            );

            document.Save(m_FileName);
        }

        public void LoadComments()
        {
            m_Comments.Clear();

            FileInfo file = new FileInfo(m_FileName);

            if (!file.Exists) 
                return;

            var comments = from p in XDocument.Load(m_FileName).Elements("Comments")
                                .Elements("Comment")
                           select new Comment
                           {
                               ID = (int)p.Element("ID"),
                               StartLine = (int)p.Element("StartLine"),
                               EndLine = (int)p.Element("EndLine"),
                               StartColumn = (int)p.Element("StartColumn"),
                               EndColumn = (int)p.Element("EndColumn"),
                               CommentText = ((string)p.Element("CommentText")).Replace("\r\n", "\n").Replace("\n", "\r\n")
                           };

            m_Comments = comments.ToList<Comment>();
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine(Path.GetFileNameWithoutExtension(m_FileName));
            report.AppendLine();

            foreach (Comment comment in m_Comments)
            {
                report.AppendLine(comment.ToString());
                report.AppendLine();
            }

            return report.ToString();
        }
    }
}
