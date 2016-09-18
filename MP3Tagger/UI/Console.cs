using System;
using MP3Tagger.UI.Interfaces;

namespace MP3Tagger.UI
{
	public class ConsolePlus : IUserInterface
	{
		public void Update(string message)
		{
			Console.WriteLine(message.Trim());
		}

		public string ReceiveMessage()
		{
			return Console.ReadLine().Trim();
		}
	}
}

