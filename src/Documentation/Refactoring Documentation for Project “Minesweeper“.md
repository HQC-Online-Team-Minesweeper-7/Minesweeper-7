## Refactoring Documentation for Project “Minesweeper”

###  1.  Redesigned the project structure: Team “Minesweeper - 7”
*   Renamed the project to Minesweeper
*   Renamed the namespace Igrata_Minichki to ConsoleMinesweeper
*   Renamed the main class Telerik to Program in ConsoleMinesweeper
*   Add ConsoleApplication with name GameEngine
*   Add folder Board in GameEngine
*   Add folder Commands in GameEngine
*   Add folder Data in GameEngine
*   Add folder State in GameEngine
*   Add folder Statistic in GameEngine
*   Add folder Field in folder Board
*   Add class ConsoleRenderSingleton.cs in ConsoleMinesweeper
*   Add class FieldVisualator.cs in ConsoleMinesweeper
*   Add class Field.cs
*   Add class FieldFactory.cs
*   Add class FieldWrapper.cs
*   Add interface IField.cs
*   Add class Board.cs
*   Add class BoardBilder.cs
*   Add class BoardRow.cs
*   Add interface IBoard.cs
*   Add interface IBoardRow.cs
*   Add class Command.cs
*   Add class ExitCommand.cs
*   Add class MoveCommand.cs
*   Add class RestartCommand.cs
*   Add class ShowStatisticCommand.cs
*   Add class FilePlayerMementoStorage.cs
*   Add interface IPlayerMementoStorage.cd 
*   Add class ExitState.cs
*   Add class FailState.cs
*   Add class MoveState.cs
*   Add class ShowStatisticState.cs
*   Add class StartState.cs
*   Add class State.cs
*   Add class SuccessState.cs
*   Add interface IPlayer.cs 
*   Add class Player.cs
*   Add class PlayerBaskwardCompare.cs
*   Add class PayerCaretaker.cs
*   Add class PlayerMemento.cs
*   Add interface IStatistic.cs 
*   Add interface IStatisticFactory.cs
*   Add interface IStatisticStorage.cs 
*   Add class Statistic.cs
*   Add class StatisticFactory.cs
*   Add class StatisticStorage.cs
*   Add class StatisticStorageDummy.cs
*   Add class CommandFactory.cs
*   Add class Engine.cs
*   Add inerface IRender.cs
*   Move all logic in classes
*   Add Unit Test Project - Minesweeper.Tests


### Using disign Patterns

*	In class IStatisticFactory - Abstract factory
 * Клас диаграма:
![alt text](https://raw.githubusercontent.com/HQC-Online-Team-Minesweeper-7/Minesweeper-7/master/src/Documentation/Picture/abstract.gif " Abstract factory Design Pattern UML Diagram")
*	In class Command - Command
*	In class Engine - Façade
*	In class Player - Memento
*	In class IStatistic и IComparer<IPlayer> - Bridge
*	In class State- State
*	In class render - Singleton
*	In class BoardBuilder - Builder
*	In class FieldFactory - Flyweight
*	In class Board - Iterator

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

*   Formatted code - if, for, while
*   Create IScoreBoard.cs
*   Create Scoreboard.cs
*   Extracted each class in a separate file with a good name: GameMinesweeper.cs, Dashboard.cs, Panel.cs, Commands.cs, Person.cs.
…
### Reformatted the source code:

1.  Reformatted class Telerik.cs.
2.  Remove blank spaces and rows
3.  Remove bad coments
```
    // taiz igra sym ya igral na 8 godinki kato biah u lqlq stefka na komputera v bibliotekata
```
4.   Remove 'usings'
```    
    using System.Linq;
    using System.Text;
```
5.   Insert class access modifier.
6.   Insert fields name , score.
7.   Move constructor before properties.
8.   Inserted empty lines between the properties.
9.  Reformatted class Dashboard.cs.
10.  Move using derectives in namespase.
11.  Put { and } after all conditionals and if statemants
12.  Renamed method Dobavi to EnterPlayerName.
13.  Move constructor before properties.
14.  Inserted empty lines between the all methods.
15.  Remove the lines and spaces containing several statements into several simple lines, e.g.:

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

>   Before
```
    if (input ==

                "exit")

            {
                Exit();


                return;


            }
```

>   After
```
      if (input == "exit")
            {
                Exit();
                return;
            }
```

>   Befor
```
     if (input

                ==

                "restart")
            {

                Start();


                return;
            }
```

>   After
```
      if (input == "restart")
            {
                Start();
                return;
            }
```

>   Before
```
     proverka =
                int.TryParse(
                input[2].ToString(),
                out colInput);
            if (!proverka) { Console.WriteLine("Illegal input!"); return; }
```

>   After

```
     proverka = int.TryParse(input[2].ToString(), out colInput);

            if (!proverka)
            {
                Console.WriteLine("Illegal input!"); return;
            }
```

>   Before
```
    if (input.Length != 3)
            {
                Console.WriteLine("Illegal input!");
                return;
            }

            if (input[1] != ' ')
            {
                Console.WriteLine("Illegal input!");
                return;
            }
```

>   After

```
    if (input.Length != Constants.InputLength || input[1] != ' ')
            {
                Console.WriteLine("Illegal input!");
                return;
            }
```

>   Before
```
    bool proverka;
            int rowInput;
            proverka = int.TryParse(input[0].ToString(), out rowInput);

            if (!proverka)
            {
                Console.WriteLine("Illegal input!");
                return;
            }

            int colInput;
            proverka = int.TryParse(input[2].ToString(), out colInput);

            if (!proverka)
            {
                Console.WriteLine("Illegal input!"); return;
            }
```

>   After

```
    int rowInput = CheckInputValue(input, 0);
    int colInput = CheckInputValue(input, 2);

    private static int CheckInputValue(string input, int position)
        {
            int result;
            bool isTrue = int.TryParse(input[position].ToString(), out result);

            if (!isTrue)
            {
                Console.WriteLine("Illegal input!");
                Commands();
            }

            return result;
        }
```

>   Before
```

```

>   After

```

```


*   Formatted the curly braces { and } according to the best practices for the C# language.
*   Put { and } after all conditionals and loops (when missing).
*   Character casing: variables and fields made camelCase; types and methods made PascalCase.
*   Formatted all other elements of the source code according to the best practices introduced in the course “High-Quality Programming Code”.
…
### Renamed variables:
*   matrica to matrix
*   In class ConsoleMinesweeperEngine remove all badd comments
…

### Renamed methods
*   Rename method NovaIgra() to Play()
*   Rename method DaiRezultati() to Scoreboard()
*   Renamed the method procheti to Commands

### Create class from method
*   In class ConsoleMinesweeperEngine export GenerateMinesweeperMatrix() to class MineGenerator.GenerareMinesweeperInMatrix()
