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

namespace MusicSort.Views
{
    /// <summary>
    /// Class representing the main interface
    /// </summary>
    public partial class ViewForm : Form
    {
        /// <summary>
        /// Control allowing the user the browse the folders for one to select
        /// </summary>
        public FolderBrowser FolderBrowser { get; private set; }

        /// <summary>
        /// Control allowing the user to view and interact with the files of the playlist
        /// </summary>
        public PlaylistView PlaylistView { get; private set; }

        /// <summary>
        /// Control allowing the user to view and interact with the files retreived from the folder
        /// </summary>
        public FolderFileListView FolderFileListView { get; private set; }

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

            Controls.Add(new FolderBrowser());
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
    }
}
