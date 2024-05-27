///ETML
///Auteur : Aurélien Devaud
///Date : 08.05.2024
///Description : Class listing the elements of the playlist

using MusicSort.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MusicSort.Views
{
    /// <summary>
    /// Class listing the elements of the playlist
    /// </summary>
    public partial class PlaylistView : ListView
    {
        /// <summary>
        /// Method to trigger when wanting play the file
        /// </summary>
        public DoActionHandler Play { get; set; }

        /// <summary>
        /// Column containing the information about the name of the file listed
        /// </summary>
        private ColumnHeader _nameColumn;

        /// <summary>
        /// Column containing the information about the extension of the file listed
        /// </summary>
        private ColumnHeader _extensionColumn;

        /// <summary>
        /// Comparer of the items
        /// </summary>
        private PlaylistItemComparer _comparer;

        /// <summary>
        /// Cosntruct the instance of the class
        /// </summary>
        public PlaylistView()
        {
            InitializeComponent();

            // PlaylistView
            Location = new Point(0, 0);
            Name = "PlaylistView";
            Size = new Size(210, 350);
            UseCompatibleStateImageBehavior = false;
            _comparer = new PlaylistItemComparer();
            ListViewItemSorter = _comparer;
            Sorting = SortOrder.Ascending;

            View = View.Details;
            Scrollable = true;

            _nameColumn = new ColumnHeader()
            {
                Width = Size.Width / 3 * 2,
                Text = "Nom"
            };
            _extensionColumn = new ColumnHeader()
            {
                Width = Size.Width / 3 - (Size.Width % 3 * 3),
                Text = "Extension"
            };

            Columns.Add(_nameColumn);
            Columns.Add(_extensionColumn);

            MouseClick += PlaylistView_MouseClick;
            MouseDoubleClick += PlaylistView_MouseDoubleClick;

            Refresh();
        }

        /// <summary>
        /// Event triggered when the user clicks the ListView
        /// </summary>
        /// <param name="sender">Object triggering the event</param>
        /// <param name="e">Arguments of the event</param>
        private void PlaylistView_MouseClick(object sender, MouseEventArgs e)
        {
            //test if the event was for a right click and if it is a file item
            if (e.Button == MouseButtons.Right && GetItemAt(e.X, e.Y) is FileItem)
            {
                //find the clicked item and show its menu
                ((FileItem)GetItemAt(e.X, e.Y))?.PlaylistMenu.Show(this, e.Location);
            }
        }

        /// <summary>
        /// Event triggered when double clicking the list view
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void PlaylistView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //test if item clicked was of FileItem type
            if (GetItemAt(e.X, e.Y) is FileItem)
            {
                //detect if an item was double clicked
                if ((FileItem)GetItemAt(e.X, e.Y) != null)
                {
                    FileItem item = (FileItem)GetItemAt(e.X, e.Y);
                    Play(item.File);
                }
            }
        }

        /// <summary>
        /// Gets the fileItems that represents the files given
        /// </summary>
        /// <param name="files">files to find the item corresponding to</param>
        /// <returns>retunrs the fileitems corresponding to the files given</returns>
        public FileItem[] GetFileItemsFromFiles(File[] files)
        {
            //list of items to returns
            List<FileItem> items = new List<FileItem>();

            //go through the files
            foreach (File file in files)
                //go through the items
                foreach (FileItem item in Items)
                    //test if it is the right item
                    if (item.File == file)
                        items.Add(item);

            return items.ToArray();
        }

        /// <summary>
        /// Class used to compare the files 
        /// </summary>
        private class PlaylistItemComparer : System.Collections.IComparer
        {
            /// <summary>
            /// Comparation method
            /// </summary>
            /// <param name="x">first value to compare</param>
            /// <param name="y">second value to compare</param>
            /// <returns>result to give</returns>
            public int Compare(object x, object y)
            {
                FileItem x_ = (FileItem)x;
                FileItem y_ = (FileItem)y;

                return x_.File.IndexInPlaylist.CompareTo(y_.File.IndexInPlaylist);
            }
        }
    }
}
