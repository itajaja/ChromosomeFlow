using System;

namespace test
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("parsing the file...");
			LevelParser parser = new LevelParser();
			parser.ParseFile(System.IO.File.ReadAllLines(@"testlevel"));
			Console.WriteLine("parsing successfull");
		}
	}

}