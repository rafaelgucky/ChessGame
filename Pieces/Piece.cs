using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.Utilities;
using ChessGame.Enums;
using ChessGame.BoardFiles;

namespace ChessGame.Pieces
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; set; }
        public string Symbol {  get; set; }


        public Piece(Position position, Color color,Board board, string symbol)
        {
			board.Positions[position.X, position.Y].Ocuped = true;
            Position = position;
            Color = color;
            Symbol = symbol;
        }
        public abstract List<Position> GetMove(Board board);

        public void Move(List<Position> listPositions, Position position, Board board)
        {
			foreach (Position positionTemp in listPositions)
			{
				if (positionTemp.Y == position.Y && positionTemp.X == position.X)
				{
					board.Positions[Position.X, Position.Y].Ocuped = false;
					board.Positions[position.X, position.Y].Ocuped = true;

					foreach (Position position1 in listPositions)
					{
						board.Positions[position1.X, position1.Y].IsPossiblePlace = false;
						board.Positions[position1.X, position1.Y].Killer = false;
					}

					board.Pieces[Position.X, Position.Y] = null;
					if(board.Pieces[position.X, position.Y] != null)
					{
						//Captured piece
					}
					board.Pieces[position.X, position.Y] = this;

					Position = position;
				}
			}
		}
    }
}
