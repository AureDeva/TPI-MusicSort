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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewForm));
            this.baseDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.openFolderLabel = new System.Windows.Forms.Label();
            this._folderFileChoicePanel = new System.Windows.Forms.Panel();
            this._folderBrowser = new MusicSort.Views.FolderBrowser();
            this._folderFileListView = new MusicSort.Views.FolderFileListView();
            this._addToPlaylistButton = new System.Windows.Forms.Button();
            this._addAllToPlaylistButton = new System.Windows.Forms.Button();
            this._selectionLabel = new System.Windows.Forms.Label();
            this._openFolderPictureBox = new System.Windows.Forms.PictureBox();
            this._baseDirectoryButton = new System.Windows.Forms.Button();
            this._playlistPanel = new System.Windows.Forms.Panel();
            this._placeDownButton = new System.Windows.Forms.Button();
            this._placeUpButton = new System.Windows.Forms.Button();
            this._playlistView = new MusicSort.Views.PlaylistView();
            this._stopButton = new System.Windows.Forms.Button();
            this._playButton = new System.Windows.Forms.Button();
            this._resetAllButton = new System.Windows.Forms.Button();
            this._sortButton = new System.Windows.Forms.Button();
            this._removeAllFromPlaylistButton = new System.Windows.Forms.Button();
            this._removeFromPlaylistButton = new System.Windows.Forms.Button();
            this._playlistLabel = new System.Windows.Forms.Label();
            this.selectedFileLabel = new System.Windows.Forms.Label();
            this._selectedFilePictureBox = new System.Windows.Forms.PictureBox();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this._applicationPanel = new System.Windows.Forms.Panel();
            this._destinationButton = new System.Windows.Forms.Button();
            this._applyButton = new System.Windows.Forms.Button();
            this._displayButton = new System.Windows.Forms.Button();
            this.destinationTextBox = new System.Windows.Forms.TextBox();
            this._destinationLabel = new System.Windows.Forms.Label();
            this._applicationModeGroupBox = new System.Windows.Forms.GroupBox();
            this._renameAndMoveModeRadioButton = new System.Windows.Forms.RadioButton();
            this._renameAndCopyModeRadioButton = new System.Windows.Forms.RadioButton();
            this._renameModeRadioButton = new System.Windows.Forms.RadioButton();
            this._fileNumberingCheckBox = new System.Windows.Forms.CheckBox();
            this.startNumberTextBox = new System.Windows.Forms.TextBox();
            this._startNumberLabel = new System.Windows.Forms.Label();
            this.generalNameErrorLabel = new System.Windows.Forms.Label();
            this._generalNameLabel = new System.Windows.Forms.Label();
            this.generalNameTextBox = new System.Windows.Forms.TextBox();
            this.numberErrorLabel = new System.Windows.Forms.Label();
            this._folderFileChoicePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._openFolderPictureBox)).BeginInit();
            this._playlistPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._selectedFilePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this._applicationPanel.SuspendLayout();
            this._applicationModeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // baseDirectoryTextBox
            // 
            this.baseDirectoryTextBox.Enabled = false;
            this.baseDirectoryTextBox.Location = new System.Drawing.Point(23, 50);
            this.baseDirectoryTextBox.Name = "baseDirectoryTextBox";
            this.baseDirectoryTextBox.ReadOnly = true;
            this.baseDirectoryTextBox.Size = new System.Drawing.Size(232, 20);
            this.baseDirectoryTextBox.TabIndex = 4;
            // 
            // openFolderLabel
            // 
            this.openFolderLabel.AutoSize = true;
            this.openFolderLabel.Location = new System.Drawing.Point(345, 53);
            this.openFolderLabel.Name = "openFolderLabel";
            this.openFolderLabel.Size = new System.Drawing.Size(99, 13);
            this.openFolderLabel.TabIndex = 5;
            this.openFolderLabel.Text = "Dossier sélectionné";
            // 
            // _folderFileChoicePanel
            // 
            this._folderFileChoicePanel.Controls.Add(this._folderBrowser);
            this._folderFileChoicePanel.Controls.Add(this._folderFileListView);
            this._folderFileChoicePanel.Controls.Add(this._addToPlaylistButton);
            this._folderFileChoicePanel.Controls.Add(this._addAllToPlaylistButton);
            this._folderFileChoicePanel.Controls.Add(this._selectionLabel);
            this._folderFileChoicePanel.Controls.Add(this.baseDirectoryTextBox);
            this._folderFileChoicePanel.Controls.Add(this._openFolderPictureBox);
            this._folderFileChoicePanel.Controls.Add(this.openFolderLabel);
            this._folderFileChoicePanel.Controls.Add(this._baseDirectoryButton);
            this._folderFileChoicePanel.Location = new System.Drawing.Point(14, 12);
            this._folderFileChoicePanel.Name = "_folderFileChoicePanel";
            this._folderFileChoicePanel.Size = new System.Drawing.Size(539, 547);
            this._folderFileChoicePanel.TabIndex = 7;
            // 
            // _folderBrowser
            // 
            this._folderBrowser.ImageIndex = 0;
            this._folderBrowser.Location = new System.Drawing.Point(23, 80);
            this._folderBrowser.MaximumSize = new System.Drawing.Size(261, 434);
            this._folderBrowser.MinimumSize = new System.Drawing.Size(261, 434);
            this._folderBrowser.Name = "_folderBrowser";
            this._folderBrowser.SelectedImageIndex = 0;
            this._folderBrowser.ShowLines = false;
            this._folderBrowser.ShowPlusMinus = false;
            this._folderBrowser.ShowRootLines = false;
            this._folderBrowser.Size = new System.Drawing.Size(261, 434);
            this._folderBrowser.TabIndex = 11;
            this._folderBrowser.FolderSelectedEvent += new MusicSort.Views.PathSelectedEventHandler(this.FolderBrowser_FolderSelectedEvent);
            // 
            // _folderFileListView
            // 
            this._folderFileListView.HideSelection = false;
            this._folderFileListView.Location = new System.Drawing.Point(316, 80);
            this._folderFileListView.MaximumSize = new System.Drawing.Size(210, 350);
            this._folderFileListView.MinimumSize = new System.Drawing.Size(210, 350);
            this._folderFileListView.Name = "_folderFileListView";
            this._folderFileListView.Play = null;
            this._folderFileListView.Reset = null;
            this._folderFileListView.Size = new System.Drawing.Size(210, 350);
            this._folderFileListView.TabIndex = 10;
            this._folderFileListView.UseCompatibleStateImageBehavior = false;
            this._folderFileListView.View = System.Windows.Forms.View.Details;
            // 
            // _addToPlaylistButton
            // 
            this._addToPlaylistButton.Location = new System.Drawing.Point(451, 436);
            this._addToPlaylistButton.Name = "_addToPlaylistButton";
            this._addToPlaylistButton.Size = new System.Drawing.Size(75, 23);
            this._addToPlaylistButton.TabIndex = 9;
            this._addToPlaylistButton.Text = ">";
            this._addToPlaylistButton.UseVisualStyleBackColor = true;
            this._addToPlaylistButton.Click += new System.EventHandler(this.AddToPlaylistButton_Click);
            // 
            // _addAllToPlaylistButton
            // 
            this._addAllToPlaylistButton.Location = new System.Drawing.Point(316, 436);
            this._addAllToPlaylistButton.Name = "_addAllToPlaylistButton";
            this._addAllToPlaylistButton.Size = new System.Drawing.Size(75, 23);
            this._addAllToPlaylistButton.TabIndex = 8;
            this._addAllToPlaylistButton.Text = ">>";
            this._addAllToPlaylistButton.UseVisualStyleBackColor = true;
            this._addAllToPlaylistButton.Click += new System.EventHandler(this.AddAllToPlaylistButton_Click);
            // 
            // _selectionLabel
            // 
            this._selectionLabel.AutoSize = true;
            this._selectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._selectionLabel.Location = new System.Drawing.Point(19, 21);
            this._selectionLabel.Name = "_selectionLabel";
            this._selectionLabel.Size = new System.Drawing.Size(240, 20);
            this._selectionLabel.TabIndex = 7;
            this._selectionLabel.Text = "Sélection des dossiers et fichiers";
            // 
            // _openFolderPictureBox
            // 
            this._openFolderPictureBox.BackgroundImage = global::MusicSort.Properties.Resources.OpenFolderIcon;
            this._openFolderPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._openFolderPictureBox.Location = new System.Drawing.Point(316, 50);
            this._openFolderPictureBox.Name = "_openFolderPictureBox";
            this._openFolderPictureBox.Size = new System.Drawing.Size(23, 23);
            this._openFolderPictureBox.TabIndex = 6;
            this._openFolderPictureBox.TabStop = false;
            // 
            // _baseDirectoryButton
            // 
            this._baseDirectoryButton.BackgroundImage = global::MusicSort.Properties.Resources.FolderIcon;
            this._baseDirectoryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._baseDirectoryButton.Location = new System.Drawing.Point(261, 50);
            this._baseDirectoryButton.Name = "_baseDirectoryButton";
            this._baseDirectoryButton.Size = new System.Drawing.Size(23, 23);
            this._baseDirectoryButton.TabIndex = 3;
            this._baseDirectoryButton.UseVisualStyleBackColor = true;
            this._baseDirectoryButton.Click += new System.EventHandler(this.BaseDirectoryButton_Click);
            // 
            // _playlistPanel
            // 
            this._playlistPanel.Controls.Add(this._placeDownButton);
            this._playlistPanel.Controls.Add(this._placeUpButton);
            this._playlistPanel.Controls.Add(this._playlistView);
            this._playlistPanel.Controls.Add(this._stopButton);
            this._playlistPanel.Controls.Add(this._playButton);
            this._playlistPanel.Controls.Add(this._resetAllButton);
            this._playlistPanel.Controls.Add(this._sortButton);
            this._playlistPanel.Controls.Add(this._removeAllFromPlaylistButton);
            this._playlistPanel.Controls.Add(this._removeFromPlaylistButton);
            this._playlistPanel.Controls.Add(this._playlistLabel);
            this._playlistPanel.Controls.Add(this.selectedFileLabel);
            this._playlistPanel.Controls.Add(this._selectedFilePictureBox);
            this._playlistPanel.Location = new System.Drawing.Point(578, 12);
            this._playlistPanel.Name = "_playlistPanel";
            this._playlistPanel.Size = new System.Drawing.Size(242, 547);
            this._playlistPanel.TabIndex = 8;
            // 
            // _placeDownButton
            // 
            this._placeDownButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._placeDownButton.Location = new System.Drawing.Point(111, 483);
            this._placeDownButton.Name = "_placeDownButton";
            this._placeDownButton.Size = new System.Drawing.Size(20, 34);
            this._placeDownButton.TabIndex = 18;
            this._placeDownButton.Text = "↓";
            this._placeDownButton.UseVisualStyleBackColor = true;
            this._placeDownButton.Click += new System.EventHandler(this.PlaceDownButton_Click);
            // 
            // _placeUpButton
            // 
            this._placeUpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._placeUpButton.Location = new System.Drawing.Point(111, 436);
            this._placeUpButton.Name = "_placeUpButton";
            this._placeUpButton.Size = new System.Drawing.Size(20, 34);
            this._placeUpButton.TabIndex = 17;
            this._placeUpButton.Text = "↑";
            this._placeUpButton.UseVisualStyleBackColor = true;
            this._placeUpButton.Click += new System.EventHandler(this.PlaceUpButton_Click);
            // 
            // _playlistView
            // 
            this._playlistView.HideSelection = false;
            this._playlistView.Location = new System.Drawing.Point(14, 79);
            this._playlistView.MaximumSize = new System.Drawing.Size(210, 350);
            this._playlistView.MinimumSize = new System.Drawing.Size(210, 350);
            this._playlistView.Name = "_playlistView";
            this._playlistView.Play = null;
            this._playlistView.Size = new System.Drawing.Size(210, 350);
            this._playlistView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this._playlistView.TabIndex = 16;
            this._playlistView.UseCompatibleStateImageBehavior = false;
            this._playlistView.View = System.Windows.Forms.View.Details;
            // 
            // _stopButton
            // 
            this._stopButton.Location = new System.Drawing.Point(149, 494);
            this._stopButton.Name = "_stopButton";
            this._stopButton.Size = new System.Drawing.Size(75, 23);
            this._stopButton.TabIndex = 15;
            this._stopButton.Text = "Stop";
            this._stopButton.UseVisualStyleBackColor = true;
            this._stopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // _playButton
            // 
            this._playButton.Location = new System.Drawing.Point(14, 494);
            this._playButton.Name = "_playButton";
            this._playButton.Size = new System.Drawing.Size(75, 23);
            this._playButton.TabIndex = 14;
            this._playButton.Text = "Play";
            this._playButton.UseVisualStyleBackColor = true;
            this._playButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // _resetAllButton
            // 
            this._resetAllButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._resetAllButton.Location = new System.Drawing.Point(149, 465);
            this._resetAllButton.Name = "_resetAllButton";
            this._resetAllButton.Size = new System.Drawing.Size(75, 23);
            this._resetAllButton.TabIndex = 13;
            this._resetAllButton.Text = "Réinitialiser";
            this._resetAllButton.UseVisualStyleBackColor = true;
            this._resetAllButton.Click += new System.EventHandler(this.ResetAllButton_Click);
            // 
            // _sortButton
            // 
            this._sortButton.Location = new System.Drawing.Point(14, 465);
            this._sortButton.Name = "_sortButton";
            this._sortButton.Size = new System.Drawing.Size(75, 23);
            this._sortButton.TabIndex = 12;
            this._sortButton.Text = "Trier";
            this._sortButton.UseVisualStyleBackColor = true;
            this._sortButton.Click += new System.EventHandler(this.SortButton_Click);
            // 
            // _removeAllFromPlaylistButton
            // 
            this._removeAllFromPlaylistButton.Location = new System.Drawing.Point(149, 436);
            this._removeAllFromPlaylistButton.Name = "_removeAllFromPlaylistButton";
            this._removeAllFromPlaylistButton.Size = new System.Drawing.Size(75, 23);
            this._removeAllFromPlaylistButton.TabIndex = 11;
            this._removeAllFromPlaylistButton.Text = "xx";
            this._removeAllFromPlaylistButton.UseVisualStyleBackColor = true;
            this._removeAllFromPlaylistButton.Click += new System.EventHandler(this.RemoveAllFromPlaylistButton_Click);
            // 
            // _removeFromPlaylistButton
            // 
            this._removeFromPlaylistButton.Location = new System.Drawing.Point(14, 436);
            this._removeFromPlaylistButton.Name = "_removeFromPlaylistButton";
            this._removeFromPlaylistButton.Size = new System.Drawing.Size(75, 23);
            this._removeFromPlaylistButton.TabIndex = 10;
            this._removeFromPlaylistButton.Text = "x";
            this._removeFromPlaylistButton.UseVisualStyleBackColor = true;
            this._removeFromPlaylistButton.Click += new System.EventHandler(this.RemoveFromPlaylistButton_Click);
            // 
            // _playlistLabel
            // 
            this._playlistLabel.AutoSize = true;
            this._playlistLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._playlistLabel.Location = new System.Drawing.Point(10, 21);
            this._playlistLabel.Name = "_playlistLabel";
            this._playlistLabel.Size = new System.Drawing.Size(57, 20);
            this._playlistLabel.TabIndex = 8;
            this._playlistLabel.Text = "Playlist";
            // 
            // selectedFileLabel
            // 
            this.selectedFileLabel.AutoSize = true;
            this.selectedFileLabel.Location = new System.Drawing.Point(44, 56);
            this.selectedFileLabel.Name = "selectedFileLabel";
            this.selectedFileLabel.Size = new System.Drawing.Size(97, 13);
            this.selectedFileLabel.TabIndex = 8;
            this.selectedFileLabel.Text = "Fichier Sélectionné";
            // 
            // _selectedFilePictureBox
            // 
            this._selectedFilePictureBox.BackgroundImage = global::MusicSort.Properties.Resources.MusicFile;
            this._selectedFilePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._selectedFilePictureBox.Location = new System.Drawing.Point(14, 50);
            this._selectedFilePictureBox.Name = "_selectedFilePictureBox";
            this._selectedFilePictureBox.Size = new System.Drawing.Size(23, 23);
            this._selectedFilePictureBox.TabIndex = 7;
            this._selectedFilePictureBox.TabStop = false;
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
            // _applicationPanel
            // 
            this._applicationPanel.Controls.Add(this.numberErrorLabel);
            this._applicationPanel.Controls.Add(this._destinationButton);
            this._applicationPanel.Controls.Add(this._applyButton);
            this._applicationPanel.Controls.Add(this._displayButton);
            this._applicationPanel.Controls.Add(this.destinationTextBox);
            this._applicationPanel.Controls.Add(this._destinationLabel);
            this._applicationPanel.Controls.Add(this._applicationModeGroupBox);
            this._applicationPanel.Controls.Add(this._fileNumberingCheckBox);
            this._applicationPanel.Controls.Add(this.startNumberTextBox);
            this._applicationPanel.Controls.Add(this._startNumberLabel);
            this._applicationPanel.Controls.Add(this.generalNameErrorLabel);
            this._applicationPanel.Controls.Add(this._generalNameLabel);
            this._applicationPanel.Controls.Add(this.generalNameTextBox);
            this._applicationPanel.Location = new System.Drawing.Point(14, 639);
            this._applicationPanel.Name = "_applicationPanel";
            this._applicationPanel.Size = new System.Drawing.Size(806, 107);
            this._applicationPanel.TabIndex = 10;
            // 
            // _destinationButton
            // 
            this._destinationButton.BackgroundImage = global::MusicSort.Properties.Resources.FolderIcon;
            this._destinationButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._destinationButton.Location = new System.Drawing.Point(765, 30);
            this._destinationButton.Name = "_destinationButton";
            this._destinationButton.Size = new System.Drawing.Size(23, 23);
            this._destinationButton.TabIndex = 12;
            this._destinationButton.UseVisualStyleBackColor = true;
            this._destinationButton.Click += new System.EventHandler(this.DestinationButton_Click);
            // 
            // _applyButton
            // 
            this._applyButton.Location = new System.Drawing.Point(713, 61);
            this._applyButton.Name = "_applyButton";
            this._applyButton.Size = new System.Drawing.Size(75, 23);
            this._applyButton.TabIndex = 12;
            this._applyButton.Text = "Appliquer";
            this._applyButton.UseVisualStyleBackColor = true;
            this._applyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // _displayButton
            // 
            this._displayButton.Location = new System.Drawing.Point(630, 61);
            this._displayButton.Name = "_displayButton";
            this._displayButton.Size = new System.Drawing.Size(75, 23);
            this._displayButton.TabIndex = 11;
            this._displayButton.Text = "Aperçu";
            this._displayButton.UseVisualStyleBackColor = true;
            this._displayButton.Click += new System.EventHandler(this.DisplayButton_Click);
            // 
            // destinationTextBox
            // 
            this.destinationTextBox.Location = new System.Drawing.Point(564, 32);
            this.destinationTextBox.Name = "destinationTextBox";
            this.destinationTextBox.ReadOnly = true;
            this.destinationTextBox.Size = new System.Drawing.Size(195, 20);
            this.destinationTextBox.TabIndex = 10;
            this.destinationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _destinationLabel
            // 
            this._destinationLabel.AutoSize = true;
            this._destinationLabel.Location = new System.Drawing.Point(564, 17);
            this._destinationLabel.Name = "_destinationLabel";
            this._destinationLabel.Size = new System.Drawing.Size(60, 13);
            this._destinationLabel.TabIndex = 9;
            this._destinationLabel.Text = "Destination";
            // 
            // _applicationModeGroupBox
            // 
            this._applicationModeGroupBox.Controls.Add(this._renameAndMoveModeRadioButton);
            this._applicationModeGroupBox.Controls.Add(this._renameAndCopyModeRadioButton);
            this._applicationModeGroupBox.Controls.Add(this._renameModeRadioButton);
            this._applicationModeGroupBox.Location = new System.Drawing.Point(339, 11);
            this._applicationModeGroupBox.Name = "_applicationModeGroupBox";
            this._applicationModeGroupBox.Size = new System.Drawing.Size(200, 82);
            this._applicationModeGroupBox.TabIndex = 8;
            this._applicationModeGroupBox.TabStop = false;
            this._applicationModeGroupBox.Text = "Modes d\'application";
            // 
            // _renameAndMoveModeRadioButton
            // 
            this._renameAndMoveModeRadioButton.AutoSize = true;
            this._renameAndMoveModeRadioButton.Location = new System.Drawing.Point(6, 63);
            this._renameAndMoveModeRadioButton.Name = "_renameAndMoveModeRadioButton";
            this._renameAndMoveModeRadioButton.Size = new System.Drawing.Size(132, 17);
            this._renameAndMoveModeRadioButton.TabIndex = 9;
            this._renameAndMoveModeRadioButton.TabStop = true;
            this._renameAndMoveModeRadioButton.Text = "Renommer et déplacer";
            this._renameAndMoveModeRadioButton.UseVisualStyleBackColor = true;
            this._renameAndMoveModeRadioButton.CheckedChanged += new System.EventHandler(this.RenameAndMoveModeRadioButton_CheckedChanged);
            // 
            // _renameAndCopyModeRadioButton
            // 
            this._renameAndCopyModeRadioButton.AutoSize = true;
            this._renameAndCopyModeRadioButton.Location = new System.Drawing.Point(6, 42);
            this._renameAndCopyModeRadioButton.Name = "_renameAndCopyModeRadioButton";
            this._renameAndCopyModeRadioButton.Size = new System.Drawing.Size(120, 17);
            this._renameAndCopyModeRadioButton.TabIndex = 8;
            this._renameAndCopyModeRadioButton.TabStop = true;
            this._renameAndCopyModeRadioButton.Text = "Renommer et copier";
            this._renameAndCopyModeRadioButton.UseVisualStyleBackColor = true;
            this._renameAndCopyModeRadioButton.CheckedChanged += new System.EventHandler(this.RenameAndCopyModeRadioButton_CheckedChanged);
            // 
            // _renameModeRadioButton
            // 
            this._renameModeRadioButton.AutoSize = true;
            this._renameModeRadioButton.Checked = true;
            this._renameModeRadioButton.Location = new System.Drawing.Point(6, 19);
            this._renameModeRadioButton.Name = "_renameModeRadioButton";
            this._renameModeRadioButton.Size = new System.Drawing.Size(76, 17);
            this._renameModeRadioButton.TabIndex = 7;
            this._renameModeRadioButton.TabStop = true;
            this._renameModeRadioButton.Text = "Renommer";
            this._renameModeRadioButton.UseVisualStyleBackColor = true;
            this._renameModeRadioButton.CheckedChanged += new System.EventHandler(this.RenameModeRadioButton_CheckedChanged);
            // 
            // _fileNumberingCheckBox
            // 
            this._fileNumberingCheckBox.AutoSize = true;
            this._fileNumberingCheckBox.Location = new System.Drawing.Point(195, 76);
            this._fileNumberingCheckBox.Name = "_fileNumberingCheckBox";
            this._fileNumberingCheckBox.Size = new System.Drawing.Size(127, 17);
            this._fileNumberingCheckBox.TabIndex = 5;
            this._fileNumberingCheckBox.Text = "Numéroter les fichiers";
            this._fileNumberingCheckBox.UseVisualStyleBackColor = true;
            this._fileNumberingCheckBox.CheckedChanged += new System.EventHandler(this.FileNumberingCheckBox_CheckedChanged);
            // 
            // startNumberTextBox
            // 
            this.startNumberTextBox.Enabled = false;
            this.startNumberTextBox.Location = new System.Drawing.Point(195, 33);
            this.startNumberTextBox.Name = "startNumberTextBox";
            this.startNumberTextBox.Size = new System.Drawing.Size(100, 20);
            this.startNumberTextBox.TabIndex = 4;
            this.startNumberTextBox.TextChanged += new System.EventHandler(this.StartNumberTextBox_TextChanged);
            // 
            // _startNumberLabel
            // 
            this._startNumberLabel.AutoSize = true;
            this._startNumberLabel.Location = new System.Drawing.Point(192, 17);
            this._startNumberLabel.Name = "_startNumberLabel";
            this._startNumberLabel.Size = new System.Drawing.Size(92, 13);
            this._startNumberLabel.TabIndex = 3;
            this._startNumberLabel.Text = "Nombre de départ";
            // 
            // generalNameErrorLabel
            // 
            this.generalNameErrorLabel.AutoSize = true;
            this.generalNameErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.generalNameErrorLabel.Location = new System.Drawing.Point(20, 60);
            this.generalNameErrorLabel.Name = "generalNameErrorLabel";
            this.generalNameErrorLabel.Size = new System.Drawing.Size(0, 13);
            this.generalNameErrorLabel.TabIndex = 2;
            // 
            // _generalNameLabel
            // 
            this._generalNameLabel.AutoSize = true;
            this._generalNameLabel.Location = new System.Drawing.Point(20, 17);
            this._generalNameLabel.Name = "_generalNameLabel";
            this._generalNameLabel.Size = new System.Drawing.Size(67, 13);
            this._generalNameLabel.TabIndex = 1;
            this._generalNameLabel.Text = "Nom général";
            // 
            // generalNameTextBox
            // 
            this.generalNameTextBox.Enabled = false;
            this.generalNameTextBox.Location = new System.Drawing.Point(23, 33);
            this.generalNameTextBox.Name = "generalNameTextBox";
            this.generalNameTextBox.Size = new System.Drawing.Size(159, 20);
            this.generalNameTextBox.TabIndex = 0;
            this.generalNameTextBox.TextChanged += new System.EventHandler(this.GeneralNameTextBox_TextChanged);
            // 
            // numberErrorLabel
            // 
            this.numberErrorLabel.AutoSize = true;
            this.numberErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.numberErrorLabel.Location = new System.Drawing.Point(192, 60);
            this.numberErrorLabel.Name = "numberErrorLabel";
            this.numberErrorLabel.Size = new System.Drawing.Size(0, 13);
            this.numberErrorLabel.TabIndex = 13;
            // 
            // ViewForm
            // 
            this.AcceptButton = this._applyButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._resetAllButton;
            this.ClientSize = new System.Drawing.Size(837, 758);
            this.Controls.Add(this._applicationPanel);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this._playlistPanel);
            this.Controls.Add(this._folderFileChoicePanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewForm";
            this.ShowIcon = false;
            this.Text = "MusicSort";
            this._folderFileChoicePanel.ResumeLayout(false);
            this._folderFileChoicePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._openFolderPictureBox)).EndInit();
            this._playlistPanel.ResumeLayout(false);
            this._playlistPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._selectedFilePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this._applicationPanel.ResumeLayout(false);
            this._applicationPanel.PerformLayout();
            this._applicationModeGroupBox.ResumeLayout(false);
            this._applicationModeGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button _baseDirectoryButton;
        private System.Windows.Forms.PictureBox _openFolderPictureBox;
        private System.Windows.Forms.Panel _folderFileChoicePanel;
        private System.Windows.Forms.Panel _playlistPanel;
        private System.Windows.Forms.Label _selectionLabel;
        private System.Windows.Forms.Label _playlistLabel;
        private System.Windows.Forms.PictureBox _selectedFilePictureBox;
        private System.Windows.Forms.Button _addToPlaylistButton;
        private System.Windows.Forms.Button _addAllToPlaylistButton;
        private System.Windows.Forms.Button _stopButton;
        private System.Windows.Forms.Button _playButton;
        private System.Windows.Forms.Button _resetAllButton;
        private System.Windows.Forms.Button _sortButton;
        private System.Windows.Forms.Button _removeAllFromPlaylistButton;
        private System.Windows.Forms.Button _removeFromPlaylistButton;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Panel _applicationPanel;
        private System.Windows.Forms.Label _generalNameLabel;
        private FolderBrowser _folderBrowser;
        private FolderFileListView _folderFileListView;
        private PlaylistView _playlistView;
        private System.Windows.Forms.Button _applyButton;
        private System.Windows.Forms.Button _displayButton;
        private System.Windows.Forms.Label _destinationLabel;
        private System.Windows.Forms.GroupBox _applicationModeGroupBox;
        private System.Windows.Forms.RadioButton _renameAndMoveModeRadioButton;
        private System.Windows.Forms.RadioButton _renameAndCopyModeRadioButton;
        private System.Windows.Forms.RadioButton _renameModeRadioButton;
        private System.Windows.Forms.CheckBox _fileNumberingCheckBox;
        private System.Windows.Forms.Label _startNumberLabel;
        private System.Windows.Forms.Button _destinationButton;
        private System.Windows.Forms.Button _placeDownButton;
        private System.Windows.Forms.Button _placeUpButton;
        public System.Windows.Forms.Label openFolderLabel;
        public System.Windows.Forms.Label selectedFileLabel;
        public System.Windows.Forms.TextBox destinationTextBox;
        public System.Windows.Forms.Label generalNameErrorLabel;
        public System.Windows.Forms.TextBox baseDirectoryTextBox;
        public System.Windows.Forms.Label numberErrorLabel;
        public System.Windows.Forms.TextBox generalNameTextBox;
        public System.Windows.Forms.TextBox startNumberTextBox;
    }
}

