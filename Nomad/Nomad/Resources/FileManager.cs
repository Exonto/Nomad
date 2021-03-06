﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.Resources
{
	class FileManager
	{
		public const string LOG_FILE = FolderManager.LOG_FOLDER + @"\GameLog.log";

		#region File Ensuring

		/// <summary>
		/// Will create the log file if it does not exist.
		/// </summary>
		/// <returns>True if it already existed</returns>
		public static bool EnsureLogFile()
		{
			FolderManager.EnsureLogFolder();

			bool exists = File.Exists(LOG_FILE);

			if (exists == false)
			{
				File.Create(LOG_FILE).Close();
			}

			return exists;
		}

		/// <summary>
		/// Will delete the log file if it exists.
		/// </summary>
		/// <returns>True if it existed</returns>
		public static bool DeleteLogFile()
		{
			bool exists = File.Exists(LOG_FILE);
			if (exists)
			{
				File.Delete(LOG_FILE);
			}

			return exists;
		}

		#endregion
	}
}
