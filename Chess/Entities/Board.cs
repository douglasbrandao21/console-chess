using Exceptions;

namespace Entities
{
    class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

            Pieces = new Piece[Rows, Columns];
        }

        public Piece SinglePiece(int row, int column)
        {
            return Pieces[row, column];
        }

        public Piece SinglePiece(Position position)
        {
            return Pieces[position.Row, position.Column];
        }

        public bool ExistsPiece(Position position)
        {
            if(!ValidPosition(position))
                throw new BoardExeption("Invalid position");

            return Pieces[position.Row, position.Column] != null;
        }

        public void PutPiece(Piece piece, Position position)
        {
            if(ExistsPiece(position))
                throw new BoardExeption("Position already ocupped.");

            Pieces[position.Row, position.Column] = piece;

            piece.Position = position;
        }

        public bool ValidPosition(Position position)
        {
            if(position.Row < 0 || position.Column < 0 || position.Row >= Rows || position.Column >= Columns)
                return false;
           
            return true;
        }
    }
}
