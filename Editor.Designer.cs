namespace HitboxEditor01
{
    partial class Editor
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.currFrameLabel = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.labelMousePos = new System.Windows.Forms.Label();
            this.labelCenterOffset = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(560, 560);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // currFrameLabel
            // 
            this.currFrameLabel.AutoSize = true;
            this.currFrameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currFrameLabel.Location = new System.Drawing.Point(573, 12);
            this.currFrameLabel.Name = "currFrameLabel";
            this.currFrameLabel.Size = new System.Drawing.Size(47, 25);
            this.currFrameLabel.TabIndex = 1;
            this.currFrameLabel.Text = "-----";
            // 
            // labelMousePos
            // 
            this.labelMousePos.AutoSize = true;
            this.labelMousePos.Location = new System.Drawing.Point(13, 13);
            this.labelMousePos.Name = "labelMousePos";
            this.labelMousePos.Size = new System.Drawing.Size(29, 13);
            this.labelMousePos.TabIndex = 2;
            this.labelMousePos.Text = "(x, x)";
            // 
            // labelCenterOffset
            // 
            this.labelCenterOffset.AutoSize = true;
            this.labelCenterOffset.Location = new System.Drawing.Point(12, 35);
            this.labelCenterOffset.Name = "labelCenterOffset";
            this.labelCenterOffset.Size = new System.Drawing.Size(29, 13);
            this.labelCenterOffset.TabIndex = 3;
            this.labelCenterOffset.Text = "(x, x)";
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 538);
            this.Controls.Add(this.labelCenterOffset);
            this.Controls.Add(this.labelMousePos);
            this.Controls.Add(this.currFrameLabel);
            this.Controls.Add(this.pictureBox);
            this.DoubleBuffered = true;
            this.Name = "Editor";
            this.Text = "Editor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Editor_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Editor_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label currFrameLabel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label labelMousePos;
        private System.Windows.Forms.Label labelCenterOffset;
    }
}