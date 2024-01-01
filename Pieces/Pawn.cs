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

			if(Color == Color.Black)
			{
				for(int i = 1; i <= quantityMoves; i++)
				{
					Position position;
					if(i == 1)
					{
						if (Position.Y + i <= 7 && Position.X + i <= 7)
						{
							position = board.Positions[Position.X + i, Position.Y + i];
							if (board.Pieces[Position.X + i, Position.Y + i] != null)
							{
								if (board.Pieces[Position.X + i, Position.Y + i].Color != Color)
								{
									if (!onlyVerication) 
									{
										positions.Add(position);
										position.Killer = true; 
									}
								}
							}
						}
						if (Position.Y - i >= 0 && Position.X + i <= 7)
						{
							position = board.Positions[Position.X + i, Position.Y - i];
							if (board.Pieces[Position.X + i, Position.Y - i] != null)
							{
								if (board.Pieces[Position.X + i, Position.Y - i].Color != Color)
								{
									if (!onlyVerication)
									{
										positions.Add(position);
										position.Killer = true;
									}
								}
							}
						}
					}
					if (Position.X + i <= 7)
					{
						position = board.Positions[Position.X + i, Position.Y];
						if (!position.Ocuped)
						{
							positions.Add(position);
							if (!onlyVerication) { position.IsPossiblePlace = true; }
						}
						else
						{
							positions.Add(position);
							if (!onlyVerication) { position.Killer = true; }
							break;
						}
					}
				}
			}
			else
			{
				for(int i = 1; i <= quantityMoves; i++)
				{
					Position position;

					if (i == 1)
					{
						if (Position.Y + i <= 7 && Position.X - i >= 0 )
						{
							position = board.Positions[Position.X - i, Position.Y + i];
							if (board.Pieces[Position.X - i, Position.Y + i] != null)
							{
								if (board.Pieces[Position.X - i, Position.Y + i].Color != Color)
								{
									if (!onlyVerication)
									{
										positions.Add(position);
										position.Killer = true;
									}
								}
							}
						}
						if (Position.Y - i >= 0 && Position.X - i >= 0)
						{
							position = board.Positions[Position.X - i, Position.Y - i];
							if (board.Pieces[Position.X - i, Position.Y - i] != null)
							{
								if (board.Pieces[Position.X - i, Position.Y - i].Color != Color)
								{
									if (!onlyVerication)
									{
										positions.Add(position);
										position.Killer = true;
									}
								}
							}
						}
					}

					if (Position.X - i >= 0)
					{
						position = board.Positions[Position.X - i, Position.Y];
						if (!position.Ocuped)
						{
							positions.Add(position);
							if (!onlyVerication) { position.IsPossiblePlace = true; }
						}
						else
						{
							positions.Add(position);
							if (!onlyVerication) { position.Killer = true; }
							break;
						}
					}
				}
			}
			return positions;
		}
	}
}
