ChromosomeFlow
==============

Genetic Algorithm solver for the game [Flow](http://app.net/flowfree)

###Input files
The Input file is a plain text as the following, each line representing a row, each character representing a tile.
```
0AB000
0CD000
000C00
000000
000A00
DB0000
```
The rules are the following:

1. The board must be squared
2. The zeros represent empy tiles
3. Letters from A to B represent the path edges
4. there must be only two edges for pipe
5. pipes are named alphabetically starting from letter A, without gaps

###Notes
The project is compiled with [MonoDevelop](http://monodevelop.com/) on Linux. It hasn't been tested on Visual Studio yet.
