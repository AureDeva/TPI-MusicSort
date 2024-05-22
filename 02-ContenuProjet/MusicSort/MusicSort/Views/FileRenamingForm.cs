///ETML
///Auteur : Aurélien Devaud
///Date : 08.05.2024
///Description : Form used to rename the files

using MusicSort.Models;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MusicSort.Views
{
    /// <summary>
    /// Form used to rename the files
    /// </summary>
    public partial class FileRenamingForm : Form
    {
        /// <summary>
        /// File to be renamed
        /// </summary>
        public Models.File File { get; }

        /// <summary>
        /// New name for the file
        /// </summary>
        public string NewName { get; private set; }

        /// <summary>
        /// Initializer of the form
        /// </summary>
        /// <param name="file">File in the process of renaming</param>
        public FileRenamingForm(Models.File file)
        {
            File = file;

            InitializeComponent();

            RenamingTextBox.Text = file.CustomName;
            ApplyButton.Enabled = false;
        }

        /// <summary>
        /// Event triggered when the cancel button is clicked
        /// </summary>
        /// <param name="sender">button clicked</param>
        /// <param name="e">arguments of the event</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Event triggered when the apply button is clicked
        /// </summary>
        /// <param name="sender">button clicked</param>
        /// <param name="e">arguments of the event</param>
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Close();
        }

        /// <summary>
        /// Event triggered when the file is changed
        /// </summary>
        /// <param name="sender">textBox</param>
        /// <param name="e">arguments of the event</param>
        private void RenamingTextBox_TextChanged(object sender, EventArgs e)
        {
            //get the new name
            string newName = ((TextBox)sender).Text;

            //test if the text is invalid as a file name
            if (newName.Any(c => Path.GetInvalidFileNameChars().Contains(c)) && newName.Length > 255)
            {
                ErrorLabel.Text = "Le nom est invalide pour un fichier.";
                ApplyButton.Enabled = false;
            }
            //test if the name could be used in the folder
            else if (System.IO.File.Exists(File.CustomPath + '\\' + newName + '.' + File.RealExtension) && newName != File.CustomName)
            {
                ErrorLabel.Text = "Un fichier avec ce nom existe déja dans le dossier cible.";
                ApplyButton.Enabled = false;
            }
            //if the name is valid
            else
            {
                NewName = newName;
                ErrorLabel.Text = "";

                //detect if the name has changed
                if (File.CustomName != newName)
                    ApplyButton.Enabled = true;
            }
        }
    }
}
