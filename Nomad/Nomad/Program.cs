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

			Logger.Log("Test");
		}

		/// <summary>
		/// Initializes the game.
		/// </summary>
		static void Initialize()
		{
			FolderManager.EnsureLogFolder();

			Clock.Start();
		}
	}
}
