using System;
using usantatecla.sudoku.models;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console
{
    public class RowView {

        private readonly int _rowNumber;
        private readonly Square[] _squares;
        private readonly int _boxDimension;
        private readonly ColorConsole _colorConsole;

        public RowView(int rowNumber, Square[] squares) {
            this._rowNumber = rowNumber;
            this._squares = squares;
            this._boxDimension = (int)Math.Sqrt(squares.Length);
            this._colorConsole = ColorConsole.Instance();
        }

        public void Display(){

            ColorConsole.Instance().Write(Character.WHITE_SPACE);
            Display(this._rowNumber);
            ColorConsole.Instance().Write(Character.WHITE_SPACE);

            ColorConsole.Instance().Write(Character.DOUBLE_VERTICAL);

            for (int i = 0; i < this._boxDimension; i++)
            {
                DisplayBoxRow(i);
            }

            ColorConsole.Instance().Write(Character.NEW_LINE);
        }

        private void DisplayBoxRow(int boxValue){
            int columnNumber = boxValue * this._boxDimension;
            Display(_squares[columnNumber++]);
            ColorConsole.Instance().Write(Character.SIMPLE_VERTICAL);
            Display(_squares[columnNumber++]);
            ColorConsole.Instance().Write(Character.SIMPLE_VERTICAL);
            Display(_squares[columnNumber++]);
            ColorConsole.Instance().Write(Character.DOUBLE_VERTICAL);
        }

        private void Display(Square square){
            ColorConsole.Instance().Write(Character.WHITE_SPACE);
            new SquareView(square).Display();
            ColorConsole.Instance().Write(Character.WHITE_SPACE);
        }

        private bool HaveToCloseTheBox(int i){
            return i % this._boxDimension == (this._boxDimension-1);
        }

        private void Display(int rowNumber) {
            _colorConsole.Write(this._rowNumber);
        }
    }
}
