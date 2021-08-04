using System;
using usantatecla.sudoku.models;

namespace usantatecla.sudoku.controllers
{
    public abstract class Controller
    {
        protected Board _board;

        protected Controller(Board board)
        {
            this._board = board;
        }

    }
}