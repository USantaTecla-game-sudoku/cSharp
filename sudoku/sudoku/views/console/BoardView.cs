using System;
using usantatecla.sudoku.models;

namespace usantatecla.sudoku.views.console
{
    public class BoardView {

        private Square[][] _squares;
        private int _boxDimension;
        public BoardView(Square[][] squares) {
            this._squares = squares;
            this._boxDimension = (int)Math.Sqrt(squares.Length);
        }

        public void Display() {
            Line.HORIZONTAL_FIRST.Display();
            for(int i = this._squares.Length - 1 ; i >= 0 ; i--){
                new RowView(i+1, this._squares[i]).Display();
                if(HaveToCloseTheBoard(i)){
                    Line.HORIZONTAL_LAST.Display();
                }else if(HaveToCloseTheBox(i)){
                    Line.HORIZONTAL_DOUBLE.Display();
                }else{
                    Line.HORIZONTAL_SIMPLE.Display();
                }
            }
            Line.HORIZONTAL_LETTER.Display();
        }

        private bool HaveToCloseTheBoard(int i){
            return i == 0;
        }

        private bool HaveToCloseTheBox(int i){
            return i % this._boxDimension == 0;
        }
    }
}
