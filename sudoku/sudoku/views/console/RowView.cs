using System;
using usantatecla.sudoku.models;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console
{
    public class RowView : ConsoleView {

        private readonly int _rowNumber;
        private readonly Square[] _squares;
        private readonly int _boxDimension;

        public RowView(int rowNumber, Square[] squares) {
            this._rowNumber = rowNumber;
            this._squares = squares;
            this._boxDimension = (int)Math.Sqrt(squares.Length);
        }

        public void Display(){
            base._colorConsole.Write(Character.WHITE_SPACE.ToString());
            Display(this._rowNumber);
            base._colorConsole.Write(Character.WHITE_SPACE.ToString());
            base._colorConsole.Write(Character.DOUBLE_VERTICAL.ToString());
            for (int i = 0; i < this._boxDimension; i++)
            {
                DisplayBoxRow(i);
            }
            base._colorConsole.Write(Character.NEW_LINE.ToString());
        }

        private void DisplayBoxRow(int boxValue){
            int columnNumber = boxValue * this._boxDimension;
            Display(_squares[columnNumber++]);
            base._colorConsole.Write(Character.SIMPLE_VERTICAL.ToString());
            Display(_squares[columnNumber++]);
            base._colorConsole.Write(Character.SIMPLE_VERTICAL.ToString());
            Display(_squares[columnNumber++]);
            base._colorConsole.Write(Character.DOUBLE_VERTICAL.ToString());
        }

        private void Display(Square square){
            base._colorConsole.Write(Character.WHITE_SPACE.ToString());
            new SquareView(square).Display();
            base._colorConsole.Write(Character.WHITE_SPACE.ToString());
        }

        private bool HaveToCloseTheBox(int i){
            return i % this._boxDimension == (this._boxDimension-1);
        }

        private void Display(int rowNumber) {
            _colorConsole.Write(this._rowNumber);
        }
    }
}
