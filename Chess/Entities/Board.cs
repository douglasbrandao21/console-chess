using Exceptions;

namespace Entities
{
    class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public Board()
        {
            Rows = 8;
            Columns = 8;

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

        public void PutPiece(Piece piece, Position position)
        {
            if(ExistsPiece(position))
                throw new BoardException("Position already ocupped.");

            Pieces[position.Row, position.Column] = piece;

            piece.Position = position;
        }

        public Piece RemovePiece(Position position)
        {
            Piece piece = SinglePiece(position);

            if(!ValidPosition(position) || piece == null)
                return null;

            piece.Position = null;

            Pieces[position.Row, position.Column] = null;

            return piece;
        }

        public bool ExistsPiece(Position position)
        {
            if(!ValidPosition(position))
                throw new BoardException("Invalid position");

            return Pieces[position.Row, position.Column] != null;
        }

        public bool ValidPosition(Position position)
        {
            if(position.Row < 0 || position.Column < 0 || position.Row >= Rows || position.Column >= Columns)
                return false;
           
            return true;
        }
    }
}
