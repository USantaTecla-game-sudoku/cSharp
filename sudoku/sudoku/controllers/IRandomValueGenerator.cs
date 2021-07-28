using System;

namespace usantatecla.sudoku.controllers
{
    public interface IRandomValueGenerator
    {
        int Next(int max);
    }
}