using System;
using System.IO;
using Moq;
using NUnit.Framework;
using usantatecla.sudoku.models;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console {

    public class SquareViewTest : ConsoleViewTest {

        [Test]
        public void GivenSquare_WhenDisplay_ThenWriteConsole(){
            SquareView one = new SquareView(new HintSquare(Number.ONE));
            one._colorConsole = mock.Object;
            one.Display();

            mock.Verify(v => v.Write(Number.ONE.ToString(), ConsoleColor.Cyan), Times.Once());
            SquareView five = new SquareView(new PlayableSquare(Number.FIVE));
            five._colorConsole = mock.Object;
            five.Display();
            mock.Verify(v => v.Write(Number.FIVE.ToString(), ConsoleColor.White), Times.Once());
        }
    }
}
