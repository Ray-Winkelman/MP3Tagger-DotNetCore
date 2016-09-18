using System;
using System.IO;

namespace Logger
{
	public static class Log
	{
		public static void Error(Exception ex)
		{
			string indent = string.Empty;
			string path = System.Reflection.Assembly.GetEntryAssembly().Location;

			do
			{
				File.AppendAllText(path, string.Format("{0}: {1}{2}", DateTime.Now.ToString("u"), indent, ex.Message));
				indent += "   ";

			} while (ex.InnerException != null);
		}
	}
}

