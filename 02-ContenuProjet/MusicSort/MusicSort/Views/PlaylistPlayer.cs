///ETML
///Auteur : Aurélien Devaud
///Date : 08.05.2024
///Description : Control used to play the musics of the playlist

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicSort.Models;

namespace MusicSort.Views
{
    /// <summary>
    /// Control used to play the musics of the playlist
    /// </summary>
    public partial class PlaylistPlayer : AxWMPLib.AxWindowsMediaPlayer
    {
        /// <summary>
        /// Files to be played
        /// </summary>
        private File[] _filesToPlay;

        /// <summary>
        /// File currently being played
        /// </summary>
        public File CurrentlyPlayingFile { get; }

        /// <summary>
        /// Constructs the instance of the class
        /// </summary>
        public PlaylistPlayer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Starts playing a file
        /// </summary>
        /// <param name="file">File to play</param>
        /// <returns>Returns if the operation was successful</returns>
        public bool PlayFile(File file)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Starts playing a group of files
        /// </summary>
        /// <param name="files">Files to play</param>
        public void PlayFiles(File[] files)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Stops playing anything
        /// </summary>
        public void StopPlaying()
        {
            throw new NotImplementedException();
        }
    }
}
