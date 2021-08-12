using System;
using usantatecla.sudoku.models;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console
{
    public class BoardView {
        private readonly Square[][] _squares;
        private readonly int _boxDimension;
        private readonly ColorConsole _colorConsole;

        public BoardView(Board board) {
            this._squares = board.GetSquares();
            this._boxDimension = (int)Math.Sqrt(Board.SIZE);
            this._colorConsole = ColorConsole.Instance();
        }

        public void Display() {

            ColorConsole.Instance().WriteLine(Line.FIRST);

            for(int row = Board.SIZE - 1 ; row >= 0 ; row--){

                new RowView(row+1, this._squares[row]).Display();
                if(HaveToCloseRowBoard(row)){

                    var line = HaveToCloseTheBox(row)
                        ? Line.DOUBLE
                        : Line.SIMPLE;

                    ColorConsole.Instance().WriteLine(line);
                }
            }
            ColorConsole.Instance().WriteLine(Line.LAST);
            ColorConsole.Instance().WriteLine(Line.LETTER);
        }

        private bool HaveToCloseRowBoard(int row) => row > 0;

        private bool HaveToCloseTheBox(int row) => row % this._boxDimension == 0;

    }
}
