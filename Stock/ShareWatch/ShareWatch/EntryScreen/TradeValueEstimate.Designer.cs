
namespace ShareWatch.EntryScreen
{
    partial class TradeValueEstimate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TradeValueEstimate));
            this.SBar = new System.Windows.Forms.StatusStrip();
            this.lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.TradeCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TradeName = new System.Windows.Forms.TextBox();
            this.panHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BuyAtAmnt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SellAtAmnt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CurrentAmnt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Week52HighAmnt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Week8HighAmnt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Week8LowAmnt = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.SoldOnDate = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SoldAtAmnt = new System.Windows.Forms.TextBox();
            this.SBar.SuspendLayout();
            this.panHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // SBar
            // 
            this.SBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMessage});
            this.SBar.Location = new System.Drawing.Point(0, 165);
            this.SBar.Name = "SBar";
            this.SBar.Size = new System.Drawing.Size(593, 22);
            this.SBar.TabIndex = 0;
            // 
            // lblMessage
            // 
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(39, 17);
            this.lblMessage.Text = "Ready";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(4, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Trade";
            // 
            // TradeCode
            // 
            this.TradeCode.Location = new System.Drawing.Point(55, 49);
            this.TradeCode.Name = "TradeCode";
            this.TradeCode.Size = new System.Drawing.Size(85, 23);
            this.TradeCode.TabIndex = 4;
            this.TradeCode.TextChanged += new System.EventHandler(this.TradeCode_TextChanged);
            this.TradeCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TradeCode_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(154, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Name";
            // 
            // TradeName
            // 
            this.TradeName.Location = new System.Drawing.Point(200, 49);
            this.TradeName.Name = "TradeName";
            this.TradeName.ReadOnly = true;
            this.TradeName.Size = new System.Drawing.Size(377, 23);
            this.TradeName.TabIndex = 5;
            // 
            // panHeader
            // 
            this.panHeader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panHeader.BackgroundImage")));
            this.panHeader.Controls.Add(this.label1);
            this.panHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panHeader.Font = new System.Drawing.Font("Pristina", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panHeader.Location = new System.Drawing.Point(0, 0);
            this.panHeader.Name = "panHeader";
            this.panHeader.Size = new System.Drawing.Size(593, 35);
            this.panHeader.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estimated Trade Value";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(4, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Buy At";
            // 
            // BuyAtAmnt
            // 
            this.BuyAtAmnt.Location = new System.Drawing.Point(55, 105);
            this.BuyAtAmnt.Name = "BuyAtAmnt";
            this.BuyAtAmnt.Size = new System.Drawing.Size(85, 23);
            this.BuyAtAmnt.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(157, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Sell At";
            // 
            // SellAtAmnt
            // 
            this.SellAtAmnt.Location = new System.Drawing.Point(199, 106);
            this.SellAtAmnt.Name = "SellAtAmnt";
            this.SellAtAmnt.Size = new System.Drawing.Size(85, 23);
            this.SellAtAmnt.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(3, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Current";
            // 
            // CurrentAmnt
            // 
            this.CurrentAmnt.Location = new System.Drawing.Point(55, 77);
            this.CurrentAmnt.Name = "CurrentAmnt";
            this.CurrentAmnt.ReadOnly = true;
            this.CurrentAmnt.Size = new System.Drawing.Size(85, 23);
            this.CurrentAmnt.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(141, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "52W Max";
            // 
            // Week52HighAmnt
            // 
            this.Week52HighAmnt.Location = new System.Drawing.Point(200, 77);
            this.Week52HighAmnt.Name = "Week52HighAmnt";
            this.Week52HighAmnt.ReadOnly = true;
            this.Week52HighAmnt.Size = new System.Drawing.Size(85, 23);
            this.Week52HighAmnt.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(289, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "8W Low";
            // 
            // Week8HighAmnt
            // 
            this.Week8HighAmnt.Location = new System.Drawing.Point(345, 77);
            this.Week8HighAmnt.Name = "Week8HighAmnt";
            this.Week8HighAmnt.ReadOnly = true;
            this.Week8HighAmnt.Size = new System.Drawing.Size(85, 23);
            this.Week8HighAmnt.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(436, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 15);
            this.label9.TabIndex = 19;
            this.label9.Text = "8W High";
            // 
            // Week8LowAmnt
            // 
            this.Week8LowAmnt.Location = new System.Drawing.Point(492, 77);
            this.Week8LowAmnt.Name = "Week8LowAmnt";
            this.Week8LowAmnt.ReadOnly = true;
            this.Week8LowAmnt.Size = new System.Drawing.Size(85, 23);
            this.Week8LowAmnt.TabIndex = 18;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(53, 134);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 26);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(463, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 15);
            this.label10.TabIndex = 24;
            this.label10.Text = "On";
            // 
            // SoldOnDate
            // 
            this.SoldOnDate.Location = new System.Drawing.Point(492, 109);
            this.SoldOnDate.Name = "SoldOnDate";
            this.SoldOnDate.ReadOnly = true;
            this.SoldOnDate.Size = new System.Drawing.Size(85, 23);
            this.SoldOnDate.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(289, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 15);
            this.label11.TabIndex = 22;
            this.label11.Text = "Last Sold";
            // 
            // SoldAtAmnt
            // 
            this.SoldAtAmnt.Location = new System.Drawing.Point(345, 109);
            this.SoldAtAmnt.Name = "SoldAtAmnt";
            this.SoldAtAmnt.ReadOnly = true;
            this.SoldAtAmnt.Size = new System.Drawing.Size(85, 23);
            this.SoldAtAmnt.TabIndex = 21;
            // 
            // TradeValueEstimate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(593, 187);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.SoldOnDate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.SoldAtAmnt);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Week8LowAmnt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Week8HighAmnt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Week52HighAmnt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CurrentAmnt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SellAtAmnt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BuyAtAmnt);
            this.Controls.Add(this.panHeader);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TradeName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TradeCode);
            this.Controls.Add(this.SBar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TradeValueEstimate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Estimated Trade Value";
            this.Load += new System.EventHandler(this.TradeValueEstimate_Load);
            this.SBar.ResumeLayout(false);
            this.SBar.PerformLayout();
            this.panHeader.ResumeLayout(false);
            this.panHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip SBar;
        private System.Windows.Forms.ToolStripStatusLabel lblMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TradeCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TradeName;
        private System.Windows.Forms.Panel panHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox BuyAtAmnt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SellAtAmnt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CurrentAmnt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Week52HighAmnt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Week8HighAmnt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Week8LowAmnt;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox SoldOnDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox SoldAtAmnt;
    }
}