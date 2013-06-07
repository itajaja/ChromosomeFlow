using System;
using System.Text;
using System.Collections.Generic;

namespace test
{

  /// <summary>
  /// Level parser translate the file level into an instance of the level class
  /// </summary>
	class LevelParser
	{

    /// <summary>
    /// Parses the file.
    /// </summary>
    /// <returns>
    /// The parsed level.
    /// </returns>
    /// <param name='filename'>
    /// the complete path to the file
    /// </param>
    public Level ParseFile(string filename){
      return ParseFile(System.IO.File.ReadAllLines(filename));
    }

    /// <summary>
    /// Parses the file.
    /// </summary>
    /// <returns>
    /// The parsed level.
    /// </returns>
    /// <param name='lines'>
    /// Lines, each one representing a row.
    /// </param>
		public Level ParseFile(string[] lines){
			Level level;
			int size = lines.Length;
      //initialize a new level
			level = new Level(size);

      //Check that the level is a square
			for (int r = 0; r < size; r++) {
				string line = lines[r];
				if (size != line.Length) {
					throw new ParseException("The file is not a square, heigth is "+size+" but the line "+line+" has "+line.Length +" characters");
				}
			}

			string levelString = Flatten(lines);
      //Find all the paths. paths must be named starting from letter A, increasing alphabetically
      for (char c = 'A'; c < 'Z'; c++) {
				List<int> occurencesList = FindMul(levelString,c);
        //Path not found, exit the loop
				if(occurencesList.Count == 0){
					break;
				}else //Path found, create it and inser into the level
				if(occurencesList.Count == 2){
					Path p = new Path();
					p.YStart = convertToMatrix(occurencesList[0],size)[0];
					p.XStart = convertToMatrix(occurencesList[0],size)[1];
					p.YEnd = convertToMatrix(occurencesList[1],size)[0];
					p.XEnd = convertToMatrix(occurencesList[1],size)[1];
					level.AddPath(p);
				}else //Path found with illegal number of ends
					throw new ParseException("The path "+c+" has wrong number of heads: "+occurencesList.Count+"(must have 2)");
			}

      //Throw exception if no path is found
			if (level.NumPaths() == 0) {
				throw new ParseException("The level contains no Paths!");
			}

      //Check that all the characters are ok
			foreach (char c in levelString) {
				if(c != '0' && !(c>='A' && c<'A'+level.NumPaths()))
					throw new ParseException("Invalid Character: "+c);
			}

			return level;
		}

    /// <summary>
    /// Converts a number to its matrix location.
    /// </summary>
    /// <returns>
    /// row and column numbers
    /// </returns>
    /// <param name='n'>
    /// input number
    /// </param>
    /// <param name='size'>
    /// Size of the matrix.
    /// </param>
		private int[] convertToMatrix(int n, int size){
			return new int[2]{n/size,n%size};
		}

    /// <summary>
    /// Counts the occurences of a character in a string.
    /// </summary>
		private int Count(string s,char c){
			int counter = 0;
			foreach (var ch in s)
				if (ch == c)
					counter++;
			return counter;
		}

    /// <summary>
    /// Finds the specified character in a string.
    /// </summary>
    /// <returns>
    /// The position of the character in the string. -1 if no character is found
    /// </returns>
		private int Find(string s, char c){
			for (int i = 0; i < s.Length; i++) {
				if(s[i]==c)
					return i;
			}
			return -1;
		}

    /// <summary>
    /// Finds all the occurrences of the specified character in a string.
    /// </summary>
    /// <returns>
    /// A list with all the position of the character
    /// </returns>
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

    /// <summary>
    /// Concatenates the array of string in a single string.
    /// </summary>
		private string Flatten(string[] strings){
			StringBuilder sb = new StringBuilder();
			foreach (string str in strings) {
				sb.Append(str);
			}
			return sb.ToString();
		}

	}

  /// <summary>
  /// Exception thrown by the parser. Thrown when errors are found when parsing the level file
  /// </summary>
	public class ParseException:Exception
	{
		public ParseException(string message)
        : base(message)
    {

		}
	}
}

