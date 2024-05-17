///ETML
///Auteur : Aurélien Devaud
///Date : 08.05.2024
///Description : Class representing the main interface

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicSort.Controllers;
using MusicSort.Models;

namespace MusicSort.Views
{
    /// <summary>
    /// Class representing the main interface
    /// </summary>
    public partial class ViewForm : Form
    {
        /// <summary>
        /// Controller of the application
        /// </summary>
        public Controller Controller { get; set; }

        /// <summary>
        /// Control allowing the user the browse the folders for one to select
        /// </summary>
        public FolderBrowser FolderBrowser { get => _folderBrowser; }

        /// <summary>
        /// Control allowing the user to view and interact with the files of the playlist
        /// </summary>
        public PlaylistView PlaylistView { get => _playlistView; }

        /// <summary>
        /// Control allowing the user to view and interact with the files retreived from the folder
        /// </summary>
        public FolderFileListView FolderFileListView { get => _folderFileListView; }

        /// <summary>
        /// Control used to listen to music
        /// </summary>
        public PlaylistPlayer MusicPlayer { get; private set; }

        /// <summary>
        /// Constructor of an instance of the class
        /// </summary>
        public ViewForm()
        {
            InitializeComponent();

            FormClosing += ViewForm_FormClosing;

            //set up the folder browser
            FolderBrowser.SetBaseDirectory();

            //set up the playlist
            PlaylistView.ColumnClick += (e, arg) => Controller.SwitchSortingOrder();
            PlaylistView.ItemSelectionChanged += PlaylistView_ItemSelectionChanged;

            //set up the music player
            MusicPlayer = new PlaylistPlayer();
            Controls.Add(MusicPlayer);
            MusicPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(new System.ComponentModel.ComponentResourceManager(typeof(ViewForm)).GetObject("MusicPlayer.OcxState")));
            MusicPlayer.MediaChange += MusicPlayer_MediaChange;


            //create the toolTip
            ToolTip toolTip = new ToolTip()
            {
                AutoPopDelay = 5000,
                InitialDelay = 1000,
                ReshowDelay = 500,
                ShowAlways = true
            };

            //set the tips
            toolTip.SetToolTip(_baseDirectoryButton, "Choix du dossier de base.");
            toolTip.SetToolTip(_addAllToPlaylistButton, "Ajout de tous les fichiers du dossier dans la playlist.");
            toolTip.SetToolTip(_addToPlaylistButton, "Ajout des fichiers sélectionnés du dossier dans la playlist.");
            toolTip.SetToolTip(_removeFromPlaylistButton, "Sort les fichiers sélectionnés de la playlist.");
            toolTip.SetToolTip(_removeAllFromPlaylistButton, "Sort tous les fichiers de la playlist.");
            toolTip.SetToolTip(_sortButton, "Trie les fichiers dans l'ordre alphabétique (sans prendre en compte le numéro ajouté).");
            toolTip.SetToolTip(_resetAllButton, "Réinitialise tous les fichiers de la playlist.");
            toolTip.SetToolTip(_playButton, "Lance la lecture de la playlist.");
            toolTip.SetToolTip(_stopButton, "Stop la lecture.");
            toolTip.SetToolTip(_placeUpButton, "Monte les fichiers sélectionnés dans la playlist.");
            toolTip.SetToolTip(_placeDownButton, "Descend les fichiers sélectionnés dans la playlist.");
            toolTip.SetToolTip(generalNameTextBox, "Donne un nom général à tous les fichiers de la playlist.");
            toolTip.SetToolTip(startNumberTextBox, "Premier numéro utilisé dans la numérotation (garde en mémoire le nombre chiffres).");
            toolTip.SetToolTip(_fileNumberingCheckBox, "Active ou désactive la numérotation des fichiers de la playlist (nécessaire pour le nom général).");
            toolTip.SetToolTip(_renameModeRadioButton, "Mode qui, lors de l'application, renomme les fichiers originaux selon les noms donnés.");
            toolTip.SetToolTip(_renameAndCopyModeRadioButton, "Mode qui, lors de l'application, copie et renomme les fichiers originaux selon les noms et la destination donnés.");
            toolTip.SetToolTip(_renameAndMoveModeRadioButton, "Mode qui, lors de l'application, déplace et renomme les fichiers originaux selon les noms et la destination donnés.");
            toolTip.SetToolTip(_destinationButton, "Choix du dossier de destination.");
            toolTip.SetToolTip(_displayButton, "Permet d'apercevoir les changements apportés par la numéroation et le nom général.");
            toolTip.SetToolTip(applyButton, "Applique les changements.");

        }

        /// <summary>
        /// Event triggered when the media is changed
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void MusicPlayer_MediaChange(object sender, AxWMPLib._WMPOCXEvents_MediaChangeEvent e)
        {
            //test if there is a media currently playing
            if (MusicPlayer.currentMedia != null)
                _filePlayingLabel.Text = MusicPlayer.currentMedia.name;
            else
                _filePlayingLabel.Text = "";
        }

