namespace Entities
{
    class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "P";
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] possibleMoviments = new bool[Board.Rows, Board.Columns];

            Position targetPosition = new Position(0, 0);

            if(Color == Color.White)
            {
                targetPosition.SetPosition(Position.Row - 1, Position.Column);
                if(Board.ValidPosition(targetPosition) && IsFree(targetPosition))
                    possibleMoviments[targetPosition.Row, targetPosition.Column] = true;

                targetPosition.SetPosition(Position.Row - 2, Position.Column);
                if(Board.ValidPosition(targetPosition) && IsFree(targetPosition) && QuantityMoviments == 0)
                    possibleMoviments[targetPosition.Row, targetPosition.Column] = true;

                targetPosition.SetPosition(Position.Row - 1, Position.Column - 1);
                if(Board.ValidPosition(targetPosition) && ExistsEnemy(targetPosition))
                    possibleMoviments[targetPosition.Row, targetPosition.Column] = true;

                targetPosition.SetPosition(Position.Row - 1, Position.Column + 1);
                if(Board.ValidPosition(targetPosition) && ExistsEnemy(targetPosition))
                    possibleMoviments[targetPosition.Row, targetPosition.Column] = true;
            }
            else
            {
                targetPosition.SetPosition(Position.Row + 1, Position.Column);
                if(Board.ValidPosition(targetPosition) && IsFree(targetPosition))
                    possibleMoviments[targetPosition.Row, targetPosition.Column] = true;

                targetPosition.SetPosition(Position.Row + 2, Position.Column);
                if(Board.ValidPosition(targetPosition) && IsFree(targetPosition) && QuantityMoviments == 0)
                    possibleMoviments[targetPosition.Row, targetPosition.Column] = true;

                targetPosition.SetPosition(Position.Row + 1, Position.Column - 1);
                if(Board.ValidPosition(targetPosition) && ExistsEnemy(targetPosition))
                    possibleMoviments[targetPosition.Row, targetPosition.Column] = true;

                targetPosition.SetPosition(Position.Row + 1, Position.Column + 1);
                if(Board.ValidPosition(targetPosition) && ExistsEnemy(targetPosition))
                    possibleMoviments[targetPosition.Row, targetPosition.Column] = true;
            }

            return possibleMoviments;
        }

        private bool ExistsEnemy(Position position)
        {
            Piece piece = Board.SinglePiece(position);

            return piece != null && piece.Color != Color;
        }

        private bool IsFree(Position position)
        {
            return Board.SinglePiece(position) == null;
        }

    }
}
