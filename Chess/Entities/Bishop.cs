namespace Entities
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "B";
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] possibleMoviments = new bool[Board.Rows, Board.Columns];

            Position targetPosition = new Position(0, 0);

            targetPosition.SetPosition(Position.Row - 1, Position.Column-1);
            while(Board.ValidPosition(targetPosition) && CanMove(targetPosition))
            {
                possibleMoviments[targetPosition.Row, targetPosition.Column] = true;

                if(Board.SinglePiece(targetPosition) != null && Board.SinglePiece(targetPosition).Color != Color)
                    break;

                targetPosition.SetPosition(targetPosition.Row - 1, targetPosition.Column - 1);
            }


            targetPosition.SetPosition(Position.Row - 1, Position.Column + 1);
            while(Board.ValidPosition(targetPosition) && CanMove(targetPosition))
            {
                possibleMoviments[targetPosition.Row, targetPosition.Column] = true;

                if(Board.SinglePiece(targetPosition) != null && Board.SinglePiece(targetPosition).Color != Color)
                    break;

                targetPosition.SetPosition(targetPosition.Row - 1, targetPosition.Column + 1);
            }


            targetPosition.SetPosition(Position.Row + 1, Position.Column + 1);
            while(Board.ValidPosition(targetPosition) && CanMove(targetPosition))
            {
                possibleMoviments[targetPosition.Row, targetPosition.Column] = true;

                if(Board.SinglePiece(targetPosition) != null && Board.SinglePiece(targetPosition).Color != Color)
                    break;

                targetPosition.SetPosition(targetPosition.Row + 1, targetPosition.Column + 1);
            }


            targetPosition.SetPosition(Position.Row + 1, Position.Column - 1);
            while(Board.ValidPosition(targetPosition) && CanMove(targetPosition))
            {
                possibleMoviments[targetPosition.Row, targetPosition.Column] = true;

                if(Board.SinglePiece(targetPosition) != null && Board.SinglePiece(targetPosition).Color != Color)
                    break;

                targetPosition.SetPosition(targetPosition.Row + 1, targetPosition.Column - 1);
            }


            return possibleMoviments;
        }
    }
}
