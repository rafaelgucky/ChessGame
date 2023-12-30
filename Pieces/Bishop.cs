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
	class Bishop : Piece
	{
		public Bishop(Position position, Color color, Board board, string symbol) : base(position, color, board, symbol)
		{
		}
		public override List<Position> GetMove(Board board, bool onlyVerication = false)
		{
			List<Position> positions = new List<Position>();
	
			int x = 1;

			while (Position.X + x <= 7 && Position.Y + x <= 7 )
			{
				if (!board.Positions[Position.X + x, Position.Y + x].Ocuped)
				{
					positions.Add(new Position(Position.X + x, Position.Y + x));
					if (!onlyVerication) { board.Positions[Position.X + x, Position.Y + x].IsPossiblePlace = true; }
				}
				else
				{
					if (board.Pieces[Position.X + x, Position.Y + x].Color != Color)
					{
						positions.Add(new Position(Position.X + x, Position.Y + x));
						if (!onlyVerication) { board.Positions[Position.X + x, Position.Y + x].Killer = true; }
					}
					break;
				}
				x++;
			}

			x = 1;

			while (Position.X - x >= 0 && Position.Y - x >= 0)
			{
				if (!board.Positions[Position.X - x, Position.Y - x].Ocuped)
				{
					positions.Add(new Position(Position.X - x, Position.Y - x));
					if (!onlyVerication) { board.Positions[Position.X - x, Position.Y - x].IsPossiblePlace = true; }
				}
				else
				{
					if (board.Pieces[Position.X - x, Position.Y - x].Color != Color)
					{
						positions.Add(new Position(Position.X - x, Position.Y - x));
						if (!onlyVerication) { board.Positions[Position.X - x, Position.Y - x].Killer = true; }
					}
					break;
				}
				x++;
			}

			x = 1;

			while (Position.X - x >= 0 && Position.Y + x <= 7)
			{
				if (!board.Positions[Position.X - x, Position.Y + x].Ocuped)
				{
					positions.Add(new Position(Position.X - x, Position.Y + x));
					if (!onlyVerication) { board.Positions[Position.X - x, Position.Y + x].IsPossiblePlace = true; }	
				}
				else
				{
					if (board.Pieces[Position.X - x, Position.Y + x].Color != Color)
					{
						positions.Add(new Position(Position.X - x, Position.Y + x));
						if (!onlyVerication) { board.Positions[Position.X - x, Position.Y + x].Killer = true; }
					}
					break;
				}
				x++;
			}

			x = 1;

			while (Position.X + x <= 7 && Position.Y - x >= 0)
			{
				if (!board.Positions[Position.X + x, Position.Y - x].Ocuped)
				{
					positions.Add(new Position(Position.X + x, Position.Y - x));
					if (!onlyVerication) { board.Positions[Position.X + x, Position.Y - x].IsPossiblePlace = true; }
				}
				else
				{
					if (board.Pieces[Position.X + x, Position.Y - x].Color != Color)
					{
						positions.Add(new Position(Position.X + x, Position.Y - x));
						if(!onlyVerication) { board.Positions[Position.X + x, Position.Y - x].Killer = true; }
					}
					break;
				}
				x++;
			}

			return positions;
		}
	}
}
