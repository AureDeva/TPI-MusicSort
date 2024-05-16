///ETML
///Auteur : Aurélien Devaud
///Date : 08.05.2024
///Description : Class managing the information of a file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MusicSort.Models
{
    /// <summary>
    /// Class managing the information of a file
    /// </summary>
    public class File
    {
        /// <summary>
        /// Full real path of the file
        /// </summary>
        public string FullRealPath { get; private set; }

        /// <summary>
        /// Getter of the real extension of the file
        /// </summary>
        public string RealExtension { get => System.IO.Path.GetExtension(FullRealPath).TrimStart('.'); }

        /// <summary>
        /// Getter of the real name of the file
        /// </summary>
        public string RealName { get => System.IO.Path.GetFileNameWithoutExtension(FullRealPath); }

        /// <summary>
        /// Getter of the real path of the file
        /// </summary>
        public string RealPath { get => System.IO.Path.GetDirectoryName(FullRealPath); }

        /// <summary>
        /// Getter of the name to display in the interface
        /// </summary>
        public string DisplayName { get => Prefix + CustomName; }

        /// <summary>
        /// Getter of the full custom name of the file
        /// </summary>
        public string FullCustomName { get => CustomPath + '\\' + Prefix + CustomName + '.' + RealExtension; }

        /// <summary>
        /// Custom name of the file (not the name of the real file) without the extension and path
        /// </summary>
        public string CustomName { get; private set; }

        /// <summary>
        /// Custom path of the file (not the path of the real file)
        /// </summary>
        public string CustomPath { get; private set; }

        /// <summary>
        /// Prefix of the file
        /// </summary>
        public string Prefix { get; private set; }

        /// <summary>
        /// Index of the file in the playlist
        /// </summary>
        public int IndexInPlaylist { get; set; }

        /// <summary>
        /// Tells if the 'custom' file is a copy
        /// </summary>
        public bool IsCopy { get; set; }

        /// <summary>
        /// Event triggered when an information is changed
        /// </summary>
        public event FileInfoChangedEventHandler FileInfoChangedEvent;

        /// <summary>
        /// Constructor of an instance of the class
        /// </summary>
        /// <param name="fullRealPath">full path of the file</param>
        /// <param name="indexInPlaylist">index of the file for sorting</param>
        public File(string fullRealPath, int indexInPlaylist = 0)
        {
            FullRealPath = fullRealPath;
            CustomName = RealName;
            CustomPath = RealPath;
            Prefix = "";
            IndexInPlaylist = indexInPlaylist;
            IsCopy = false;
        }

        /// <summary>
        /// Tests if the file would be unique in the path given
        /// </summary>
        /// <param name="path">Path of the file</param>
        /// <returns>Returns if the file would be unique</returns>
        public bool WouldFileBeUnique(string path) => !System.IO.File.Exists(path + "\\" + DisplayName + "." + RealExtension);

        /// <summary>
        /// Sets a new prefix for the file
        /// </summary>
        /// <param name="prefix">new prefix of the file</param>
        /// <returns>Returns if the operation was successful</returns>
        public bool SetNewPrefix(string prefix)
        {
            Prefix = prefix + "_";
            FileInfoChangedEvent?.Invoke(this);
            return true;
        }

        /// <summary>
        /// Sets a new name for the file
        /// </summary>
        /// <param name="name">new name of the file</param>
        /// <returns>Returns if the operation was successful</returns>
        public bool SetNewName(string name)
        {
            //verify validity
            //test the name is valid
            if(!name.Any(c => Path.GetInvalidFileNameChars().Contains(c)) || name.Length <= 255)
            {
                //test if the name would still be unique
                if (!(System.IO.File.Exists(CustomPath + '\\' + name + '.' + RealExtension) || name == CustomName))
                {
                    CustomName = name;
                    FileInfoChangedEvent?.Invoke(this);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Sets a new path for the file
        /// </summary>
        /// <param name="path">new path of the file</param>
        /// <returns>Returns if the operation was successful</returns>
        public bool SetNewPath(string path)
        {
            //test if the path is valid
            if (path != null && Directory.Exists(path))
            {
                CustomPath = path;
                FileInfoChangedEvent?.Invoke(this);
                return true;
            }
            else
                return false;

        }

        /// <summary>
        /// Applies the changes done to the file
        /// </summary>
        /// <returns>Returns if the operation was successful</returns>
        public bool ApplyChanges()
        {
            //test if the name is different than the last one
            if (FullCustomName == FullRealPath)
                return true;

            //test if the new full name is valid
            if (Path.IsPathRooted(FullCustomName) && FullCustomName.Length < 260)
            {
                //test if a file doesn't already exist with the same name 
                if (!System.IO.File.Exists(FullCustomName))
                {
                    //test if the file should be renamed
                    if (!IsCopy)
                        System.IO.File.Move(FullRealPath, FullCustomName);
                    else
                        System.IO.File.Copy(FullRealPath, FullCustomName);

                    FullRealPath = FullCustomName;

                    return true;
                }
                //if not, try to replace it
                else
                {
                    try
                    {
                        System.IO.File.Delete(FullCustomName);

                        //test if the file should be renamed
                        if (!IsCopy)
                            System.IO.File.Move(FullRealPath, FullCustomName);
                        else
                            System.IO.File.Copy(FullRealPath, FullCustomName);

                        FullRealPath = FullCustomName;

                        return true;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        return false;
                    }
                }
            }
            else
                return false;
        }
    }

    /// <summary>
    /// Delegate handling the event an info changed in the file
    /// </summary>
    /// <param name="file">File changed</param>
    public delegate void FileInfoChangedEventHandler(File file);
}
