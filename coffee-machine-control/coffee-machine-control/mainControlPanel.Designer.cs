namespace coffee_machine_control
{
    partial class mainControlPanel
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
            this.americanoBtn = new coffee_machine_control.tools.startBtn();
            this.espressoBtn = new coffee_machine_control.tools.startBtn();
            this.espressoLbl = new System.Windows.Forms.Label();
            this.cornerCut = new coffee_machine_control.tools.startBtn();
            this.espressoPanel = new System.Windows.Forms.Panel();
            this.machiatoPanel = new System.Windows.Forms.Panel();
            this.machiatoLbl = new System.Windows.Forms.Label();
            this.machiatoBtn = new coffee_machine_control.tools.startBtn();
            this.americanoPanel = new System.Windows.Forms.Panel();
            this.americanoLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.americanoBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.espressoBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cornerCut)).BeginInit();
            this.espressoPanel.SuspendLayout();
            this.machiatoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.machiatoBtn)).BeginInit();
            this.americanoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // americanoBtn
            // 
            this.americanoBtn.BackColor = System.Drawing.SystemColors.Control;
            this.americanoBtn.Image = global::coffee_machine_control.Properties.Resources.cof3;
            this.americanoBtn.Location = new System.Drawing.Point(8, 2);
            this.americanoBtn.Margin = new System.Windows.Forms.Padding(2);
            this.americanoBtn.Name = "americanoBtn";
            this.americanoBtn.Size = new System.Drawing.Size(74, 80);
            this.americanoBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.americanoBtn.TabIndex = 2;
            this.americanoBtn.TabStop = false;
            this.americanoBtn.MouseEnter += new System.EventHandler(this.americano_MouseEnter);
            this.americanoBtn.MouseLeave += new System.EventHandler(this.americano_MouseLeave);
            // 
            // espressoBtn
            // 
            this.espressoBtn.BackColor = System.Drawing.SystemColors.Control;
            this.espressoBtn.Image = global::coffee_machine_control.Properties.Resources.cof1;
            this.espressoBtn.Location = new System.Drawing.Point(8, 4);
            this.espressoBtn.Margin = new System.Windows.Forms.Padding(2);
            this.espressoBtn.Name = "espressoBtn";
            this.espressoBtn.Size = new System.Drawing.Size(74, 80);
            this.espressoBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.espressoBtn.TabIndex = 0;
            this.espressoBtn.TabStop = false;
            this.espressoBtn.MouseEnter += new System.EventHandler(this.espresso_MouseEnter);
            this.espressoBtn.MouseLeave += new System.EventHandler(this.machiato_MouseEnter);
            // 
            // espressoLbl
            // 
            this.espressoLbl.AutoSize = true;
            this.espressoLbl.Location = new System.Drawing.Point(101, 37);
            this.espressoLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.espressoLbl.MaximumSize = new System.Drawing.Size(248, 0);
            this.espressoLbl.Name = "espressoLbl";
            this.espressoLbl.Size = new System.Drawing.Size(243, 13);
            this.espressoLbl.TabIndex = 3;
            this.espressoLbl.Text = "Espresso is rich in coffee flavour but bitter in taste.";
            this.espressoLbl.MouseEnter += new System.EventHandler(this.espresso_MouseEnter);
            this.espressoLbl.MouseLeave += new System.EventHandler(this.espresso_MouseLeave);
            // 
            // cornerCut
            // 
            this.cornerCut.BackColor = System.Drawing.SystemColors.Control;
            this.cornerCut.Location = new System.Drawing.Point(301, 246);
            this.cornerCut.Margin = new System.Windows.Forms.Padding(2);
            this.cornerCut.Name = "cornerCut";
            this.cornerCut.Size = new System.Drawing.Size(74, 80);
            this.cornerCut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cornerCut.TabIndex = 6;
            this.cornerCut.TabStop = false;
            // 
            // espressoPanel
            // 
            this.espressoPanel.BackColor = System.Drawing.Color.White;
            this.espressoPanel.Controls.Add(this.espressoBtn);
            this.espressoPanel.Controls.Add(this.espressoLbl);
            this.espressoPanel.Location = new System.Drawing.Point(1, 10);
            this.espressoPanel.Margin = new System.Windows.Forms.Padding(2);
            this.espressoPanel.Name = "espressoPanel";
            this.espressoPanel.Size = new System.Drawing.Size(356, 91);
            this.espressoPanel.TabIndex = 7;
            this.espressoPanel.MouseEnter += new System.EventHandler(this.espresso_MouseEnter);
            this.espressoPanel.MouseLeave += new System.EventHandler(this.espresso_MouseLeave);
            // 
            // machiatoPanel
            // 
            this.machiatoPanel.Controls.Add(this.machiatoLbl);
            this.machiatoPanel.Controls.Add(this.machiatoBtn);
            this.machiatoPanel.Location = new System.Drawing.Point(1, 106);
            this.machiatoPanel.Margin = new System.Windows.Forms.Padding(2);
            this.machiatoPanel.Name = "machiatoPanel";
            this.machiatoPanel.Size = new System.Drawing.Size(356, 91);
            this.machiatoPanel.TabIndex = 8;
            this.machiatoPanel.MouseEnter += new System.EventHandler(this.machiato_MouseEnter);
            this.machiatoPanel.MouseLeave += new System.EventHandler(this.machiato_MouseLeave);
            // 
            // machiatoLbl
            // 
            this.machiatoLbl.AutoSize = true;
            this.machiatoLbl.Location = new System.Drawing.Point(101, 32);
            this.machiatoLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.machiatoLbl.MaximumSize = new System.Drawing.Size(248, 0);
            this.machiatoLbl.Name = "machiatoLbl";
            this.machiatoLbl.Size = new System.Drawing.Size(215, 26);
            this.machiatoLbl.TabIndex = 5;
            this.machiatoLbl.Text = "Machiato is rich in coffee flavour but slightly sweeter as compared to Espresso.";
            this.machiatoLbl.MouseEnter += new System.EventHandler(this.machiato_MouseEnter);
            this.machiatoLbl.MouseLeave += new System.EventHandler(this.machiato_MouseLeave);
            // 
            // machiatoBtn
            // 
            this.machiatoBtn.BackColor = System.Drawing.SystemColors.Control;
            this.machiatoBtn.Image = global::coffee_machine_control.Properties.Resources.cof2;
            this.machiatoBtn.Location = new System.Drawing.Point(8, 2);
            this.machiatoBtn.Margin = new System.Windows.Forms.Padding(2);
            this.machiatoBtn.Name = "machiatoBtn";
            this.machiatoBtn.Size = new System.Drawing.Size(74, 80);
            this.machiatoBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.machiatoBtn.TabIndex = 4;
            this.machiatoBtn.TabStop = false;
            this.machiatoBtn.MouseEnter += new System.EventHandler(this.machiato_MouseEnter);
            this.machiatoBtn.MouseLeave += new System.EventHandler(this.machiato_MouseLeave);
            // 
            // americanoPanel
            // 
            this.americanoPanel.Controls.Add(this.americanoLbl);
            this.americanoPanel.Controls.Add(this.americanoBtn);
            this.americanoPanel.Location = new System.Drawing.Point(1, 202);
            this.americanoPanel.Margin = new System.Windows.Forms.Padding(2);
            this.americanoPanel.Name = "americanoPanel";
            this.americanoPanel.Size = new System.Drawing.Size(356, 91);
            this.americanoPanel.TabIndex = 9;
            this.americanoPanel.MouseEnter += new System.EventHandler(this.americano_MouseEnter);
            this.americanoPanel.MouseLeave += new System.EventHandler(this.americano_MouseLeave);
            // 
            // americanoLbl
            // 
            this.americanoLbl.AutoSize = true;
            this.americanoLbl.Location = new System.Drawing.Point(101, 37);
            this.americanoLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.americanoLbl.MaximumSize = new System.Drawing.Size(248, 0);
            this.americanoLbl.Name = "americanoLbl";
            this.americanoLbl.Size = new System.Drawing.Size(172, 13);
            this.americanoLbl.TabIndex = 6;
            this.americanoLbl.Text = "Americano is just water and coffee.";
            this.americanoLbl.MouseEnter += new System.EventHandler(this.americano_MouseEnter);
            this.americanoLbl.MouseLeave += new System.EventHandler(this.americano_MouseLeave);
            // 
            // mainControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(356, 302);
            this.Controls.Add(this.machiatoPanel);
            this.Controls.Add(this.espressoPanel);
            this.Controls.Add(this.cornerCut);
            this.Controls.Add(this.americanoPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "mainControlPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "mainControlPanel";
            ((System.ComponentModel.ISupportInitialize)(this.americanoBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.espressoBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cornerCut)).EndInit();
            this.espressoPanel.ResumeLayout(false);
            this.espressoPanel.PerformLayout();
            this.machiatoPanel.ResumeLayout(false);
            this.machiatoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.machiatoBtn)).EndInit();
            this.americanoPanel.ResumeLayout(false);
            this.americanoPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private tools.startBtn espressoBtn;
        private tools.startBtn americanoBtn;
        private System.Windows.Forms.Label espressoLbl;
        private tools.startBtn cornerCut;
        private System.Windows.Forms.Panel espressoPanel;
        private System.Windows.Forms.Panel machiatoPanel;
        private System.Windows.Forms.Label machiatoLbl;
        private tools.startBtn machiatoBtn;
        private System.Windows.Forms.Panel americanoPanel;
        private System.Windows.Forms.Label americanoLbl;
    }
}