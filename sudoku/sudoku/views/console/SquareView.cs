using System;
using usantatecla.sudoku.models;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console
{
    public class SquareView {

        private readonly Square _square;

        public SquareView(Square square) {
            this._square = square;
        }

        public void Display() {
            ColorConsole.Instance().Write(_square.Number, _square.GetColor());
        }

    }
}