namespace CorvinMozi {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.panelPictureBox = new System.Windows.Forms.Panel();
            this.iconBox = new System.Windows.Forms.PictureBox();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ButtonStatistics = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPictureBox
            // 
            this.panelPictureBox.AutoSize = true;
            this.panelPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.panelPictureBox.Location = new System.Drawing.Point(173, 46);
            this.panelPictureBox.Name = "panelPictureBox";
            this.panelPictureBox.Size = new System.Drawing.Size(178, 132);
            this.panelPictureBox.TabIndex = 0;
            // 
            // iconBox
            // 
            this.iconBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iconBox.Location = new System.Drawing.Point(26, 46);
            this.iconBox.Name = "iconBox";
            this.iconBox.Size = new System.Drawing.Size(92, 132);
            this.iconBox.TabIndex = 1;
            this.iconBox.TabStop = false;
            // 
            // leftButton
            // 
            this.leftButton.BackColor = System.Drawing.Color.Transparent;
            this.leftButton.BackgroundImage = global::CorvinMozi.Properties.Resources.balnyil;
            this.leftButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.leftButton.FlatAppearance.BorderSize = 0;
            this.leftButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leftButton.Location = new System.Drawing.Point(381, 457);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(87, 48);
            this.leftButton.TabIndex = 2;
            this.leftButton.UseVisualStyleBackColor = false;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.BackgroundImage = global::CorvinMozi.Properties.Resources.jobbra;
            this.rightButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rightButton.FlatAppearance.BorderSize = 0;
            this.rightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rightButton.Location = new System.Drawing.Point(495, 457);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(87, 48);
            this.rightButton.TabIndex = 3;
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(264, 463);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(87, 37);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Mentés";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ButtonStatistics
            // 
            this.ButtonStatistics.Location = new System.Drawing.Point(605, 463);
            this.ButtonStatistics.Name = "ButtonStatistics";
            this.ButtonStatistics.Size = new System.Drawing.Size(87, 37);
            this.ButtonStatistics.TabIndex = 5;
            this.ButtonStatistics.Text = "Statisztikák";
            this.ButtonStatistics.UseVisualStyleBackColor = true;
            this.ButtonStatistics.Click += new System.EventHandler(this.ButtonStatistics_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.panelPictureBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.iconBox);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.ButtonStatistics);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CorvinMozi";
            ((System.ComponentModel.ISupportInitialize)(this.iconBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelPictureBox;
        private System.Windows.Forms.PictureBox iconBox;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ButtonStatistics;
    }
}

