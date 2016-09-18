using System.Collections.Generic;
using System.Linq;
using MP3Tagger.Extensions.Strings;
using MP3Tagger.Extensions.Enumerations;
using MP3Tagger.UI.Interfaces;
using MP3Tagger.Core.Enumerations;
using MP3Tagger.Core.Commands;
using MP3Tagger.Exceptions;
using MP3Tagger.Configuration;
using MP3Tagger.Logger;
using MP3Tagger.Resources;

namespace MP3Tagger.Core
{
	public class Dispatcher
	{
		// Dictionaries.
		Dictionary<string, EActionArgument> _actions = new Dictionary<string, EActionArgument>();
		Dictionary<string, EOptionArgument> _options = new Dictionary<string, EOptionArgument>();
		Dictionary<string, EMP3Attribute> _mp3attributes = new Dictionary<string, EMP3Attribute>();

		// Command.
		Command _command;

		// UI
		IUserInterface _ui;

		/// <summary>
		/// The command to be executed by the Dispatcher.
		/// </summary>
		/// <value>The command.</value>
		public Command Command
		{
			get
			{
				return _command;
			}
		}

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
		public void Dispatch(string[] arguments)
		{
			EActionArgument action;
			EMP3Attribute attribute;
			List<EOptionArgument> options;

			ParseArguments(arguments, out action, out attribute, out options);

			if (attribute == EMP3Attribute.None)
			{
				throw new InvalidAttributeException();
			}

			switch (action)
			{
				case EActionArgument.Clean:
					_command = new CleanCommand(attribute);
					break;
				case EActionArgument.Clear:
					_command = new ClearCommand(attribute);
					break;
				case EActionArgument.Set:
					_command = new SetCommand(attribute);
					break;
				default:
					throw new InvalidActionException();
			}

			SetOptions(options);

			if (Config.VerboseLogEnabled)
			{
				Log.Info(Strings.ValidArguments);
			}

			if (Config.VerboseUIEnabled)
			{
				_ui.Update(Strings.ValidArguments);
			}

			_command.Execute();
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
				_ui.Update(argument);

				if (_actions.Any(a => a.Key.EqualsInsensitive(argument)))
				{
					action = _actions[argument.ToLower()];
				}
				else if (_options.Any(o => o.Key.EqualsInsensitive(argument)))
				{
					options.Add(_options[argument.ToLower()]);
				}
				else if (_mp3attributes.Any(a => a.Key.EqualsInsensitive(argument)))
				{
					attribute = _mp3attributes[argument.ToLower()];
				}
				else
				{
					throw new InvalidArgumentException(argument);
				}
			}
		}

		void SetOptions(List<EOptionArgument> options)
		{
			if (options.Any(a => a == EOptionArgument.Log))
			{
				Config.VerboseLogEnabled = true;
			}

			if (options.Any(a => a == EOptionArgument.Verbose))
			{
				Config.VerboseUIEnabled = true;
			}
		}
	}
}

