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
using NAudio.Wave;
using System.Diagnostics;
using NAudio.Lame;

namespace MusicSort.Models
{
    /// <summary>
    /// Class managing the information of a file
    /// </summary>
    public class File
    {
        /// <summary>
        /// Path of the temporary files' directory
        /// </summary>
        public static string TempFilesDirectoryPath { get => AppDomain.CurrentDomain.BaseDirectory + "\\" + "temp_files"; }

        /// <summary>
        /// Separator of the prefix and the name
        /// </summary>
        private static  readonly char _prefixSeparator = ' ';

        /// <summary>
        /// Consctructs the static parts of the class
        /// </summary>
        static File()
        {
            //set temp files directory
            //test if the directory exists
            if (Directory.Exists(TempFilesDirectoryPath))
                CleanTempFilesDirectory();
            else
                Directory.CreateDirectory(TempFilesDirectoryPath);
        }

        /// <summary>
        /// Clean the directory of files
        /// </summary>
        public static void CleanTempFilesDirectory()
        {
            //test if the directory exists
            if (Directory.Exists(TempFilesDirectoryPath))
            {
                //find all files of the directory
                string[] tempFiles = Directory.GetFiles(TempFilesDirectoryPath);

                //delete all files
                foreach (string file in tempFiles)
                    System.IO.File.Delete(file);
            }
        }

        /// <summary>
        /// Temporary path of the file
        /// </summary>
        public string TempFilePath { get; private set; }

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
            TempFilePath = "";
        }

        /// <summary>
        /// Get the path of the file to listen to
        /// </summary>
        /// <returns>Returns the path of the file to listen to</returns>
        public string GetListeningPath()
        {
            //test if the file is of the FLAC type
            if (RealExtension.ToLower() == "flac")
            {
                //test if the temp file already exists
                if (System.IO.File.Exists(TempFilePath))
                    return TempFilePath;
                else
                {
                    //set the temp path
                    int fileId = 0;

                    //find a unique name
                    while (System.IO.File.Exists(TempFilesDirectoryPath + "\\" + fileId + ".mp3"))
                        fileId++;

                    TempFilePath = TempFilesDirectoryPath + "\\" + fileId + ".mp3";

                    //create a reader of the file
                    using (var reader = new AudioFileReader(FullRealPath))
                    {
                        //create the writer of the file
                        using (var writer = new LameMP3FileWriter(TempFilePath, reader.WaveFormat, LAMEPreset.VBR_90))
                        {
                            //copy the file to mp3
                            reader.CopyTo(writer);
                        }
                    }

                    return TempFilePath;
                }
            }
            else
                return FullRealPath;
        }

        /// <summary>
        /// Sets a new prefix for the file
        /// </summary>
        /// <param name="prefix">new prefix of the file</param>
        /// <returns>Returns if the operation was successful</returns>
        public bool SetNewPrefix(string prefix)
        {
            //test if the prefix is not empty
            if (prefix != null && prefix != "")
            {
                Prefix = prefix + _prefixSeparator;
                FileInfoChangedEvent?.Invoke(this);
            }
            else
            {
                Prefix = "";
                FileInfoChangedEvent?.Invoke(this);
            }

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
                if (!System.IO.File.Exists(CustomPath + '\\' + name + '.' + RealExtension) && name != CustomName || name == RealName && CustomName != RealName)
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
            try
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
            catch (FileNotFoundException)
            {
                return false;
            }
        }
    }

    /// <summary>
    /// Delegate handling the event an info changed in the file
    /// </summary>
    /// <param name="file">File changed</param>
    public delegate void FileInfoChangedEventHandler(File file);
}
