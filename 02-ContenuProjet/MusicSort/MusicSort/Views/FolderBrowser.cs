///ETML
///Auteur : Aurélien Devaud
///Date : 08.05.2024
///Description : Class used to brows the folders for selection

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MusicSort.Properties;

namespace MusicSort.Views
{
    /// <summary>
    /// Class used to brows the folders for selection
    /// </summary>
    public partial class FolderBrowser : TreeView
    {
        /// <summary>
        /// Stores the treeNode selected with a double click
        /// </summary>
        private TreeNode _selectedNode;

        /// <summary>
        /// Base directory of the browser 
        /// </summary>
        public string BaseDirectory { get; private set; }

        /// <summary>
        /// Event triggered when a folder is selected
        /// </summary>
        public event PathSelectedEventHandler FolderSelectedEvent;

        /// <summary>
        /// Constructor of an instance of the class
        /// </summary>
        public FolderBrowser()
        {
            InitializeComponent();

            _selectedNode = null;

            Location = new Point(27, 76);
            Size = new Size(207, 268);

            ImageList = new ImageList();
            ImageList.Images.Add("SelectedDrive", Resources.SelectedDriveIcon);
            ImageList.Images.Add("OpenFolder", Resources.OpenFolderIcon);
            ImageList.Images.Add("Drive", Resources.DriveIcon);
            ImageList.Images.Add("Folder", Resources.FolderIcon);

            ShowPlusMinus = false;
            ShowRootLines = false;
            ShowLines = false;

            NodeMouseClick += FolderBrowser_NodeMouseClick;
        }

        /// <summary>
        /// Event triggered when a node is clicked
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">arguments of the event</param>
        private void FolderBrowser_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //test if the folder exists
            if (Path.IsPathRooted((string)e.Node.Tag))
            {
                //test if there are already nodes
                if (e.Node.Nodes.Count == 0)
                    e.Node.Nodes.AddRange(GetNodeChildren((string)e.Node.Tag));

                //test if the nodes are expanded
                if (e.Node.IsExpanded)
                    e.Node.Collapse();
                else
                    e.Node.Expand();
                
                SelectNode(e.Node);
                FolderSelectedEvent?.Invoke(sender, (string)e.Node.Tag);
            }
        }

        /// <summary>
        /// Sets the base directory of the browser and change the tree accordingly
        /// </summary>
        /// <param name="path">Path of the new base directory</param>
        public bool SetBaseDirectory(string path = "")
        {
            //test if no base was provided or if the base is a root device
            if (path == "" || (Path.IsPathRooted(path) && Directory.GetParent(path) == null))
            {
                //clean the view
                Nodes.Clear();

                //add the root directories
                try
                {
                    Directory.GetLogicalDrives().ToList().ForEach(d =>
                    {
                        Nodes.Add(new TreeNode()
                        {
                            Text = d,
                            Name = d,
                            ImageKey = "Drive",
                            SelectedImageKey = "Drive",
                            Tag = d
                        });
                    });

                    BaseDirectory = path;

                    return true;
                }
                catch (UnauthorizedAccessException)
                {
                    if (Parent is ViewForm)
                        ((ViewForm)Parent).SendErrorMessage("Erreur", "Action non autorisée !");

                    return false;
                }
            }
            //test if the directory exists
            else if (Path.IsPathRooted(path))
            {
                //clean the view
                Nodes.Clear();

                //create base node
                TreeNode baseNode = new TreeNode()
                {
                    Name = Path.GetFileName(path),
                    Text = Path.GetFileName(path),
                    ImageKey = "Folder",
                    SelectedImageKey = "Folder",
                    Tag = path
                };

                baseNode.Nodes.AddRange(GetNodeChildren(path));

                Nodes.Add(baseNode);

                BaseDirectory = path;

                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Get the folders inside the targeted path as nodes
        /// </summary>
        /// <param name="path">Path to search</param>
        /// <returns>The array of nodes representing the folders</returns>
        private TreeNode[] GetNodeChildren(string path)
        {
            //test if the path is valid
            if (Path.IsPathRooted(path))
            {
                List<TreeNode> nodes = new List<TreeNode>();
                try
                {
                    foreach (string directory in Directory.GetDirectories(path))
                        nodes.Add(new TreeNode()
                        {
                            Name = Path.GetFileName(directory),
                            Text = Path.GetFileName(directory),
                            ImageKey = "Folder",
                            SelectedImageKey = "Folder",
                            Tag = directory
                        });
                }
                catch(UnauthorizedAccessException)
                {
                    if (Parent is ViewForm)
                        ((ViewForm)Parent).SendErrorMessage("Erreur", "Action non autorisée !");
                }

                return nodes.ToArray();
            }
            else
                return null;
        }

        /// <summary>
        /// Select the new node and change the image
        /// </summary>
        /// <param name="node">Node to select</param>
        private void SelectNode(TreeNode node)
        {
            //test if the new value is different
            if (_selectedNode != node)
            {
                //test if there was a previous selection
                if (_selectedNode != null)
                {
                    //remove the selected image of the other node
                    //test if the image index is that of a folder
                    if (_selectedNode.ImageKey.Contains("Folder"))
                    {
                        _selectedNode.ImageKey = "Folder";
                        _selectedNode.SelectedImageKey = "Folder";
                    }
                    //test if the image is that of a drive
                    else if (_selectedNode.ImageKey.Contains("Drive"))
                    {
                        _selectedNode.ImageKey = "Drive";
                        _selectedNode.SelectedImageKey = "Drive";
                    }
                }

                _selectedNode = node;

                //give the selected image to the newly selected node
                //test if the image index is that of a folder
                if (_selectedNode.ImageKey.Contains("Folder"))
                {
                    _selectedNode.ImageKey = "OpenFolder";
                    _selectedNode.SelectedImageKey = "OpenFolder";
                }
                //test if the image is that of a drive
                else if (_selectedNode.ImageKey.Contains("Drive"))
                {
                    _selectedNode.ImageKey = "SelectedDrive";
                    _selectedNode.SelectedImageKey = "SelectedDrive";
                }
            }
        }
    }
}
