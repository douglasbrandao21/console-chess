namespace Entities
{
    class Horse : Piece
    {
        public Horse(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "C";
        }

        public override bool[,] PossibleMoviments()
        {
            bool[,] possibleMoviments = new bool[Board.Rows, Board.Columns];

            Position targetPosition = new Position(0, 0);


            targetPosition.SetPosition(Position.Row - 1, Position.Column - 2);
            if(Board.ValidPosition(targetPosition) && CanMove(targetPosition))
                possibleMoviments[targetPosition.Row, targetPosition.Column] = true;


            targetPosition.SetPosition(Position.Row - 1, Position.Column + 2);
            if(Board.ValidPosition(targetPosition) && CanMove(targetPosition))
                possibleMoviments[targetPosition.Row, targetPosition.Column] = true;


            targetPosition.SetPosition(Position.Row + 1, Position.Column + 2);
            if(Board.ValidPosition(targetPosition) && CanMove(targetPosition))
                possibleMoviments[targetPosition.Row, targetPosition.Column] = true;

            targetPosition.SetPosition(Position.Row + 1, Position.Column - 2);
            if(Board.ValidPosition(targetPosition) && CanMove(targetPosition))
                possibleMoviments[targetPosition.Row, targetPosition.Column] = true;


            targetPosition.SetPosition(Position.Row - 2, Position.Column - 1);
            if(Board.ValidPosition(targetPosition) && CanMove(targetPosition))
                possibleMoviments[targetPosition.Row, targetPosition.Column] = true;


            targetPosition.SetPosition(Position.Row - 2, Position.Column + 1);
            if(Board.ValidPosition(targetPosition) && CanMove(targetPosition))
                possibleMoviments[targetPosition.Row, targetPosition.Column] = true;

            targetPosition.SetPosition(Position.Row + 2, Position.Column + 1);
            if(Board.ValidPosition(targetPosition) && CanMove(targetPosition))
                possibleMoviments[targetPosition.Row, targetPosition.Column] = true;


            targetPosition.SetPosition(Position.Row + 2, Position.Column - 1);
            if(Board.ValidPosition(targetPosition) && CanMove(targetPosition))
                possibleMoviments[targetPosition.Row, targetPosition.Column] = true;


            return possibleMoviments;
        }
    }
}
