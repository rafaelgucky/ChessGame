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
        public Pawn(Position position, Color color, string symbol) : base(position, color, symbol)
		{
			
		}

		public override List<Position> GetMove(Board board)
		{
			List<Position> positions = new List<Position>();


			foreach(Position position in board.Positions)
			{
				if (!position.Ocuped)
				{
					if(Color == Color.White)
					{
						if(position.Y == Position.Y && position.X < Position.X && position.X >= Position.X - 2)
						{
							positions.Add(position);
						}
					}
					else
					{
						if (position.Y == Position.Y && position.X > Position.X && position.X <= Position.X + 2)
						{
							positions.Add(position);
						}
					}
				}

			}
			return positions;
		}
		public override void Move(Position position)
		{
			
		}
	}
}
