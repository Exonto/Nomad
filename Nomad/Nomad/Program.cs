using Nomad.Clocking;
using Nomad.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nomad
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new GameForm());

			Initialize();
		}

		/// <summary>
		/// Initializes the game.
		/// </summary>
		static void Initialize()
		{
			FolderManager.EnsureLogFolder();
			FileManager.DeleteLogFile();
			FileManager.EnsureLogFile();

			Clock c = new Clock(100);
			c.Start();
		}
	}
}
