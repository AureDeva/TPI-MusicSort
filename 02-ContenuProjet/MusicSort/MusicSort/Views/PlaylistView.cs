///ETML
///Auteur : Aurélien Devaud
///Date : 08.05.2024
///Description : Class listing the elements of the playlist

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicSort.Models;

namespace MusicSort.Views
{
    /// <summary>
    /// Class listing the elements of the playlist
    /// </summary>
    public partial class PlaylistView : ListView
    {
        /// <summary>
        /// Column containing the information about the name of the file listed
        /// </summary>
        private ColumnHeader _nameColumn;

        /// <summary>
        /// Column containing the information about the extension of the file listed
        /// </summary>
        private ColumnHeader _extensionColumn;

        /// <summary>
        /// Cosntruct the instance of the class
        /// </summary>
        public PlaylistView()
        {
            InitializeComponent();

            _nameColumn = new ColumnHeader();
            _extensionColumn = new ColumnHeader();

            // NameColumn
            _nameColumn.Text = "Nom";

            // ExtensionColumn
            _extensionColumn.Text = "Extension";

            // PlaylistView
            Columns.AddRange(new ColumnHeader[] {
            _nameColumn,
            _extensionColumn});
            Location = new Point(89, 82);
            Name = "PlaylistView";
            Size = new Size(163, 268);
            UseCompatibleStateImageBehavior = false;
            ListViewItemSorter = new PlaylistItemComparer();

            Refresh();
        }

        /// <summary>
        /// Switches the sorting order of the list
        /// </summary>
        public void SwitchSortOrder()
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Sorts the files in the alphabetical order then return the files in the order found
        /// </summary>
        /// <returns>Files in alphabetical order</returns>
        public File[] SortFiles()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the new files of the list
        /// </summary>
        /// <param name="files">files to set</param>
        public void SetNewFiles(File[] files)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the fileItems that represents the files given
        /// </summary>
        /// <param name="file">files to find the item corresponding to</param>
        /// <returns>retunrs the fileitems corresponding to the files given</returns>
        public FileItem[] GetFileItemsFromFiles(File[] file)
        {
            throw new NotImplementedException();
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
                return Compare(((FileItem)x).File.IndexInPlaylist, ((FileItem)y).File.IndexInPlaylist);
            }
        }
    }
}
