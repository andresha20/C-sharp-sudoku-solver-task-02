using System;
using static System.Console;


namespace sudokuSolver
{
    internal class Program
    {
        private const int GRID_SIZE = 9;

        static void Main(string[] args) {
            int[,] board = new int[9, 9] {
                {7, 0, 2, 0, 5, 0, 6, 0, 0},
                {0, 0, 0, 0, 0, 3, 0, 0, 0},
                {1, 0, 0, 0, 0, 9, 5, 0, 0},
                {8, 0, 0, 0, 0, 0, 0, 9, 0},
                {0, 4, 3, 0, 0, 0, 7, 5, 0},
                {0, 9, 0, 0, 0, 0, 0, 0, 8},
                {0, 0, 9, 7, 0, 0, 0, 0, 5},
                {0, 0, 0, 2, 0, 0, 0, 0, 0},
                {0, 0, 7, 0, 4, 0, 2, 0, 3}
            };
            printBoard(board);
            if (solveBoard(board))
            {
                WriteLine("Successful!");
            }
            else
            {
                WriteLine("Unsuccessful...");
            }
            printBoard(board);
        }

        public static Boolean isNumberInRow(int[,] targetArray, int number, int row)
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                if (targetArray[row, i] == number)
                {
                    return true;
                }
            }
            return false;
        }

        public static Boolean isNumberInColumn(int[,] targetArray, int number, int columnIndex)
        {
            for (int i = 0; i < GRID_SIZE; i++)
            {
                if (targetArray[i, columnIndex] == number)
                {
                    return true;
                }
            }
            return false;
        }

        public static Boolean isNumberInBox(int[,] targetArray, int number, int row, int column)
        {
            int localBoxRow = row - row % 3;
            int localBoxColumn = column - column % 3;

            for (int i = localBoxRow; i < localBoxRow + 3; i++)
            {
                for (int i2 = localBoxColumn; i2 < localBoxColumn + 3; i2++)
                {
                    if (targetArray[i, i2] == number)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static Boolean isValidPlacement(int[,] targetArray, int number, int row, int column)
        {
            return !isNumberInRow(targetArray, number, row) &&
                    !isNumberInColumn(targetArray, number, column) &&
                    !isNumberInBox(targetArray, number, row, column);
        }

        public static Boolean solveBoard(int[,] targetArray)
        {
            for (int row = 0; row < GRID_SIZE; row++)
            {
                for (int column = 0; column < GRID_SIZE; column++)
                {
                    if (targetArray[row, column] == 0)
                    {
                        for (int numberToTry = 1; numberToTry <= GRID_SIZE; numberToTry++)
                        {
                            if (isValidPlacement(targetArray, numberToTry, row, column))
                            {
                                targetArray[row, column] = numberToTry;
                                if (solveBoard(targetArray))
                                {
                                    return true;
                                }
                                else
                                {
                                    targetArray[row, column] = 0;
                                }
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        private static void printBoard(int[,] board)
        {
            for (int row = 0; row < GRID_SIZE; row++)
            {
                if (row % 3 == 0 && row != 0)
                {
                    WriteLine("-----------");
                }
                for (int column = 0; column < GRID_SIZE; column++)
                {
                    if (column % 3 == 0 && column != 0)
                    {
                        WriteLine("|");
                    }
                    WriteLine(board[row, column]);
                }
                WriteLine();
            }
        }
    }
}
