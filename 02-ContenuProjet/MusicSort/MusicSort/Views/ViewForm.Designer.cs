namespace MusicSort.Views
{
    partial class ViewForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewForm));
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ExtensionColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView1 = new System.Windows.Forms.ListView();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.BaseDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.OpenFolderLabel = new System.Windows.Forms.Label();
            this.FolderFileChoicePanel = new System.Windows.Forms.Panel();
            this.PlaylistPanel = new System.Windows.Forms.Panel();
            this.SelectedFileLabel = new System.Windows.Forms.Label();
            this.Section1Label = new System.Windows.Forms.Label();
            this.PlaylistLabel = new System.Windows.Forms.Label();
            this.SelectedFilePictureBox = new System.Windows.Forms.PictureBox();
            this.OpenFolderPictureBox = new System.Windows.Forms.PictureBox();
            this.BaseDirectoryButton = new System.Windows.Forms.Button();
            this.AddAllToPlaylistButton = new System.Windows.Forms.Button();
            this.AddToPlaylistButton = new System.Windows.Forms.Button();
            this.RemoveFromPlaylistButton = new System.Windows.Forms.Button();
            this.RemoveAllFromPlaylistButton = new System.Windows.Forms.Button();
            this.SortButton = new System.Windows.Forms.Button();
            this.ResetAllButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.ApplicationPanel = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FolderFileChoicePanel.SuspendLayout();
            this.PlaylistPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedFilePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpenFolderPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.ApplicationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(14, 79);
            this.listView2.MaximumSize = new System.Drawing.Size(210, 350);
            this.listView2.MinimumSize = new System.Drawing.Size(210, 350);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(210, 350);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nom";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Extension";
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Nom";
            // 
            // ExtensionColumn
            // 
            this.ExtensionColumn.Text = "Extension";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn,
            this.ExtensionColumn});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(316, 79);
            this.listView1.MaximumSize = new System.Drawing.Size(210, 350);
            this.listView1.MinimumSize = new System.Drawing.Size(210, 350);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(210, 350);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(23, 79);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(261, 434);
            this.treeView1.TabIndex = 2;
            // 
            // BaseDirectoryTextBox
            // 
            this.BaseDirectoryTextBox.Enabled = false;
            this.BaseDirectoryTextBox.Location = new System.Drawing.Point(23, 50);
            this.BaseDirectoryTextBox.Name = "BaseDirectoryTextBox";
            this.BaseDirectoryTextBox.Size = new System.Drawing.Size(232, 20);
            this.BaseDirectoryTextBox.TabIndex = 4;
            // 
            // OpenFolderLabel
            // 
            this.OpenFolderLabel.AutoSize = true;
            this.OpenFolderLabel.Location = new System.Drawing.Point(345, 53);
            this.OpenFolderLabel.Name = "OpenFolderLabel";
            this.OpenFolderLabel.Size = new System.Drawing.Size(99, 13);
            this.OpenFolderLabel.TabIndex = 5;
            this.OpenFolderLabel.Text = "Dossier sélectionné";
            // 
            // FolderFileChoicePanel
            // 
            this.FolderFileChoicePanel.Controls.Add(this.AddToPlaylistButton);
            this.FolderFileChoicePanel.Controls.Add(this.AddAllToPlaylistButton);
            this.FolderFileChoicePanel.Controls.Add(this.Section1Label);
            this.FolderFileChoicePanel.Controls.Add(this.BaseDirectoryTextBox);
            this.FolderFileChoicePanel.Controls.Add(this.OpenFolderPictureBox);
            this.FolderFileChoicePanel.Controls.Add(this.listView1);
            this.FolderFileChoicePanel.Controls.Add(this.OpenFolderLabel);
            this.FolderFileChoicePanel.Controls.Add(this.treeView1);
            this.FolderFileChoicePanel.Controls.Add(this.BaseDirectoryButton);
            this.FolderFileChoicePanel.Location = new System.Drawing.Point(14, 12);
            this.FolderFileChoicePanel.Name = "FolderFileChoicePanel";
            this.FolderFileChoicePanel.Size = new System.Drawing.Size(539, 547);
            this.FolderFileChoicePanel.TabIndex = 7;
            // 
            // PlaylistPanel
            // 
            this.PlaylistPanel.Controls.Add(this.StopButton);
            this.PlaylistPanel.Controls.Add(this.PlayButton);
            this.PlaylistPanel.Controls.Add(this.ResetAllButton);
            this.PlaylistPanel.Controls.Add(this.SortButton);
            this.PlaylistPanel.Controls.Add(this.RemoveAllFromPlaylistButton);
            this.PlaylistPanel.Controls.Add(this.RemoveFromPlaylistButton);
            this.PlaylistPanel.Controls.Add(this.PlaylistLabel);
            this.PlaylistPanel.Controls.Add(this.SelectedFileLabel);
            this.PlaylistPanel.Controls.Add(this.SelectedFilePictureBox);
            this.PlaylistPanel.Controls.Add(this.listView2);
            this.PlaylistPanel.Location = new System.Drawing.Point(578, 12);
            this.PlaylistPanel.Name = "PlaylistPanel";
            this.PlaylistPanel.Size = new System.Drawing.Size(242, 547);
            this.PlaylistPanel.TabIndex = 8;
            // 
            // SelectedFileLabel
            // 
            this.SelectedFileLabel.AutoSize = true;
            this.SelectedFileLabel.Location = new System.Drawing.Point(44, 56);
            this.SelectedFileLabel.Name = "SelectedFileLabel";
            this.SelectedFileLabel.Size = new System.Drawing.Size(97, 13);
            this.SelectedFileLabel.TabIndex = 8;
            this.SelectedFileLabel.Text = "Fichier Sélectionné";
            // 
            // Section1Label
            // 
            this.Section1Label.AutoSize = true;
            this.Section1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Section1Label.Location = new System.Drawing.Point(19, 21);
            this.Section1Label.Name = "Section1Label";
            this.Section1Label.Size = new System.Drawing.Size(240, 20);
            this.Section1Label.TabIndex = 7;
            this.Section1Label.Text = "Sélection des dossiers et fichiers";
            // 
            // PlaylistLabel
            // 
            this.PlaylistLabel.AutoSize = true;
            this.PlaylistLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlaylistLabel.Location = new System.Drawing.Point(10, 21);
            this.PlaylistLabel.Name = "PlaylistLabel";
            this.PlaylistLabel.Size = new System.Drawing.Size(57, 20);
            this.PlaylistLabel.TabIndex = 8;
            this.PlaylistLabel.Text = "Playlist";
            // 
            // SelectedFilePictureBox
            // 
            this.SelectedFilePictureBox.BackgroundImage = global::MusicSort.Properties.Resources.MusicFile;
            this.SelectedFilePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SelectedFilePictureBox.Location = new System.Drawing.Point(14, 50);
            this.SelectedFilePictureBox.Name = "SelectedFilePictureBox";
            this.SelectedFilePictureBox.Size = new System.Drawing.Size(23, 23);
            this.SelectedFilePictureBox.TabIndex = 7;
            this.SelectedFilePictureBox.TabStop = false;
            // 
            // OpenFolderPictureBox
            // 
            this.OpenFolderPictureBox.BackgroundImage = global::MusicSort.Properties.Resources.OpenFolderIcon;
            this.OpenFolderPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OpenFolderPictureBox.Location = new System.Drawing.Point(316, 50);
            this.OpenFolderPictureBox.Name = "OpenFolderPictureBox";
            this.OpenFolderPictureBox.Size = new System.Drawing.Size(23, 23);
            this.OpenFolderPictureBox.TabIndex = 6;
            this.OpenFolderPictureBox.TabStop = false;
            // 
            // BaseDirectoryButton
            // 
            this.BaseDirectoryButton.BackgroundImage = global::MusicSort.Properties.Resources.FolderIcon;
            this.BaseDirectoryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BaseDirectoryButton.Location = new System.Drawing.Point(261, 50);
            this.BaseDirectoryButton.Name = "BaseDirectoryButton";
            this.BaseDirectoryButton.Size = new System.Drawing.Size(23, 23);
            this.BaseDirectoryButton.TabIndex = 3;
            this.BaseDirectoryButton.UseVisualStyleBackColor = true;
            // 
            // AddAllToPlaylistButton
            // 
            this.AddAllToPlaylistButton.Location = new System.Drawing.Point(316, 436);
            this.AddAllToPlaylistButton.Name = "AddAllToPlaylistButton";
            this.AddAllToPlaylistButton.Size = new System.Drawing.Size(75, 23);
            this.AddAllToPlaylistButton.TabIndex = 8;
            this.AddAllToPlaylistButton.Text = ">>";
            this.AddAllToPlaylistButton.UseVisualStyleBackColor = true;
            // 
            // AddToPlaylistButton
            // 
            this.AddToPlaylistButton.Location = new System.Drawing.Point(451, 436);
            this.AddToPlaylistButton.Name = "AddToPlaylistButton";
            this.AddToPlaylistButton.Size = new System.Drawing.Size(75, 23);
            this.AddToPlaylistButton.TabIndex = 9;
            this.AddToPlaylistButton.Text = ">";
            this.AddToPlaylistButton.UseVisualStyleBackColor = true;
            // 
            // RemoveFromPlaylistButton
            // 
            this.RemoveFromPlaylistButton.Location = new System.Drawing.Point(14, 436);
            this.RemoveFromPlaylistButton.Name = "RemoveFromPlaylistButton";
            this.RemoveFromPlaylistButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveFromPlaylistButton.TabIndex = 10;
            this.RemoveFromPlaylistButton.Text = "<";
            this.RemoveFromPlaylistButton.UseVisualStyleBackColor = true;
            // 
            // RemoveAllFromPlaylistButton
            // 
            this.RemoveAllFromPlaylistButton.Location = new System.Drawing.Point(149, 436);
            this.RemoveAllFromPlaylistButton.Name = "RemoveAllFromPlaylistButton";
            this.RemoveAllFromPlaylistButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveAllFromPlaylistButton.TabIndex = 11;
            this.RemoveAllFromPlaylistButton.Text = "<<";
            this.RemoveAllFromPlaylistButton.UseVisualStyleBackColor = true;
            // 
            // SortButton
            // 
            this.SortButton.Location = new System.Drawing.Point(14, 465);
            this.SortButton.Name = "SortButton";
            this.SortButton.Size = new System.Drawing.Size(75, 23);
            this.SortButton.TabIndex = 12;
            this.SortButton.Text = "Trier";
            this.SortButton.UseVisualStyleBackColor = true;
            // 
            // ResetAllButton
            // 
            this.ResetAllButton.Location = new System.Drawing.Point(149, 465);
            this.ResetAllButton.Name = "ResetAllButton";
            this.ResetAllButton.Size = new System.Drawing.Size(75, 23);
            this.ResetAllButton.TabIndex = 13;
            this.ResetAllButton.Text = "Réinitialiser";
            this.ResetAllButton.UseVisualStyleBackColor = true;
            // 
            // PlayButton
            // 
            this.PlayButton.Location = new System.Drawing.Point(14, 494);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(75, 23);
            this.PlayButton.TabIndex = 14;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(149, 494);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 15;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(14, 576);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(806, 45);
            this.axWindowsMediaPlayer1.TabIndex = 9;
            // 
            // ApplicationPanel
            // 
            this.ApplicationPanel.Controls.Add(this.label1);
            this.ApplicationPanel.Controls.Add(this.textBox1);
            this.ApplicationPanel.Location = new System.Drawing.Point(14, 639);
            this.ApplicationPanel.Name = "ApplicationPanel";
            this.ApplicationPanel.Size = new System.Drawing.Size(806, 107);
            this.ApplicationPanel.TabIndex = 10;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(23, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 758);
            this.Controls.Add(this.ApplicationPanel);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.PlaylistPanel);
            this.Controls.Add(this.FolderFileChoicePanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewForm";
            this.ShowIcon = false;
            this.Text = "MusicSort";
            this.FolderFileChoicePanel.ResumeLayout(false);
            this.FolderFileChoicePanel.PerformLayout();
            this.PlaylistPanel.ResumeLayout(false);
            this.PlaylistPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedFilePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OpenFolderPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ApplicationPanel.ResumeLayout(false);
            this.ApplicationPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader ExtensionColumn;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button BaseDirectoryButton;
        private System.Windows.Forms.TextBox BaseDirectoryTextBox;
        private System.Windows.Forms.Label OpenFolderLabel;
        private System.Windows.Forms.PictureBox OpenFolderPictureBox;
        private System.Windows.Forms.Panel FolderFileChoicePanel;
        private System.Windows.Forms.Panel PlaylistPanel;
        private System.Windows.Forms.Label Section1Label;
        private System.Windows.Forms.Label PlaylistLabel;
        private System.Windows.Forms.Label SelectedFileLabel;
        private System.Windows.Forms.PictureBox SelectedFilePictureBox;
        private System.Windows.Forms.Button AddToPlaylistButton;
        private System.Windows.Forms.Button AddAllToPlaylistButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button ResetAllButton;
        private System.Windows.Forms.Button SortButton;
        private System.Windows.Forms.Button RemoveAllFromPlaylistButton;
        private System.Windows.Forms.Button RemoveFromPlaylistButton;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Panel ApplicationPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

