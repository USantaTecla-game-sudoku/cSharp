using System;
using usantatecla.sudoku.models;

namespace usantatecla.sudoku.views.console
{
    public class RowView {

        private int _rowNumber;
        private Square[] _squares;
        private int _boxDimension;
        public RowView(int rowNumber, Square[] squares) {
            this._rowNumber = rowNumber;
            this._squares = squares;
            this._boxDimension = (int)Math.Sqrt(squares.Length);
        }

        public void Display(){
            Character.WHITE_SPACE.Display();
            this._rowNumber.ToNumber().Display();
            Character.WHITE_SPACE.Display();
            Character.DOUBLE_VERTICAL_BAR.Display();
            for(int i = 0; i < this._boxDimension ; i++){
                DisplayBox(i);
            }
            utils.ColorConsole.Instance().WriteLine();
        }

        private void DisplayBox(int boxValue){
            int columnNumber = boxValue * this._boxDimension;
            DisplaySquare(_squares[columnNumber++]);
            Character.SIMPLE_VERTICAL_BAR.Display();
            DisplaySquare(_squares[columnNumber++]);
            Character.SIMPLE_VERTICAL_BAR.Display();
            DisplaySquare(_squares[columnNumber++]);
            Character.DOUBLE_VERTICAL_BAR.Display();
        }

        private void DisplaySquare(Square square){
            Character.WHITE_SPACE.Display();
            new SquareView(square).Display();
            Character.WHITE_SPACE.Display();
        }

        public bool HaveToCloseTheBox(int i){
            return i % this._boxDimension == (this._boxDimension-1);
        }
    }
}
