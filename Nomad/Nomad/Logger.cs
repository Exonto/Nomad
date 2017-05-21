using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysWorld
{
	static class Logger
	{
		static string LOG_FOLDER = "C:\\PhysWorld\\logs";
		static string LOG_FILE = "C:\\PhysWorld\\logs\\program.log";
		static bool IS_INITIALIZED = false;

		private static void EnsureLogFolder()
		{
			if (Directory.Exists(LOG_FOLDER) == false)
			{
				Directory.CreateDirectory(LOG_FOLDER);
			}
		}

		private static void EnsureLog()
		{
			EnsureLogFolder();

			if (File.Exists(LOG_FILE) == false)
			{
				var stream = File.Create(LOG_FILE);
				stream.Close();
			}
			else if (IS_INITIALIZED == false)
			{
				File.Delete(LOG_FILE);
				var stream = File.Create(LOG_FILE);
				stream.Close();

				IS_INITIALIZED = true;
			}
		}

		public static void Log(string text)
		{
			EnsureLog();

			File.AppendAllText(LOG_FILE, text + Environment.NewLine);
		}

		public static void Log(object text)
		{
			EnsureLog();

			File.AppendAllText(LOG_FILE, text.ToString() + Environment.NewLine);
		}

		public static void Log(string[] text)
		{
			EnsureLog();

			File.AppendAllLines(LOG_FILE, text);
		}

		public static void Log(IEnumerable<string> text)
		{
			EnsureLog();

			File.AppendAllLines(LOG_FILE, text);
		}

		public static void Log(List<string> text)
		{
			EnsureLog();

			File.AppendAllLines(LOG_FILE, text);
		}

		public static void Log(List<object> text)
		{
			EnsureLog();

			File.AppendAllLines(LOG_FILE, text.OfType<string>());
		}
	}
}