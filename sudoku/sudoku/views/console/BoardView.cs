using System;
using usantatecla.sudoku.models;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console
{
    public class BoardView : ConsoleView {

        private static readonly int BOX_DIMENSION = (int)Math.Sqrt(Board.SIZE);
        private readonly Board _board;

        public BoardView(Board board) {
            this._board = board;
        }

        public void Display() {

            base._colorConsole.WriteLine(Line.FIRST.ToString());

            for(int row = Board.SIZE - 1 ; row >= 0 ; row--)
            {
                new RowView(row+1, this._board.GetRow(row)).Display();
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

        private bool HaveToCloseTheBox(int row) => row % BOX_DIMENSION == 0;
    }
}