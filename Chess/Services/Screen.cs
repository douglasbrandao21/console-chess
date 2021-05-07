using System;
using Entities;

namespace Services
{
    class Screen
    {
        public static void ShowBoard(Board board)
        {
            for(int row = 0; row < board.Rows; row++)
            {
                Console.Write(8 - row + " ");
                for(int column = 0; column < board.Columns; column++)
                {
                    PrintPiece(board.SinglePiece(row, column));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ShowBoard(Board board, bool[,] possibleMoviments)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor darkGray = ConsoleColor.DarkGray;

            for(int row = 0; row < board.Rows; row++)
            {
                Console.Write(8 - row + " ");
                for(int column = 0; column < board.Columns; column++)
                {
                    if(possibleMoviments[row, column])
                        Console.BackgroundColor = darkGray;
                    else
                        Console.BackgroundColor = originalBackground;

                    PrintPiece(board.SinglePiece(row, column));

                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");

            
        }

        private static void PrintPiece(Piece piece)
        {
            if(piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if(piece.Color == Color.White)
                    Console.Write(piece);

                else
                {
                    ConsoleColor consoleColor = Console.ForegroundColor;

                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(piece);

                    Console.ForegroundColor = consoleColor;
                }
                Console.Write(" ");
            }

            
        }

        public static Coordinate ReadPosition()
        {
            String input = Console.ReadLine();

            char column = input[0];
            int row = int.Parse($"{input[1]}");

            return new Coordinate(column, row);
        }
    }
}
