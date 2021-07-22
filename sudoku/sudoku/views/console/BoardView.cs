using System;
using usantatecla.sudoku.models;
using usantatecla.utils;

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
            utils.ColorConsole.Instance().WriteLine(Line.HORIZONTAL_FIRST.GetDescription());
            for(int i = this._squares.Length - 1 ; i >= 0 ; i--){
                new RowView(i+1, this._squares[i]).Display();
                if(HaveToCloseRowBoard(i)){
                    if(HaveToCloseTheBox(i)){
                        utils.ColorConsole.Instance().WriteLine(Line.HORIZONTAL_DOUBLE.GetDescription());
                    }else{
                        utils.ColorConsole.Instance().WriteLine(Line.HORIZONTAL_SIMPLE.GetDescription());
                    }
                }
            }
            utils.ColorConsole.Instance().WriteLine(Line.HORIZONTAL_LAST.GetDescription());
            utils.ColorConsole.Instance().WriteLine(Line.HORIZONTAL_LETTER.GetDescription());
        }

        private bool HaveToCloseRowBoard(int i){
            return i > 0;
        }

        private bool HaveToCloseTheBox(int i){
            return i % this._boxDimension == 0;
        }
    }
}
