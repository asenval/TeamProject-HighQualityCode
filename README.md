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

20.XML Documentation in classes Player, Scoreboard and Command.			-- Georgi Rusev
21.Adding Refracturing documentation.			-- Georgi Rusev
22.Create GameFifteenUnitTests and adding unit tests  CommandTest			-- Georgi Rusev
23.Adding unit test PlayerTest. 			-- Georgi Rusev
24.Updating Readme.md			-- Georgi Rusev
25.Change assembly name to GameFifteen.			-- Georgi Rusev
26.Changing default name space to GameFifteenProject.			-- Georgi Rusev
27.Move Using out of name spaces.			-- Georgi Rusev
28.Move fields before methods and public methods before private.			-- Georgi Rusev
29.Fix emty lines and missing lines in code.			-- Georgi Rusev

30.Make DeleteAllExceptTopFivePlayers to private and call it every time when add player. We mustn't have more than 5 player in Player list. - Asen.
31.Add CheckPlayerScores method to check if player must be added to playlist, and use it in PlayGameFifteen to ask for player name. - Asen
32.Add AssemblyInfo.cs to the project    			- Asen
33.Add ClearPlayers internal method and add it to be visible for test class GameFifteenUnitTests - Asen
34.Correct Players list Sort, it is not working.
35.Add test for Scoreboard.  					- Krasi and Asen
36.Add test for GamePlay.					- Asen
37.Add test for MatrixGenerator. 				- Georgi and Asen







V scoreboard documentation
 добавиш доументация за пропъртитата и конструкорите
 
Da se napravi Refactoring Documentation ot Readmeto.


