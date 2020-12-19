
namespace ShareWatch.EntryScreen
{
    partial class BankTransactionImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BankTransactionImport));
            this.SBar = new System.Windows.Forms.StatusStrip();
            this.lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.Spliter = new System.Windows.Forms.SplitContainer();
            this.btnCommitTransaction = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.FileName = new System.Windows.Forms.TextBox();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.SBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Spliter)).BeginInit();
            this.Spliter.Panel1.SuspendLayout();
            this.Spliter.Panel2.SuspendLayout();
            this.Spliter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // SBar
            // 
            this.SBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMessage});
            this.SBar.Location = new System.Drawing.Point(0, 428);
            this.SBar.Name = "SBar";
            this.SBar.Size = new System.Drawing.Size(800, 22);
            this.SBar.TabIndex = 0;
            this.SBar.Text = "statusStrip1";
            // 
            // lblMessage
            // 
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(39, 17);
            this.lblMessage.Text = "Ready";
            // 
            // Spliter
            // 
            this.Spliter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Spliter.IsSplitterFixed = true;
            this.Spliter.Location = new System.Drawing.Point(0, 0);
            this.Spliter.Name = "Spliter";
            this.Spliter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Spliter.Panel1
            // 
            this.Spliter.Panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Spliter.Panel1.BackgroundImage")));
            this.Spliter.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Spliter.Panel1.Controls.Add(this.btnCommitTransaction);
            this.Spliter.Panel1.Controls.Add(this.btnProcess);
            this.Spliter.Panel1.Controls.Add(this.label7);
            this.Spliter.Panel1.Controls.Add(this.FileName);
            // 
            // Spliter.Panel2
            // 
            this.Spliter.Panel2.Controls.Add(this.Grid);
            this.Spliter.Size = new System.Drawing.Size(800, 428);
            this.Spliter.SplitterDistance = 80;
            this.Spliter.TabIndex = 1;
            // 
            // btnCommitTransaction
            // 
            this.btnCommitTransaction.Location = new System.Drawing.Point(172, 40);
            this.btnCommitTransaction.Name = "btnCommitTransaction";
            this.btnCommitTransaction.Size = new System.Drawing.Size(100, 29);
            this.btnCommitTransaction.TabIndex = 13;
            this.btnCommitTransaction.Text = "Commit 2 DB";
            this.btnCommitTransaction.UseVisualStyleBackColor = true;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(85, 40);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(81, 29);
            this.btnProcess.TabIndex = 11;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.BtnProcess_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(19, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "File Name";
            // 
            // FileName
            // 
            this.FileName.Location = new System.Drawing.Point(85, 11);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(697, 23);
            this.FileName.TabIndex = 9;
            this.FileName.Text = "C:\\Interface\\Input\\Transaction";
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
            // BankTransactionImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Spliter);
            this.Controls.Add(this.SBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BankTransactionImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bank Transaction Import";
            this.Load += new System.EventHandler(this.BankTransactionImport_Load);
            this.SBar.ResumeLayout(false);
            this.SBar.PerformLayout();
            this.Spliter.Panel1.ResumeLayout(false);
            this.Spliter.Panel1.PerformLayout();
            this.Spliter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Spliter)).EndInit();
            this.Spliter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip SBar;
        private System.Windows.Forms.ToolStripStatusLabel lblMessage;
        private System.Windows.Forms.SplitContainer Spliter;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.Button btnCommitTransaction;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox FileName;
    }
}