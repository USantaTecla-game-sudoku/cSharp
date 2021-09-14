using NUnit.Framework;
using usantatecla.sudoku.models;
using usantatecla.sudoku.controllers.loaders;

namespace usantatecla.sudoku.controllers
{
    public class StartControllerTest
    {
        private Board _board;
        private StartController _sut;

        [SetUp]
        public void Setup() { 
            this._board = new Board();
            this._sut = new StartController(_board, new FivesSudokuLoader());
        }

        [Test]
        public void Given_StartController_WhenNotStartYet_ThenBoardHasNullSquares()
        {
            var expected = new object[] { null, null, null, null, null, null, null, null, null };
            Assert.AreEqual(expected, _board.GetRow(0));
        }

    }

    class FivesSudokuLoader : ISudokuLoader
    {
        public string Load() => new string('5', 81);
    }

}