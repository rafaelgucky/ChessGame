using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.Exceptions;
using ChessGame.Utilities;
using ChessGame.Enums;
using ChessGame.BoardFiles;

namespace ChessGame.Pieces
{
    abstract class Piece
    {
        public string Symbol {  get; set; }
		public int Moves { get; set; }
		public Position Position { get; set; }
        public Color Color { get; set; }
		public List<Piece> CapturedPieces { get; set; } = new List<Piece>();


        public Piece(Position position, Color color,Board board, string symbol)
        {
			board.Positions[position.X, position.Y].Ocuped = true;
            Position = position;
            Color = color;
            Symbol = symbol;
        }
        public abstract List<Position> GetMove(Board board, bool onlyVerification = false);

        public void Move(List<Position> listPositions, Position position, Board board)
        {
			bool moved = false;

			foreach (Position position2 in board.Positions)
			{
				position2.Killer = false;
				position2.IsPossiblePlace = false;
			}

			foreach (Position positionTemp in listPositions)
			{
				if (positionTemp.Y == position.Y && positionTemp.X == position.X)
				{
					Moves++;

					board.Positions[Position.X, Position.Y].Ocuped = false;
					board.Positions[position.X, position.Y].Ocuped = true;

					board.Pieces[Position.X, Position.Y] = null;
					if(board.Pieces[position.X, position.Y] != null)
					{
						CapturedPieces.Add(board.Pieces[position.X, position.Y]);
					}
					board.Pieces[position.X, position.Y] = this;

					Position = position;

					moved = true;
				}
			}
			if (!moved)
			{
				throw new GameException("Invalid position to move the selected piece!");
			}
		}
		public List<Piece> GetCapturesPieces()
		{
			List<Piece> pieces = new List<Piece>();

			foreach(Piece piece in CapturedPieces)
			{
				pieces.Add(piece);
			}
			return pieces;
		}
    }
}
