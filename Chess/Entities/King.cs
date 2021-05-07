using Services;

namespace Entities
{
    class King : Piece
    {
        private Match Match { get; set; }

        public King(Match match, Board board, Color color) : base(board, color)
        {
            Match = match;
        }


        public override string ToString()
        {
            return "R";
        }

        private bool TowerCanRoque(Position position)
        {
            Piece piece = Board.SinglePiece(position);

            return piece != null && piece is Tower && piece.Color == Color && piece.QuantityMoviments == 0;
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] possibleMoviments = new bool[Board.Rows, Board.Columns];

            Position targetPosition = new Position(0, 0);

            targetPosition.SetPosition(Position.Row - 1, Position.Column);
            if(Board.ValidPosition(targetPosition) && CanMove(targetPosition))
                possibleMoviments[targetPosition.Row, targetPosition.Column] = true;


            targetPosition.SetPosition(Position.Row - 1, Position.Column + 1);
            if(Board.ValidPosition(targetPosition) && CanMove(targetPosition))
                possibleMoviments[targetPosition.Row, targetPosition.Column] = true;


            targetPosition.SetPosition(Position.Row, Position.Column + 1);
            if(Board.ValidPosition(targetPosition) && CanMove(targetPosition))
                possibleMoviments[targetPosition.Row, targetPosition.Column] = true;


            targetPosition.SetPosition(Position.Row + 1, Position.Column + 1);
            if(Board.ValidPosition(targetPosition) && CanMove(targetPosition))
                possibleMoviments[targetPosition.Row, targetPosition.Column] = true;

            targetPosition.SetPosition(Position.Row + 1, Position.Column);
            if(Board.ValidPosition(targetPosition) && CanMove(targetPosition))
                possibleMoviments[targetPosition.Row, targetPosition.Column] = true;


            targetPosition.SetPosition(Position.Row + 1, Position.Column - 1);
            if(Board.ValidPosition(targetPosition) && CanMove(targetPosition))
                possibleMoviments[targetPosition.Row, targetPosition.Column] = true;


            targetPosition.SetPosition(Position.Row, Position.Column - 1);
            if(Board.ValidPosition(targetPosition) && CanMove(targetPosition))
                possibleMoviments[targetPosition.Row, targetPosition.Column] = true;


            targetPosition.SetPosition(Position.Row - 1, Position.Column - 1);
            if(Board.ValidPosition(targetPosition) && CanMove(targetPosition))
                possibleMoviments[targetPosition.Row, targetPosition.Column] = true;


            if(QuantityMoviments == 0 && !Match.IsInXeque)
            {
                Position towerPositionInSmallRoque = new Position(Position.Row, Position.Column + 3);
                Position towerPositionInBigRoque = new Position(Position.Row, Position.Column - 4);

                if(TowerCanRoque(towerPositionInSmallRoque))
                {
                    Position positionBesideKing1 = new Position(Position.Row, Position.Column + 1);
                    Position positionBesideKing2 = new Position(Position.Row, Position.Column + 2);

                    if(Board.SinglePiece(positionBesideKing1) == null && Board.SinglePiece(positionBesideKing2) == null)
                    {
                        possibleMoviments[Position.Row, Position.Column + 2] = true;
                    }
                }


                if(TowerCanRoque(towerPositionInBigRoque))
                {
                    Position positionBesideKing1 = new Position(Position.Row, Position.Column - 1);
                    Position positionBesideKing2 = new Position(Position.Row, Position.Column - 2);
                    Position positionBesideKing3 = new Position(Position.Row, Position.Column - 3);

                    if(
                        Board.SinglePiece(positionBesideKing1) == null &&
                        Board.SinglePiece(positionBesideKing2) == null &&
                        Board.SinglePiece(positionBesideKing3) == null
                    )
                    {
                        possibleMoviments[Position.Row, Position.Column - 2] = true;
                    }
                }
            }

            return possibleMoviments;
        }
    }
}
