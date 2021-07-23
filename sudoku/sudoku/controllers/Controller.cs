using System;
using usantatecla.sudoku.models;

namespace usantatecla.sudoku.controllers
{
    public abstract class Controller
    {
        protected Board _board;

        public Controller(Board board)
        {
            this._board = board;
        }

    }
}