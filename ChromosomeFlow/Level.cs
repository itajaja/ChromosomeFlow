using System;
using System.Text;
using System.Collections.Generic;

namespace test
{

  //Immutable interface for level
  interface ILevel
  {
    Path at(int x, int y); 

    int NumPaths(); 

    int Size {
      get;
    }
  }

  /// <summary>
  /// Class representing an instance of the level.
  /// A level stores all the information of the paths
  /// </summary>
	class Level: ILevel{

    /// <summary>
    /// Initializes a new instance of the <see cref="test.Level"/> class.
    /// </summary>
    /// <param name='size'>
    /// Size of the board
    /// </param>
		public Level(int size){
			this.size = size;
			this.paths = new List<Path>();
      this.levelMatrix = new Path[size,size];
		}

    /// <summary>
    /// Adds a path to the level.
    /// </summary>
    public void AddPath(Path p){
      paths.Add(p);
      levelMatrix[p.YEnd,p.XEnd] = p;
      levelMatrix[p.YStart,p.XStart] = p;
    }

    /// <summary>
    /// Adds a path to the level.
    /// </summary>
    public void AddPath(int xStart, int yStart, int xEnd, int yEnd){
      AddPath(new Path(xStart, yStart, xEnd, yEnd));
    }

    /// <summary>
    /// Gets the matrix representation of the level
    /// </summary>
    /// <returns>
    /// A matrix representation. changes to this object don't modify the level
    /// </returns>
    public Path[,] getMatrixRepresentation(){
      return levelMatrix.Clone();
    }

    public override string ToString(){
      StringBuilder sb = new StringBuilder();
      sb.Append(" ");
      for (int x = 0; x < this.size; x++)
        sb.Append("__");
      sb.Append("\n");
      for (int y = 0; y < this.size; y++) {
        sb.Append("|");
        for (int x = 0; x < this.size; x++) {
          Path p = levelMatrix[y,x];
          if(p!=null){
            int id = paths.IndexOf(levelMatrix[y,x]);
            sb.Append((char)('A'+id)+" ");
          }
          else
            sb.Append("  ");
        }
        sb.Append("|\n");
      }
      sb.Append(" ");
      for (int x = 0; x < this.size; x++)
        sb.Append("--");
      return sb.ToString();
    }

    /// <summary>
    /// return the path edge at the specified x and y.
    /// </summary>
    public Path at(int x, int y){
      return levelMatrix[y,x];
    }

    /// <summary>
    /// Number of paths in the level.
    /// </summary>
    public int NumPaths(){
      return paths.Count;
    }

		public int Size {
			get {
				return size;
			}
			set {
				size = value;
			}
		}
		private int size;

    private List<Path> paths;

    private Path[,] levelMatrix;
	}

  /// <summary>
  /// An element is a generic object that can be placed on the level
  /// </summary>
  abstract class Element{

  }

  /// <summary>
  /// A path contains the location of the start and the end points to be connected
  /// </summary>
	class Path : Element{

    public Path(){

    }

    public Path(int xStart, int yStart, int xEnd, int yEnd){
      this.xStart = xStart;
      this.yStart = yStart;
      this.xEnd = xEnd;
      this.xEnd = xEnd;
    }

		public int XStart {
			get {
				return xStart;
			}
			set {
				xStart = value;
			}
		}

		public int YStart {
			get {
				return yStart;
			}
			set {
				yStart = value;
			}
		}

		public int XEnd {
			get {
				return xEnd;
			}
			set {
				xEnd = value;
			}
		}

		public int YEnd {
			get {
				return yEnd;
			}
			set {
				yEnd = value;
			}
		}

		private int xStart,yStart,xEnd,yEnd;
	}
}

