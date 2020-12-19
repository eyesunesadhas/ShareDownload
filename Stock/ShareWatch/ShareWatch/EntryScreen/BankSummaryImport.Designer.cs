
namespace ShareWatch.EntryScreen
{
    partial class BankSummaryImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BankSummaryImport));
            this.SBar = new System.Windows.Forms.StatusStrip();
            this.lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblClock = new System.Windows.Forms.ToolStripStatusLabel();
            this.Splitter = new System.Windows.Forms.SplitContainer();
            this.btnTallyReport = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.FileName = new System.Windows.Forms.TextBox();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.FileOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.SBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Splitter)).BeginInit();
            this.Splitter.Panel1.SuspendLayout();
            this.Splitter.Panel2.SuspendLayout();
            this.Splitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // SBar
            // 
            this.SBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMessage,
            this.lblClock});
            this.SBar.Location = new System.Drawing.Point(0, 428);
            this.SBar.Name = "SBar";
            this.SBar.Size = new System.Drawing.Size(800, 22);
            this.SBar.TabIndex = 0;
            this.SBar.Text = "Status Bar";
            // 
            // lblMessage
            // 
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(714, 17);
            this.lblMessage.Spring = true;
            this.lblMessage.Text = "Ready";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblClock
            // 
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(71, 17);
            this.lblClock.Text = "10:10:10 AM";
            // 
            // Splitter
            // 
            this.Splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Splitter.IsSplitterFixed = true;
            this.Splitter.Location = new System.Drawing.Point(0, 0);
            this.Splitter.Name = "Splitter";
            this.Splitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Splitter.Panel1
            // 
            this.Splitter.Panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Splitter.Panel1.BackgroundImage")));
            this.Splitter.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Splitter.Panel1.Controls.Add(this.btnTallyReport);
            this.Splitter.Panel1.Controls.Add(this.btnProcess);
            this.Splitter.Panel1.Controls.Add(this.label7);
            this.Splitter.Panel1.Controls.Add(this.FileName);
            // 
            // Splitter.Panel2
            // 
            this.Splitter.Panel2.Controls.Add(this.Grid);
            this.Splitter.Size = new System.Drawing.Size(800, 428);
            this.Splitter.SplitterDistance = 80;
            this.Splitter.TabIndex = 1;
            // 
            // btnTallyReport
            // 
            this.btnTallyReport.Location = new System.Drawing.Point(165, 39);
            this.btnTallyReport.Name = "btnTallyReport";
            this.btnTallyReport.Size = new System.Drawing.Size(81, 29);
            this.btnTallyReport.TabIndex = 8;
            this.btnTallyReport.Text = "Tally Report";
            this.btnTallyReport.UseVisualStyleBackColor = true;
            this.btnTallyReport.Click += new System.EventHandler(this.btnTallyReport_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(78, 39);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(81, 29);
            this.btnProcess.TabIndex = 6;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.BtnProcess_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(12, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "File Name";
            // 
            // FileName
            // 
            this.FileName.Location = new System.Drawing.Point(78, 10);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(697, 23);
            this.FileName.TabIndex = 2;
            this.FileName.Text = "C:\\Interface\\Input\\";
            // 
            // Grid
            // 
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid.Location = new System.Drawing.Point(0, 0);
            this.Grid.Name = "Grid";
            this.Grid.RowTemplate.Height = 25;
            this.Grid.Size = new System.Drawing.Size(800, 344);
            this.Grid.TabIndex = 0;
            // 
            // BankSummaryImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Splitter);
            this.Controls.Add(this.SBar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BankSummaryImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bank Summary Import";
            this.Load += new System.EventHandler(this.BankSummaryImport_Load);
            this.SBar.ResumeLayout(false);
            this.SBar.PerformLayout();
            this.Splitter.Panel1.ResumeLayout(false);
            this.Splitter.Panel1.PerformLayout();
            this.Splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Splitter)).EndInit();
            this.Splitter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip SBar;
        private System.Windows.Forms.ToolStripStatusLabel lblMessage;
        private System.Windows.Forms.ToolStripStatusLabel lblClock;
        private System.Windows.Forms.SplitContainer Splitter;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox FileName;
        private System.Windows.Forms.OpenFileDialog FileOpenDialog;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnTallyReport;
    }
}