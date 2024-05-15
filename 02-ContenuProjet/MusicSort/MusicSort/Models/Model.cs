///ETML
///Auteur : Aurélien Devaud
///Date : 08.05.2024
///Description : Model of the application

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicSort.Controllers;
using System.IO;
using System.Windows.Forms;

namespace MusicSort.Models
{
    /// <summary>
    /// Model of the application
    /// </summary>
    public class Model
    {

        /// <summary>
        /// Tells if the number prefix is activated
        /// </summary>
        private bool _isPrefixActivated;

        /// <summary>
        /// File types supported by the applicatiom
        /// </summary>
        public string[] SupportedTypes { get; }

        /// <summary>
        /// Controller of the application
        /// </summary>
        public Controller Controller { get; set; }

        /// <summary>
        /// List containing the files of the playlist
        /// </summary>
        public List<File> Playlist { get; private set; }

        /// <summary>
        /// Path of the directory where the files end after application
        /// </summary>
        public string DestinationPath { get; private set; }

        /// <summary>
        /// Path of the directory currently selected for file selection
        /// </summary>
        public string SelectedPath { get; set; }

        /// <summary>
        /// General name given to all files of the playlist
        /// </summary>
        public string GeneralName { get; private set; }

        /// <summary>
        /// Prefix of files if the numbering is activated
        /// </summary>
        public string NumberPrefix { get => throw new NotImplementedException(); }

        /// <summary>
        /// Number of digits in the prefix
        /// </summary>
        public int NumberDigit { get; private set; }

        /// <summary>
        /// Starting number of the playlist numbering
        /// </summary>
        public int StartNumber { get; private set; }

        /// <summary>
        /// Get: Tells if the number prefix is activated
        /// Set: If the prefix is activated, set the prefix, if not remove it
        /// </summary>
        public bool IsPrefixActivated 
        { 
            get => _isPrefixActivated; 
            set => throw new NotImplementedException();
        }

        /// <summary>
        /// Mode of application of the changes
        /// </summary>
        public ApplicationMode ApplicationMode { get; set; }

        /// <summary>
        /// Constructor of the Model
        /// </summary>
        public Model()
        {
            Playlist = new List<File>();
            DestinationPath = "";
            SelectedPath = "";
            GeneralName = "";
            NumberDigit = 0;
            StartNumber = 0;
            _isPrefixActivated = false;
            ApplicationMode = ApplicationMode.Rename;
            SupportedTypes = new string[] { "mp3", "wma", "flac"};
        }

        /// <summary>
        /// Sorts the files alphabeticaly
        /// </summary>
        public void SortFiles()
        {
            //sort the list
            Playlist.Sort((f1, f2) => f1.CustomName.CompareTo(f2.CustomName));

            //update the indexes
            for (int i = 0; i < Playlist.Count; i++)
                Playlist[i].IndexInPlaylist = i;
        }

        /// <summary>
        /// Finds a file wich has the given index
        /// </summary>
        /// <param name="index">index of the file to find</param>
        /// <returns>File found</returns>
        public File FindFileByIndex(int index)
        {
            //find the file
            foreach (File file in Playlist)
                if (file.IndexInPlaylist == index)
                    return file;

            return null;
        }

        /// <summary>
        /// Sets a new destination for the applied changes
        /// </summary>
        /// <param name="path">Path of destination</param>
        /// <returns>returns if the operation was successful</returns>
        public bool SetNewDestination(string path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the music files from a directory
        /// </summary>
        /// <param name="path">Path of the directory to search through</param>
        /// <returns>Returns the flac, mp3, wma files found in the directory</returns>
        public File[] GetFilesFromDirectory(string path)
        {
            //test if the directory exists
            if (Path.IsPathRooted(path))
            {
                //get the files of the directory
                try
                {
                    //get the files of the directory and filter them
                    List<File> files = new List<File>();
                    foreach (string file in Directory.GetFiles(path))
                        //filter the files
                        if (SupportedTypes.Contains(file.Substring(file.LastIndexOf('.') + 1).ToLower()))
                            files.Add(new File(file));

                    return files.ToArray();
                }
                catch (UnauthorizedAccessException)
                {
                    return null;
                }
            }
            else
                return null;
        }

        /// <summary>
        /// Tests if a name is valid for a file
        /// </summary>
        /// <param name="name">New name of the file</param>
        /// <param name="file">file to test</param>
        /// <returns>Returns if the name is valid</returns>
        public bool IsValidFileName(string name, File file)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Tests if the mode selected is possibly applicable
        /// </summary>
        /// <param name="mode">mode to test</param>
        /// <returns>returns if the mode is applicable</returns>
        public bool TestMode(ApplicationMode mode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets a new mode for application
        /// </summary>
        /// <param name="mode">new mode of application</param>
        public void SetNewMode(ApplicationMode mode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Tests if the changes can be applied
        /// </summary>
        /// <returns>Returns each file and their errors</returns>
        public List<Tuple<File, string>> TestForApplication()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the prefix of the files from their index
        /// </summary>
        /// <returns>returns if the operation was successful</returns>
        public bool SetPrefixFromIndex()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets a new general name if it is valid
        /// </summary>
        /// <param name="name">new name</param>
        /// <returns>successfulness of the operation</returns>
        public bool SetNewGeneralName(string name)
        {
            //verify validity
            //test the name is valid
            if (!name.Any(c => Path.GetInvalidFileNameChars().Contains(c)) || name.Length <= 255)
            {
                GeneralName = name;
                return true;
            }

            return false;
        }
    }

    /// <summary>
    /// Enumerates the diffent ways the application of the modifications can be applied
    /// </summary>
    public enum ApplicationMode
    {
        Rename,
        RenameAndCopy,
        RenameAndMove
    }
}
