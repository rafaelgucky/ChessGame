using System;
using System.Globalization;
using ChessGame.BoardFiles;
using ChessGame.Utilities;
using ChessGame.Pieces;
using ChessGame.Enums;
using ChessGame.Exceptions;

namespace ChessGame
{
	class Program
	{
		static void Main(string[] args)
		{
			Board board = new Board(8, 8);
			Manager manager = new Manager(board, Color.White);
			King king = null;

			List<Piece> listPieceWhite = new List<Piece>();
			List<Piece> listPieceBlack = new List<Piece>();
			try
			{
				while (!manager.Ended)
				{
					Screen.Print(board);

					if (listPieceWhite.Count > 0 || listPieceBlack.Count > 0)
					{
						Console.Write("White captured pieces: ");
						foreach (Piece piece in listPieceWhite)
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

					listPieceWhite = new List<Piece>();
					listPieceBlack = new List<Piece>();

					List<Position> positions;
					Console.WriteLine();

					Console.Write($"Select one piece to move [{manager.Color}]: ");

					Position pos = Position.Convert(Console.ReadLine());

					manager.RoundVerification(board.Pieces[pos.X, pos.Y]);

					positions = board.Pieces[pos.X, pos.Y].GetMove(board);

					Screen.Print(board);

					Console.Write("Move: ");

					board.Pieces[pos.X, pos.Y].Move(positions, Position.Convert(Console.ReadLine()), board);

					Console.WriteLine();

					foreach (Piece piece in board.Pieces)
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
					//Console.ReadLine();
				}

				Screen.Print(board);

				if (king.Color == Color.White) { Console.WriteLine("Victory of Black"); }
				else { Console.WriteLine("Victory of White"); }
			}
			catch(GameException e)
			{
				Console.WriteLine(e.Message);
			}

		}
	}
}