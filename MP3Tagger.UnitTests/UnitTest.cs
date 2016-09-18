namespace MP3Tagger.UnitTests
{
	public class UnitTest
	{
		public delegate bool Run();
		Run runTest;
		string name;

		public Run RunTest
		{
			get
			{
				return runTest;
			}

			set
			{
				runTest = value;
			}
		}

		public string Name
		{
			get
			{
				return name;
			}

			set
			{
				name = value;
			}
		}

		public UnitTest(string name, Run func)
		{
			RunTest = func;
			Name = name;
		}
	}
}

