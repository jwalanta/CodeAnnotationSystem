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
        public frmCodeAnnotation()
        {
            InitializeComponent();
        }

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            IntPtr curScintilla = IntPtr.Zero;

            try
            {
                curScintilla = PluginBase.GetCurrentScintilla();

                int selectionStartPos = CommenterHelper.GetSelectionPosition(ref curScintilla, SciMsg.SCI_GETSELECTIONSTART);
                int selectionEndPos = CommenterHelper.GetSelectionPosition(ref curScintilla, SciMsg.SCI_GETSELECTIONEND);
                int selectionStartLine = CommenterHelper.GetSelectionLineFromPosition(ref curScintilla, selectionStartPos);
                int selectionEndLine = CommenterHelper.GetSelectionLineFromPosition(ref curScintilla, selectionEndPos);
                int selectionStartCol = selectionStartPos - CommenterHelper.GetSelectionPositionFromLine(ref curScintilla, selectionStartLine);
                int selectionEndCol = selectionEndPos - CommenterHelper.GetSelectionPositionFromLine(ref curScintilla, selectionEndLine);

                Comment comment = new Comment();

                comment.StartLine = selectionStartLine;
                comment.EndLine = selectionEndLine;
                comment.StartColumn = selectionStartCol;
                comment.EndColumn = selectionEndCol;

                using (frmAddComment frm = new frmAddComment())
                {
                    frm.Comment = comment;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        comment = frm.Comment;

                        lstComments.Items.Add(new ListViewItem(comment.ComboText).Text);
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
            MessageBox.Show("Buffer Changed", "!!");
        }
    }
}
