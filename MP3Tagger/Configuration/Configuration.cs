namespace MP3Tagger.Configuration
{
	public static class Config
	{
		static bool _verboseLogging;
		static bool _verboseUI;

		/// <summary>
		/// Gets or sets the global logging verbosity.
		/// </summary>
		/// <value>The logging verbosity.</value>
		public static bool VerboseLogEnabled
		{
			get
			{
				return _verboseLogging;
			}

			set
			{
				_verboseLogging = value;
			}
		}

		/// <summary>
		/// Gets or sets the global user interface verbosity.
		/// </summary>
		/// <value>The user interface verbosity.</value>
		public static bool VerboseUIEnabled
		{
			get
			{
				return _verboseUI;
			}

			set
			{
				_verboseUI = value;
			}
		}
	}
}