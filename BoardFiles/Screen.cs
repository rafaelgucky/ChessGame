using ChessGame.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.BoardFiles
{
	static class Screen
	{
		public static void Print(Board board)
		{
			foreach(Piece piece in board.Pieces)
			{

			}
			for (int i = 0; i < board.Width; i++)
			{
				for(int y = 0; y < board.Height; y++)
				{
					if (board.Pieces[i, y] == null)
					{
						Console.Write("|-|");
					}
					else
					{
						Console.Write("|P|");
					}
				}
				Console.WriteLine();
			}
		}
	}
}
