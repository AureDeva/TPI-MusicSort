///ETML
///Auteur : Aurélien Devaud
///Date : 08.05.2024
///Description : Class representing an item of the lists of files

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicSort.Models;

namespace MusicSort.Views
{
    /// <summary>
    /// Class representing an item of the lists of files
    /// </summary>
    public class FileItem : ListViewItem
    {
        /// <summary>
        /// File the item represents
        /// </summary>
        public File File { get; private set; }

        /// <summary>
        /// Menu of the file item when it is in the playlist
        /// </summary>
        public PlaylistItemMenu PlaylistMenu { get; private set; }

        /// <summary>
        /// Menu of the file item when it is in the folder
        /// </summary>
        public FolderFileItemMenu FolderFileMenu { get; private set; }

        /// <summary>
        /// Type of the item
        /// </summary>
        public FileItemType ItemType { get; private set; }

        /// <summary>
        /// Method to trigger when wanting to play the file
        /// </summary>
        public DoActionHandler Play { get; }

        /// <summary>
        /// Extension of the item
        /// </summary>
        public ListViewSubItem ItemExtension { get; private set; }

        /// <summary>
        /// Constructor of an instance of the class
        /// </summary>
        /// <param name="file">File the item represents</param>
        /// <param name="reset">Method to trigger when wanting a reset of the file</param>
        /// <param name="play">Method to trigger when wanting to play the file</param>
        /// <param name="rename">Method to trigger when wanting to rename a file</param>
        /// <param name="removeFromPlaylist">Method to trigger when wanting to remove a file from the playlist</param>
        /// <param name="placeHigher">Method to trigger when wanting to place the file higher in the playlist</param>
        /// <param name="placeLower">Method to trigger when wanting to place the file lower in the playlist</param>
        /// <param name="sendToPlaylist">Method to trigger when wanting to send the file to the playlist</param>
        public FileItem(File file, DoActionHandler reset, DoActionHandler play, DoActionHandler rename, DoActionHandler removeFromPlaylist, 
            DoActionHandler placeHigher, DoActionHandler placeLower, DoActionHandler sendToPlaylist)
        {
            File = file;
            Play = play;
            Text = File.DisplayName;
            ItemExtension = new ListViewSubItem(this, file.RealExtension);
            FolderFileMenu = new FolderFileItemMenu(file, sendToPlaylist, play);
            PlaylistMenu = new PlaylistItemMenu(file, reset, play, rename, removeFromPlaylist, placeHigher, placeLower);

            SubItems.Add(ItemExtension);
        }

        /// <summary>
        /// Switch the type of the item to the one given
        /// </summary>
        /// <param name="itemType">new type</param>
        public void SwitchItemType(FileItemType itemType)
        {
            //test if the type is different than the current one
            if (itemType != ItemType)
                ItemType = itemType;
        }

        /// <summary>
        /// Refreshes the name of the file
        /// </summary>
        public void RefreshName()
        {
            Text = File.DisplayName;
            ItemExtension.Text = File.RealExtension;
        }
    }
}
