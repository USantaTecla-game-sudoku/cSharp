using System;

namespace usantatecla.sudoku.models
{
	public class HintSquare : Square
	{
		public HintSquare(Number number) : base(number) { }

		public override bool CanAssign() => false;
		public override bool IsEmpty() => false;
	}


}
