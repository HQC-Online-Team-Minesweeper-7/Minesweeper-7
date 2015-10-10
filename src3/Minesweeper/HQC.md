## Refactoring Documentation for Project “Minesweeper”

###  1.  Redesigned the project structure: Team “Minesweeper - 7”
*   Renamed the project to Minesweeper. - T Dakov
*    Renamed the namespace Igrata_Minichki to Minesweeper. - T Dakov
*    Renamed the main class Telerik to MainesweeperEntryPoint. - T Dakov
*   Add folder GameModel
*   Add folder Board
*   Add folder Field
 *   Add class Field.cs
 ```
    namespace Minesweeper.GameModel.Board.Field
    {
    using System;
    using Utils;

    public class Field
    {
        public const int MineContent = -1;

        public Field(int content)
        {
            if (content < MineContent || Constants.MatrixColumn < content)
            {
                throw new ArgumentOutOfRangeException("Content is invalid - out fo range");
            }

            this.Content = content;
        }

        public int Content { get; private set; }

        public bool IsMine
        {
            get
            {
                return Content == MineContent;
            }
        }
    }
}
```
*   Add folder Utils
    
```
    namespace Minesweeper.Utils
    {
    static class Constants
    {
        public static char MinesSymbol = '*';
        public static char Symbol = '?';
        public static char EmptySymbol = '-';
        public static char EmptyString = '-';
        public static int InputLength = 3;
        public static int MatrixRow = 5;
        public static int MatrixColumn = 10;
        public static int MaxScore = 35;
        public static int MinesToInsert = 15;
    }
}
```

-   Add class FieldFactory
```
namespace Minesweeper.GameModel.Board.Field
{
    using System.Collections.Generic;

    public class FieldFactory
    {
        private Dictionary<int, Field> Fields = new Dictionary<int, Field>();

        public Field GetField(int content)
        {
            Field field;

            if (!this.Fields.TryGetValue(content, out field))
            {
                field = new Field(content);
                this.Fields.Add(content, field);
            }

            return field;
        }
    }
}
```
    -   Renamed the method DaiRezultati to Scoreboard. - T Dakov
*   Renamed the method procheti to Commands. T Dakov
*   Formatted code - if, for, while - T Dakov
*   Create IScoreBoard.cs - T Dakov
*   Create Scoreboard.cs - T Dakov
*   Extracted each class in a separate file with a good name: GameMinesweeper.cs, Dashboard.cs, Panel.cs, Commands.cs, Person.cs.
…
### Reformatted the source code:

1.  Reformatted class Telerik.cs.
*   Remove blank spaces and rows
*   Insert class access modifier.
*   Insert fields name , score.
*   Move constructor before properties.
*   Inserted empty lines between the properties.

2.  Reformatted class Dashboard.cs.

3.  Move using derectives in namespase.
4.  Put { and } after all conditionals and if statemants
5.  Renamed method Dobavi to EnterPlayerName.
7.  Move constructor before properties.
8.  Inserted empty lines between the all methods.

9.  Remove the lines and spaces containing several statements into several simple lines, e.g.:

>   Before:

```
if (currentNeighbourRow < 0 
                    
                    || 
                    
                    currentNeighbourRow >= matrica.GetLength(0) 
                    
                    ||


                    currentNeighbourCol < 0 
                    
                    ||
                    
                    currentNeighbourCol >= matrica.GetLength(1))
                {
                    continue;
                }
```
>   After:
```
 if (currentNeighbourRow < 0 ||
                    currentNeighbourRow >= matrica.GetLength(0) ||
                    currentNeighbourCol < 0 ||
                    currentNeighbourCol >= matrica.GetLength(1))
                {
                    continue;
                }
```

>   Before
```
  if (matrica[currentNeighbourRow, 
                    currentNeighbourCol] == '*')
                {

                 
                    minesCount++;
                }
```
>   After
```
if (matrica[currentNeighbourRow, currentNeighbourCol] == '*')
                {
                    minesCount++;
                }

```
*   Formatted the curly braces { and } according to the best practices for the C# language.
*   Put { and } after all conditionals and loops (when missing).
*   Character casing: variables and fields made camelCase; types and methods made PascalCase.
*   Formatted all other elements of the source code according to the best practices introduced in the course “High-Quality Programming Code”.
…
### Renamed variables:
*   In class Fifteen: number to numberOfMoves.
*   In Main(string\[\] args): g to gameFifteen.
*   Introduced constants:
*   GAME\_BOARD\_SIZE = 4
*   SCORE\_BOARD\_SIZE = 5.
*   Extracted the method GenerateRandomGame() from the method Main().
*   Introduced class ScoreBoard and moved all related functionality in it.
*   Moved method GenerateRandomNumber(int start, int end) to separate class RandomUtils.
…

### Removed blank rows
