using MP3Tagger.Core.Enumerations;

namespace MP3Tagger.Core
{
	public abstract class Command
	{
		EMP3Attribute _attribute;

		public Command(EMP3Attribute attribute)
		{
			_attribute = attribute;
		}

		public EMP3Attribute Attribute
		{
			get
			{
				return _attribute;
			}

			set
			{
				_attribute = value;
			}
		}

		/// <summary>
		/// Executes the command.
		/// </summary>
		public abstract void Execute();
	}
}

