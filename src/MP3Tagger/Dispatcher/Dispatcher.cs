using System.Collections.Generic;
using System.Linq;
using Extensions.Strings;
using Extensions.Enumerations;
using UI.Interfaces;
using Enumerations;
using Exceptions;

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

			// Prepare the actions.
			foreach (EActionArgument action in EnumExtensions.ToList<EActionArgument>())
			{
				_actions.Add(action.ToLowercaseString(), action);
			}

			// Prepare the options.
			foreach (EOptionArgument option in EnumExtensions.ToList<EOptionArgument>())
			{
				_options.Add(option.ToLowercaseString(), option);
			}

			// Prepare the MP3 attributes.
			foreach (EMP3Attribute attribute in EnumExtensions.ToList<EMP3Attribute>())
			{
				_mp3attributes.Add(attribute.ToLowercaseString(), attribute);
			}
		}

		/// <summary>
		/// Determine the code paths to be executed, by iterating over the application arguments.
		/// </summary>
		/// <param name="arguments">Arguments.</param>
		public int Dispatch(string[] arguments)
		{
			EActionArgument action;
			EMP3Attribute attribute;
			List<EOptionArgument> options;

			ParseArguments(arguments, out action, out attribute, out options);

			if (action == EActionArgument.None)
			{
				throw new InvalidActionException();
			}

			if (attribute == EMP3Attribute.None)
			{
				throw new InvalidAttributeException();
			}

			// TODO: Actually dispatch now. Haha.

			return 0;
		}

		/// <summary>
		/// Parses the string array containing arguments into meaningful Enumeration values.
		/// </summary>
		/// <param name="arguments">Arguments.</param>
		/// <param name="action">Action.</param>
		/// <param name="attribute">Attribute.</param>
		/// <param name="options">Options.</param>
		void ParseArguments(string[] arguments, out EActionArgument action, out EMP3Attribute attribute, out List<EOptionArgument> options)
		{
			// Instantiate the output variables.
			action = EActionArgument.None;
			attribute = EMP3Attribute.None;
			options = new List<EOptionArgument>();

			// Loop through the arguments and check to see if anything valid was supplied.
			foreach (string argument in arguments)
			{
				if (_actions.Any(a => a.Key.ContainsInsensitive(argument)))
				{
					action = _actions[argument];
				}
				else if (_options.Any(o => o.Key.ContainsInsensitive(argument)))
				{
					options.Add(_options[argument]);
				}
				else if (_mp3attributes.Any(a => a.Key.ContainsInsensitive(argument)))
				{
					attribute = _mp3attributes[argument];
				}
			}
		}
	}
}

