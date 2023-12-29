using System;
using System.Globalization;
using ChessGame.BoardFiles;
using ChessGame.Utilities;
using ChessGame.Pieces;
using ChessGame.Enums;

/*
Mostrar o tabuleiro completo
Escolha da cor [ preto/branco ]
Escolha de uma peça para mover - Movimentos possíveis [ Executar ]
Mostrar o tabuleiro completo
*/

namespace ChessGame
{
	class Program
	{
		static void Main(string[] args)
		{
			Board board = new Board(8, 8);

			Screen.Print(board);;

			for(int i = 0; i < 8; i++)
			{
				board.AddPiece(new Pawn(board.Positions[1, i], Color.White, "P"));
				board.AddPiece(new Pawn(board.Positions[6, i], Color.Black, "P"));
			}

			Pawn pawn = new Pawn(board.Positions[2, 4], Color.Black, "T");
			board.AddPiece(pawn);

			List<Position> positions = new List<Position>(pawn.GetMove(board));

			foreach (Position position in positions) 
			{
				Console.WriteLine(position.X + ", " + position.Y);
			}
			
			Console.WriteLine();


			Screen.Print(board);
		}
	}
}