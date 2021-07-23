using System;

namespace usantatecla.sudoku.models
{
	public class Assignment {

        public Coordinate Coordinate { get; set; }
        public Number Number { get; set; }

        public Assignment(Coordinate coordinate, Number number)
        {
            this.Coordinate = coordinate;
            this.Number = number;
        }

        public override string ToString()
        {
            return "Coordinate: " + this.Coordinate.ToString() + ", Number: " + this.Number;
        }

    }
}
