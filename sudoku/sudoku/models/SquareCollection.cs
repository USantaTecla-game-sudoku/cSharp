using System;
using usantatecla.utils;

namespace usantatecla.sudoku.models
{
	public class SquareCollection {

		private readonly Square[] _squares;

        public SquareCollection(Square[] squares)
        {
            this._squares = squares;
        }

        public bool CanAssign(Number number)
        {
            if (number == Number.EMPTY) 
            {
                return true;
            } 

            foreach (Square square in this._squares)
            {
                if (square.HasNumber(number))
                {
                    return false;
                }
            }

            return true;
        }
    }
}