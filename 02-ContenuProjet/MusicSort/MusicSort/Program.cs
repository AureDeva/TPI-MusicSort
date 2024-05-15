///ETML
///Auteur : Aurélien Devaud
///Date : 08.05.2024
///Description : Main page of code of the application

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicSort.Models;
using MusicSort.Views;
using MusicSort.Controllers;

namespace MusicSort
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //set up th mvc
            Model model = new Model();
            ViewForm view = new ViewForm();
            Controller controller = new Controller(model, view);

            //start the application
            Application.Run(view);
        }
    }
}
