using UI.Interfaces;
using UI;
namespace MP3Tagger
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// Injections
			IUserInterface ui = new ConsolePlus();

			Dispatcher dispatcher = new Dispatcher(ui);
			dispatcher.Dispatch(args);
		}
	}
}
