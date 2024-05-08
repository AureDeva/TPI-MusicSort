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

namespace MusicSort.Views
{
    /// <summary>
    /// Control used to play the musics of the playlist
    /// </summary>
    public partial class PlaylistPlayer : AxWMPLib.AxWindowsMediaPlayer
    {
        /// <summary>
        /// Constructs the instance of the class
        /// </summary>
        public PlaylistPlayer()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
