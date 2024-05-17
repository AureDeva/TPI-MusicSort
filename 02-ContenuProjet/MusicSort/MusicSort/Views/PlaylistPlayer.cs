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
using AxWMPLib;

namespace MusicSort.Views
{
    /// <summary>
    /// Control used to play the musics of the playlist
    /// </summary>
    public partial class PlaylistPlayer : AxWindowsMediaPlayer
    {
        /// <summary>
        /// Files to be played
        /// </summary>
        private File[] _filesToPlay;

        /// <summary>
        /// File currently being played
        /// </summary>
        public File CurrentlyPlayingFile 
        { 
            get 
            { 
                //test if there are no files playing
                if (_filesToPlay.Length == 0)
                    return null;
                //test if there is only one file in the files to play
                else if (_filesToPlay.Length == 1)
                    return _filesToPlay[0];
                else
                    return _filesToPlay.ToList().Find(f => f.GetListeningPath() == currentMedia.sourceURL); 
            } 
        }

        /// <summary>
        /// Constructs the instance of the class
        /// </summary>
        public PlaylistPlayer()
        {
            InitializeComponent();

            Location = new Point(14, 576);
            Name = "MusicPlayer";
            Size = new System.Drawing.Size(806, 45);

            _filesToPlay = new File[0];
        }

        /// <summary>
        /// Starts playing a file
        /// </summary>
        /// <param name="file">File to play</param>
        /// <returns>Returns if the operation was successful</returns>
        public void PlayFile(File file)
        {
            StopPlaying();
            _filesToPlay = new File[] { file };
            URL = file.GetListeningPath();
            currentMedia.name = file.DisplayName;
            Ctlcontrols.play();
        }

        /// <summary>
        /// Starts playing a group of files
        /// </summary>
        /// <param name="files">Files to play</param>
        public void PlayFiles(File[] files)
        {
            //create a new playlist
            WMPLib.IWMPPlaylist playlist = newPlaylist("Playlist", string.Empty);

            //add files to the playlist
            foreach (File file in files)
            {
                WMPLib.IWMPMedia media = newMedia(file.GetListeningPath());
                media.name = file.DisplayName;
                playlist.appendItem(media);
            }

            //set the playlist
            currentPlaylist = playlist;

            _filesToPlay = files;

            //start playing
            Ctlcontrols.play();
        }

        /// <summary>
        /// Stops playing anything
        /// </summary>
        public void StopPlaying()
        {
            Ctlcontrols.stop();

            _filesToPlay = new File[0];

            currentPlaylist.clear();
        }
    }
}
