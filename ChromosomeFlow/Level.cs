using System;
using System.Collections.Generic;

namespace test
{

  /// <summary>
  /// Class representing an instance of the level.
  /// A level stores all the information of the paths
  /// </summary>
	class Level{

    /// <summary>
    /// Initializes a new instance of the <see cref="test.Level"/> class.
    /// </summary>
    /// <param name='size'>
    /// Size of the board
    /// </param>
		public Level(int size){
			this.size = size;
			this.paths = new List<Path>();
		}

		private List<Path> paths;

		public List<Path> Paths {
			get {
				return paths;
			}
			set {
				paths = value;
			}
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
	}


  /// <summary>
  /// A path contains the location of the start and the end points to be connected
  /// </summary>
	class Path{

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

