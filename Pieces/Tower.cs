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
	class Tower : Piece
	{
		public Tower(Position position, Color color, Board board, string symbol) : base(position, color, board, symbol)
		{
		}
		public override List<Position> GetMove(Board board)
		{
			List<Position> positions = new List<Position>();

			int x = 1;

			while (Position.X + x <= 7)
			{
				if (!board.Positions[Position.X + x, Position.Y].Ocuped)
				{
					positions.Add(new Position(Position.X + x, Position.Y));
					board.Positions[Position.X + x, Position.Y].IsPossiblePlace = true;
				}
				else
				{
					if (board.Pieces[Position.X + x, Position.Y].Color != Color)
					{
						positions.Add(new Position(Position.X + x, Position.Y));
						board.Positions[Position.X + x, Position.Y].Killer = true;
					}
					break;
				}
				x++;
			}

			x = 1;

			while (Position.X - x >= 0)
			{
				if (!board.Positions[Position.X - x, Position.Y].Ocuped)
				{
					positions.Add(new Position(Position.X - x, Position.Y));
					board.Positions[Position.X - x, Position.Y].IsPossiblePlace = true;
				}
				else 
				{
					if(board.Pieces[Position.X - x, Position.Y].Color != Color)
					{
						positions.Add(new Position(Position.X - x, Position.Y));
						board.Positions[Position.X - x, Position.Y].Killer = true;
					}
					break; 
				}
				x++;
			}

			x = 1;

			while (Position.Y + x <= 7)
			{
				if (!board.Positions[Position.X, Position.Y + x].Ocuped)
				{
					positions.Add(new Position(Position.X, Position.Y + x));
					board.Positions[Position.X, Position.Y + x].IsPossiblePlace = true;
				}
				else
				{
					if (board.Pieces[Position.X, Position.Y + x].Color != Color)
					{
						positions.Add(new Position(Position.X, Position.Y + x));
						board.Positions[Position.X, Position.Y + x].Killer = true;
					}
					break;
				}
				x++;
			}

			x = 1;

			while (Position.Y - x >= 0)
			{
				if (!board.Positions[Position.X, Position.Y - x].Ocuped)
				{
					positions.Add(new Position(Position.X, Position.Y - x));
					board.Positions[Position.X, Position.Y - x].IsPossiblePlace = true;
				}
				else
				{
					if (board.Pieces[Position.X, Position.Y - x].Color != Color)
					{
						positions.Add(new Position(Position.X, Position.Y - x));
						board.Positions[Position.X, Position.Y - x].Killer = true;
					}
					break;
				}
				x++;
			}

			return positions;
		}
	}
}
