// Program.cs
using System;
using System.Windows.Forms;
using ProyeccionPoblacionalINEC.Forms;

namespace ProyeccionPoblacionalINEC
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicaci�n.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Ejecutar el formulario principal
            Application.Run(new MainForm());
        }
    }
}
    