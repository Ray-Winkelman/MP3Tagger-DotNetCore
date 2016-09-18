using System.Collections.Generic;
using System.Linq;
using Extensions.Strings;
using UI.Interfaces;
using Enumerations;

namespace MP3Tagger
{
	public class Dispatcher
	{
		// Dictionaries.
		Dictionary<string, EActionArgument> _actions = new Dictionary<string, EActionArgument>();
		Dictionary<string, EOptionArgument> _options = new Dictionary<string, EOptionArgument>();
		Dictionary<string, EMP3Attribute> _mp3attributes = new Dictionary<string, EMP3Attribute>();

		// UI
		IUserInterface _ui;

		// Constructor
		public Dispatcher(IUserInterface ui)
		{
			_ui = ui;
			_actions.Add("clean", EActionArgument.Clean);
			_actions.Add("clear", EActionArgument.Clean);
		}

		/// <summary>
		/// Determine the code paths to be executed, by iterating over the application arguments.
		/// </summary>
		/// <param name="arguments">Arguments.</param>
		public int Dispatch(string[] arguments)
		{
			foreach (string argument in arguments)
			{
				if (_actions.Any(a => a.Key.ContainsInsensitive(argument)))
				{

				}
			}

			return 0;
		}
	}
}

