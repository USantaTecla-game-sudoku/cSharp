using System;
using usantatecla.sudoku.models;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console
{
    public class RowView {

        private int _rowNumber;
        private Square[] _squares;
        private int _boxDimension;
        private ColorConsole _colorConsole;

        public RowView(int rowNumber, Square[] squares) {
            this._rowNumber = rowNumber;
            this._squares = squares;
            this._boxDimension = (int)Math.Sqrt(squares.Length);
            this._colorConsole = ColorConsole.Instance();
        }

        public void Display(){
            Character.WHITE_SPACE.ConsoleDisplay();
            Display(this._rowNumber);
            Character.WHITE_SPACE.ConsoleDisplay();
            Character.DOUBLE_VERTICAL.ConsoleDisplay();
            for (int i = 0; i < this._boxDimension; i++)
            {
                DisplayBoxRow(i);
            }
            Character.NEW_LINE.ConsoleDisplay();
        }

        private void DisplayBoxRow(int boxValue){
            int columnNumber = boxValue * this._boxDimension;
            Display(_squares[columnNumber++]);
            Character.SIMPLE_VERTICAL.ConsoleDisplay();
            Display(_squares[columnNumber++]);
            Character.SIMPLE_VERTICAL.ConsoleDisplay();
            Display(_squares[columnNumber++]);
            Character.DOUBLE_VERTICAL.ConsoleDisplay();
        }

        private void Display(Square square){
            Character.WHITE_SPACE.ConsoleDisplay();
            new SquareView(square).Display();
            Character.WHITE_SPACE.ConsoleDisplay();
        }

        public bool HaveToCloseTheBox(int i){
            return i % this._boxDimension == (this._boxDimension-1);
        }

        private void Display(int rowNumber) {
            _colorConsole.Write(this._rowNumber);
        }
    }
}
