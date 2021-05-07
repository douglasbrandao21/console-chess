using Entities;
using Services;
using System;

namespace Chess
{
    class Program
    {
        static void Main()
        {
            try
            {
                Board board = new Board(8, 8);

                board.PutPiece(new King(board, Color.Black), new Position(0, 0));

                board.PutPiece(new Tower(board, Color.Black), new Position(1, 0));

                Screen.ShowBoard(board);
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
