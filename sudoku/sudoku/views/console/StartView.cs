using System;
using usantatecla.sudoku.controllers;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console
{
    public class StartView {

        private StartController startController;

        public StartView(StartController startController) {
            this.startController = startController;
        }

        public void Interact() {
            Message.START.ConsoleDisplayLine();
            this.startController.Start();
        }
    }
}
