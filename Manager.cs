using ChessGame.BoardFiles;
using ChessGame.Pieces;
using ChessGame.Utilities;
using ChessGame.Enums;
using ChessGame.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    class Manager
    {
        public bool Ended { get; set; }
		public Color Color { get; set; }

		private King BlackKing;
		private King WhiteKing;
		private Board Board;
		

		public Manager(Board board, Color color)
        {
			Board = board;
			Color = color;

			for (int i = 0; i < 8; i++)
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

			BlackKing = new King(new Position(0, 3), Color.Black, board, "K");

			board.AddPiece(BlackKing);
			board.AddPiece(new Queen(new Position(0, 4), Color.Black, board, "Q"));

			WhiteKing = new King(new Position(7, 3), Color.White, board, "K");

			board.AddPiece(WhiteKing);
			board.AddPiece(new Queen(new Position(7, 4), Color.White, board, "Q"));
		}

		public King XequeMateVerification()
		{
			List<Position> kingMoves;
			List<Position> pieceMoves;

			King king = WhiteKing;

			kingMoves = king.GetMove(Board, true);

			for (int i = 0; i < 2; i++)
			{
				int count = kingMoves.Count;
				foreach (Piece piece in Board.Pieces)
				{	
					if (piece != null)
					{
						if (piece.Color != king.Color)
						{
							pieceMoves = piece.GetMove(Board, true);

							foreach(Position position in pieceMoves)
							{
								foreach(Position position1 in kingMoves)
								{
									if(position.X == position1.X && position.Y == position1.Y)
									{
										count--;
									}
								}
								if(position.X == king.Position.X && position.Y == king.Position.Y)
								{
									//CHECK
									//count--;
								}
							}
						}
					}	
				}
				//Console.WriteLine("Count: " + count + ", KingMoves: " + kingMoves.Count);
				if(count < kingMoves.Count && count <= 0)
				{
					Ended = true;

					return king;
				}

				king = BlackKing;
				kingMoves = king.GetMove(Board, true);
			}

			return null;
		}

		public void RoundVerification(Piece piece)
		{
			if(piece.Color != Color)
			{
				throw new GameException("The color is wrong!");
			}
			if (Color == Color.White) { Color = Color.Black; }
			else { Color = Color.White; }
		}

		public List<Piece> GetTotalCapturedPieces(Color color)
		{
			List<Piece> tempList = new List<Piece>();
			
			foreach (Piece piece in Board.Pieces)
			{
				if (piece != null)
				{
					if (piece.Color == color)
					{
						tempList.AddRange(piece.GetCapturesPieces());
					}
				}
			}
			return tempList;
		}
	}
}
