using System;
using System.Collections.Generic;

namespace MP3Tagger.UnitTests
{
	public partial class Program
	{
		static List<UnitTest> tests = new List<UnitTest>();

		public static void Main(string[] args)
		{
			MakeTests();

			string result = string.Empty;

			foreach (UnitTest test in tests)
			{
				if (test.RunTest())
				{
					result = "[Yes]   ";
					Console.ForegroundColor = ConsoleColor.Green;
				}
				else
				{
					result = "[No]    ";
					Console.ForegroundColor = ConsoleColor.Red;
				}

				Console.Write(Environment.NewLine + result);
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine(test.Name);
			}

			Environment.Exit(0);
		}
	}
}
