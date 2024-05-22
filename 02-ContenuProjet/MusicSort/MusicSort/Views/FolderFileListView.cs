///ETML
///Auteur : Aurélien Devaud
///Date : 08.05.2024
///Description : Class listing the files of the selected folder

using MusicSort.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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
        /// Cosntruct the instance of the class
        /// </summary>
        public FolderFileListView()
        {
            InitializeComponent();

            Location = new Point(0, 0);
            Name = "FolderFileListView";
            Size = new Size(210, 350);
            UseCompatibleStateImageBehavior = false;
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

            MouseClick += FolderFileListView_MouseClick;
            MouseDoubleClick += FolderFileListView_MouseDoubleClick;

            Refresh();
        }

        /// <summary>
        /// Event triggered when the user clicks the ListView
        /// </summary>
        /// <param name="sender">Object triggering the event</param>
        /// <param name="e">Arguments of the event</param>
        private void FolderFileListView_MouseClick(object sender, MouseEventArgs e)
        {
            //test if the event was for a right click and if it is a file item
            if (e.Button == MouseButtons.Right && GetItemAt(e.X, e.Y) is FileItem)
            {
                //find the clicked item and show its menu
                ((FileItem)GetItemAt(e.X, e.Y))?.FolderFileMenu.Show(this, e.Location);
            }
        }

        /// <summary>
        /// Event triggered when the control is double clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void FolderFileListView_MouseDoubleClick(object sender, MouseEventArgs e)
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
        /// Sets the new fileItems of the folder
        /// </summary>
        /// <param name="items">new fileItems to set</param>
        public void SetNewFileItems(FileItem[] items)
        {
            //add items that should be added
            foreach (FileItem item in items)
                //test if the item isn't present in the list
                if (!Items.Contains(item))
                    Items.Add(item);

            //remove items that should be removed
            foreach (FileItem item in Items)
                //test if the item isn't present in the array given
                if (!items.Contains(item))
                    Items.Remove(item);

            Refresh();
        }

        /// <summary>
        /// Gets the fileitems corresponding to the files given
        /// </summary>
        /// <param name="files">Files to find to fileitems corresponding to</param>
        /// <returns>returns the fileitems found</returns>
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
    }
}
