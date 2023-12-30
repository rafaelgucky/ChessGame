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

			for(int i = 0; i < 8; i++)
			{
				board.AddPiece(new Pawn(new Position(1, i), Color.Black, board, "P"));
				board.AddPiece(new Pawn(new Position(6, i), Color.White, board, "P"));

			}
			board.AddPiece(new Bishop(new Position(0, 2), Color.Black, board, "B"));
			board.AddPiece(new Bishop(new Position(0, 5), Color.Black, board, "B"));

			board.AddPiece(new Bishop(new Position(7, 2), Color.White, board, "B"));
			board.AddPiece(new Bishop(new Position(7, 5), Color.White, board, "B"));

			board.AddPiece(new Tower(new Position(0, 0), Color.Black, board, "T"));
			board.AddPiece(new Tower(new Position(0, 7), Color.Black, board, "T"));

			board.AddPiece(new Tower(new Position(7, 0), Color.White, board, "T"));
			board.AddPiece(new Tower(new Position(7, 7), Color.White, board, "T"));

			board.AddPiece(new Horse(new Position(0, 1), Color.Black, board, "C"));
			board.AddPiece(new Horse(new Position(0, 6), Color.Black, board, "C"));

			board.AddPiece(new Horse(new Position(7, 1), Color.White, board, "C"));
			board.AddPiece(new Horse(new Position(7, 6), Color.White, board, "C"));


			int temp = 0;

			while(temp < 5)
			{

				Screen.Print(board);

				List<Position> positions;

				Console.Write("Select one piece to move: ");

				Position pos = Position.Convert(Console.ReadLine());

				positions = board.Pieces[pos.X, pos.Y].GetMove(board);

				Screen.Print(board);

				Console.Write("Move: ");

				board.Pieces[pos.X, pos.Y].Move(positions, Position.Convert(Console.ReadLine()), board);

				Console.WriteLine();

				temp++;
			}

		}
	}
}