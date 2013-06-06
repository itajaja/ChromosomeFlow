using System;

namespace test
{
	class MainClass
	{
    /// <summary>
    /// The entry point of the program, where the program control starts and ends.
    /// </summary>
    /// <param name='args'>
    /// The command-line arguments.
    /// </param>
		public static void Main (string[] args)
		{
			Console.WriteLine ("parsing the file...");
			LevelParser parser = new LevelParser();
			parser.ParseFile(System.IO.File.ReadAllLines(@"../../testlevel1.cf"));
			Console.WriteLine("parsing successfull");
		}
	}

}
