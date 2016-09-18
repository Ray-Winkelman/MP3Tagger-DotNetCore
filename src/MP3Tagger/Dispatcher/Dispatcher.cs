using System.Collections.Generic;
using System.Linq;
using Extensions.Strings;

namespace MP3Tagger
{
	public class Dispatcher
	{
		private Dictionary<string, EActionArgument> _actions = new Dictionary<string, EActionArgument>();

		public Dispatcher()
		{
			_actions.Add("clean", EActionArgument.Clean);
		}

		public Dictionary<string, EActionArgument> Actions
		{
			get
			{
				return _actions;
			}

			set
			{
				_actions = value;
			}
		}

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

