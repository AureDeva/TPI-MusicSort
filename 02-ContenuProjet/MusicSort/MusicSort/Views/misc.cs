///ETML
///Auteur : Aurélien Devaud
///Date : 08.05.2024
///Description : Contains the more miscellaneous code that doesn't justify the use of multiple files

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
    /// Enumerate the different types of FileItems
    /// </summary>
    public enum FileItemType
    {
        None,
        Playlist,
        FolderFile
    }
}