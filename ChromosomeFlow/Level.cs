using System;
using System.Collections.Generic;

namespace test
{
	class Level{

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

