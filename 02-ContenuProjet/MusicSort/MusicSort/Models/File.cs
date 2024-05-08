///ETML
///Auteur : Aurélien Devaud
///Date : 08.05.2024
///Description : Class managing the information of a file

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSort.Models
{
    /// <summary>
    /// Class managing the information of a file
    /// </summary>
    public class File
    {
        /// <summary>
        /// Custom name of the file (not the name of the real file) without the extension and path
        /// </summary>
        public string CustomName { get; private set; }

        /// <summary>
        /// Custom path of the file (not the path of the real file)
        /// </summary>
        public string CustomPath { get; private set; }
    }
}
