Refactoring documentation:

Finished Tasks
1.Renamed the project to GameFifteen.							- Asen Valyoski
2.Renamed the main class Program to PlayGameFifteen. 				 	-  Asen Valyovski
3.Removed all unneeded empty lines.  							- Asen Valyovski
4.Split the lines containing several statements into several simple lines, e.g.:	-  Asen Valyovski
5.Formatted the curly braces { and } according to the best practices for the C# language.-  Asen Valyovski
6.Put { and } after all conditionals and loops (when missing).				-  Asen Valyovski

7.Appropriate names for fields, properties, methods, given. Renamed all constant fields, using PascalCase 
instead of ALL_CAPS. All freeTile appearances in fields and methods renamed to emptyTile. tempTile fields,
renamed to currentTile. tileName and tileValue fields renamed to tileLabel. resultMatrix field in ShuffleMatrix() 
method, renamed to shuffledMatrix. isValidHorizontalNeighbour and isValidVerticalNeighbour renamed to 
areValidHorizontalNeighbours and areValidVerticalNeighbours. switchedindexNumber field renamed to position. All 
appearances of tiles in fields and methods renamed to tilesMatrix. cnt field renamed to movesCount. s field renamed
to command. flag field renamed to isMatrixSolved. destinationTileValue field renamed to tileLabel. isSuccessfulParsing
field renamed to isMovingCommand. rowCounter field renamed to currentColumn. currentElement renamed to currentTile. 
tileLabelInt and parsedLabel fields renamed to currentTileLabel.  			-  Krasimir Uzunov

8.Change method name CommandType to IsCommandValid.					- Asen Valyoski
9.Refacrorigng PlayGameFifteen.cs. Remove ifs.						- Asen Valyoski
10.scoreboardLine is change + concatenate of string to string.Format			- Asen Valyoski
11. Remove Empty Tile constructor and correct DetermineEmptyTile and change it to GetEmptyTile - Asen Valyoski
12. Remove GenerateNeighbourTilesList - it is unneeded.					- Asen Valyoski
13. Refacturing AreValidNeighbours method.						- Asen Valyoski
14. IsMatrixSolved code formating.							- Asen Valyoski
15. Remove dublicated method AreValidNeighbours().					- Asen Valyoski
16. Change MoveTiles method logic.
17. Remove class Command and change method isValidCommand to one enumeration checking for validate it - - Asen Valyoski

18.XML Documentation in classes Tile, Scoreboard, PlayGameFifteen, MatrixGenerator, Gameplay added. 
TilePositionValidation method removed. Enum members renamed from camelCase to PascalCase.

19. Unit Tests for classes Scoreboard and Tile added. - Krasimir Uzunov

