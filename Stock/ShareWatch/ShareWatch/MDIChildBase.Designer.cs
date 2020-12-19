namespace ShareWatch
{
    partial class MDIChildBase
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
            this.ClockTimer = new System.Windows.Forms.Timer(this.components);
            this.ProcessTimer = new System.Windows.Forms.Timer(this.components);
            this.TTip = new System.Windows.Forms.ToolTip(this.components);
            this.EP = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.EP)).BeginInit();
            this.SuspendLayout();
            // 
            // EP
            // 
            this.EP.ContainerControl = this;
            // 
            // MDIChildBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 611);
            this.Name = "MDIChildBase";
            this.Text = "MDIChildBase";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDIChildBase_FormClosing);
            this.Load += new System.EventHandler(this.MDIChildBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer ClockTimer;
        private System.Windows.Forms.Timer ProcessTimer;
        private System.Windows.Forms.ToolTip TTip;
        private System.Windows.Forms.ErrorProvider EP;
    }
}