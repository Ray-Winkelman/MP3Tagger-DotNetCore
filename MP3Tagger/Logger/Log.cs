using System;
using System.IO;

namespace MP3Tagger.Logger
{
	public static class Log
	{
		static string _path = System.Reflection.Assembly.GetEntryAssembly().Location;

		public static void Error(Exception ex)
		{
			string indent = string.Empty;

			do
			{
				File.AppendAllText(_path, string.Format("EXCEPTION | {0}: {1}{2}{3}", DateTime.Now.ToString("u"), indent, ex.ToString(), ex.Message));
				indent += "   ";

			} while (ex.InnerException != null);
		}

		public static void Info(string message)
		{
			File.AppendAllText(_path, string.Format("INFO | {0}: {1}", DateTime.Now.ToString("u"), message));
		}
	}
}

