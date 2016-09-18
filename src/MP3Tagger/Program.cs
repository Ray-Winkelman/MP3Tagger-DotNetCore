using UI.Interfaces;
using UI;
using Exceptions;
using Logger;
using Resources;

namespace MP3Tagger
{
	public class Program
	{
		public static void Main(string[] args)
		{

			// Injections
			IUserInterface ui = new ConsolePlus();

			// Almost 100% of code coverage will bubble up to here. I wanted to update the UI with exceptions. 
			// So I'll catch anything going wrong with the injection of the UI dependancy seperately.
			try
			{
				Dispatcher dispatcher = new Dispatcher(ui);
				dispatcher.Dispatch(args);
			}
			catch (InvalidActionException ex)
			{
				Log.Error(ex);
				ui.Update(Strings.InvalidAction);
			}
			catch (InvalidAttributeException ex)
			{
				Log.Error(ex);
				ui.Update(Strings.InvalidAttribute);
			}

		}
	}
}
