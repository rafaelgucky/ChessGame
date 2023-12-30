using ChessGame.BoardFiles;
using ChessGame.Enums;
using ChessGame.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Pieces
{
	class Pawn : Piece
	{
        public Pawn(Position position, Color color, Board board, string symbol) : base(position, color, board, symbol)
		{
		}

		public override List<Position> GetMove(Board board, bool onlyVerication = false)
		{
			int quantityMoves = 2;

			List<Position> positions = new List<Position>();

			if(Moves >= 1)
			{
				quantityMoves = 1;
			}

			foreach(Position position in board.Positions)
			{
				if (!position.Ocuped)
				{
					if(Color == Color.White)
					{
						if(position.Y == Position.Y && position.X < Position.X && position.X >= Position.X - quantityMoves)
						{
							positions.Add(position);
							if (!onlyVerication) { board.Positions[position.X, Position.Y].IsPossiblePlace = true; }
						}
					}
					else
					{
						if (position.Y == Position.Y && position.X > Position.X && position.X <= Position.X + quantityMoves)
						{
							positions.Add(position);
							if (!onlyVerication) { board.Positions[position.X, Position.Y].IsPossiblePlace = true; }
						}
					}
				}

			}
			return positions;
		}
	}
}
