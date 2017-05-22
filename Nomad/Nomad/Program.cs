using Nomad.Clocking;
using Nomad.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nomad
{
	static class Program
	{
		static void Main()
		{
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

		}
	}
}
