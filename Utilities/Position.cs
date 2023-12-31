﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Utilities
{
	class Position
	{
        public int X { get; set; }
        public int Y { get; set; }
        public bool Ocuped { get; set; }
        public bool IsPossiblePlace { get; set; } = false;
        public bool Killer { get; set; }

        public Position() { }
        public Position(int axeX, int axeY)
        {
            X = axeX;
            Y = axeY;
        }
		public Position(int axeX, int axeY, bool ocuped)
		{
			X = axeX;
			Y = axeY;
			Ocuped = ocuped;
		}

		public Position(int axeX, int axeY, bool ocuped, bool isPossiblePlace)
		{
			X = axeX;
			Y = axeY;
			Ocuped = ocuped;
            IsPossiblePlace = isPossiblePlace;
		}

		public static Position Convert(string entry)
        {
            string[] dic = new string[8] {"a", "b", "c", "d", "e", "f", "g", "h"};

            string result = entry.ToLower().Trim();

            int axeX = int.Parse(result[0].ToString());
            int axeY = Array.IndexOf(dic, result[1].ToString());

            return new Position(axeX, axeY);

           
        }

        /*
         0  1  2  3  4  5  6  7

         0  1  2  3  4  5  6  7   0
         8  9 10 11 12 13 14 15   1
        16 17 18 19 20 21 22 23   2
        24 25 26 27 28 29 30 31   3
        32 33 34 35 36 37 38 39   4
        40 41 42 43 44 45 46 47   5
        48 49 50 51 52 53 54 55   6
        56 57 58 59 60 61 62 63   7

         */
	}
}
