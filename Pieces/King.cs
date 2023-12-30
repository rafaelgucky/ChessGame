using ChessGame.BoardFiles;
using ChessGame.Utilities;
using ChessGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Pieces
{
	class King : Piece
	{
		public King(Position position, Color color, Board board, string symbol) : base(position, color, board, symbol)
		{

		}
		public override List<Position> GetMove(Board board, bool onlyVerification = false)
		{
			int[] x = new int[8] {-1, -1, 0, 1, 1, 1, 0, -1};
			int[] y = new int[8] {0, 1, 1, 1, 0, -1, -1, -1 };

			List<Position> positions = new List<Position>();

			for(int i = 0; i < 8; i++)
			{
				if (Position.X + x[i] >= 0 && Position.X + x[i] <= 7 && Position.Y + x[i] >= 0 && Position.Y + x[i] <= 7)
				{
					if (!board.Positions[Position.X + x[i], Position.Y + y[i]].Ocuped) // 1
					{
						positions.Add(new Position(Position.X + x[i], Position.Y + y[i]));
						if (!onlyVerification) { board.Positions[Position.X + x[i], Position.Y + y[i]].IsPossiblePlace = true; }
					}
					else
					{
						if (board.Pieces[Position.X + x[i], Position.Y + y[i]].Color != Color)
						{
							positions.Add(new Position(Position.X + x[i], Position.Y + y[i]));
							if (onlyVerification) { board.Positions[Position.X + x[i], Position.Y + y[i]].Killer = true; }
						}
					}
				}
			}

			
			return positions;
		}
	}
}