        /// <summary>
        /// Event triggered when the form is closing
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void ViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool cancel = false;
            Controller.Exit(out cancel);
            e.Cancel = cancel;
        }

        /// <summary>
        /// Event triggered when the selection of items changes
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void PlaylistView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            selectedFileLabel.Text = ((FileItem)e.Item).File.DisplayName;
        }

        /// <summary>
        /// Ask a new name for the file from the user
        /// </summary>
        /// <param name="file">file renaming</param>
        /// <returns>new name</returns>
        public string AskForNewName(File file)
        {
            //open the renaming form
            FileRenamingForm form = new FileRenamingForm(file);
            DialogResult result = form.ShowDialog();

            if (result == DialogResult.Yes)
                return form.NewName;
            else
                return null;
        }

        /// <summary>
        /// Set the fileItems of the folder list view
        /// </summary>
        /// <param name="files">Files to set</param>
        public void SetFileItemsForFolderListView(File[] files)
        {
            //items to set for the folder list view
            List<FileItem> fileItems = new List<FileItem>();

            FolderFileListView.Items.Clear();

            //create the items
            foreach (File file in files)
            {
                fileItems.Add(
                        new FileItem(
                            file,
                            Controller.ResetFile,
                            Controller.ListenToFile,
                            Controller.RenameFile,
                            new DoActionHandler(f => Controller.RemoveFilesFromPlaylist(new File[] { f })),
                            new DoActionHandler(f => Controller.PlaceFilesHigher(new File[] { f })),
                            new DoActionHandler(f => Controller.PlaceFilesLower(new File[] { f })),
                            new DoActionHandler(f => Controller.SendFilesToPlaylist(new File[] { f })),
                            FileItemType.FolderFile
                            )
                        );
            }

            FolderFileListView.Items.AddRange(fileItems.ToArray());
        }

        /// <summary>
        /// Add new FileItems to the playlist
        /// </summary>
        /// <param name="files">files to add as items</param>
        public void SetFileItemsForPlaylistView(File[] files) 
        {
            //items to set for the playlist view
            List<FileItem> fileItemsToRemove = new List<FileItem>();

            //create the items that are missing in the playlist
            foreach (File file in files)
            {
                bool isMissing = true;

                //test if the fileitem is already there
                foreach (FileItem item in PlaylistView.Items)
                    if (item.File == file)
                        isMissing = false;

                //add the file item
                if (isMissing)
                    PlaylistView.Items.Add(
                        new FileItem(
                            file,
                            Controller.ResetFile,
                            Controller.ListenToFile,
                            Controller.RenameFile,
                            new DoActionHandler(f => Controller.RemoveFilesFromPlaylist(new File[] { f })),
                            new DoActionHandler(f => Controller.PlaceFilesHigher(new File[] { f })),
                            new DoActionHandler(f => Controller.PlaceFilesLower(new File[] { f })),
                            new DoActionHandler(f => Controller.SendFilesToPlaylist(new File[] { f })),
                            FileItemType.Playlist
                            )
                        );
            }

            //remove the unwanted fileItems
            foreach (FileItem item in PlaylistView.Items)
            {
                bool inPlaylist = false;

                //find if there is a corresponding file
                foreach (File file in files)
                    if (item.File == file)
                        inPlaylist = true;

                if (!inPlaylist)
                    fileItemsToRemove.Add(item);
            }

            //remove the fileItems
            foreach (FileItem item in fileItemsToRemove)
                PlaylistView.Items.Remove(item);
        }

        /// <summary>
        /// Method used to inform the user of something
        /// </summary>
        /// <param name="title">Title of the info</param>
        /// <param name="info">Information to send</param>
        public void InformUser(string title, string info) => MessageBox.Show(info, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

        /// <summary>
        /// Asks for confirmation of the user
        /// </summary>
        /// <param name="title">title of the Message box</param>
        /// <param name="query">Query to the user</param>
        /// <returns>Answer of the user</returns>
        public bool AskForConfirmation(string title, string query) => MessageBox.Show(query, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes;

        /// <summary>
        /// Sends an error message to the user
        /// </summary>
        /// <param name="title">Title of the message</param>
        /// <param name="errorMessage">Message</param>
        public void SendErrorMessage(string title, string errorMessage) => MessageBox.Show(errorMessage, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

        /// <summary>
        /// Open a folder browser and get a path
        /// </summary>
        /// <returns>Folder path</returns>
        public string OpenFolderBrowserDialog()
        {
            //open a folder browser and return the path if one was selected
            using (FolderBrowserDialog browser = new FolderBrowserDialog() { Description = "Recherche de dossier d'images" })
                return browser.ShowDialog() == DialogResult.OK ? browser.SelectedPath : null;
        }
        /// <summary>
        /// Event triggered when the button to find the base directory is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void BaseDirectoryButton_Click(object sender, EventArgs e)
        {
            Controller.SelectDirectory();
        }

        /// <summary>
        /// Event triggered when the button to add all files to the playlist is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void AddAllToPlaylistButton_Click(object sender, EventArgs e)
        {
            //files to send to playlist
            List<File> files = new List<File>();

            //find the items
            foreach (FileItem item in FolderFileListView.Items)
                files.Add(item.File);

            Controller.SendFilesToPlaylist(files.ToArray());
        }

        /// <summary>
        /// Event triggered when the button to add the selected files to the playlist is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void AddToPlaylistButton_Click(object sender, EventArgs e)
        {
            //files to send to playlist
            List<File> files = new List<File>();

            //find the selected items
            foreach (FileItem item in FolderFileListView.SelectedItems)
                files.Add(item.File);

            Controller.SendFilesToPlaylist(files.ToArray());
        }

        /// <summary>
        /// Event triggered when the button to remove the selected files from the playlist
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void RemoveFromPlaylistButton_Click(object sender, EventArgs e)
        {
            //files to send to playlist
            List<File> files = new List<File>();

            //find the selected items
            foreach (FileItem item in PlaylistView.SelectedItems)
                files.Add(item.File);

            Controller.RemoveFilesFromPlaylist(files.ToArray());
        }

        /// <summary>
        /// Event triggered when the button the remove all files of the playlist
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void RemoveAllFromPlaylistButton_Click(object sender, EventArgs e)
        {
            //files to send to playlist
            List<File> files = new List<File>();

            //find the selected items
            foreach (FileItem item in PlaylistView.Items)
                files.Add(item.File);

            Controller.RemoveFilesFromPlaylist(files.ToArray());
        }

        /// <summary>
        /// Event triggered when the button to sort the playlist is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void SortButton_Click(object sender, EventArgs e)
        {
            Controller.SortPlaylist();
        }

        /// <summary>
        /// Event triggered when the button to reset all is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void ResetAllButton_Click(object sender, EventArgs e)
        {
            Controller.ResetAll();
        }

        /// <summary>
        /// Event triggered when the button to play the playlist is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void PlayButton_Click(object sender, EventArgs e)
        {
            Controller.StartPlaylist();
        }

        /// <summary>
        /// Event triggered when the button to stop playing music is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void StopButton_Click(object sender, EventArgs e)
        {
            Controller.StopPlaylist();
        }

        /// <summary>
        /// Event triggered when the check box of the numbering is checked or unchecked 
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void FileNumberingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //test if the box was checked
            if (((CheckBox)sender).Checked)
            {
                Controller.ActivateNumbering();
                generalNameTextBox.Enabled = true;
                startNumberTextBox.Enabled = true;
                _displayButton.Enabled = true;
            }
            //if the box was unchecked
            else
            {
                Controller.DeactivateNumbering();
                generalNameTextBox.Enabled = false;
                startNumberTextBox.Enabled = false;
                _displayButton.Enabled = false;
            }
        }

        /// <summary>
        /// Event triggered when the text of the start number text box is changed
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void StartNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            Controller.InputNewNumber(((TextBox)sender).Text);
        }

        /// <summary>
        /// Event triggered when the text of the general name text box is changed
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void GeneralNameTextBox_TextChanged(object sender, EventArgs e)
        {
            Controller.InputNewGeneralName(((TextBox)sender).Text);
        }

        /// <summary>
        /// Event triggered when the radio button of the rename mode is selected
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void RenameModeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Controller.ChangeApplicationMode(ApplicationMode.Rename);
        }

        /// <summary>
        /// Event triggered when the radio button of the rename and copy mode is selected
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void RenameAndCopyModeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Controller.ChangeApplicationMode(ApplicationMode.RenameAndCopy);
        }

        /// <summary>
        /// Event triggered when the radio button of the rename and move mode is selected
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void RenameAndMoveModeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Controller.ChangeApplicationMode(ApplicationMode.RenameAndMove);
        }

        /// <summary>
        /// Event triggered when the button to chose a destination is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void DestinationButton_Click(object sender, EventArgs e)
        {
            Controller.SearchForDestinationDirectory();
        }

        /// <summary>
        /// Event triggered when the button to display the changes is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void DisplayButton_Click(object sender, EventArgs e)
        {
            Controller.DisplayGeneralChanges();
        }

        /// <summary>
        /// Event triggered when the button to apply the changes is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            Controller.Apply();
        }

        /// <summary>
        /// Event triggered when a folder is selected in the browser
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void FolderBrowser_FolderSelectedEvent(object sender, string path)
        {
            Controller.DirectorySelected(path);
        }

        /// <summary>
        /// Event triggered when the button to place the file higher is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void PlaceUpButton_Click(object sender, EventArgs e)
        {
            //files to send to place higher
            List<File> files = new List<File>();

            //find the selected items
            foreach (FileItem item in PlaylistView.SelectedItems)
                files.Add(item.File);

            Controller.PlaceFilesHigher(files.ToArray());
        }

        /// <summary>
        /// Event triggered when the button to place the file lower is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void PlaceDownButton_Click(object sender, EventArgs e)
        {
            //files to send to place higher
            List<File> files = new List<File>();

            //find the selected items
            foreach (FileItem item in PlaylistView.SelectedItems)
                files.Add(item.File);

            Controller.PlaceFilesLower(files.ToArray());
        }
    }
}
