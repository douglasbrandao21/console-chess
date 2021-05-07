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
                for(int column = 0; column < board.Columns; column++)
                {
                    if(board.SinglePiece(row, column) == null)
                        Console.Write("- ");
                    else
                        Console.Write($"{board.SinglePiece(row, column)} ");
                }
                Console.WriteLine();
            }
        }
    }
}
