using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace NppPluginNET
{
    public partial class frmCodeAnnotation : Form
    {
        private CommentFile file = null;

        public frmCodeAnnotation()
        {
            InitializeComponent();

            file = new CommentFile();

            bufferChanged();

            lstComments.SelectedIndex = -1;
        }

        private void bindComment()
        {
            lstComments.DataSource = null;
            lstComments.Items.Clear();

            lstComments.DataSource = file.Comments;
            lstComments.ValueMember = "ID";
            lstComments.DisplayMember = "ComboText";
        }

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            IntPtr curScintilla = IntPtr.Zero;

            try
            {
                curScintilla = PluginBase.GetCurrentScintilla();

                int selectionStartPos = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_GETSELECTIONSTART, 0, 0);
                int selectionEndPos = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_GETSELECTIONEND, 0, 0);

                int selectionStartLine = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_LINEFROMPOSITION, selectionStartPos, 0);
                int selectionEndLine = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_LINEFROMPOSITION, selectionEndPos, 0);

                int selectionStartCol = selectionStartPos - (int)Win32.SendMessage(curScintilla, SciMsg.SCI_POSITIONFROMLINE, selectionStartLine, 0);
                int selectionEndCol = selectionEndPos - (int)Win32.SendMessage(curScintilla, SciMsg.SCI_POSITIONFROMLINE, selectionEndLine, 0);

                using (frmAddComment frm = new frmAddComment())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        file.AddComment(selectionStartLine, selectionEndLine, selectionStartCol, selectionEndCol, frm.Comment.CommentText);

                        bindComment();

                        // Highlight 
                        Win32.SendMessage(curScintilla, SciMsg.SCI_INDICSETSTYLE, 20, 7);
                        Win32.SendMessage(curScintilla, SciMsg.SCI_INDICSETFORE, 20, 0x00FFFF);
                        Win32.SendMessage(curScintilla, SciMsg.SCI_INDICSETALPHA, 20, 50);
                        Win32.SendMessage(curScintilla, SciMsg.SCI_SETINDICATORCURRENT, 20, 0);
                        Win32.SendMessage(curScintilla, SciMsg.SCI_INDICATORFILLRANGE, selectionStartPos, selectionEndPos - selectionStartPos);

                        // select the latest item
                        lstComments.SelectedIndex = lstComments.Items.Count - 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Marshal.Release(curScintilla);
            }
        }

        public void bufferChanged()
        {
             IntPtr curScintilla = IntPtr.Zero;

             try
             {
                 // Get current filename
                 StringBuilder path = new StringBuilder(Win32.MAX_PATH);
                 Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_GETFULLCURRENTPATH, 0, path);

                 // initialize CommentFile
                 file.FileName = String.Format("{0}.ano", path.ToString());

                 file.LoadComments();

                 bindComment();

                 // highlight all comments
                 curScintilla = PluginBase.GetCurrentScintilla();

                 foreach (Comment comment in file.Comments)
                 {
                     // get selection start and end from comment
                     int selectionStartLine = comment.StartLine;
                     int selectionStartCol = comment.StartColumn;
                     int selectionEndLine = comment.EndLine;
                     int selectionEndCol = comment.EndColumn;

                     // convert to position
                     int selectionStartPos = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_POSITIONFROMLINE, selectionStartLine, 0) + selectionStartCol;
                     int selectionEndPos = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_POSITIONFROMLINE, selectionEndLine, 0) + selectionEndCol;

                     // Highlight 
                     Win32.SendMessage(curScintilla, SciMsg.SCI_INDICSETSTYLE, 20, 7);
                     Win32.SendMessage(curScintilla, SciMsg.SCI_INDICSETFORE, 20, 0x00FFFF);
                     Win32.SendMessage(curScintilla, SciMsg.SCI_INDICSETALPHA, 20, 32);
                     Win32.SendMessage(curScintilla, SciMsg.SCI_SETINDICATORCURRENT, 20, 0);
                     Win32.SendMessage(curScintilla, SciMsg.SCI_INDICATORFILLRANGE, selectionStartPos, selectionEndPos - selectionStartPos);
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             finally
             {
                 Marshal.Release(curScintilla);
             }
        }

        private void btnDeleteComment_Click(object sender, EventArgs e)
        {
            IntPtr curScintilla = IntPtr.Zero;

            try
            {
                int intSelection = (int)lstComments.SelectedIndex;

                Comment comment = new Comment();

                comment = file.Comments[intSelection];

                // get selection start and end from comment
                int selectionStartLine = comment.StartLine;
                int selectionStartCol = comment.StartColumn;
                int selectionEndLine = comment.EndLine;
                int selectionEndCol = comment.EndColumn;

                // convert to position
                curScintilla = PluginBase.GetCurrentScintilla();
                int selectionStartPos = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_POSITIONFROMLINE, selectionStartLine, 0) + selectionStartCol;
                int selectionEndPos = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_POSITIONFROMLINE, selectionEndLine, 0) + selectionEndCol;

                // Remove highlight 
                Win32.SendMessage(curScintilla, SciMsg.SCI_INDICATORCLEARRANGE, selectionStartPos, selectionEndPos - selectionStartPos);

                file.DeleteComment(comment);

                bindComment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Marshal.Release(curScintilla);
            }
        }

        private void lstComments_DoubleClick(object sender, EventArgs e)
        {
            int intSelection = (int)lstComments.SelectedIndex;

            Comment comment = new Comment();

            comment = file.Comments[intSelection];

            using (frmAddComment frm = new frmAddComment())
            {
                frm.loadCommentText(comment.CommentText);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    comment.CommentText = frm.Comment.CommentText;

                    file.UpdateComment(comment);

                    bindComment();
                }
            }
        }

        private void lstComments_SelectedIndexChanged(object sender, EventArgs e)
        {
            IntPtr curScintilla = IntPtr.Zero;

            try
            {
                // highlight the commented segment
                curScintilla = PluginBase.GetCurrentScintilla();

                // get selected comment
                int intSelection = (int)lstComments.SelectedIndex;

                if (intSelection >= 0)
                {
                    Comment comment = new Comment();
                    comment = file.Comments[intSelection];

                    // get selection start and end from comment
                    int selectionStartLine = comment.StartLine;
                    int selectionStartCol = comment.StartColumn;
                    int selectionEndLine = comment.EndLine;
                    int selectionEndCol = comment.EndColumn;

                    // convert to position
                    int selectionStartPos = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_POSITIONFROMLINE, selectionStartLine, 0) + selectionStartCol;
                    int selectionEndPos = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_POSITIONFROMLINE, selectionEndLine, 0) + selectionEndCol;

                    // goto the starting line
                    Win32.SendMessage(curScintilla, SciMsg.SCI_GOTOLINE, selectionEndLine + 100, 0);
                    Win32.SendMessage(curScintilla, SciMsg.SCI_GOTOLINE, selectionStartLine - 1, 0);
                    Win32.SendMessage(curScintilla, SciMsg.SCI_GRABFOCUS, 0, 0);

                    // select the segment
                    Win32.SendMessage(curScintilla, SciMsg.SCI_SETSELECTIONSTART, selectionStartPos, 0);
                    Win32.SendMessage(curScintilla, SciMsg.SCI_SETSELECTIONEND, selectionEndPos, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Marshal.Release(curScintilla);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            IntPtr curScintilla = IntPtr.Zero;

            try
            {
                // Get the report
                String report = file.Report();

                // Open a new document
                Win32.SendMessage(PluginBase.nppData._nppHandle, NppMsg.NPPM_MENUCOMMAND, 0, NppMenuCmd.IDM_FILE_NEW);

                // Get the current scintilla
                curScintilla = PluginBase.GetCurrentScintilla();

                Win32.SendMessage(curScintilla, SciMsg.SCI_APPENDTEXT, report.Length, report);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
