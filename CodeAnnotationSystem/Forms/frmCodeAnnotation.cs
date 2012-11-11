using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
            IntPtr curScintilla = PluginBase.GetCurrentScintilla();

            int selectionStartPos = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_GETSELECTIONSTART, 0, 0);
            int selectionEndPos = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_GETSELECTIONEND, 0, 0);

            int selectionStartLine = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_LINEFROMPOSITION, selectionStartPos, 0);
            int selectionEndLine = (int)Win32.SendMessage(curScintilla, SciMsg.SCI_LINEFROMPOSITION, selectionEndPos, 0);

            int selectionStartCol = selectionStartPos - (int)Win32.SendMessage(curScintilla, SciMsg.SCI_POSITIONFROMLINE, selectionStartLine, 0);
            int selectionEndCol = selectionEndPos - (int)Win32.SendMessage(curScintilla, SciMsg.SCI_POSITIONFROMLINE, selectionEndLine, 0);

            String location = selectionStartLine.ToString() + "," + selectionStartCol.ToString() + "-" +
                selectionEndLine.ToString() + "," + selectionEndCol.ToString();
            
            MessageBox.Show(location, "Current Selection");

            frmAddComment frm = new frmAddComment();
            frm.ShowDialog();

            MessageBox.Show(frm.comment, "Comment:");

            this.lstComments.Items.Add(location+": "+frm.comment);


        }

        public void bufferChanged()
        {
            MessageBox.Show("Buffer Changed", "!!");
        }


    }
}
