using MP3Tagger.UI.Interfaces;

namespace MP3Tagger.UnitTests.UI.Overrrides
{
	public class TestUI : IUserInterface
	{
		public void Update(string message)
		{

		}

		public string ReceiveMessage()
		{
			return string.Empty;
		}
	}
}

