using System;
using usantatecla.sudoku.models;

namespace usantatecla.sudoku.controllers.loaders
{

    public class LevelGenerator : IValueGenerator
    {
        private Board _board;

        public LevelGenerator(Board board)
        {
            this._board = board;
        }

        public virtual int Next(int max)
        {
            int nextValue = this._board.Level;
            if (nextValue < max)
            {
                return nextValue;
            }
            this._board.Level = 0;
            return 0;
        }
    }
}