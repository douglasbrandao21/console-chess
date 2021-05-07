namespace Entities
{
    class King : Piece
    {
        public King(Board board, Color color) : base(board, color) {}

        public override string ToString()
        {
            return "R";
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] possibleMoviments = new bool[Board.Rows, Board.Columns];

            Position targetPosition = new Position(0, 0);

            targetPosition.SetPosition(Position.Row - 1, Position.Column);

            possibleMoviments[targetPosition.Row, targetPosition.Column] = Board.ValidPosition(targetPosition) && CanMove(targetPosition);


            targetPosition.SetPosition(Position.Row -1, Position.Column + 1);

            possibleMoviments[targetPosition.Row, targetPosition.Column] = Board.ValidPosition(targetPosition) && CanMove(targetPosition);


            targetPosition.SetPosition(Position.Row, Position.Column + 1);

            possibleMoviments[targetPosition.Row, targetPosition.Column] = Board.ValidPosition(targetPosition) && CanMove(targetPosition);

            
            targetPosition.SetPosition(Position.Row+1, Position.Column+1);

            possibleMoviments[targetPosition.Row, targetPosition.Column] = Board.ValidPosition(targetPosition) && CanMove(targetPosition);

            
            targetPosition.SetPosition(Position.Row+1, Position.Column);

            possibleMoviments[targetPosition.Row, targetPosition.Column] = Board.ValidPosition(targetPosition) && CanMove(targetPosition);

            
            targetPosition.SetPosition(Position.Row+1, Position.Column-1);

            possibleMoviments[targetPosition.Row, targetPosition.Column] = Board.ValidPosition(targetPosition) && CanMove(targetPosition);


            targetPosition.SetPosition(Position.Row, Position.Column-1);

            possibleMoviments[targetPosition.Row, targetPosition.Column] = Board.ValidPosition(targetPosition) && CanMove(targetPosition);


            targetPosition.SetPosition(Position.Row-1, Position.Column-1);

            possibleMoviments[targetPosition.Row, targetPosition.Column] = Board.ValidPosition(targetPosition) && CanMove(targetPosition);

            return possibleMoviments;
        }
    }
}
