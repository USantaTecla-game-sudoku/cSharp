using System;
using System.IO;
using NUnit.Framework;
using usantatecla.sudoku.models;

namespace usantatecla.sudoku.views.console {

    public class BoardViewTest {

        [Test]
        public void GivenMatrixSquares_WhenDisplay_ThenWriteConsole(){
            var output = new StringWriter();
            System.Console.SetOut(output);

            var result = new StringWriter();
            result.Write(output.ToString());

            Square[][] rows = new Square[9][];
            for(int i = 0 ; i < 9 ; i++ ){
                rows[i] = new Square[9]{
                    new PlayableSquare(),
                    new PlayableSquare(),
                    new PlayableSquare(),
                    new PlayableSquare(),
                    new PlayableSquare(),
                    new PlayableSquare(),
                    new PlayableSquare(),
                    new PlayableSquare(),
                    new PlayableSquare()
                };
            }
            rows[3] = new Square[9]{
                new PlayableSquare(Number.THREE),
                new PlayableSquare(Number.FOUR),
                new PlayableSquare(Number.FIVE),
                new HintSquare(Number.TWO),
                new PlayableSquare(Number.EIGHT),
                new PlayableSquare(Number.SIX),
                new PlayableSquare(Number.ONE),
                new HintSquare(Number.SEVEN),
                new HintSquare(Number.NINE)
            };

            BoardView view = new BoardView(rows);
            view.Display();

            result.WriteLine("   ╔═══════════╦═══════════╦═══════════╗");
            result.WriteLine(" 9 ║   |   |   ║   |   |   ║   |   |   ║");
            result.WriteLine("   ║───|───|───║───|───|───║───|───|───║");
            result.WriteLine(" 8 ║   |   |   ║   |   |   ║   |   |   ║");
            result.WriteLine("   ║───|───|───║───|───|───║───|───|───║");
            result.WriteLine(" 7 ║   |   |   ║   |   |   ║   |   |   ║");
            result.WriteLine("   ╠═══════════╬═══════════╬═══════════╣");
            result.WriteLine(" 6 ║   |   |   ║   |   |   ║   |   |   ║");
            result.WriteLine("   ║───|───|───║───|───|───║───|───|───║");
            result.WriteLine(" 5 ║   |   |   ║   |   |   ║   |   |   ║");
            result.WriteLine("   ║───|───|───║───|───|───║───|───|───║");
            result.WriteLine(" 4 ║ 3 | 4 | 5 ║ 2 | 8 | 6 ║ 1 | 7 | 9 ║");
            result.WriteLine("   ╠═══════════╬═══════════╬═══════════╣");
            result.WriteLine(" 3 ║   |   |   ║   |   |   ║   |   |   ║");
            result.WriteLine("   ║───|───|───║───|───|───║───|───|───║");
            result.WriteLine(" 2 ║   |   |   ║   |   |   ║   |   |   ║");
            result.WriteLine("   ║───|───|───║───|───|───║───|───|───║");
            result.WriteLine(" 1 ║   |   |   ║   |   |   ║   |   |   ║");
            result.WriteLine("   ╚═══════════╩═══════════╩═══════════╝");
            result.WriteLine("     A   B   C   D   E   F   G   H   I  ");
            Assert.AreEqual(output.ToString(), result.ToString());

            output.Flush();
            output.Close();
        }
    }
}
