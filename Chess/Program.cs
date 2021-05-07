using Entities;
using Services;
using System;

namespace Chess
{
    class Program
    {
        static void Main()
        {
            Match match = new Match();

            Screen.ShowBoard(match.Board);

            while(!match.Finished)
            {
                try
                {
                    Console.Clear();

                    Screen.ShowMatch(match);

                    Console.Write("Origin: ");
                    Position origin = Screen.ReadPosition().ToPosition();

                    match.ValidateOriginPosition(origin);

                    bool[,] possibleMoviments = match.Board.SinglePiece(origin).PossibleMoviments();

                    Console.Clear();
                    Screen.ShowBoard(match.Board, possibleMoviments);

                    Console.Write("Target: ");
                    Position target = Screen.ReadPosition().ToPosition();

                    match.ValidateTargetPosition(origin, target);

                    match.Play(origin, target);
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.ReadLine();
                }
            }

            Console.Clear();
            Screen.ShowMatch(match);

            //Coordinate coordinate = new Coordinate('c', 7);

            //Console.WriteLine(coordinate);
            //Console.WriteLine(coordinate.ToPosition());

        }
    }
}

