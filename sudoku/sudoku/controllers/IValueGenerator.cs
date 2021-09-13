using System;

namespace usantatecla.sudoku.controllers
{
    public interface IValueGenerator
    {
        int Next(int max);
    }
}
