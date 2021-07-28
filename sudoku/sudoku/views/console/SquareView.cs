using System;
using usantatecla.sudoku.models;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console
{
    public class SquareView {

        private Square _square;

        public SquareView(Square square) {
            this._square = square;
        }

        public void Display() {
            _square.Number.ConsoleDisplay(_square.GetColor());
        }

    }
}