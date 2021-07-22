using System;
using System.Collections.Generic;

namespace usantatecla.sudoku.models
{
	public class Board {

		public static int SIZE = 9;

		private Square[][] _squares;

        public Board()
        {
			this._squares = new Square[SIZE][];
		}

		public void Load(string sudoku) {
			string[] rows = sudoku.Split(";");
			for(int i = 0 ; i < SIZE ; i++){
				int row = (SIZE) - (i + 1);
				this._squares[row] = GetRow(sudoku.Substring((i * SIZE), SIZE));
			}
		}

		private Square[] GetRow(string line){
			Square[] row = new Square[SIZE];
			for(int j = 0 ; j < line.Length ; j++ ){
				row[j] = GetSquare(line[j].ToNumber());
			}
			return row;
		}

		private Square GetSquare(Number number){
			if(Number.EMPTY.Equals(number)){
				return new PlayableSquare();
			}
			return new HintSquare(number);
		}

		public void Assign(Assignment assignment)
		{

		}

		public bool CanAssign(Assignment assignment)
		{
			return false;
		}

		public bool HasSudoku()
		{
			return false;
		}

		public Square[][] GetBoard() => this._squares;

		public SquareCollection GetRow(Assignment assignment) {
			return new SquareCollection(NullArrayOfSquares());
		}

		public SquareCollection GetColumn(Assignment assignment)
		{
			return new SquareCollection(NullArrayOfSquares());
		}

		public SquareCollection GetBox(Assignment assignment)
		{
			return new SquareCollection(NullArrayOfSquares());
		}

		private Square[] NullArrayOfSquares() {
			return new Square[1];
		}
	}
}
