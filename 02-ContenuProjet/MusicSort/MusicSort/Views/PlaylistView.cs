///ETML
///Auteur : Aurélien Devaud
///Date : 08.05.2024
///Description : Class listing the elements of the playlist

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
    /// Class listing the elements of the playlist
    /// </summary>
    public partial class PlaylistView : ListView
    {
        /// <summary>
        /// Column containing the information about the name of the file listed
        /// </summary>
        private ColumnHeader _nameColumn;

        /// <summary>
        /// Column containing the information about the extension of the file listed
        /// </summary>
        private ColumnHeader _extensionColumn;

        /// <summary>
        /// Cosntruct the instance of the class
        /// </summary>
        public PlaylistView()
        {
            InitializeComponent();

            _nameColumn = new ColumnHeader();
            _extensionColumn = new ColumnHeader();

            // NameColumn
            _nameColumn.Text = "Nom";

            // ExtensionColumn
            _extensionColumn.Text = "Extension";

            // PlaylistView
            Columns.AddRange(new ColumnHeader[] {
            _nameColumn,
            _extensionColumn});
            Location = new Point(89, 82);
            Name = "PlaylistView";
            Size = new Size(163, 268);
            UseCompatibleStateImageBehavior = false;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
