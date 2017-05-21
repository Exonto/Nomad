using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.Resources
{
	/// <summary>
	/// Keeps track of all folder locations.
	/// </summary>
	static class FolderManager
	{
		public const string GAME_FOLDER = @"C:\Nomad";
		
		public const string LOG_FOLDER = GAME_FOLDER + @"\Logs";

		#region Folder Ensuring

		/// <summary>
		/// Will create the game folder if it does not exist.
		/// </summary>
		/// <returns>True if it already existed</returns>
		public static bool EnsureGameFolder()
		{
			bool exists = Directory.Exists(GAME_FOLDER);

			if (exists == false)
			{
				Directory.CreateDirectory(GAME_FOLDER);
			}

			return exists;
		}

		/// <summary>
		/// Will create the log folder if it does not exist.
		/// </summary>
		/// <returns>True if it already existed</returns>
		public static bool EnsureLogFolder()
		{
			bool exists = Directory.Exists(LOG_FOLDER);

			if (exists == false)
			{
				Directory.CreateDirectory(LOG_FOLDER);
			}

			return exists;
		}

		#endregion
	}
}
