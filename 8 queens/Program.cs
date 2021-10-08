using System;
using System.Collections.Generic;
using System.Globalization;

namespace _8_queens
{
    internal class Program
    {
        private const int queens = 8;
        static void Main(string[] args)
        {
            int[,] board = new int[8, 8]
            {
                {0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0}
            };
            if(!isValid(board, 0))
                Console.WriteLine("Solution not found");

            ShowBoard(board);
        }

        public static bool isValid(int[,] board, int col)
        {
            if (col >= 8)
                return true;

            for (int rows = 0; rows < 8; rows++)
            {
                if (CheckForQueens(board, rows, col))
                {
                    board[rows, col] = 2;
                    if (isValid(board, col + 1)) return true;
                    board[rows, col] = 0;
                }
            }

            return false;
        }

        public static bool CheckForQueens(int[,] board, int row, int col)
        {
            // Check horizontal
            for (int i = 0; i < col; i++)
            {
                if(board[row,i] == 2) return false;
            }

            // Check vertical
            for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 2) return false;
            }

            // Check diagonal
            for (int i = row, j = col; j >= 0 && i < 8; i++, j--)
            {
                if (board[i, j] == 2) return false;
            }

            return true;
        }
        public static void ShowBoard(int[,] board)
        {
            string output = "";
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                    switch (board[row, column])
                    {
                        case 0:
                            output += "|x|";
                            break;

                        case 2:
                            output += "|Q|";
                            break;
                    }
                }

                output += Environment.NewLine;
            }

            Console.WriteLine(output);
        }
    }
}
