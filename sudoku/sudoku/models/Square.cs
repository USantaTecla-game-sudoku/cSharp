using System;
using usantatecla.utils;

namespace usantatecla.sudoku.models
{
	public abstract class Square {

        protected Number Number;

        public Square(Number number)
        {
            this.Number = number;
        }

        public override string ToString()
        {
            return this.Number.GetDescription();
        }
        public abstract bool CanAssign();
        public abstract bool IsEmpty();
        public abstract ConsoleColor GetColor();
	}
}
