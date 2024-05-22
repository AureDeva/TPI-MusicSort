///ETML
///Auteur : Aurélien Devaud
///Date : 08.05.2024
///Description : Class representing the menu of an item of the playlist

using MusicSort.Models;
using System;
using System.Windows.Forms;

namespace MusicSort.Views
{
    /// <summary>
    /// Class representing the menu of an item of the playlist
    /// </summary>
    public partial class PlaylistItemMenu : ContextMenuStrip
    {
        /// <summary>
        /// File the menu is for
        /// </summary>
        public File File { get; private set; }

        /// <summary>
        /// Constructor of an instance of the class
        /// </summary>
        /// <param name="file">File the menu is for</param>
        /// <param name="reset">Method to trigger when wanting to reset the file</param>
        /// <param name="play">Method to trigger when wanting play the file</param>
        /// <param name="rename">Method to trigger when wanting rename the file</param>
        /// <param name="removeFromPlaylist">Method to trigger when wanting remove the file from the playlist</param>
        /// <param name="placeHigher">Method to trigger when wanting place the file higher in the order</param>
        /// <param name="placeLower">Method to trigger when wanting place the file lower in the order</param>
        public PlaylistItemMenu(File file, DoActionHandler reset, DoActionHandler play, DoActionHandler rename,
            DoActionHandler removeFromPlaylist, DoActionHandler placeHigher, DoActionHandler placeLower)
        {
            InitializeComponent();

            File = file;

            Items.AddRange(new ToolStripItem[]
            {
                new ToolStripMenuItem("Monter", null, (object s, EventArgs e) => placeHigher(File)),
                new ToolStripMenuItem("Descendre", null, (object s, EventArgs e) => placeLower(File)),
                new ToolStripMenuItem("Écouter", null, (object s, EventArgs e) => play(File)),
                new ToolStripMenuItem("Sortir de la playlist", null, (object s, EventArgs e) => removeFromPlaylist(File)),
                new ToolStripMenuItem("Renommer", null, (object s, EventArgs e) => rename(File)),
                new ToolStripMenuItem("Réinitialiser", null, (object s, EventArgs e) => reset(File))
            });
        }
    }
}
