using NUnit.Framework;
using usantatecla.sudoku.models;

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
            var actual = _board.GetSquares()[0][0];
            Assert.IsNull(actual);
        }

    }

    class FivesSudokuLoader : ISudokuLoader
    {
        public string Load() => new string('5', 81);
    }

}