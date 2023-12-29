using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.Utilities;
using ChessGame.Enums;
using ChessGame.BoardFiles;

namespace ChessGame.Pieces
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; set; }
        public string Symbol {  get; set; }


        public Piece(Position position, Color color, string symbol)
        {
            position.Ocuped = true;
            Position = position;
            Color = color;
            Symbol = symbol;
        }
        public abstract List<Position> GetMove(Board board);
        public abstract void Move(Position position);
    }
}
