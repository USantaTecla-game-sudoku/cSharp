using System;
using Moq;
using NUnit.Framework;

using usantatecla.sudoku.controllers;
using usantatecla.sudoku.models;
using usantatecla.sudoku.views;
using usantatecla.sudoku.views.console;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console {

    public class ResumeViewTest : ConsoleViewTest
    {
        [Test]
        public void GivenBoard_WhenFinishGame_ThenNoContinue()
        {
            mock.Setup(s => s.Read(Message.RESUME.ToString())).Returns("n");
            ResumeView view = new ResumeView(new ResumeController(new Board()));
            view._colorConsole = mock.Object;
            bool result = view.Interact();

            mock.Verify(v => v.Read(Message.RESUME.ToString()), Times.Once());
            Assert.IsFalse(result);
        }

        [Test]
        public void GivenBoard_WhenFinishGame_ThenContinue()
        {
            mock.Setup(s => s.Read(Message.RESUME.ToString())).Returns("y");
            ResumeView view = new ResumeView(new ResumeController(new Board()));
            view._colorConsole = mock.Object;
            bool result = view.Interact();

            mock.Verify(v => v.Read(Message.RESUME.ToString()), Times.Once());
            Assert.IsTrue(result);
        }

        [Test]
        public void GivenBoard_WhenFinishGame_ThenIntentContinue()
        {
            mock.SetupSequence(s => s.Read(Message.RESUME.ToString())).Returns("h").Returns("i").Returns("y");
            ResumeView view = new ResumeView(new ResumeController(new Board()));
            view._colorConsole = mock.Object;
            bool result = view.Interact();

            mock.Verify(v => v.Read(Message.RESUME.ToString()), Times.Exactly(3));
            Assert.IsTrue(result);
        }

    }

}
