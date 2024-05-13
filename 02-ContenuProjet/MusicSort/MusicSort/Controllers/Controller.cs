///ETML
///Auteur : Aurélien Devaud
///Date : 08.05.2024
///Description : Controller of the processes of the application

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicSort.Models;
using MusicSort.Views;

namespace MusicSort.Controllers
{
    /// <summary>
    /// Controller of the processes of the application
    /// </summary>
    public class Controller
    {
        /// <summary>
        /// Model of the application, manages information
        /// </summary>
        public Model Model { get; private set; }

        /// <summary>
        /// View of the application, manages the interface
        /// </summary>
        public ViewForm View { get; private set; }

        /// <summary>
        /// Constructor of the application
        /// </summary>
        /// <param name="model">Model of the application, manages information</param>
        /// <param name="view">View of the application, manages the interface</param>
        public Controller(Model model, ViewForm view)
        {
            Model = model;
            View = view;

            model.Controller = this;
            view.Controller = this;
        }

        /// <summary>
        /// Start playling the files of the playlist
        /// </summary>
        public void StartPlaylist()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stop playing the files of the playlist
        /// </summary>
        public void StopPlaylist()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Listen to a specific file
        /// </summary>
        /// <param name="file">file to listen to</param>
        public void ListenToFile(File file)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Switch the order with wich the playlist should be sorted
        /// </summary>
        public void SwitchSortOrder()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Start the process of directory selection for file selection
        /// </summary>
        public void SelectDirectory()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method triggered when the user selects a directory for file selection
        /// </summary>
        /// <param name="path">Path of the directory selected</param>
        public void DirectorySelected(string path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sends files from the directory selected to the playlist
        /// </summary>
        /// <param name="files">files to send to the playlist</param>
        public void SendFilesToPlaylist(File[] files)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes files from the list of the playlist
        /// </summary>
        /// <param name="files">files to remove</param>
        public void RemoveFilesFromPlaylist(File[] files)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Trie les éléments de la playlist
        /// </summary>
        public void SortPlaylist()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Place file higher in the order of the playlist
        /// </summary>
        /// <param name="file">File ot place higher</param>
        public void PlaceFileHigher(File file)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Place file lower in the order of the playlist
        /// </summary>
        /// <param name="file">File ot place lower</param>
        public void PlaceFileLower(File file)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Start the process of renaming a file
        /// </summary>
        /// <param name="file">File to rename</param>
        public void RenameFile(File file)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reset a file to its default state
        /// Reset name and order
        /// </summary>
        /// <param name="file">File to reset</param>
        public void ResetFile(File file)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inputs a new number for numbering
        /// </summary>
        /// <param name="number">number to input</param>
        public void InputNewNumber(string number)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inputs a new general name
        /// </summary>
        /// <param name="name">New general name</param>
        public void InputNewGeneralName(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Activates the numbering of the playlist files
        /// </summary>
        public void ActivateNumbering()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deactivates the numbering of the playlist files
        /// </summary>
        public void DeactivateNumbering()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Starts the process for destination directory selection
        /// </summary>
        public void SearchForDestinationDirectory()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Displays the general changes done
        /// </summary>
        public void DisplayGeneralChanges()
        {
            throw new NotImplementedException();
        }
         /// <summary>
         /// Applies all changes to the real files
         /// </summary>
        public void Apply()
        {
            throw new NotImplementedException();
        }
    }
}
