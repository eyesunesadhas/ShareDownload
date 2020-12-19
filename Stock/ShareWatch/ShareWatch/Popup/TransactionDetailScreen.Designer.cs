namespace ShareWatch.Popup
{
    partial class TransactionDetailScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionDetailScreen));
            this.SBar = new System.Windows.Forms.StatusStrip();
            this.lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.AccountID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TradeCode = new System.Windows.Forms.TextBox();
            this.TradeName = new System.Windows.Forms.TextBox();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.SBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // SBar
            // 
            this.SBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMessage});
            this.SBar.Location = new System.Drawing.Point(0, 438);
            this.SBar.Name = "SBar";
            this.SBar.Size = new System.Drawing.Size(1065, 22);
            this.SBar.TabIndex = 0;
            this.SBar.Text = "Status";
            // 
            // lblMessage
            // 
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(39, 17);
            this.lblMessage.Text = "Ready";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitContainer1.Panel1.BackgroundImage")));
            this.splitContainer1.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer1.Panel1.Controls.Add(this.btnSearch);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.AccountID);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.TradeCode);
            this.splitContainer1.Panel1.Controls.Add(this.TradeName);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Grid);
            this.splitContainer1.Size = new System.Drawing.Size(1065, 438);
            this.splitContainer1.SplitterDistance = 40;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.Text = "splitContainer1";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(765, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(67, 24);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(380, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Account";
            // 
            // AccountID
            // 
            this.AccountID.FormattingEnabled = true;
            this.AccountID.Location = new System.Drawing.Point(437, 9);
            this.AccountID.Name = "AccountID";
            this.AccountID.Size = new System.Drawing.Size(317, 23);
            this.AccountID.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Trade";
            // 
            // TradeCode
            // 
            this.TradeCode.Location = new System.Drawing.Point(48, 8);
            this.TradeCode.Name = "TradeCode";
            this.TradeCode.Size = new System.Drawing.Size(62, 23);
            this.TradeCode.TabIndex = 0;
            this.TradeCode.TextChanged += new System.EventHandler(this.TradeCode_TextChanged);
            // 
            // TradeName
            // 
            this.TradeName.Location = new System.Drawing.Point(113, 8);
            this.TradeName.Name = "TradeName";
            this.TradeName.ReadOnly = true;
            this.TradeName.Size = new System.Drawing.Size(264, 23);
            this.TradeName.TabIndex = 0;
            // 
            // Grid
            // 
            this.Grid.AllowUserToAddRows = false;
            this.Grid.AllowUserToDeleteRows = false;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid.Location = new System.Drawing.Point(0, 0);
            this.Grid.Name = "Grid";
            this.Grid.ReadOnly = true;
            this.Grid.Size = new System.Drawing.Size(1065, 394);
            this.Grid.TabIndex = 0;
            this.Grid.Text = "dataGridView1";
            // 
            // TransactionDetailScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 460);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.SBar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransactionDetailScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Transaction Details";
            this.Load += new System.EventHandler(this.TransactionDetailScreen_Load);
            this.SBar.ResumeLayout(false);
            this.SBar.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip SBar;
        private System.Windows.Forms.ToolStripStatusLabel lblMessage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TradeCode;
        private System.Windows.Forms.TextBox TradeName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox AccountID;
        private System.Windows.Forms.DataGridView Grid;
    }
}