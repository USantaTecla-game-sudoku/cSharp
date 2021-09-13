using System;
using Moq;
using NUnit.Framework;

using usantatecla.sudoku.controllers;
using usantatecla.sudoku.models;
using usantatecla.sudoku.views;
using usantatecla.sudoku.views.console;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console {

    public class PlayViewTest : ConsoleViewTest
    {
        [Test]
        public void GivenBoard_WhenInsertAssignement_ThenFinishGame()
        {
            Board board = new Board();
            board.Load(CreateStringTemplate());
            mock.SetupSequence(s => s.Read(Message.ASSIGNMENT.ToString())).Returns("c1+5").Returns("h9+4").Returns("h9+1");
            PlayView view = new PlayView(new PlayController(board));
            view._colorConsole = mock.Object;
            view.Interact();

            mock.Verify(v => v.Read(Message.ASSIGNMENT.ToString()), Times.Exactly(3));
            mock.Verify(v => v.WriteLine(Message.WINNER.ToString()), Times.Once());
        }

        public string CreateStringTemplate(){
            return  "5346789.2" +
                    "672195348" +
                    "198342567" +
                    "859761423" +
                    "426853791" +
                    "713924856" +
                    "961537284" +
                    "287419635" +
                    "34.286179";
        }

    }

}
