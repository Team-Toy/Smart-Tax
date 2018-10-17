namespace Tax_Calculator
{
    partial class Form1_WelcomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1_WelcomePage));
            this.label3 = new System.Windows.Forms.Label();
            this.btContinue = new MetroFramework.Controls.MetroButton();
            this.btAbout = new MetroFramework.Controls.MetroButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(86, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Smart Tax Calculator";
            // 
            // btContinue
            // 
            this.btContinue.BackColor = System.Drawing.Color.SandyBrown;
            this.btContinue.BackgroundImage = global::Tax_Calculator.Properties.Resources._continue;
            this.btContinue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btContinue.ForeColor = System.Drawing.Color.Black;
            this.btContinue.Location = new System.Drawing.Point(156, 126);
            this.btContinue.Name = "btContinue";
            this.btContinue.Size = new System.Drawing.Size(79, 82);
            this.btContinue.TabIndex = 9;
            this.btContinue.Text = "Continue";
            this.btContinue.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btContinue.UseSelectable = true;
            this.btContinue.Click += new System.EventHandler(this.btContinue_Click);
            // 
            // btAbout
            // 
            this.btAbout.BackgroundImage = global::Tax_Calculator.Properties.Resources.about;
            this.btAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btAbout.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btAbout.Location = new System.Drawing.Point(15, 259);
            this.btAbout.Name = "btAbout";
            this.btAbout.Size = new System.Drawing.Size(55, 62);
            this.btAbout.TabIndex = 11;
            this.btAbout.Text = "About";
            this.btAbout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btAbout.UseSelectable = true;
            this.btAbout.Click += new System.EventHandler(this.btAbout_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Tax_Calculator.Properties.Resources.smart_icon;
            this.pictureBox1.Location = new System.Drawing.Point(32, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(322, 66);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // Form1_WelcomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(447, 322);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btAbout);
            this.Controls.Add(this.btContinue);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1_WelcomePage";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroButton btContinue;
        private MetroFramework.Controls.MetroButton btAbout;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}