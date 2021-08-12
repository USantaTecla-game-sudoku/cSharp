using System;
using usantatecla.sudoku.controllers;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console
{
    public class StartView {

        private readonly StartController startController;

        public StartView(StartController startController) {
            this.startController = startController;
        }

        public void Interact() {
            ColorConsole.Instance().WriteLine(Message.START);
            this.startController.Start();
        }
    }
}
