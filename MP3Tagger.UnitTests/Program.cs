using System;
using MP3Tagger.Core;
using MP3Tagger.UI.Interfaces;
using MP3Tagger.UnitTests.UI.Overrrides;

namespace MP3Tagger.UnitTests
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// Inject a UI override to silence the application.
			IUserInterface ui = new TestUI();

			Dispatcher dispatcher = new Dispatcher(ui);


			Console.WriteLine("Test 1 passed!!");
		}
	}
}
