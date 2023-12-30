using System;
using System.Globalization;
using ChessGame.BoardFiles;
using ChessGame.Utilities;
using ChessGame.Pieces;
using ChessGame.Enums;

namespace ChessGame
{
	class Program
	{
		static void Main(string[] args)
		{
			Board board = new Board(8, 8);
			Manager manager = new Manager(board);
			King king = null;

			List<Piece> listPieceWhite;
			List<Piece> listPieceBlack;

			while(!manager.Ended)
			{
				listPieceWhite = new List<Piece>();
				listPieceBlack = new List<Piece>();

				Screen.Print(board);

				if(listPieceWhite.Count > 0 || listPieceBlack.Count > 0)
				{
					Console.Write("White captured pieces: ");
					foreach(Piece piece in listPieceWhite)
					{
						Console.Write(piece.Symbol + " ");
					}
					Console.WriteLine();
					Console.Write("Black captured pieces: ");
					foreach (Piece piece in listPieceBlack)
					{
						Console.Write(piece.Symbol + " ");
					}
				}

				List<Position> positions;
				Console.WriteLine();
				Console.Write("Select one piece to move: ");

				Position pos = Position.Convert(Console.ReadLine());

				positions = board.Pieces[pos.X, pos.Y].GetMove(board);

				Screen.Print(board);

				Console.Write("Move: ");

				board.Pieces[pos.X, pos.Y].Move(positions, Position.Convert(Console.ReadLine()), board);

				Console.WriteLine();

				foreach(Piece piece in board.Pieces)
				{
					if (piece != null)
					{ 
						if (piece.Color == Color.White)
						{
							listPieceWhite.AddRange(piece.GetCapturesPieces());
						}
						else
						{
							listPieceBlack.AddRange(piece.GetCapturesPieces());
						}
					}
				}

				king = manager.XequeMateVerification();
				Console.ReadLine();
			}

			Screen.Print(board);

			if(king.Color == Color.White) { Console.WriteLine("Victory of White"); }
			else { Console.WriteLine("Victory of Black"); }

		}
	}
}