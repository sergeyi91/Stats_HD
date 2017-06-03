namespace HDCLUB_Stat
{
    partial class OpenSiteForm
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
         this.hdclubWebBrowser = new System.Windows.Forms.WebBrowser();
         this.richTextBox1 = new System.Windows.Forms.RichTextBox();
         this.SuspendLayout();
         // 
         // hdclubWebBrowser
         // 
         this.hdclubWebBrowser.Location = new System.Drawing.Point(27, 102);
         this.hdclubWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
         this.hdclubWebBrowser.Name = "hdclubWebBrowser";
         this.hdclubWebBrowser.Size = new System.Drawing.Size(799, 432);
         this.hdclubWebBrowser.TabIndex = 0;
         // 
         // richTextBox1
         // 
         this.richTextBox1.Location = new System.Drawing.Point(27, 12);
         this.richTextBox1.Name = "richTextBox1";
         this.richTextBox1.Size = new System.Drawing.Size(786, 84);
         this.richTextBox1.TabIndex = 1;
         this.richTextBox1.Text = "";
         // 
         // OpenSiteForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(825, 533);
         this.Controls.Add(this.richTextBox1);
         this.Controls.Add(this.hdclubWebBrowser);
         this.Name = "OpenSiteForm";
         this.Text = "OpenSite";
         this.Load += new System.EventHandler(this.loadForm);
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser hdclubWebBrowser;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}