namespace ShareWatch.EntryScreen
{
    partial class PortFolioEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PortFolioEntry));
            this.EP = new System.Windows.Forms.ErrorProvider(this.components);
            this.SBar = new System.Windows.Forms.StatusStrip();
            this.lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuyMore = new System.Windows.Forms.Button();
            this.TractionActionDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.TractionActionCode = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.TotalAmnt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CostBasisAmnt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SharesCount = new System.Windows.Forms.TextBox();
            this.TransID = new System.Windows.Forms.TextBox();
            this.TradeName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TradeCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AccountID = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.EP)).BeginInit();
            this.SBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // EP
            // 
            this.EP.ContainerControl = this;
            // 
            // SBar
            // 
            this.SBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMessage});
            this.SBar.Location = new System.Drawing.Point(0, 222);
            this.SBar.Name = "SBar";
            this.SBar.Size = new System.Drawing.Size(789, 22);
            this.SBar.TabIndex = 0;
            // 
            // lblMessage
            // 
            this.lblMessage.Image = ((System.Drawing.Image)(resources.GetObject("lblMessage.Image")));
            this.lblMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMessage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(774, 17);
            this.lblMessage.Spring = true;
            this.lblMessage.Text = "Ready";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.splitContainer1.Panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitContainer1.Panel1.BackgroundImage")));
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitContainer1.Panel2.BackgroundImage")));
            this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer1.Panel2.Controls.Add(this.btnBuyMore);
            this.splitContainer1.Panel2.Controls.Add(this.TractionActionDate);
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Panel2.Controls.Add(this.TractionActionCode);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.btnClear);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.TotalAmnt);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.CostBasisAmnt);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.SharesCount);
            this.splitContainer1.Panel2.Controls.Add(this.TransID);
            this.splitContainer1.Panel2.Controls.Add(this.TradeName);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.TradeCode);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.AccountID);
            this.splitContainer1.Size = new System.Drawing.Size(789, 222);
            this.splitContainer1.SplitterDistance = 28;
            this.splitContainer1.TabIndex = 2;
            this.splitContainer1.Text = "splitContainer1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(331, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Portfoilo Entry";
            // 
            // btnBuyMore
            // 
            this.btnBuyMore.Location = new System.Drawing.Point(147, 134);
            this.btnBuyMore.Name = "btnBuyMore";
            this.btnBuyMore.Size = new System.Drawing.Size(75, 26);
            this.btnBuyMore.TabIndex = 7;
            this.btnBuyMore.Text = "&More Trade";
            this.btnBuyMore.UseVisualStyleBackColor = true;
            this.btnBuyMore.Click += new System.EventHandler(this.BtnBuyMore_Click);
            // 
            // TractionActionDate
            // 
            this.TractionActionDate.CustomFormat = "MM/dd/yyyy";
            this.TractionActionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TractionActionDate.Location = new System.Drawing.Point(679, 72);
            this.TractionActionDate.Name = "TractionActionDate";
            this.TractionActionDate.Size = new System.Drawing.Size(98, 23);
            this.TractionActionDate.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(648, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 15);
            this.label10.TabIndex = 1;
            this.label10.Text = "On";
            // 
            // TractionActionCode
            // 
            this.TractionActionCode.FormattingEnabled = true;
            this.TractionActionCode.Location = new System.Drawing.Point(459, 72);
            this.TractionActionCode.Name = "TractionActionCode";
            this.TractionActionCode.Size = new System.Drawing.Size(121, 23);
            this.TractionActionCode.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(406, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 15);
            this.label9.TabIndex = 1;
            this.label9.Text = "Action";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(225, 134);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 26);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(70, 134);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 26);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(183, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "Total Cost";
            // 
            // TotalAmnt
            // 
            this.TotalAmnt.Location = new System.Drawing.Point(249, 102);
            this.TotalAmnt.Name = "TotalAmnt";
            this.TotalAmnt.ReadOnly = true;
            this.TotalAmnt.Size = new System.Drawing.Size(140, 23);
            this.TotalAmnt.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(204, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 1;
            this.label7.Text = "Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(183, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Cost Basis";
            // 
            // CostBasisAmnt
            // 
            this.CostBasisAmnt.Location = new System.Drawing.Point(249, 72);
            this.CostBasisAmnt.Name = "CostBasisAmnt";
            this.CostBasisAmnt.Size = new System.Drawing.Size(140, 23);
            this.CostBasisAmnt.TabIndex = 4;
            this.CostBasisAmnt.TextChanged += new System.EventHandler(this.SharesCount_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(12, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Shares #";
            // 
            // SharesCount
            // 
            this.SharesCount.Location = new System.Drawing.Point(69, 72);
            this.SharesCount.Name = "SharesCount";
            this.SharesCount.Size = new System.Drawing.Size(98, 23);
            this.SharesCount.TabIndex = 3;
            this.SharesCount.TextChanged += new System.EventHandler(this.SharesCount_TextChanged);
            // 
            // TransID
            // 
            this.TransID.Location = new System.Drawing.Point(696, 10);
            this.TransID.Name = "TransID";
            this.TransID.ReadOnly = true;
            this.TransID.Size = new System.Drawing.Size(80, 23);
            this.TransID.TabIndex = 0;
            // 
            // TradeName
            // 
            this.TradeName.Location = new System.Drawing.Point(249, 42);
            this.TradeName.Name = "TradeName";
            this.TradeName.ReadOnly = true;
            this.TradeName.Size = new System.Drawing.Size(527, 23);
            this.TradeName.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(12, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Trade";
            // 
            // TradeCode
            // 
            this.TradeCode.Location = new System.Drawing.Point(70, 42);
            this.TradeCode.Name = "TradeCode";
            this.TradeCode.Size = new System.Drawing.Size(62, 23);
            this.TradeCode.TabIndex = 2;
            this.TradeCode.TextChanged += new System.EventHandler(this.TradeCode_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(609, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Transaction ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Account";
            // 
            // AccountID
            // 
            this.AccountID.FormattingEnabled = true;
            this.AccountID.Location = new System.Drawing.Point(70, 13);
            this.AccountID.Name = "AccountID";
            this.AccountID.Size = new System.Drawing.Size(431, 23);
            this.AccountID.TabIndex = 1;
            // 
            // PortFolioEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 244);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.SBar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PortFolioEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PortFolio Entry";
            this.Load += new System.EventHandler(this.PortFolioEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EP)).EndInit();
            this.SBar.ResumeLayout(false);
            this.SBar.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider EP;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip SBar;
        private System.Windows.Forms.ToolStripStatusLabel lblMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox AccountID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TotalAmnt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CostBasisAmnt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SharesCount;
        private System.Windows.Forms.TextBox TransID;
        private System.Windows.Forms.TextBox TradeName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TradeCode;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox TractionActionCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker TractionActionDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnBuyMore;
    }
}