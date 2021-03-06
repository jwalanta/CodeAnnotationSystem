﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NppPluginNET
{
    public class Comment
    {
        private int m_ID = 0;

        public int ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }

        private int m_StartLine = 0;

        public int StartLine
        {
            get { return this.m_StartLine; }
            set { this.m_StartLine = value; }
        }

        private int m_EndLine = 0;

        public int EndLine
        {
            get { return this.m_EndLine; }
            set { this.m_EndLine = value; }
        }

        private int m_StartColumn = 0;

        public int StartColumn
        {
            get { return this.m_StartColumn; }
            set { this.m_StartColumn = value; }
        }

        private int m_EndColumn = 0;

        public int EndColumn
        {
            get { return this.m_EndColumn; }
            set { this.m_EndColumn = value; }
        }

        private string m_CommentText = string.Empty;

        public string CommentText
        {
            get { return this.m_CommentText; }
            set { this.m_CommentText = value; }
        }

        public string ComboText
        {
            get
            {
                return string.Format
                (
                    "[{0},{1}-{2},{3}]: {4}",
                    this.m_StartLine + 1,
                    this.m_StartColumn + 1,
                    this.m_EndLine + 1,
                    this.m_EndColumn + 1,
                    this.m_CommentText
                );
            }
        }

        public override string ToString()
        {
            StringBuilder commentString = new StringBuilder();

            commentString.AppendLine
            (
                string.Format
                (
                    "[Line: {0},{1} to {2},{3}]",
                    this.m_StartLine + 1, 
                    this.m_StartColumn + 1, 
                    this.m_EndLine + 1,
                    this.m_EndColumn + 1
                )
            );
            commentString.Append(m_CommentText);

            return commentString.ToString();
        }
    }
}
