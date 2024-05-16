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
using System.Windows.Forms;

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

            view.FolderFileListView.Play = ListenToFile;
            view.PlaylistView.Play = ListenToFile;
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
        public void SwitchSortingOrder()
        {
            View.PlaylistView.SwitchSortOrder();
        }

        /// <summary>
        /// Start the process of directory selection for file selection
        /// </summary>
        public void SelectDirectory()
        {
            //open dialog to find a directory
            string path = View.OpenFolderBrowserDialog();

            if (path != null)
            {
                View.FolderBrowser.SetBaseDirectory(path);
                View.baseDirectoryTextBox.Text = path;
            }
        }

        /// <summary>
        /// Method triggered when the user selects a directory for file selection
        /// </summary>
        /// <param name="path">Path of the directory selected</param>
        public void DirectorySelected(string path)
        {
            //get the directory's files
            File[] files = Model.GetFilesFromDirectory(path);

            //test if there was no error
            if (files != null)
            {
                View.SetFileItemsForFolderListView(files);
                Model.SelectedPath = path;
                View.openFolderLabel.Text = path.Substring(path.LastIndexOf('\\'));
            }
            else
                View.SendErrorMessage("Erreur lors de la récupération des fichiers", "Une erreur s'est produite lors de la récupération des fichiers du dossier sélectionné");
        }

        /// <summary>
        /// Sends files from the directory selected to the playlist
        /// </summary>
        /// <param name="files">files to send to the playlist</param>
        public void SendFilesToPlaylist(File[] files)
        {
            //go through the files given
            foreach (File file in files)
            {
                Model.Playlist.Add(file);
                file.IndexInPlaylist = Model.Playlist.Count;
            }

            View.SetFileItemsForPlaylistView(Model.Playlist.ToArray());
        }

        /// <summary>
        /// Removes files from the list of the playlist
        /// </summary>
        /// <param name="files">files to remove</param>
        public void RemoveFilesFromPlaylist(File[] files)
        {
            //remove each file
            foreach (File file in files)
                Model.Playlist.Remove(file);

            View.SetFileItemsForPlaylistView(Model.Playlist.ToArray());
        }

        /// <summary>
        /// Trie les éléments de la playlist
        /// </summary>
        public void SortPlaylist()
        {
            Model.SortFiles();
            View.PlaylistView.Sort();
        }

        /// <summary>
        /// Place files higher in the order of the playlist
        /// </summary>
        /// <param name="files">Files to place higher</param>
        public void PlaceFilesHigher(File[] files)
        {
            //test if there are files to place higher
            if (files != null && files.Length > 0)
            {
                //sort the selected files
                List<File> files_ = files.OrderBy(f => f.IndexInPlaylist).ToList();

                //test if the highest file has room to go up
                if (files_[0].IndexInPlaylist > 0) 
                {
                    //place the displaced file lower
                    Model.FindFileByIndex(files_[0].IndexInPlaylist - 1).IndexInPlaylist = files_[files_.Count - 1].IndexInPlaylist;

                    //place the files higher
                    foreach (File file in files_)
                        file.IndexInPlaylist--; 
                }

                View.PlaylistView.Sort();
            }
        }

        /// <summary>
        /// Place files lower in the order of the playlist
        /// </summary>
        /// <param name="files">Files to place lower</param>
        public void PlaceFilesLower(File[] files)
        {
            //test if there are files to place lower
            if (files != null && files.Length > 0)
            {
                //sort the selected files
                List<File> files_ = files.OrderBy(f => f.IndexInPlaylist).Reverse().ToList();

                //test if the highest file has room to go down
                if (files_[0].IndexInPlaylist < Model.Playlist[Model.Playlist.Count - 1].IndexInPlaylist)
                {
                    //place the displaced file higher
                    Model.FindFileByIndex(files_[0].IndexInPlaylist + 1).IndexInPlaylist = files_[files_.Count - 1].IndexInPlaylist;

                    //place the files higher
                    foreach (File file in files_)
                        file.IndexInPlaylist++;
                }

                View.PlaylistView.Sort();
            }
        }

        /// <summary>
        /// Start the process of renaming a file
        /// </summary>
        /// <param name="file">File to rename</param>
        public void RenameFile(File file)
        {
            //ask the user for a new name
            string newName = View.AskForNewName(file);
            if (!file.SetNewName(newName))
                View.SendErrorMessage("Erreur de renommage", "Le nom n'est pas valide pour ce fichier.");

            View.PlaylistView.Refresh();
        }

        /// <summary>
        /// Reset a file to its default state
        /// Reset name
        /// </summary>
        /// <param name="file">File to reset</param>
        public void ResetFile(File file)
        {
            if (!file.SetNewName(file.RealName))
                View.SendErrorMessage("Erreur de renommage", "Le nom n'est pas valide pour ce fichier.");

            View.PlaylistView.Refresh();
        }

        /// <summary>
        /// Reset all files to their default state
        /// Reset name, order and numbers
        /// </summary>
        public void ResetAll()
        {
            //reset every file if possible
            foreach (File file in Model.Playlist)
            {
                file.SetNewName(file.RealName);
                file.SetNewPrefix("");
                file.SetNewPath(file.RealPath);
                Model.SortFiles();
                View.PlaylistView.Sort();
            }
        }

        /// <summary>
        /// Inputs a new number for numbering
        /// </summary>
        /// <param name="number">number to input</param>
        public void InputNewNumber(string number)
        {
            //test if name is valid
            if (number != null)
            {
                if (Model.SetNewStartingNumber(number))
                    View.numberErrorLabel.Text = "";
                else
                    View.numberErrorLabel.Text = "Nombre invalide!";
            }
            else
                View.numberErrorLabel.Text = "Le nombre ne peut pas être vide!";
        }

        /// <summary>
        /// Inputs a new general name
        /// </summary>
        /// <param name="name">New general name</param>
        public void InputNewGeneralName(string name)
        {
            //test if name is not null
            if (name != null)
            {
                if (Model.SetNewGeneralName(name))
                    View.generalNameErrorLabel.Text = "";
                else
                    View.generalNameErrorLabel.Text = "Nom invalide!";
            }
            else
                View.generalNameErrorLabel.Text = "Le nom ne peut pas être vide!";
        }

        /// <summary>
        /// Activates the numbering of the playlist files
        /// </summary>
        public void ActivateNumbering()
        {
            Model.IsPrefixActivated = true;
        }

        /// <summary>
        /// Deactivates the numbering of the playlist files
        /// </summary>
        public void DeactivateNumbering()
        {
            Model.IsPrefixActivated = false;
        }

        /// <summary>
        /// Starts the process for destination directory selection
        /// </summary>
        public void SearchForDestinationDirectory()
        {
            //open the folder browser dialog
            string path = View.OpenFolderBrowserDialog();

            if (path != null)
            {
                Model.SetNewDestination(path);
                View.destinationTextBox.Text = path;
            }
        }

        /// <summary>
        /// Displays the general changes done
        /// </summary>
        public void DisplayGeneralChanges()
        {
            //test if the number and name are set
            if (Model.NumberDigit > 0 && Model.GeneralName.Length > 0 && Model.IsPrefixActivated)
            {
                Model.SetPrefixFromIndex();
                Model.DisplayGeneralName();
            }
            else
                View.SendErrorMessage("Erreur dans l'aperçu des changements", "Une erreur c'est produite lors de l'aperçu des changements!");
        }

        /// <summary>
        /// Change the mode of application of the changes
        /// </summary>
        /// <param name="mode">new mode of application</param>
        public void ChangeApplicationMode(ApplicationMode mode)
        {
            Model.SetNewMode(mode);
        }

         /// <summary>
         /// Applies all changes to the real files
         /// </summary>
        public void Apply()
        {
            //test what is applicable
            List<Tuple<File, ApplicationError>> testResults = Model.TestForApplication();

            //keep in mind if it is possible to continue 
            bool canContinue = true;

            //test if there were errors
            if (testResults.Count > 0)
                canContinue = View.AskForConfirmation("Problème(s) pour l'application", 
                    $"Il y aura {testResults.Count} complication durant l'application des changements. \n" +
                    "Voulez-vous quand même continué?");

            if (canContinue)
            {
                //apply the changes to each file
                foreach (File file in Model.Playlist)
                {
                    //find if the file had an error
                    if (testResults.Exists(r => r.Item1 == file))
                    {
                        switch (testResults.Find(r => r.Item1 == file).Item2)
                        {
                            case ApplicationError.FileAlreadyExists:
                                //ask the user for confirmation to replace the file
                                if (View.AskForConfirmation("Doublon", $"Un fichier du nom : {file.FullCustomName} existe déjà. \nVoulez-vous le remplacer ?"))
                                    if (!file.ApplyChanges())
                                        View.SendErrorMessage("Erreur", $"Une erreur s'est produite lors de l'application des changements sur le fichier : \n {file.RealPath}");
                                break;
                            case ApplicationError.ActionUnauthorized:
                                View.SendErrorMessage("Erreur", $"Action non-autorisée sur le fichier : \n {file.RealPath}");
                                break;
                        }
                    }
                    else
                    {
                        if (!file.ApplyChanges())
                            View.SendErrorMessage("Erreur", $"Une erreur s'est produite lors de l'application des changements sur le fichier : \n {file.RealPath}");
                    }
                }
            }
        }
    }
}
