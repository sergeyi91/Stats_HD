namespace HDCLUB_Stat
{
    partial class MainForm
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
         this.inputFileTextBox = new System.Windows.Forms.TextBox();
         this.baseOfTorrentsPathTextBox = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.analyzeButton = new System.Windows.Forms.Button();
         this.richTextBox1 = new System.Windows.Forms.RichTextBox();
         this.analyzeAllCheckBox = new System.Windows.Forms.CheckBox();
         this.resultsButton = new System.Windows.Forms.Button();
         this.label3 = new System.Windows.Forms.Label();
         this.resultsFileTextBox = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.reportFileTextBox = new System.Windows.Forms.TextBox();
         this.reportButton = new System.Windows.Forms.Button();
         this.uploadLiveTextBox = new System.Windows.Forms.TextBox();
         this.uploadLiveButton = new System.Windows.Forms.Button();
         this.label5 = new System.Windows.Forms.Label();
         this.editBaseButton = new System.Windows.Forms.Button();
         this.button1 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // inputFileTextBox
         // 
         this.inputFileTextBox.Location = new System.Drawing.Point(154, 28);
         this.inputFileTextBox.Name = "inputFileTextBox";
         this.inputFileTextBox.Size = new System.Drawing.Size(208, 20);
         this.inputFileTextBox.TabIndex = 0;
         this.inputFileTextBox.Text = "D:\\HDCLUB_Stat\\15.05.2013.htm";
         // 
         // baseOfTorrentsPathTextBox
         // 
         this.baseOfTorrentsPathTextBox.Location = new System.Drawing.Point(154, 62);
         this.baseOfTorrentsPathTextBox.Name = "baseOfTorrentsPathTextBox";
         this.baseOfTorrentsPathTextBox.Size = new System.Drawing.Size(208, 20);
         this.baseOfTorrentsPathTextBox.TabIndex = 1;
         this.baseOfTorrentsPathTextBox.Text = "D:\\HDCLUB_Base.xml";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(56, 68);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(31, 13);
         this.label1.TabIndex = 2;
         this.label1.Text = "Base";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(57, 30);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(50, 13);
         this.label2.TabIndex = 3;
         this.label2.Text = "Input File";
         // 
         // analyzeButton
         // 
         this.analyzeButton.Location = new System.Drawing.Point(429, 42);
         this.analyzeButton.Name = "analyzeButton";
         this.analyzeButton.Size = new System.Drawing.Size(75, 23);
         this.analyzeButton.TabIndex = 4;
         this.analyzeButton.Text = "Analyze";
         this.analyzeButton.UseVisualStyleBackColor = true;
         this.analyzeButton.Click += new System.EventHandler(this.button1_Click);
         // 
         // richTextBox1
         // 
         this.richTextBox1.Location = new System.Drawing.Point(64, 218);
         this.richTextBox1.Name = "richTextBox1";
         this.richTextBox1.Size = new System.Drawing.Size(590, 121);
         this.richTextBox1.TabIndex = 5;
         this.richTextBox1.Text = "";
         // 
         // analyzeAllCheckBox
         // 
         this.analyzeAllCheckBox.AutoSize = true;
         this.analyzeAllCheckBox.Location = new System.Drawing.Point(581, 38);
         this.analyzeAllCheckBox.Name = "analyzeAllCheckBox";
         this.analyzeAllCheckBox.Size = new System.Drawing.Size(74, 17);
         this.analyzeAllCheckBox.TabIndex = 6;
         this.analyzeAllCheckBox.Text = "AnalyzeAll";
         this.analyzeAllCheckBox.UseVisualStyleBackColor = true;
         // 
         // resultsButton
         // 
         this.resultsButton.Location = new System.Drawing.Point(429, 98);
         this.resultsButton.Name = "resultsButton";
         this.resultsButton.Size = new System.Drawing.Size(75, 23);
         this.resultsButton.TabIndex = 7;
         this.resultsButton.Text = "Results";
         this.resultsButton.UseVisualStyleBackColor = true;
         this.resultsButton.Click += new System.EventHandler(this.button2_Click);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(54, 104);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(61, 13);
         this.label3.TabIndex = 8;
         this.label3.Text = "Results File";
         // 
         // resultsFileTextBox
         // 
         this.resultsFileTextBox.Location = new System.Drawing.Point(154, 101);
         this.resultsFileTextBox.Name = "resultsFileTextBox";
         this.resultsFileTextBox.Size = new System.Drawing.Size(208, 20);
         this.resultsFileTextBox.TabIndex = 9;
         this.resultsFileTextBox.Text = "D:\\HDCLUB_results.txt";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(53, 144);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(81, 13);
         this.label4.TabIndex = 10;
         this.label4.Text = "LastDay Report";
         // 
         // reportFileTextBox
         // 
         this.reportFileTextBox.Location = new System.Drawing.Point(154, 140);
         this.reportFileTextBox.Name = "reportFileTextBox";
         this.reportFileTextBox.Size = new System.Drawing.Size(208, 20);
         this.reportFileTextBox.TabIndex = 11;
         this.reportFileTextBox.Text = "D:\\HDCLUB_report.txt";
         // 
         // reportButton
         // 
         this.reportButton.Location = new System.Drawing.Point(429, 139);
         this.reportButton.Name = "reportButton";
         this.reportButton.Size = new System.Drawing.Size(75, 23);
         this.reportButton.TabIndex = 12;
         this.reportButton.Text = "Report";
         this.reportButton.UseVisualStyleBackColor = true;
         this.reportButton.Click += new System.EventHandler(this.button3_Click);
         // 
         // uploadLiveTextBox
         // 
         this.uploadLiveTextBox.Location = new System.Drawing.Point(154, 178);
         this.uploadLiveTextBox.Name = "uploadLiveTextBox";
         this.uploadLiveTextBox.Size = new System.Drawing.Size(208, 20);
         this.uploadLiveTextBox.TabIndex = 13;
         this.uploadLiveTextBox.Text = "D:\\HDCLUB_uploadLive.txt";
         // 
         // uploadLiveButton
         // 
         this.uploadLiveButton.Location = new System.Drawing.Point(429, 174);
         this.uploadLiveButton.Name = "uploadLiveButton";
         this.uploadLiveButton.Size = new System.Drawing.Size(75, 23);
         this.uploadLiveButton.TabIndex = 14;
         this.uploadLiveButton.Text = "Upload Live";
         this.uploadLiveButton.UseVisualStyleBackColor = true;
         this.uploadLiveButton.Click += new System.EventHandler(this.uploadLiveButton_Click);
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(51, 181);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(96, 13);
         this.label5.TabIndex = 15;
         this.label5.Text = "UploadLive Report";
         // 
         // editBaseButton
         // 
         this.editBaseButton.Location = new System.Drawing.Point(554, 121);
         this.editBaseButton.Name = "editBaseButton";
         this.editBaseButton.Size = new System.Drawing.Size(75, 23);
         this.editBaseButton.TabIndex = 16;
         this.editBaseButton.Text = "Edit Base";
         this.editBaseButton.UseVisualStyleBackColor = true;
         this.editBaseButton.Click += new System.EventHandler(this.editBaseOfTorrentsButton_Click);
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(554, 174);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 17;
         this.button1.Text = "OpenSite";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click_1);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(698, 351);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.editBaseButton);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.uploadLiveButton);
         this.Controls.Add(this.uploadLiveTextBox);
         this.Controls.Add(this.reportButton);
         this.Controls.Add(this.reportFileTextBox);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.resultsFileTextBox);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.resultsButton);
         this.Controls.Add(this.analyzeAllCheckBox);
         this.Controls.Add(this.richTextBox1);
         this.Controls.Add(this.analyzeButton);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.baseOfTorrentsPathTextBox);
         this.Controls.Add(this.inputFileTextBox);
         this.Name = "MainForm";
         this.Text = "Form1";
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputFileTextBox;
        private System.Windows.Forms.TextBox baseOfTorrentsPathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button analyzeButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox analyzeAllCheckBox;
        private System.Windows.Forms.Button resultsButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox resultsFileTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox reportFileTextBox;
        private System.Windows.Forms.Button reportButton;
        private System.Windows.Forms.TextBox uploadLiveTextBox;
        private System.Windows.Forms.Button uploadLiveButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button editBaseButton;
        private System.Windows.Forms.Button button1;
    }
}

