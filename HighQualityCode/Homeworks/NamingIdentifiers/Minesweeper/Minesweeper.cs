using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class Minesweeper
    {
        public class Player
        {
            private string name;
            private int points;
            public string Name
            {
                get
                {
                    return this.name;
                }

                set
                {
                    this.name = value;
                }
            }

            public int Points
            {
                get
                {
                    return this.points;
                }

                set
                {
                    this.points = value;
                }
            }

            public Player()
            {
            }

            public Player(string name, int points)
            {
                this.name = name;
                this.points = points;
            }
        }

        public static void Main(string[] args)
        {
            string userMenuChoice = string.Empty;
            char[,] gameField = CreateGameField();
            char[,] enemy = PlaceBombs();
            int turnsCount = 0;
            bool isBombField = false;
            List<Player> winners = new List<Player>(6);
            int row = 0;
            int column = 0;
            const int MaxTurns = 35;
            bool isMenu = true;
            bool isWin = false;

            do
            {
                if (isMenu)
                {
                    Console.WriteLine("Let's play \"Minesweeper\". Try finding the fields without bombs."
                        + " Command 'top' shows the current ranking, 'restart' starts a new game, 'exit' exits and goodbye!");
                    ShowObject(gameField);
                    isMenu = false;
                }

                Console.Write("Enter row and column: ");
                userMenuChoice = Console.ReadLine().Trim();
                if (userMenuChoice.Length >= 3)
                {
                    if (int.TryParse(userMenuChoice[0].ToString(), out row) && int.TryParse(userMenuChoice[2].ToString(), out column) &&
                        row <= gameField.GetLength(0) && column <= gameField.GetLength(1))
                    {
                        userMenuChoice = "turn";
                    }
                }

                switch (userMenuChoice)
                {
                    case "top":
                        ShowRanking(winners);
                        break;
                    case "restart":
                        gameField = CreateGameField();
                        enemy = PlaceBombs();
                        ShowObject(gameField);
                        isBombField = false;
                        isMenu = false;
                        break;
                    case "exit":
                        Console.WriteLine("Goodbye!");
                        break;
                    case "turn":
                        if (enemy[row, column] != '*')
                        {
                            if (enemy[row, column] == '-')
                            {
                                PlayerMove(gameField, enemy, row, column);
                                turnsCount++;
                            }

                            if (turnsCount == MaxTurns)
                            {
                                isWin = true;
                            }
                            else
                            {
                                ShowObject(gameField);
                            }
                        }
                        else
                        {
                            isBombField = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid command\n");
                        break;
                }

                if (isBombField)
                {
                    ShowObject(enemy);
                    Console.Write("\nGame Over! Score {0}. Enter Nickname: ", turnsCount);
                    string nickname = Console.ReadLine();
                    Player winner = new Player(nickname, turnsCount);
                    if (winners.Count < 5)
                    {
                        winners.Add(winner);
                    }
                    else
                    {
                        for (int i = 0; i < winners.Count; i++)
                        {
                            if (winners[i].Points < winner.Points)
                            {
                                winners.Insert(i, winner);
                                winners.RemoveAt(winners.Count - 1);
                                break;
                            }
                        }
                    }

                    winners.Sort((Player winnerOne, Player winnerTwo) => winnerTwo.Name.CompareTo(winnerOne.Name));
                    winners.Sort((Player winnerOne, Player winnerTwo) => winnerTwo.Points.CompareTo(winnerOne.Points));
                    ShowRanking(winners);

                    gameField = CreateGameField();
                    enemy = PlaceBombs();
                    turnsCount = 0;
                    isBombField = false;
                    isMenu = true;
                }

                if (isWin)
                {
                    Console.WriteLine("\nYou win.");
                    ShowObject(enemy);
                    Console.WriteLine("Your name: ");
                    string name = Console.ReadLine();
                    Player winner = new Player(name, turnsCount);
                    winners.Add(winner);
                    ShowRanking(winners);
                    gameField = CreateGameField();
                    enemy = PlaceBombs();
                    turnsCount = 0;
                    isWin = false;
                    isMenu = true;
                }
            }
            while (userMenuChoice != "exit");
            Console.WriteLine("Goodbye!");
            Console.Read();
        }

        private static void ShowRanking(List<Player> winners)
        {
            Console.WriteLine("\nPoints:");
            if (winners.Count > 0)
            {
                for (int i = 0; i < winners.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes", i + 1, winners[i].Name, winners[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty ranking!\n");
            }
        }

        private static void PlayerMove(char[,] gameField, char[,] enemies, int row, int column)
        {
            char enemiesCount = GetCount(enemies, row, column);
            enemies[row, column] = enemiesCount;
            gameField[row, column] = enemiesCount;
        }

        private static void ShowObject(char[,] field)
        {
            int row = field.GetLength(0);
            int column = field.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < row; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < column; j++)
                {
                    Console.Write(string.Format("{0} ", field[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int fieldRows = 5;
            int fieldColumns = 10;
            char[,] field = new char[fieldRows, fieldColumns];
            for (int i = 0; i < fieldRows; i++)
            {
                for (int j = 0; j < fieldColumns; j++)
                {
                    field[i, j] = '?';
                }
            }

            return field;
        }

        private static char[,] PlaceBombs()
        {
            int rows = 5;
            int columns = 10;
            char[,] gameField = new char [rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    gameField[i, j] = '-';
                }
            }

            List<int> numbers = new List<int>();
            while (numbers.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!numbers.Contains(randomNumber))
                {
                    numbers.Add(randomNumber);
                }
            }

            foreach (int number in numbers)
            {
                int column = number / columns;
                int row = number % columns;
                if (row == 0 && number != 0)
                {
                    column--;
                    row = columns;
                }
                else
                {
                    row++;
                }

                gameField[column, row - 1] = '*';
            }

            return gameField;
        }

        private static void CalculatePoints(char[,] gameField)
        {
            int column = gameField.GetLength(0);
            int row = gameField.GetLength(1);

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (gameField[i, j] != '*')
                    {
                        char point = GetCount(gameField, i, j);
                        gameField[i, j] = point;
                    }
                }
            }
        }

        private static char GetCount(char[,] gameField, int row, int column)
        {
            int minesCount = 0;
            int rows = gameField.GetLength(0);
            int columns = gameField.GetLength(1);

            if (row - 1 >= 0)
            {
                if (gameField[row - 1, column] == '*')
                {
                    minesCount++;
                }
            }

            if (row + 1 < rows)
            {
                if (gameField[row + 1, column] == '*')
                {
                    minesCount++;
                }
            }

            if (column - 1 >= 0)
            {
                if (gameField[row, column - 1] == '*')
                {
                    minesCount++;
                }
            }

            if (column + 1 < columns)
            {
                if (gameField[row, column + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row - 1 >= 0) && (columns - 1 >= 0))
            {
                if (gameField[row - 1, column - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < columns))
            {
                if (gameField[row - 1, column + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row + 1 < rows) && (column - 1 >= 0))
            {
                if (gameField[row + 1, column - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((row + 1 < rows) && (column + 1 < columns))
            {
                if (gameField[row + 1, column + 1] == '*')
                {
                    minesCount++;
                }
            }

            return char.Parse(minesCount.ToString());
        }
    }
}