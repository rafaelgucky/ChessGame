using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Exceptions
{
	class GameException : Exception
	{
		public GameException(string msg) : base(msg) { }
	}
}
