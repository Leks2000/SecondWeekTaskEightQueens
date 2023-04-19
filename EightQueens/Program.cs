using System;

namespace EightQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            int queens = 8;
            int solutions = 0;
            int[] board = new int[queens];
            PlaceQueen(board, 0, queens, ref solutions);
            Console.WriteLine("Number of solutions: " + solutions);
        }

        static void PlaceQueen(int[] board, int row, int n, ref int solutions)
        {
            if (row == n)
            {
                PrintBoard(board);
                solutions++;
                return;
            }
            for (int i = 0; i < n; i++)
            {
                board[row] = i;
                if (IsValid(board, row))
                {
                    PlaceQueen(board, row + 1, n, ref solutions);
                }
            }
        }

        static bool IsValid(int[] board, int row)
        {
            for (int i = 0; i < row; i++)
            {
                int diff = Math.Abs(board[row] - board[i]);
                if (diff == 0 || diff == row - i)
                {
                    return false;
                }
            }
            return true;
        }

        static void PrintBoard(int[] board)
        {
            Console.WriteLine();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    if (board[i] == j)
                    {
                        Console.Write(" Q ");
                    }
                    else
                    {
                        Console.Write(" . ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}