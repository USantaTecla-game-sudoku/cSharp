using System;
using System.Collections.Generic;
using usantatecla.utils;

namespace usantatecla.sudoku.models
{
	public class Board {

		public static int SIZE = 9;
		public static int SIZE_BOX = SIZE / 3;
		public static string LOAD_EMPTY_SQUARE = ".";

		private Square[][] _squares;

        public Board()
        {
			this._squares = new Square[SIZE][];
			for (int i=0; i<SIZE; i++){
				_squares[i] = new Square[SIZE];
			}
		}

		public virtual void Load(string sudoku) {
			for (int i=0; i<SIZE; i++){
				for (int j=0; j<SIZE; j++){
					int position = j + i*SIZE;
					string value = sudoku.Substring(position, 1);
					if (value == LOAD_EMPTY_SQUARE) {
						_squares[SIZE-i-1][j] = new PlayableSquare();
					}
					else {
						_squares[SIZE-i-1][j] = new HintSquare(EnumExtension.GetValueFromDescription<Number>(value));
					}
				}
			}
		}

		public virtual void Assign(Assignment assignment)
		{
			PlayableSquare playableSquare = new PlayableSquare();
			playableSquare.Assign(assignment.Number);
			_squares[assignment.Coordinate.Row][assignment.Coordinate.Column] = playableSquare;
		}

		public virtual bool CanAssign(Assignment assignment)
		{
			SquareCollection SquareCollectionRow = this.GetRow(assignment);
			SquareCollection SquareCollectionColum = this.GetColumn(assignment);
			SquareCollection SquareCollectionBox = this.GetBox(assignment);
			return  SquareCollectionRow.CanAssign(assignment.Number) &&
					SquareCollectionColum.CanAssign(assignment.Number) &&
					SquareCollectionBox.CanAssign(assignment.Number) &&
					this._squares[assignment.Coordinate.Row-1][assignment.Coordinate.Column-1].CanAssign();
		}

		private SquareCollection GetRow(Assignment assignment) {
			return 	new SquareCollection(this._squares[assignment.Coordinate.Row-1]);
		}

		private SquareCollection GetColumn(Assignment assignment)
		{
			Square[] squaresColum = new Square[SIZE];
			for (int i=0; i<SIZE; i++)	{
				squaresColum[i] = this._squares[i][assignment.Coordinate.Column-1];
			}
			return 	new SquareCollection(squaresColum);
		}

		private SquareCollection GetBox(Assignment assignment)
		{
			Square[] squaresBox = new Square[SIZE];
			int initIndexRow = SIZE_BOX * ((assignment.Coordinate.Row-1) / SIZE_BOX);
			int initIndexColumn = SIZE_BOX * ((assignment.Coordinate.Column-1) / SIZE_BOX);
			int index = 0;
			for (int i=initIndexRow; i<initIndexRow+SIZE_BOX; i++)	{
				for (int j=initIndexColumn; j<initIndexColumn+SIZE_BOX; j++) {
					squaresBox[index] = this._squares[i][j];
					index++;
				}
			}
			return 	new SquareCollection(squaresBox);
		}

		public virtual Square[][] GetBoard() => this._squares;

		public virtual bool HasSudoku()
		{
			for (int i=0; i<SIZE; i++)	{
				for (int j=0; j<SIZE; j++)	{
					if (this._squares[i][j].IsEmpty()) {
						return false;
					}
				}
			}
			return true;
		}

	}

}
