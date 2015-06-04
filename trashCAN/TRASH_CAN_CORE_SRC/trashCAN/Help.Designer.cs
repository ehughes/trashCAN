namespace trashCAN
{
    partial class Help
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
            this.trashCANHTMLView = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // trashCANHTMLView
            // 
            this.trashCANHTMLView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trashCANHTMLView.Location = new System.Drawing.Point(0, 0);
            this.trashCANHTMLView.MinimumSize = new System.Drawing.Size(20, 20);
            this.trashCANHTMLView.Name = "trashCANHTMLView";
            this.trashCANHTMLView.Size = new System.Drawing.Size(468, 394);
            this.trashCANHTMLView.TabIndex = 0;
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 394);
            this.Controls.Add(this.trashCANHTMLView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Help";
            this.Text = "trashCAN Help";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Help_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser trashCANHTMLView;

    }
}