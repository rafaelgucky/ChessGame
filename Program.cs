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

					Screen.PrintCapturedPieces(listPieceWhite, listPieceBlack);

					listPieceWhite.Clear();
					listPieceBlack.Clear();

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

					listPieceWhite = manager.GetTotalCapturedPieces(Color.White);
					listPieceBlack = manager.GetTotalCapturedPieces(Color.Black);

					king = manager.XequeMateVerification();
				}

				Screen.Print(board);

				Screen.Victory(king);
			}
			catch(GameException e)
			{
				Console.WriteLine(e.Message);
			}

		}
	}
}