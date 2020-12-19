
namespace ShareWatch.EntryScreen
{
    partial class CostBaseAdjuster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CostBaseAdjuster));
            this.Split = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.CostBasisAmnt = new System.Windows.Forms.TextBox();
            this.TradeName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TradeCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AccountID = new System.Windows.Forms.ComboBox();
            this.SBar = new System.Windows.Forms.StatusStrip();
            this.lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.EP = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Split)).BeginInit();
            this.Split.Panel1.SuspendLayout();
            this.Split.Panel2.SuspendLayout();
            this.Split.SuspendLayout();
            this.SBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EP)).BeginInit();
            this.SuspendLayout();
            // 
            // Split
            // 
            this.Split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Split.IsSplitterFixed = true;
            this.Split.Location = new System.Drawing.Point(0, 0);
            this.Split.Name = "Split";
            this.Split.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Split.Panel1
            // 
            this.Split.Panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Split.Panel1.BackgroundImage")));
            this.Split.Panel1.Controls.Add(this.label1);
            this.Split.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Split_Panel1_Paint);
            // 
            // Split.Panel2
            // 
            this.Split.Panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Split.Panel2.BackgroundImage")));
            this.Split.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Split.Panel2.Controls.Add(this.btnSave);
            this.Split.Panel2.Controls.Add(this.label6);
            this.Split.Panel2.Controls.Add(this.CostBasisAmnt);
            this.Split.Panel2.Controls.Add(this.TradeName);
            this.Split.Panel2.Controls.Add(this.label4);
            this.Split.Panel2.Controls.Add(this.TradeCode);
            this.Split.Panel2.Controls.Add(this.label2);
            this.Split.Panel2.Controls.Add(this.AccountID);
            this.Split.Panel2.Controls.Add(this.SBar);
            this.Split.Panel2MinSize = 35;
            this.Split.Size = new System.Drawing.Size(480, 186);
            this.Split.SplitterDistance = 35;
            this.Split.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bradley Hand ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cost Basis Correction";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(66, 98);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 26);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(6, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "Cost Basis";
            // 
            // CostBasisAmnt
            // 
            this.CostBasisAmnt.Location = new System.Drawing.Point(66, 69);
            this.CostBasisAmnt.Name = "CostBasisAmnt";
            this.CostBasisAmnt.Size = new System.Drawing.Size(140, 23);
            this.CostBasisAmnt.TabIndex = 8;
            // 
            // TradeName
            // 
            this.TradeName.Location = new System.Drawing.Point(134, 37);
            this.TradeName.Name = "TradeName";
            this.TradeName.ReadOnly = true;
            this.TradeName.Size = new System.Drawing.Size(332, 23);
            this.TradeName.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(10, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Trade";
            // 
            // TradeCode
            // 
            this.TradeCode.Location = new System.Drawing.Point(66, 37);
            this.TradeCode.Name = "TradeCode";
            this.TradeCode.ReadOnly = true;
            this.TradeCode.Size = new System.Drawing.Size(62, 23);
            this.TradeCode.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(8, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Account";
            // 
            // AccountID
            // 
            this.AccountID.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.AccountID.Enabled = false;
            this.AccountID.FormattingEnabled = true;
            this.AccountID.Location = new System.Drawing.Point(66, 9);
            this.AccountID.Name = "AccountID";
            this.AccountID.Size = new System.Drawing.Size(400, 23);
            this.AccountID.TabIndex = 3;
            // 
            // SBar
            // 
            this.SBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMessage});
            this.SBar.Location = new System.Drawing.Point(0, 125);
            this.SBar.Name = "SBar";
            this.SBar.Size = new System.Drawing.Size(480, 22);
            this.SBar.TabIndex = 0;
            this.SBar.Text = "statusStrip1";
            // 
            // lblMessage
            // 
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(39, 17);
            this.lblMessage.Text = "Ready";
            // 
            // EP
            // 
            this.EP.ContainerControl = this;
            // 
            // CostBaseAdjuster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 186);
            this.Controls.Add(this.Split);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CostBaseAdjuster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cost Base Adjuster";
            this.Load += new System.EventHandler(this.CostBaseAdjuster_Load);
            this.Split.Panel1.ResumeLayout(false);
            this.Split.Panel1.PerformLayout();
            this.Split.Panel2.ResumeLayout(false);
            this.Split.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Split)).EndInit();
            this.Split.ResumeLayout(false);
            this.SBar.ResumeLayout(false);
            this.SBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer Split;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip SBar;
        private System.Windows.Forms.ToolStripStatusLabel lblMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox AccountID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TradeCode;
        private System.Windows.Forms.TextBox TradeName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CostBasisAmnt;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider EP;
    }
}