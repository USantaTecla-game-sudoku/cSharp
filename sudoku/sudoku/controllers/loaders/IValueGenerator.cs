using System;

namespace usantatecla.sudoku.controllers.loaders
{
    public interface IValueGenerator
    {
        int Next(int max);
    }
}
