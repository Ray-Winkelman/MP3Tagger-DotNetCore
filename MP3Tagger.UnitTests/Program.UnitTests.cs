using MP3Tagger.UI.Interfaces;
using MP3Tagger.UnitTests.UI.Overrrides;
using MP3Tagger.Core;
using MP3Tagger.Core.Enumerations;
using MP3Tagger.Exceptions;
using MP3Tagger.Core.Commands;

namespace MP3Tagger.UnitTests
{
	public partial class Program
	{
		public static void MakeTests()
		{
			tests.Add(new UnitTest("Action: Clean", delegate
			{
				IUserInterface ui = new TestUI();
				Dispatcher dispatcher = new Dispatcher(ui);
				dispatcher.Dispatch(new string[] { "clean", "title" });

				return dispatcher.Command.GetType() == typeof(CleanCommand);
			}));

			tests.Add(new UnitTest("Action: Clear", delegate
			{
				IUserInterface ui = new TestUI();
				Dispatcher dispatcher = new Dispatcher(ui);
				dispatcher.Dispatch(new string[] { "clear", "title" });

				return dispatcher.Command.GetType() == typeof(ClearCommand);
			}));

			tests.Add(new UnitTest("Action: Set", delegate
			{
				IUserInterface ui = new TestUI();
				Dispatcher dispatcher = new Dispatcher(ui);
				dispatcher.Dispatch(new string[] { "set", "title" });

				return dispatcher.Command.GetType() == typeof(SetCommand);
			}));

			tests.Add(new UnitTest("Catch: InvalidActionException", delegate
			{
				IUserInterface ui = new TestUI();
				Dispatcher dispatcher = new Dispatcher(ui);

				try
				{
					dispatcher.Dispatch(new string[] { "title", "title" });
				}
				catch (InvalidActionException)
				{
					return true;
				}

				return false;
			}));

			tests.Add(new UnitTest("Catch: InvalidAttributeException", delegate
			{
				IUserInterface ui = new TestUI();
				Dispatcher dispatcher = new Dispatcher(ui);

				try
				{
					dispatcher.Dispatch(new string[] { "clear", "clear" });
				}
				catch (InvalidAttributeException)
				{
					return true;
				}

				return false;
			}));

			tests.Add(new UnitTest("Catch: InvalidArgumentException", delegate
			{
				IUserInterface ui = new TestUI();
				Dispatcher dispatcher = new Dispatcher(ui);

				try
				{
					dispatcher.Dispatch(new string[] { "clear", "title", "12345" });
				}
				catch (InvalidArgumentException)
				{
					return true;
				}

				return false;
			}));

			tests.Add(new UnitTest("Attribute: title", delegate
			{
				IUserInterface ui = new TestUI();
				Dispatcher dispatcher = new Dispatcher(ui);
				dispatcher.Dispatch(new string[] { "set", "title" });

				return dispatcher.Command.Attribute == EMP3Attribute.Title;
			}));

			tests.Add(new UnitTest("Attribute: Album Artist", delegate
			{
				IUserInterface ui = new TestUI();
				Dispatcher dispatcher = new Dispatcher(ui);
				dispatcher.Dispatch(new string[] { "set", "albumartist" });

				return dispatcher.Command.Attribute == EMP3Attribute.AlbumArtist;
			}));

			tests.Add(new UnitTest("Attribute: Artist", delegate
			{
				IUserInterface ui = new TestUI();
				Dispatcher dispatcher = new Dispatcher(ui);
				dispatcher.Dispatch(new string[] { "set", "artist" });

				return dispatcher.Command.Attribute == EMP3Attribute.Artist;
			}));
		}
	}
}

