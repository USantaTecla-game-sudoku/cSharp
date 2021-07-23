using System;

namespace usantatecla.sudoku.models
{
	public class PlayableSquare : Square
	{
		public PlayableSquare() : base(Number.EMPTY) { }

		public PlayableSquare(Number number) : base(number) { }

		public override bool CanAssign() => true;
		public override bool IsEmpty() => Number.EMPTY.Equals(this.Number);
		public override ConsoleColor GetColor() => ConsoleColor.White;
		public void Assign(Number number){
			this.Number = number;
		}		
	}
}
