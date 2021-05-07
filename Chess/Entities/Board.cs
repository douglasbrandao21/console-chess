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

        public void PutPiece(Piece piece, Position position)
        {
            Pieces[position.Row, position.Column] = piece;

            piece.Position = position;
        }
    }
}
