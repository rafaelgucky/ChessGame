﻿using ChessGame.Pieces;
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
			Console.Clear();
			for (int i = 0; i < board.Width; i++)
			{
				Console.Write(i + " ");
				for(int y = 0; y < board.Height; y++)
				{
					if (board.Positions[i, y].Killer)
					{
						Console.Write("|");
						Console.ForegroundColor = ConsoleColor.Red;
						Console.Write(board.Pieces[i, y].Symbol);
						Console.ForegroundColor = ConsoleColor.White;
						Console.Write("|");
					}
					else if (board.Positions[i, y].IsPossiblePlace)
					{
						Console.Write("|");
						Console.BackgroundColor = ConsoleColor.White;
						Console.Write(" ");
						Console.BackgroundColor = ConsoleColor.Black;
						Console.Write("|");
					}
					else if (board.Positions[i, y].Ocuped)
					{
						Console.Write("|");
						if(board.Pieces[i, y].Color == Enums.Color.Black)
						{
							Console.ForegroundColor = ConsoleColor.DarkYellow;
						}
						Console.Write(board.Pieces[i, y].Symbol);
						Console.ForegroundColor = ConsoleColor.White;
						Console.Write("|");
					}
					else
					{
						Console.Write("|-|");
					}
				}
				Console.WriteLine();
			}
			Console.WriteLine("   A  B  C  D  E  F  G  H");
		}
		public static void PrintCapturedPieces(List<Piece> listPieceWhite, List<Piece> listPieceBlack)
		{
			if (listPieceWhite.Count > 0 || listPieceBlack.Count > 0)
			{
				Console.Write("White's captured pieces: ");
				foreach (Piece piece in listPieceWhite)
				{
					Console.Write(piece.Symbol + " ");
				}
				Console.WriteLine();
				Console.Write("Black's captured pieces: ");
				foreach (Piece piece in listPieceBlack)
				{
					Console.Write(piece.Symbol + " ");
				}
			}
		}
		public static void Victory(Piece piece)
		{
			Console.WriteLine("Vistory of " + piece.Color);
		}
	}
}
