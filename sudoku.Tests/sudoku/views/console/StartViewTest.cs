using System;
using Moq;
using NUnit.Framework;

using usantatecla.sudoku.controllers;
using usantatecla.sudoku.models;
using usantatecla.sudoku.views;
using usantatecla.sudoku.views.console;

namespace usantatecla.sudoku.views.console {

    public class StartViewTest : ConsoleViewTest {

        public void GivenBoard_WhenStartGame_ThenPrintMessage(){

            StartView view = new StartView(new StartController(new Board()));
            view._colorConsole = mock.Object;
            view.Interact();

            mock.Verify(v => v.WriteLine(Message.START.ToString()), Times.Once());
        }

    }

}
