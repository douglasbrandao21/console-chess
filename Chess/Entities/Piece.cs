namespace Entities
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Board Board { get; protected set; }
        public Color Color { get; protected set; }
        public int QuantityMoviments { get; set; }
       
        public Piece() { }

        public Piece(Board board, Color color)
        {
            Board = board;
            Color = color;
        }

        public void IncreaseMoviments()
        {
            QuantityMoviments++;
        }

        public void DecreaseMoviments()
        {
            QuantityMoviments--;
        }

        protected bool CanMove(Position position)
        {
            Piece piece = Board.SinglePiece(position);

            return piece == null || piece.Color != Color;
        }

        public bool ExistsPossibleMoviments()
        {
            bool[,] possibleMoviments = PossibleMoviments();

            for(int row = 0; row < Board.Rows; row++)
            {
                for(int column = 0; column < Board.Columns; column++)
                {
                    if(possibleMoviments[row, column]) return true;
                }
            }

            return false;
        }

        public bool CanMoveTo(Position position)
        {
            return PossibleMoviments()[position.Row, position.Column];
        }

        public abstract bool[,] PossibleMoviments();
    }
}
