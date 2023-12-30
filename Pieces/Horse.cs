using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.Enums;
using ChessGame.Utilities;
using ChessGame.BoardFiles;

namespace ChessGame.Pieces
{
	class Horse : Piece
	{
		public Horse(Position position, Color color, Board board, string symbol) : base(position, color, board, symbol)
		{
		}

		public override List<Position> GetMove(Board board)
		{
			List<Position> positions = new List<Position>();

			int[] x = new int[8] {-2, -2, -1, 1, 2,  2,  1, -1};
			int[] y = new int[8] {-1,  1,  2, 2, 1, -1, -2, -2};

			for(int i = 0; i < 8; i++)
			{
				if (Position.X + x[i] <= 7 && Position.X + x[i] >= 0 && Position.Y + y[i] >= 0 && Position.Y + y[i] <= 7)
				{
					if (!board.Positions[Position.X + x[i], Position.Y + y[i]].Ocuped)
					{
						positions.Add(new Position(Position.X + x[i], Position.Y + y[i]));
						board.Positions[Position.X + x[i], Position.Y + y[i]].IsPossiblePlace = true;
					}
					else
					{
						if (board.Pieces[Position.X + x[i], Position.Y + y[i]].Color != Color)
						{
							positions.Add(new Position(Position.X + x[i], Position.Y + y[i]));
							board.Positions[Position.X + x[i], Position.Y + y[i]].Killer = true;
						}
					}
				}
				

			}

			return positions;
		}
	}
}
