
namespace Entities
{
    class Tower : Piece
    {
        public Tower(Board board, Color color) : base(board, color) {}

        public override string ToString()
        {
            return "T";
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] possibleMoviments = new bool[Board.Rows, Board.Columns];

            Position targetPosition = new Position(0, 0);


            // Above
            targetPosition.SetPosition(Position.Row - 1, Position.Column);
            while(Board.ValidPosition(targetPosition) && CanMove(targetPosition))
            {
                possibleMoviments[targetPosition.Row, targetPosition.Column] = true;

                if(Board.SinglePiece(targetPosition) != null && Board.SinglePiece(targetPosition).Color != Color)
                    break;

                targetPosition.Row -= 1;
            }


            // Right
            targetPosition.SetPosition(Position.Row, Position.Column + 1);
            while(Board.ValidPosition(targetPosition) && CanMove(targetPosition))
            {
                possibleMoviments[targetPosition.Row, targetPosition.Column] = true;

                Piece pieceInTarget = Board.SinglePiece(targetPosition);

                if(pieceInTarget != null && pieceInTarget.Color != Color)
                    break;

                targetPosition.Column += 1;
            }

            // Below
            targetPosition.SetPosition(Position.Row + 1, Position.Column);
            while(Board.ValidPosition(targetPosition) && CanMove(targetPosition))
            {
                possibleMoviments[targetPosition.Row, targetPosition.Column] = true;

                Piece pieceInTarget = Board.SinglePiece(targetPosition);

                if(pieceInTarget != null && pieceInTarget.Color != Color)
                    break;

                targetPosition.Row += 1;
            }


            // Left
            targetPosition.SetPosition(Position.Row, Position.Column-1);
            while(Board.ValidPosition(targetPosition) && CanMove(targetPosition))
            {
                possibleMoviments[targetPosition.Row, targetPosition.Column] = true;

                Piece pieceInTarget = Board.SinglePiece(targetPosition);

                if(pieceInTarget != null && pieceInTarget.Color != Color)
                    break;

                targetPosition.Column -= 1;
            }

            return possibleMoviments;
        }
    }
}
