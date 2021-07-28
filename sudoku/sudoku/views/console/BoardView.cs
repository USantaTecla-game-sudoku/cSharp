using System;
using usantatecla.sudoku.models;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console
{
    public class BoardView {
        private Square[][] _squares;
        private int _boxDimension;
        private ColorConsole _colorConsole;

        public BoardView(Board board) {
            this._squares = board.GetSquares();
            this._boxDimension = (int)Math.Sqrt(Board.SIZE);
            this._colorConsole = ColorConsole.Instance();
        }

        public void Display() {

            Line.FIRST.ConsoleDisplayLine();

            for(int row = Board.SIZE - 1 ; row >= 0 ; row--){

                new RowView(row+1, this._squares[row]).Display();
                if(HaveToCloseRowBoard(row)){

                    var line = HaveToCloseTheBox(row)
                        ? Line.DOUBLE
                        : Line.SIMPLE;

                    line.ConsoleDisplayLine();
                }
            }
            Line.LAST.ConsoleDisplayLine();
            Line.LETTER.ConsoleDisplayLine();
        }

        private bool HaveToCloseRowBoard(int row) => row > 0;

        private bool HaveToCloseTheBox(int row) => row % this._boxDimension == 0;

    }
}
