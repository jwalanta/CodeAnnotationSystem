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

                int selectionStartPos = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_GETSELECTIONSTART, 0, 0);
                int selectionEndPos = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_GETSELECTIONEND, 0, 0);

                int selectionStartLine = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_LINEFROMPOSITION, selectionStartPos, 0);
                int selectionEndLine = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_LINEFROMPOSITION, selectionEndPos, 0);

                int selectionStartCol = selectionStartPos - (int)Win32.SendMessage(curScintilla, SciMsg.SCI_POSITIONFROMLINE, selectionStartLine, 0);
                int selectionEndCol = selectionEndPos - (int)Win32.SendMessage(curScintilla, SciMsg.SCI_POSITIONFROMLINE, selectionEndLine, 0);

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
            //MessageBox.Show("Buffer Changed", "!!");
        }
    }
}
