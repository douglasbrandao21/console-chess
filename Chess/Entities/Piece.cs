namespace Entities
{
    class Piece
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
    }
}
