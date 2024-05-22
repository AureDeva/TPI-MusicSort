///ETML
///Auteur : Aurélien Devaud
///Date : 08.05.2024
///Description : Model of the application

using MusicSort.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text.RegularExpressions;

namespace MusicSort.Models
{
    /// <summary>
    /// Model of the application
    /// </summary>
    public class Model
    {
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
        public bool IsPrefixActivated { get; set; }

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
            IsPrefixActivated = false;
            ApplicationMode = ApplicationMode.Rename;
            SupportedTypes = new string[] { "mp3", "wma", "flac", "aac", "wav", "midi", "asf" };
        }

        /// <summary>
        /// Inverts the files' indexes
        /// </summary>
        public void InvertIndexes()
        {
            //ensure the order of the playlist
            RearrangeList();

            //reverse the list
            Playlist.Reverse();

            UpdateIndexes();
        }

        /// <summary>
        /// Sorts the files alphabeticaly
        /// </summary>
        public void SortFiles()
        {
            //sort the list
            Playlist.Sort((f1, f2) => f1.CustomName.CompareTo(f2.CustomName));

            UpdateIndexes();
        }

        /// <summary>
        /// Updates the indexes of the files
        /// </summary>
        public void UpdateIndexes()
        {
            //update the indexes
            for (int i = 0; i < Playlist.Count; i++)
                Playlist[i].IndexInPlaylist = i;
        }

