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

            FolderBrowser.SetBaseDirectory();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event triggered when the button to add all files to the playlist is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void AddAllToPlaylistButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event triggered when the button to add the selected files to the playlist is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void AddToPlaylistButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event triggered when the button to remove the selected files from the playlist
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void RemoveFromPlaylistButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event triggered when the button the remove all files of the playlist
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void RemoveAllFromPlaylistButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event triggered when the button to sort the playlist is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void SortButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event triggered when the button to reset all is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void ResetAllButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event triggered when the button to play the playlist is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void PlayButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event triggered when the button to stop playing music is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void StopButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event triggered when the check box of the numbering is checked or unchecked 
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void FileNumberingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event triggered when the text of the start number text box is changed
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void StartNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event triggered when the text of the general name text box is changed
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void GeneralNameTextBox_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event triggered when the radio button of the rename mode is selected
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void RenameModeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event triggered when the radio button of the rename and copy mode is selected
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void RenameAndCopyModeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event triggered when the radio button of the rename and move mode is selected
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void RenameAndMoveModeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event triggered when the button to chose a destination is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void DestinationButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event triggered when the button to display the changes is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void DisplayButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event triggered when the button to apply the changes is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event triggered when a folder is selected in the browser
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void FolderBrowser_FolderSelectedEvent(object sender, string path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event triggered when the button to place the file higher is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void PlaceUpButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event triggered when the button to place the file lower is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void PlaceDownButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
