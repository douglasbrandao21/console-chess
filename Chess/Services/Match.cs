using Entities;
using System;

namespace Services
{
    class Match
    {
        public Board Board { get; private set; }
        private int Shift { get; set; }
        private Color CurrentPlayer { get; set; }
        public bool Finished { get; set; }

        public Match()
        {
            Board = new Board();
            Shift = 1;
            CurrentPlayer = Color.White;

            PutPieces();
        }

        public void Moviment(Position origin, Position target)
        {
            Piece piece = Board.RemovePiece(origin);

            piece.IncreaseMoviments();

            Piece capturedPice = Board.RemovePiece(target);

            Board.PutPiece(piece, target);
        }

        private void PutPieces()
        {
            Board.PutPiece(new Tower(Board, Color.White), new Coordinate('c', 1).ToPosition());
            Board.PutPiece(new Tower(Board, Color.White), new Coordinate('c', 2).ToPosition());

            Board.PutPiece(new Tower(Board, Color.Black), new Coordinate('c', 7).ToPosition());
            Board.PutPiece(new Tower(Board, Color.Black), new Coordinate('c', 8).ToPosition());
        }
    }
}