        /// <summary>
        /// Rearrange the list in function of the indexes
        /// </summary>
        public void RearrangeList()
        {
            Playlist.Sort((f1, f2) => f1.IndexInPlaylist.CompareTo(f2.IndexInPlaylist));
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
            //test if the directory exists
            if (path != null && Directory.Exists(path) && path.Length > 0)
            {
                DestinationPath = path;

                //set the paths for the files
                foreach (File file in Playlist)
                    file.SetNewPath(path);

                return true;
            }
            else if (path.Length == 0)
            {
                DestinationPath = "";

                return true;
            }
            else
                return false;
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
                    {
                        //test if the file is already in the playlist
                        if (Playlist.Exists(f => f.FullRealPath == file))
                            files.Add(Playlist.Find(f => f.FullRealPath == file));
                        else
                        {
                            //filter the files
                            if (SupportedTypes.Contains(file.Substring(file.LastIndexOf('.') + 1).ToLower()))
                                files.Add(new File(file));
                        }
                    }

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
        /// Tests if the mode selected is possibly applicable
        /// </summary>
        /// <param name="mode">mode to test</param>
        /// <returns>returns the errors if there are any</returns>
        public List<Tuple<File, ApplicationError>> TestMode(ApplicationMode mode)
        {
            List<Tuple<File, ApplicationError>> results = new List<Tuple<File, ApplicationError>>();

            foreach (File file in Playlist)
            {
                //test if the file is modified
                if (file.FullCustomName != file.FullRealPath)
                {
                    //test for the corresponding mode of application
                    switch (mode)
                    {
                        case ApplicationMode.Rename:
                            //test if the file is read-only
                            if ((System.IO.File.GetAttributes(file.FullRealPath) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                            {
                                results.Add(new Tuple<File, ApplicationError>(file, ApplicationError.ActionUnauthorized));
                            }
                            else
                            {
                                //test the write permissions
                                try
                                {
                                    new FileIOPermission(FileIOPermissionAccess.Write, file.FullRealPath).Demand();

                                    //test if a file already exists with the name
                                    if (System.IO.File.Exists(file.FullCustomName))
                                        results.Add(new Tuple<File, ApplicationError>(file, ApplicationError.FileAlreadyExists));
                                }
                                catch (System.Security.SecurityException)
                                {
                                    results.Add(new Tuple<File, ApplicationError>(file, ApplicationError.ActionUnauthorized));
                                }
                            }
                            break;

                        case ApplicationMode.RenameAndCopy:
                            //test the read permissions
                            try
                            {
                                new FileIOPermission(FileIOPermissionAccess.Read, file.FullRealPath).Demand();

                                //test if a file already exists with the name
                                if (System.IO.File.Exists(file.FullCustomName))
                                    results.Add(new Tuple<File, ApplicationError>(file, ApplicationError.FileAlreadyExists));
                            }
                            catch (System.Security.SecurityException)
                            {
                                results.Add(new Tuple<File, ApplicationError>(file, ApplicationError.ActionUnauthorized));
                            }
                            break;

                        case ApplicationMode.RenameAndMove:
                            //test the write permissions
                            try
                            {
                                new FileIOPermission(FileIOPermissionAccess.Read, file.FullRealPath).Demand();
                                new FileIOPermission(FileIOPermissionAccess.Write, file.FullRealPath).Demand();

                                //test if a file already exists with the name
                                if (System.IO.File.Exists(file.FullCustomName))
                                    results.Add(new Tuple<File, ApplicationError>(file, ApplicationError.FileAlreadyExists));
                            }
                            catch (System.Security.SecurityException)
                            {
                                results.Add(new Tuple<File, ApplicationError>(file, ApplicationError.ActionUnauthorized));
                            }
                            break;
                    }
                }
            }

            return results;
        }

        /// <summary>
        /// Sets a new mode for application
        /// </summary>
        /// <param name="mode">new mode of application</param>
        public void SetNewMode(ApplicationMode mode)
        {
            //test for the corresponding mode of application
            switch (mode)
            {
                case ApplicationMode.Rename:
                    Playlist.ForEach(f =>
                    {
                        f.SetNewPath(f.RealPath);
                        f.IsCopy = false;
                    }
                    );
                    break;

                case ApplicationMode.RenameAndCopy:
                    Playlist.ForEach(f =>
                    {
                        f.SetNewPath(DestinationPath);
                        f.IsCopy = true;
                    }
                    );
                    break;

                case ApplicationMode.RenameAndMove:
                    Playlist.ForEach(f =>
                    {
                        f.SetNewPath(DestinationPath);
                        f.IsCopy = false;
                    }
                     );
                    break;
            }

            ApplicationMode = mode;
        }

        /// <summary>
        /// Tests if the changes can be applied
        /// </summary>
        /// <returns>Returns each file and their errors</returns>
        public List<Tuple<File, ApplicationError>> TestForApplication() => TestMode(ApplicationMode);

        /// <summary>
        /// Sets the prefix of the files from their index
        /// </summary>
        /// <returns>returns if the operation was successful</returns>
        public bool SetPrefixFromIndex()
        {
            if (NumberDigit > 0)
            {
                //number of zeros to add before the number
                int numberOfZeros = 0;

                //set the new prefixes
                foreach (File file in Playlist)
                {
                    numberOfZeros = NumberDigit - $"{file.IndexInPlaylist + StartNumber}".Length;

                    //prefix of the file's name
                    string prefix = "";

                    //add the zeros
                    for (int i = 0; i < numberOfZeros; i++)
                        prefix += "0";

                    prefix += $"{file.IndexInPlaylist + StartNumber}";

                    file.SetNewPrefix(prefix);
                }

                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Sets the custom names of the files as the general name
        /// </summary>
        /// <returns>returns if the operation was successful</returns>
        public bool DisplayGeneralName()
        {
            if (GeneralName != null && GeneralName.Length > 0)
            {
                //set the new names
                foreach (File file in Playlist)
                    file.SetNewName(GeneralName);

                return true;
            }
            else
                return false;
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

        /// <summary>
        /// Sets the new starting number if it is valid
        /// </summary>
        /// <param name="number">new number</param>
        /// <returns>successfulness of the operation</returns>
        public bool SetNewStartingNumber(string number)
        {
            //verify validity
            //test the number is valid
            if (number != null || number.Length > 0)
            {
                if (Regex.IsMatch(number, @"^\d+$"))
                {
                    //stores the result of the parsing
                    int parseResult = 0;

                    //try to parse the given number
                    if (Int32.TryParse(number, out parseResult))
                    {
                        StartNumber = parseResult;
                        NumberDigit = number.Length;
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
            {
                StartNumber = 0;
                NumberDigit = 0;

                return true;
            }
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

    /// <summary>
    /// Enumerates the diffent ways the application of the modifications can be applied
    /// </summary>
    public enum ApplicationError
    {
        FileAlreadyExists,
        ActionUnauthorized
    }
}
