using System;
using System.Collections.Generic;
using Entities;

namespace Services
{
    class Screen
    {
        public static void ShowMatch(Match match)
        {
            ShowBoard(match.Board);

            ShowCapturedPieces(match);

            Console.WriteLine();
            Console.WriteLine($"Shift: {match.Shift}");

            if(!match.Finished)
            {
                Console.WriteLine($"Waiting moviment: {match.CurrentPlayer}");

                if(match.IsInXeque)
                {
                    Console.WriteLine();
                    Console.WriteLine("XEQUE!");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("XEQUE MATE!");
                Console.WriteLine($"Winner: {match.CurrentPlayer}");
            }
            
        }

        public static void ShowCapturedPieces(Match match)
        {
            Console.WriteLine();
            Console.WriteLine("Captured Pieces: ");
            Console.Write("Whites: ");

            ShowCollection(match.CapturedPiecesByColor(Color.White));

            Console.WriteLine();

            ConsoleColor consoleColor = Console.ForegroundColor;
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Blacks: ");

            ShowCollection(match.CapturedPiecesByColor(Color.Black));
            Console.ForegroundColor = consoleColor;

            Console.WriteLine();
        }

        public static void ShowCollection(HashSet<Piece> pieces)
        {
            Console.Write("[ ");

            foreach(Piece piece in pieces)
            {
                Console.Write($"{piece} ");
            }

            Console.Write(" ]");
        }

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
