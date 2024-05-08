///ETML
///Auteur : Aurélien Devaud
///Date : 08.05.2024
///Description : Model of the application

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSort.Models
{
    /// <summary>
    /// Model of the application
    /// </summary>
    public class Model
    {

        /// <summary>
        /// Enumerates the diffent ways the application of the modifications can be applied
        /// </summary>
        public enum ApplicationMode
        {
            Rename,
            RenameAndCopy,
            RenameAndMove
        }
    }
}
