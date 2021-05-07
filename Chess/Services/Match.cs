using Entities;
using Exceptions;
using System;
using System.Collections.Generic;

namespace Services
{
    class Match
    {
        public Board Board { get; private set; }
        public int Shift { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; set; }

        private HashSet<Piece> PiecesInGame;
        private HashSet<Piece> CapturedPieces;
        public bool IsInXeque { get; private set; }

        public Match()
        {
            Board = new Board();
            Shift = 1;
            CurrentPlayer = Color.White;

            PiecesInGame = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();

            IsInXeque = false;

            PutPieces();
        }

        public bool IsInXequeMate(Color color)
        {
            if(!IsKingInXequeByColor(color)) return false;

            foreach(Piece piece in InGamePiecesByColor(color))
            {
                bool[,] possibleMoviments = piece.PossibleMoviments();

                for(int row = 0; row < Board.Rows; row++)
                {
                    for(int column = 0; column < Board.Columns; column++)
                    {
                        if(possibleMoviments[row, column])
                        {
                            Position origin = piece.Position;
                            Position target = new Position(row, column);

                            Piece capturedPiece = Moviment(origin, target);

                            bool isInXeque = IsKingInXequeByColor(color);

                            UndoMoviment(origin, target, capturedPiece);

                            if(!isInXeque) return false;
                        }
                    }
                }
            }

            return true;
        }

        public Piece Moviment(Position origin, Position target)
        {
            Piece piece = Board.RemovePiece(origin);

            piece.IncreaseMoviments();

            Piece capturedPiece = Board.RemovePiece(target);

            Board.PutPiece(piece, target);

            if(capturedPiece != null)
                CapturedPieces.Add(capturedPiece);

            return capturedPiece;
        }

        public void UndoMoviment(Position origin, Position target, Piece capturedPiece)
        {
            Piece piece = Board.RemovePiece(target);

            piece.DecreaseMoviments();

            if(capturedPiece != null)
            {
                Board.PutPiece(capturedPiece, target);

                CapturedPieces.Remove(capturedPiece);
            }
            Board.PutPiece(piece, origin);
        }

        public HashSet<Piece> CapturedPiecesByColor(Color color)
        {
            HashSet<Piece> capturedPieces = new HashSet<Piece>();

            foreach(Piece piece in CapturedPieces)
                if(piece.Color == color)
                    capturedPieces.Add(piece);

            return capturedPieces;
        }

        public HashSet<Piece> InGamePiecesByColor(Color color)
        {
            HashSet<Piece> piecesInGame = new HashSet<Piece>();

            foreach(Piece piece in PiecesInGame)
                if(piece.Color == color)
                    piecesInGame.Add(piece);

            piecesInGame.ExceptWith(CapturedPiecesByColor(color));

            return piecesInGame;
        }

        private Color GetAdversary(Color color)
        {
            if(color == Color.Black) return Color.White;

            return Color.Black;
        }

        private Piece GetKingByColor(Color color)
        {
            foreach(Piece piece in InGamePiecesByColor(color))
            {
                if(piece is King) return piece;
            }

            return null;
        }

        private bool IsKingInXequeByColor(Color color)
        {
            Piece king = GetKingByColor(color);

            if(king == null) throw new BoardException("WTF is going on?");

            foreach(Piece piece in InGamePiecesByColor(GetAdversary(color)))
            {
                bool[,] possibleMoviments = piece.PossibleMoviments();

                if(possibleMoviments[king.Position.Row, king.Position.Column]) return true;
            }

            return false;
        }

        public void Play(Position origin, Position target)
        {
            Piece capturedPiece = Moviment(origin, target);

            if(IsKingInXequeByColor(CurrentPlayer))
            {
                UndoMoviment(origin, target, capturedPiece);

                throw new BoardException("You cannot put yourself in xeque!");
            }

            if(IsKingInXequeByColor(GetAdversary(CurrentPlayer)))
                IsInXeque = true;
            else
                IsInXeque = false;


            if(IsInXequeMate(GetAdversary(CurrentPlayer))) {
                Finished = true;
            }
            else
            {
                Shift++;

                ChangePlayer();
            }
        }

        private void ChangePlayer()
        {
            if(CurrentPlayer == Color.White) CurrentPlayer = Color.Black;
            else CurrentPlayer = Color.White;
        }

        public void ValidateOriginPosition(Position origin)
        {

            if(Board.SinglePiece(origin) == null)
                throw new BoardException("There's no piece in this position");

            if(CurrentPlayer != Board.SinglePiece(origin).Color)
                throw new BoardException("Wait your turn");

            if(!Board.SinglePiece(origin).ExistsPossibleMoviments())
                throw new BoardException("There's no possible moviments for this piece");
        }

        public void ValidateTargetPosition(Position origin, Position target)
        {
            if(!Board.SinglePiece(origin).CanMoveTo(target))
                throw new BoardException("Cannot move to that target position");
        }

        public void PutNewPiece(char column, int row, Piece piece)
        {
            Board.PutPiece(piece, new Coordinate(column, row).ToPosition());

            PiecesInGame.Add(piece);
        }

        private void PutPieces()
        {
            //PutNewPiece('c', 1, new Tower(Board, Color.White));
            //PutNewPiece('c', 2, new Tower(Board, Color.White));

            //PutNewPiece('d', 1, new King(Board, Color.White));
            //PutNewPiece('d', 2, new Tower(Board, Color.White));

            //PutNewPiece('e', 1, new Tower(Board, Color.White));
            //PutNewPiece('e', 2, new Tower(Board, Color.White));

            //PutNewPiece('c', 7, new Tower(Board, Color.Black));
            //PutNewPiece('c', 8, new Tower(Board, Color.Black));

            //PutNewPiece('d', 7, new Tower(Board, Color.Black));
            //PutNewPiece('d', 8, new King(Board, Color.Black));

            //PutNewPiece('e', 7, new Tower(Board, Color.Black));
            //PutNewPiece('e', 8, new Tower(Board, Color.Black));

            PutNewPiece('c', 1, new Tower(Board, Color.White));
            PutNewPiece('d', 1, new King(Board, Color.White));
            PutNewPiece('h', 7, new Tower(Board, Color.White));

            PutNewPiece('a', 8, new King(Board, Color.Black));
            PutNewPiece('b', 8, new Tower(Board, Color.Black));
        }
    }
}
