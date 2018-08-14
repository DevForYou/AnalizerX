namespace WindowsFormsApp1
{
    partial class Form1
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
            this.ZedGraphz = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // ZedGraphz
            // 
            this.ZedGraphz.IsShowPointValues = false;
            this.ZedGraphz.Location = new System.Drawing.Point(12, 12);
            this.ZedGraphz.Name = "ZedGraphz";
            this.ZedGraphz.PointValueFormat = "G";
            this.ZedGraphz.Size = new System.Drawing.Size(550, 378);
            this.ZedGraphz.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 402);
            this.Controls.Add(this.ZedGraphz);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl ZedGraphz;
    }
}