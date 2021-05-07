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
                Match match = new Match();

                Screen.ShowBoard(match.Board);

                while(!match.Finished)
                {
                    Console.Clear();

                    Screen.ShowBoard(match.Board);

                    Console.Write("Origin: ");
                    Position origin = Screen.ReadPosition().ToPosition();

                    Console.Write("Target: ");
                    Position target = Screen.ReadPosition().ToPosition();

                    match.Moviment(origin, target);
                }

                //Coordinate coordinate = new Coordinate('c', 7);

                //Console.WriteLine(coordinate);
                //Console.WriteLine(coordinate.ToPosition());

            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
