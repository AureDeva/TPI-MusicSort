///ETML
///Auteur : Aurélien Devaud
///Date : 08.05.2024
///Description : Class representing the menu of an item of the FolderFileList

using MusicSort.Models;
using System;
using System.Windows.Forms;

namespace MusicSort.Views
{
    /// <summary>
    /// Class representing the menu of an item of the FolderFileList
    /// </summary>
    public partial class FolderFileItemMenu : ContextMenuStrip
    {
        /// <summary>
        /// File the menu is for
        /// </summary>
        public File File { get; private set; }

        /// <summary>
        /// Constructor of an instance of the class
        /// </summary>
        /// <param name="file">File the menu is for</param>
        /// <param name="sendToPlaylist">Method to trigger when wanting to play the file</param>
        /// <param name="play">Method to trigger when wanting to send the file to the playlist</param>
        public FolderFileItemMenu(File file, DoActionHandler sendToPlaylist, DoActionHandler play)
        {
            InitializeComponent();

            File = file;

            Items.AddRange(new ToolStripItem[]
            {
                new ToolStripMenuItem("Écouter", null, (object s, EventArgs e) => play(File)),
                new ToolStripMenuItem("Envoyer dans la playlist", null, (object s, EventArgs e) => sendToPlaylist(File))
            });
        }
    }
}
