///ETML
///Auteur : Aurélien Devaud
///Date : 08.05.2024
///Description : Class representing the menu of an item of the playlist

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
    /// Class representing the menu of an item of the playlist
    /// </summary>
    public partial class PlaylistItemMenu : ContextMenuStrip
    {
        /// <summary>
        /// Constructor of an instance of the class
        /// </summary>
        public PlaylistItemMenu()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
