using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace usantatecla.sudoku.controllers
{
    public class SudokuRandomValueGenerator : IRandomValueGenerator
    {
        private Random _random;

        public SudokuRandomValueGenerator()
        {
            this._random = new Random();
        }

        public virtual int Next(int max) => _random.Next(max);

    }
}