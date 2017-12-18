namespace HitboxEditor01
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
            this.openButton = new System.Windows.Forms.Button();
            this.tileWidthBox = new System.Windows.Forms.TextBox();
            this.tileHeightBox = new System.Windows.Forms.TextBox();
            this.getSpriteSheetButton = new System.Windows.Forms.Button();
            this.spriteNameLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.startEditorButton = new System.Windows.Forms.Button();
            this.startIndexBox = new System.Windows.Forms.TextBox();
            this.numTilesBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(39, 12);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // tileWidthBox
            // 
            this.tileWidthBox.Location = new System.Drawing.Point(39, 134);
            this.tileWidthBox.Name = "tileWidthBox";
            this.tileWidthBox.Size = new System.Drawing.Size(77, 20);
            this.tileWidthBox.TabIndex = 2;
            // 
            // tileHeightBox
            // 
            this.tileHeightBox.Location = new System.Drawing.Point(122, 134);
            this.tileHeightBox.Name = "tileHeightBox";
            this.tileHeightBox.Size = new System.Drawing.Size(77, 20);
            this.tileHeightBox.TabIndex = 3;
            // 
            // getSpriteSheetButton
            // 
            this.getSpriteSheetButton.Location = new System.Drawing.Point(39, 105);
            this.getSpriteSheetButton.Name = "getSpriteSheetButton";
            this.getSpriteSheetButton.Size = new System.Drawing.Size(134, 23);
            this.getSpriteSheetButton.TabIndex = 4;
            this.getSpriteSheetButton.Text = "get spritesheet";
            this.getSpriteSheetButton.UseVisualStyleBackColor = true;
            this.getSpriteSheetButton.Click += new System.EventHandler(this.getSpriteSheetButton_Click);
            // 
            // spriteNameLabel
            // 
            this.spriteNameLabel.AutoSize = true;
            this.spriteNameLabel.Location = new System.Drawing.Point(179, 110);
            this.spriteNameLabel.Name = "spriteNameLabel";
            this.spriteNameLabel.Size = new System.Drawing.Size(25, 13);
            this.spriteNameLabel.TabIndex = 6;
            this.spriteNameLabel.Text = "------";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // startEditorButton
            // 
            this.startEditorButton.Location = new System.Drawing.Point(39, 251);
            this.startEditorButton.Name = "startEditorButton";
            this.startEditorButton.Size = new System.Drawing.Size(134, 23);
            this.startEditorButton.TabIndex = 7;
            this.startEditorButton.Text = "go to editor";
            this.startEditorButton.UseVisualStyleBackColor = true;
            this.startEditorButton.Click += new System.EventHandler(this.startEditorButton_Click);
            // 
            // startIndexBox
            // 
            this.startIndexBox.Location = new System.Drawing.Point(39, 160);
            this.startIndexBox.Name = "startIndexBox";
            this.startIndexBox.Size = new System.Drawing.Size(77, 20);
            this.startIndexBox.TabIndex = 8;
            // 
            // numTilesBox
            // 
            this.numTilesBox.Location = new System.Drawing.Point(122, 160);
            this.numTilesBox.Name = "numTilesBox";
            this.numTilesBox.Size = new System.Drawing.Size(77, 20);
            this.numTilesBox.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 415);
            this.Controls.Add(this.numTilesBox);
            this.Controls.Add(this.startIndexBox);
            this.Controls.Add(this.startEditorButton);
            this.Controls.Add(this.spriteNameLabel);
            this.Controls.Add(this.getSpriteSheetButton);
            this.Controls.Add(this.tileHeightBox);
            this.Controls.Add(this.tileWidthBox);
            this.Controls.Add(this.openButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.TextBox tileWidthBox;
        private System.Windows.Forms.TextBox tileHeightBox;
        private System.Windows.Forms.Button getSpriteSheetButton;
        private System.Windows.Forms.Label spriteNameLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button startEditorButton;
        private System.Windows.Forms.TextBox startIndexBox;
        private System.Windows.Forms.TextBox numTilesBox;
    }
}

