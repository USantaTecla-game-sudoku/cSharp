using System;
using usantatecla.sudoku.models;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console
{
    public class BoardView : ConsoleView {
        private Square[][] _squares;
        private int _boxDimension;

        public BoardView(Board board) {
            this._squares = board.GetSquares();
            this._boxDimension = (int)Math.Sqrt(Board.SIZE);
        }

        public void Display() {

            base._colorConsole.WriteLine(Line.FIRST.ToString());

            for(int row = Board.SIZE - 1 ; row >= 0 ; row--){

                new RowView(row+1, this._squares[row]).Display();
                if(HaveToCloseRowBoard(row)){

                    var line = HaveToCloseTheBox(row)
                        ? Line.DOUBLE
                        : Line.SIMPLE;

                    base._colorConsole.WriteLine(line.ToString());
                }
            }
            base._colorConsole.WriteLine(Line.LAST.ToString());
            base._colorConsole.WriteLine(Line.LETTER.ToString());
        }

        private bool HaveToCloseRowBoard(int row) => row > 0;

        private bool HaveToCloseTheBox(int row) => row % this._boxDimension == 0;

    }
}
