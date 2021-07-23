using System;
using System.IO;
using NUnit.Framework;
using usantatecla.sudoku.models;

namespace usantatecla.sudoku.views.console {

    public class BoardViewTest : ConsoleViewTest{

        [Test]
        public void GivenMatrixSquares_WhenDisplay_ThenWriteConsole(){

            Board board = new Board();
            board.Load(CreateStringTemplate());
            BoardView view = new BoardView(board.GetBoard());
            view.Display();

            CreateManualBoard();
            Assert.AreEqual(output.ToString(), result.ToString());
        }

        public string CreateStringTemplate(){
            return  "53..7...." +
                    "6..195..." +
                    ".98....6." +
                    "8...6...3" +
                    "4..8.3..1" +
                    "7...2...6" +
                    ".6....28." +
                    "...419..5" +
                    "....8..79";
        }

        public void CreateManualBoard(){
            result.WriteLine("   ╔═══════════╦═══════════╦═══════════╗");
            result.WriteLine(" 9 ║ 5 | 3 |   ║   | 7 |   ║   |   |   ║");
            result.WriteLine("   ║───|───|───║───|───|───║───|───|───║");
            result.WriteLine(" 8 ║ 6 |   |   ║ 1 | 9 | 5 ║   |   |   ║");
            result.WriteLine("   ║───|───|───║───|───|───║───|───|───║");
            result.WriteLine(" 7 ║   | 9 | 8 ║   |   |   ║   | 6 |   ║");
            result.WriteLine("   ╠═══════════╬═══════════╬═══════════╣");
            result.WriteLine(" 6 ║ 8 |   |   ║   | 6 |   ║   |   | 3 ║");
            result.WriteLine("   ║───|───|───║───|───|───║───|───|───║");
            result.WriteLine(" 5 ║ 4 |   |   ║ 8 |   | 3 ║   |   | 1 ║");
            result.WriteLine("   ║───|───|───║───|───|───║───|───|───║");
            result.WriteLine(" 4 ║ 7 |   |   ║   | 2 |   ║   |   | 6 ║");
            result.WriteLine("   ╠═══════════╬═══════════╬═══════════╣");
            result.WriteLine(" 3 ║   | 6 |   ║   |   |   ║ 2 | 8 |   ║");
            result.WriteLine("   ║───|───|───║───|───|───║───|───|───║");
            result.WriteLine(" 2 ║   |   |   ║ 4 | 1 | 9 ║   |   | 5 ║");
            result.WriteLine("   ║───|───|───║───|───|───║───|───|───║");
            result.WriteLine(" 1 ║   |   |   ║   | 8 |   ║   | 7 | 9 ║");
            result.WriteLine("   ╚═══════════╩═══════════╩═══════════╝");
            result.WriteLine("     A   B   C   D   E   F   G   H   I  ");
        }
    }
}
