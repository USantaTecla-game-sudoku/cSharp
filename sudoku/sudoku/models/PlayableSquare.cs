using System;
using System.Drawing;

namespace usantatecla.sudoku.models
{
	public class PlayableSquare : Square
	{
		public PlayableSquare() : this(Number.EMPTY) { }

		public PlayableSquare(Number number) : base(number) { }

		public override bool CanAssign() => true;
		public override bool IsEmpty() => this.Number.Equals(Number.EMPTY);

		public void Assign(Number number){
			this.Number = number;
		}
	}
}