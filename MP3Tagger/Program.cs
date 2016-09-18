using System;
using MP3Tagger.UI.Interfaces;
using MP3Tagger.UI;
using MP3Tagger.Exceptions;
using MP3Tagger.Logger;
using MP3Tagger.Resources;
using MP3Tagger.Core;

namespace MP3Tagger
{
	public class Program
	{
		public static void Main(string[] args)
		{
			IUserInterface ui = null;

			// 100% of code coverage will bubble up to here. I wanted to update the UI with exceptions. 
			try
			{
				ui = new ConsolePlus();

				if (args.Length < 2)
				{
					ui.Update(Strings.TooFewArguments);
					Environment.Exit(1);
				}

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
			catch (Exception ex)
			{
				Log.Error(ex);
				ui.Update(Strings.GenericError);
			}
		}
	}
}
