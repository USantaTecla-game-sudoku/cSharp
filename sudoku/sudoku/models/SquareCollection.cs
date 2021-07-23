using System;
using usantatecla.utils;

namespace usantatecla.sudoku.models
{
	public class SquareCollection {

		private Square[] _squares;

        public SquareCollection(Square[] squares)
        {
            this._squares = squares;
        }

        public bool CanAssign(Number number) {
            foreach(Square square in this._squares)
            {
                if (square.ToString() == number.GetDescription()) {
                    return false;
                }
            }
            return true;
        }

        public bool IsNotCompleted() => !IsCompleted();

        public bool IsCompleted()
        {
            foreach(Square square in this._squares)
            {
                if (square.IsEmpty()) {
                    return false;
                }
            }            
            return true;
        }
    }
}