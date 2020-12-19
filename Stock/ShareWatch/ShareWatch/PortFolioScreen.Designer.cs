namespace ShareWatch
{
    partial class PortFolioScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PortFolioScreen));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TradeName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TradeCode = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.AccountID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.CMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolSell = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolBuy = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolTradeValue = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolACB = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.CMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitContainer1.Panel1.BackgroundImage")));
            this.splitContainer1.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer1.Panel1.Controls.Add(this.TradeName);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.TradeCode);
            this.splitContainer1.Panel1.Controls.Add(this.btnNew);
            this.splitContainer1.Panel1.Controls.Add(this.btnRefresh);
            this.splitContainer1.Panel1.Controls.Add(this.AccountID);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Grid);
            this.splitContainer1.Size = new System.Drawing.Size(1384, 611);
            this.splitContainer1.SplitterDistance = 46;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.Text = "splitContainer1";
            // 
            // TradeName
            // 
            this.TradeName.Location = new System.Drawing.Point(566, 16);
            this.TradeName.Name = "TradeName";
            this.TradeName.ReadOnly = true;
            this.TradeName.Size = new System.Drawing.Size(310, 23);
            this.TradeName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(457, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trade";
            // 
            // TradeCode
            // 
            this.TradeCode.Location = new System.Drawing.Point(498, 15);
            this.TradeCode.Name = "TradeCode";
            this.TradeCode.Size = new System.Drawing.Size(62, 23);
            this.TradeCode.TabIndex = 3;
            this.TradeCode.TextChanged += new System.EventHandler(this.TradeCode_TextChanged);
            this.TradeCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AccountID_KeyUp);
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(923, 13);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(96, 28);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "Trade";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(882, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(35, 28);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // AccountID
            // 
            this.AccountID.FormattingEnabled = true;
            this.AccountID.Location = new System.Drawing.Point(70, 15);
            this.AccountID.Name = "AccountID";
            this.AccountID.Size = new System.Drawing.Size(381, 23);
            this.AccountID.TabIndex = 2;
            this.AccountID.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AccountID_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Account";
            // 
            // Grid
            // 
            this.Grid.AllowUserToAddRows = false;
            this.Grid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.ContextMenuStrip = this.CMenu;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid.DefaultCellStyle = dataGridViewCellStyle2;
            this.Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid.Location = new System.Drawing.Point(0, 0);
            this.Grid.Name = "Grid";
            this.Grid.ReadOnly = true;
            this.Grid.Size = new System.Drawing.Size(1384, 561);
            this.Grid.TabIndex = 0;
            this.Grid.Text = "dataGridView1";
            this.Grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellDoubleClick);
            this.Grid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.Grid_CellFormatting);
            this.Grid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.Grid_RowPostPaint);
            // 
            // CMenu
            // 
            this.CMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolSell,
            this.ToolBuy,
            this.ToolTradeValue,
            this.ToolACB});
            this.CMenu.Name = "CMenu";
            this.CMenu.Size = new System.Drawing.Size(199, 92);
            // 
            // ToolSell
            // 
            this.ToolSell.Image = ((System.Drawing.Image)(resources.GetObject("ToolSell.Image")));
            this.ToolSell.Name = "ToolSell";
            this.ToolSell.Size = new System.Drawing.Size(198, 22);
            this.ToolSell.Text = "Sell";
            this.ToolSell.Click += new System.EventHandler(this.ToolSell_Click);
            // 
            // ToolBuy
            // 
            this.ToolBuy.Image = ((System.Drawing.Image)(resources.GetObject("ToolBuy.Image")));
            this.ToolBuy.Name = "ToolBuy";
            this.ToolBuy.Size = new System.Drawing.Size(198, 22);
            this.ToolBuy.Text = "Buy";
            this.ToolBuy.Click += new System.EventHandler(this.ToolBuy_Click);
            // 
            // ToolTradeValue
            // 
            this.ToolTradeValue.Name = "ToolTradeValue";
            this.ToolTradeValue.Size = new System.Drawing.Size(198, 22);
            this.ToolTradeValue.Text = "Trade Rate";
            this.ToolTradeValue.Click += new System.EventHandler(this.ToolTradeValue_Click);
            // 
            // ToolACB
            // 
            this.ToolACB.Name = "ToolACB";
            this.ToolACB.Size = new System.Drawing.Size(198, 22);
            this.ToolACB.Text = "Adjust Cost Basis (ACB)";
            this.ToolACB.Click += new System.EventHandler(this.ToolACB_Click);
            // 
            // PortFolioScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 611);
            this.Controls.Add(this.splitContainer1);
            this.Name = "PortFolioScreen";
            this.Text = "PortFolioScreen";
            this.Load += new System.EventHandler(this.PortFolioScreen_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.CMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox AccountID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TradeCode;
        private System.Windows.Forms.TextBox TradeName;
        private System.Windows.Forms.ContextMenuStrip CMenu;
        private System.Windows.Forms.ToolStripMenuItem ToolSell;
        private System.Windows.Forms.ToolStripMenuItem ToolBuy;
        private System.Windows.Forms.ToolStripMenuItem ToolTradeValue;
        private System.Windows.Forms.ToolStripMenuItem ToolACB;
    }
}