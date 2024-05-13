///ETML
///Auteur : Aurélien Devaud
///Date : 08.05.2024
///Description : Class listing the files of the selected folder

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
    /// Class listing the files of the selected folder
    /// </summary>
    public partial class FolderFileListView : ListView
    {
        /// <summary>
        /// Method to trigger when wanting to reset the file
        /// </summary>
        public DoActionHandler Reset { get; set; }

        /// <summary>
        /// Method to trigger when wanting place the file lower in the order
        /// </summary>
        public DoActionHandler Play { get; set; }

        /// <summary>
        /// Method to trigger when wanting rename the file
        /// </summary>
        public DoActionHandler Rename { get; set; }

        /// <summary>
        /// Method to trigger when wanting remove the file from the playlist
        /// </summary>
        public DoActionHandler RemoveFromPlaylist { get; set; }

        /// <summary>
        /// Method to trigger when wanting place the file higher in the order
        /// </summary>
        public DoActionHandler PlaceHigher { get; set; }

        /// <summary>
        /// Method to trigger when wanting place the file lower in the order
        /// </summary>
        public DoActionHandler PlaceLower { get; set; }

        /// <summary>
        /// Method to trigger when wanting to send the file to the playlist
        /// </summary>
        public DoActionHandler SendToPlaylist { get; set; }

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
        public FolderFileListView()
        {
            InitializeComponent();

            _nameColumn = new ColumnHeader();
            _extensionColumn = new ColumnHeader();

            // NameColumn
            _nameColumn.Text = "Nom";

            // ExtensionColumn
            _extensionColumn.Text = "Extension";

            // FolderFileListView
            Columns.AddRange(new ColumnHeader[] {
            _nameColumn,
            _extensionColumn});
            Location = new Point(89, 82);
            Name = "FolderFileListView";
            Size = new Size(163, 268);
            UseCompatibleStateImageBehavior = false;

            Refresh();
        }

        /// <summary>
        /// Sets the new files of the folder
        /// </summary>
        /// <param name="files">new files to set</param>
        public void SetNewFiles(File[] files)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the fileitems corresponding to the files given
        /// </summary>
        /// <param name="files">Files to find to fileitems corresponding to</param>
        /// <returns>returns the fileitems found</returns>
        public FileItem[] GetFileItemsFromFiles(File[] files)
        {
            throw new NotImplementedException();
        }
    }
}
