namespace coffee_machine_control
{
    partial class mainControl
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
            this.startBtn1 = new coffee_machine_control.tools.startBtn();
            ((System.ComponentModel.ISupportInitialize)(this.startBtn1)).BeginInit();
            this.SuspendLayout();
            // 
            // startBtn1
            // 
            this.startBtn1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.startBtn1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.startBtn1.ErrorImage = global::coffee_machine_control.Properties.Resources.logo1;
            this.startBtn1.ForeColor = System.Drawing.Color.Transparent;
            this.startBtn1.InitialImage = global::coffee_machine_control.Properties.Resources.logo1;
            this.startBtn1.Location = new System.Drawing.Point(39, 0);
            this.startBtn1.Name = "startBtn1";
            this.startBtn1.Size = new System.Drawing.Size(98, 98);
            this.startBtn1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.startBtn1.TabIndex = 0;
            this.startBtn1.TabStop = false;
            this.startBtn1.Click += new System.EventHandler(this.connectBtn_Click);
            this.startBtn1.MouseEnter += new System.EventHandler(this.startBtn_MouseEnter);
            this.startBtn1.MouseLeave += new System.EventHandler(this.startBtn_MouseLeave);
            // 
            // mainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 101);
            this.Controls.Add(this.startBtn1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mainControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "mainControl";
            ((System.ComponentModel.ISupportInitialize)(this.startBtn1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private tools.startBtn startBtn1;
    }
}