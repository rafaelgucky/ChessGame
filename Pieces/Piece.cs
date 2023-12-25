using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.Utilities;
using ChessGame.Enums;

namespace ChessGame.Pieces
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; set; }


        public Piece(Position position, Color color)
        {
            Position = position;
            Color = color;
        }
        //public abstract  GetMove()
    }
}
