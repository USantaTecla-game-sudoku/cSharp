using System;

namespace usantatecla.sudoku.models
{
	public class Coordinate {

        public int Row { get; set; }
        public int Column { get; set; }

        public Coordinate(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public override string ToString()
        {
            return "(" + this.Column + "," + this.Row + ")";
        }
	}
}
