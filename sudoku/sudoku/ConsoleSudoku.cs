using System;
using usantatecla.sudoku.controllers;
using usantatecla.sudoku.views.console;

namespace usantatecla.sudoku
{
    public class ConsoleSudoku : Sudoku
    {
        
        protected override View CreateView(StartController startController, PlayController playController){
            return new View(startController, playController);
        }

        static void Main(string[] args)
        {
            new ConsoleSudoku().Play();
        }
    }
}
