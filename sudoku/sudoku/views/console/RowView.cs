using System;
using usantatecla.sudoku.models;
using usantatecla.utils;

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
            utils.ColorConsole.Instance().Write(Character.WHITE_SPACE.GetDescription());
            utils.ColorConsole.Instance().Write(this._rowNumber.ToString());
            utils.ColorConsole.Instance().Write(Character.WHITE_SPACE.GetDescription());
            utils.ColorConsole.Instance().Write(Character.DOUBLE_VERTICAL_BAR.GetDescription());
            for(int i = 0; i < this._boxDimension ; i++){
                DisplayBoxRow(i);
            }
            utils.ColorConsole.Instance().NewLine();
        }

        private void DisplayBoxRow(int boxValue){
            int columnNumber = boxValue * this._boxDimension;
            DisplaySquare(_squares[columnNumber++]);
            utils.ColorConsole.Instance().Write(Character.SIMPLE_VERTICAL_BAR.GetDescription());
            DisplaySquare(_squares[columnNumber++]);
            utils.ColorConsole.Instance().Write(Character.SIMPLE_VERTICAL_BAR.GetDescription());
            DisplaySquare(_squares[columnNumber++]);
            utils.ColorConsole.Instance().Write(Character.DOUBLE_VERTICAL_BAR.GetDescription());
        }

        private void DisplaySquare(Square square){
            utils.ColorConsole.Instance().Write(Character.WHITE_SPACE.GetDescription());
            new SquareView(square).Display();
            utils.ColorConsole.Instance().Write(Character.WHITE_SPACE.GetDescription());
        }

        public bool HaveToCloseTheBox(int i){
            return i % this._boxDimension == (this._boxDimension-1);
        }
    }
}
