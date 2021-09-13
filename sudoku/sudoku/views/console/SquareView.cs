using System;
using usantatecla.sudoku.models;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console
{
    public class SquareView : ConsoleView {

        private readonly Square _square;

        public SquareView(Square square) : base() {
            this._square = square;
        }

        public void Display() {
            var color = _square.CanAssign() ? ConsoleColor.White : ConsoleColor.Cyan;
            base._colorConsole.Write(_square.Number.ToString(), color);
        }

    }
}
