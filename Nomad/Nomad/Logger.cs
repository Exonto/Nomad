using Nomad.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad
{
	/// <summary>
	/// Used to log basic information to a designated log file.
	/// </summary>
	static class Logger
	{
		public static void Log(string text)
		{
			File.AppendAllText(FileManager.LOG_FILE, text + Environment.NewLine);
		}

		public static void Log(object text)
		{
			File.AppendAllText(FileManager.LOG_FILE, text.ToString() + Environment.NewLine);
		}

		public static void Log(string[] text)
		{
			File.AppendAllLines(FileManager.LOG_FILE, text);
		}

		public static void Log(IEnumerable<string> text)
		{
			File.AppendAllLines(FileManager.LOG_FILE, text);
		}

		public static void Log(List<string> text)
		{
			File.AppendAllLines(FileManager.LOG_FILE, text);
		}

		public static void Log(List<object> text)
		{
			File.AppendAllLines(FileManager.LOG_FILE, text.OfType<string>());
		}
	}
}