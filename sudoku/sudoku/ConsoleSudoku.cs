using System;
using usantatecla.sudoku.controllers;
using usantatecla.sudoku.views.console;

namespace usantatecla.sudoku
{
    public class ConsoleSudoku : Sudoku
    {

        protected override View CreateView(StartController startController, PlayController playController, ResumeController resumeController){
            return new View(startController, playController, resumeController);
        }

        static void Main(string[] args)
        {
            new ConsoleSudoku().Play();
        }
    }
}
