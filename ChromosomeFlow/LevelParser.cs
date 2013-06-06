using System;
using System.Text;
using System.Collections.Generic;

namespace test
{

	class LevelParser
	{
		public Level ParseFile(string[] lines){
			Level level;
			int size = lines.Length;
			level = new Level(size);
			for (int r = 0; r < size; r++) {
				string line = lines[r];
				if (size != line.Length) {
					throw new ParseException("The file is not a square, heigth is "+size+" but the line "+line+" has "+line.Length +" characters");
				}
			}
			string levelString = Flatten(lines);
			for (char c = 'A'; c < 'Z'; c++) {
				List<int> occurencesList = FindMul(levelString,c);
				if(occurencesList.Count == 0){
					break;
				}else
				if(occurencesList.Count == 2){
					Path p = new Path();
					p.YStart = convertToMatrix(occurencesList[0],size)[0];
					p.XStart = convertToMatrix(occurencesList[0],size)[1];
					p.YEnd = convertToMatrix(occurencesList[1],size)[0];
					p.XEnd = convertToMatrix(occurencesList[1],size)[1];
					level.Paths.Add(p);
				}else
					throw new ParseException("The path "+c+" has wrong number of heads: "+occurencesList.Count+"(must have 2)");
			}
			if (level.Paths.Count == 0) {
				throw new ParseException("The level contains no Paths!");
			}
			foreach (char c in levelString) {
				if(c != '0' && !(c>='A' && c<'A'+level.Paths.Count))
					throw new ParseException("Invalid Character: "+c);
			}
			return level;
		}

		private int[] convertToMatrix(int n, int size){
			return new int[2]{n/size,n%size};
		}

		private int Count(string s,char c){
			int counter = 0;
			foreach (var ch in s)
				if (ch == c)
					counter++;
			return counter;
		}

		private int Find(string s, char c){
			for (int i = 0; i < s.Length; i++) {
				if(s[i]==c)
					return i;
			}
			return -1;
		}

		private List<int> FindMul (string s, char c)
		{
			List<int> found = new List<int>();
			int occurences = 0;
			for (int i = 0; i < s.Length; i++) {
				if(s[i]==c){
					found.Add(i);
					occurences++;
				}
			}
			return found;
		}

		private string Flatten(string[] strings){
			StringBuilder sb = new StringBuilder();
			foreach (string str in strings) {
				sb.Append(str);
			}
			return sb.ToString();
		}

	}



	public class ParseException:Exception
	{
		public ParseException(string message)
        : base(message)
    {

		}
	}
}

