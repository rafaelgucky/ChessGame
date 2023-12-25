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
			//Board deve ser abstract

			Board board = new Board(8, 8);

			Piece piece = new Piece(new Position(3, 3), Color.White);

			board.AddPiece(piece);

			board.AddPiece(new Piece(new Position(4, 4), Color.Black));

			Screen.Print(board);

			board.RemovePiece(piece);

			Console.WriteLine();


			Screen.Print(board);
		}
	}
}