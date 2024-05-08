///ETML
///Auteur : Aurélien Devaud
///Date : 08.05.2024
///Description : Class listing the files of the selected folder

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
    /// Class listing the files of the selected folder
    /// </summary>
    public partial class FolderFileListView : ListView
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
        public FolderFileListView()
        {
            InitializeComponent();

            _nameColumn = new ColumnHeader();
            _extensionColumn = new ColumnHeader();

            // NameColumn
            _nameColumn.Text = "Nom";

            // ExtensionColumn
            _extensionColumn.Text = "Extension";

            // FolderFileListView
            Columns.AddRange(new ColumnHeader[] {
            _nameColumn,
            _extensionColumn});
            Location = new Point(89, 82);
            Name = "FolderFileListView";
            Size = new Size(163, 268);
            UseCompatibleStateImageBehavior = false;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
