///ETML
///Auteur : Aurélien Devaud
///Date : 08.05.2024
///Description : Contains the more miscellaneous code that doesn't justify the use of multiple files

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
    /// Handles the methods given to controls for triggering actions all the way back to the controller
    /// </summary>
    /// <param name="file">File concerned by the action</param>
    public delegate void DoActionHandler(File file);

    /// <summary>
    /// Handler of events where a path is selected
    /// </summary>
    /// <param name="sender">Sender of the event</param>
    /// <param name="path">Path selected</param>
    public delegate void PathSelectedEventHandler(object sender, string path);

    /// <summary>
    /// Class used to compare elements in the playlist to order them
    /// </summary>
    internal class PlaylistItemComparer : System.Collections.IComparer
    {
        /// <summary>
        /// Comparation method
        /// </summary>
        /// <param name="x">first value to compare</param>
        /// <param name="y">second value to compare</param>
        /// <returns>result to give</returns>
        public int Compare(object x, object y)
        {
            /*
            FileItem x_ = (FileItem)x;

            //test how the items should be sorted
            switch (SortingColumn)
            {
                case SortingColumn.Name:
                    return Compare(((FileItem)x).Text, ((FileItem)y).Text);

                case SortingColumn.Extension:
                    return Compare(((FileItem)x).ItemExtension.Text, ((FileItem)y).ItemExtension.Text);

                default:
                    return Compare(((FileItem)x).Text, ((FileItem)y).Text);

            }
            */
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Enumerate the different types of FileItems
    /// </summary>
    public enum FileItemType
    {
        None,
        Playlist,
        FolderFile
    }
}