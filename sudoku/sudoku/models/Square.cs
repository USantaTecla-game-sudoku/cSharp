using System;
using usantatecla.utils;

namespace usantatecla.sudoku.models
{
	public abstract class Square {

        public Number Number { get; protected set; }

        protected Square(Number number)
        {
            this.Number = number;
        }
    
        public bool HasNumber(Number number) => this.Number == number;
        public abstract bool CanAssign();
        public abstract bool IsEmpty();
        public abstract ConsoleColor GetColor();
	}

}
