namespace MusicSort.Views
{
    partial class FileRenamingForm
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
            this.CancelButton_ = new System.Windows.Forms.Button();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.RenamingTextBox = new System.Windows.Forms.TextBox();
            this.RenamingLabel = new System.Windows.Forms.Label();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CancelButton_
            // 
            this.CancelButton_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton_.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton_.Location = new System.Drawing.Point(331, 88);
            this.CancelButton_.Name = "CancelButton_";
            this.CancelButton_.Size = new System.Drawing.Size(75, 23);
            this.CancelButton_.TabIndex = 0;
            this.CancelButton_.Text = "Annuler";
            this.CancelButton_.UseVisualStyleBackColor = true;
            this.CancelButton_.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ApplyButton.Location = new System.Drawing.Point(412, 88);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 1;
            this.ApplyButton.Text = "Renommer";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // RenamingTextBox
            // 
            this.RenamingTextBox.Location = new System.Drawing.Point(15, 34);
            this.RenamingTextBox.Name = "RenamingTextBox";
            this.RenamingTextBox.Size = new System.Drawing.Size(472, 20);
            this.RenamingTextBox.TabIndex = 2;
            this.RenamingTextBox.TextChanged += new System.EventHandler(this.RenamingTextBox_TextChanged);
            // 
            // RenamingLabel
            // 
            this.RenamingLabel.AutoSize = true;
            this.RenamingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RenamingLabel.Location = new System.Drawing.Point(12, 9);
            this.RenamingLabel.Name = "RenamingLabel";
            this.RenamingLabel.Size = new System.Drawing.Size(122, 13);
            this.RenamingLabel.TabIndex = 3;
            this.RenamingLabel.Text = "Renommage du fichier : ";
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(12, 57);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(0, 13);
            this.ErrorLabel.TabIndex = 4;
            // 
            // FileRenamingForm
            // 
            this.AcceptButton = this.ApplyButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 129);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.RenamingLabel);
            this.Controls.Add(this.RenamingTextBox);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.CancelButton_);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(525, 168);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(525, 168);
            this.Name = "FileRenamingForm";
            this.ShowIcon = false;
            this.Text = "Renommage de fichier";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelButton_;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.TextBox RenamingTextBox;
        private System.Windows.Forms.Label RenamingLabel;
        public System.Windows.Forms.Label ErrorLabel;
    }
}