using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.Pieces;
using ChessGame.Utilities;
using ChessGame.Enums;

namespace ChessGame.BoardFiles
{
	class Board
	{
		public int Width {  get; set; }
		public int Height { get; set; }
		public Piece[,] Pieces { get; set; }

		public Board(int width, int height)
		{
			Width = width;
			Height = height;
			Pieces = new Piece[Width, Height];
		}

		public void AddPiece(Piece piece)
		{
			Pieces[piece.Position.X, piece.Position.Y] = piece;
		}
		public void RemovePiece(Piece piece)
		{
			Pieces[piece.Position.X, piece.Position.Y] = null;
		}
		public List<Position> UsedPlaces()
		{
			List<Position> places = new List<Position>();

			foreach (Piece piece in Pieces)
			{
				places.Add(piece.Position);
			}
			return places;
		}
	}
}
