using System;
using usantatecla.sudoku.controllers;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console
{
    public class StartView : ConsoleView{

        private readonly StartController startController;

        public StartView(StartController startController) {
            this.startController = startController;
        }

        public void Interact() {
            base._colorConsole.WriteLine(Message.START.ToString());
            this.startController.Start();
        }
    }
}
