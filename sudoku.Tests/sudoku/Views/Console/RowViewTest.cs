using System;
using System.IO;
using Moq;
using NUnit.Framework;
using usantatecla.sudoku.models;
using usantatecla.sudoku.views;

namespace usantatecla.sudoku.views.console {

    public class RowViewTest : ConsoleViewTest{

        [Test]
        public void GivenArraySquares_WhenDisplay_ThenWriteConsole(){
            Square[] squares = new Square[9]{
                new HintSquare(Number.ONE),
                new PlayableSquare(Number.FIVE),
                new PlayableSquare(Number.EIGHT),
                new PlayableSquare(Number.FOUR),
                new HintSquare(Number.NINE),
                new PlayableSquare(Number.EMPTY),
                new PlayableSquare(Number.SEVEN),
                new PlayableSquare(Number.TWO),
                new HintSquare(Number.THREE)
            };

            RowView view = new RowView(1, squares);
            view.Display();

            result.WriteLine(" 1 ║ 1 | 5 | 8 ║ 4 | 9 |   ║ 7 | 2 | 3 ║");
            Assert.AreEqual(output.ToString(), result.ToString());
        }
    }
}
