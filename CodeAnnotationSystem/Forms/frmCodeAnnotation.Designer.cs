namespace NppPluginNET
{
    partial class frmCodeAnnotation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReportAll = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lstComments = new System.Windows.Forms.ListBox();
            this.btnAddComment = new System.Windows.Forms.Button();
            this.btnDeleteComment = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReportAll
            // 
            this.btnReportAll.Location = new System.Drawing.Point(183, 3);
            this.btnReportAll.Name = "btnReportAll";
            this.btnReportAll.Size = new System.Drawing.Size(75, 23);
            this.btnReportAll.TabIndex = 3;
            this.btnReportAll.Text = "Report All";
            this.btnReportAll.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(123, 3);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(54, 23);
            this.btnReport.TabIndex = 2;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lstComments, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnReportAll, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddComment, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnReport, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnDeleteComment, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(290, 765);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lstComments
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lstComments, 4);
            this.lstComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstComments.FormattingEnabled = true;
            this.lstComments.Location = new System.Drawing.Point(3, 32);
            this.lstComments.Name = "lstComments";
            this.lstComments.Size = new System.Drawing.Size(284, 730);
            this.lstComments.TabIndex = 0;
            this.lstComments.SelectedIndexChanged += new System.EventHandler(this.lstComments_SelectedIndexChanged);
            this.lstComments.DoubleClick += new System.EventHandler(this.lstComments_DoubleClick);
            // 
            // btnAddComment
            // 
            this.btnAddComment.Location = new System.Drawing.Point(3, 3);
            this.btnAddComment.Name = "btnAddComment";
            this.btnAddComment.Size = new System.Drawing.Size(54, 23);
            this.btnAddComment.TabIndex = 1;
            this.btnAddComment.Text = "Add";
            this.btnAddComment.UseVisualStyleBackColor = true;
            this.btnAddComment.Click += new System.EventHandler(this.btnAddComment_Click);
            // 
            // btnDeleteComment
            // 
            this.btnDeleteComment.Location = new System.Drawing.Point(63, 3);
            this.btnDeleteComment.Name = "btnDeleteComment";
            this.btnDeleteComment.Size = new System.Drawing.Size(54, 23);
            this.btnDeleteComment.TabIndex = 2;
            this.btnDeleteComment.Text = "Delete";
            this.btnDeleteComment.UseVisualStyleBackColor = true;
            this.btnDeleteComment.Click += new System.EventHandler(this.btnDeleteComment_Click);
            // 
            // frmCodeAnnotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 765);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmCodeAnnotation";
            this.Text = "Code Annotation System";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReportAll;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox lstComments;
        private System.Windows.Forms.Button btnAddComment;
        private System.Windows.Forms.Button btnDeleteComment;


    }
}