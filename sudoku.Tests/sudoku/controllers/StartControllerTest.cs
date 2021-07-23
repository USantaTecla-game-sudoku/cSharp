using NUnit.Framework;
using Moq;
using usantatecla.sudoku.models;

namespace usantatecla.sudoku.controllers
{
    public class StartControllerTest
    {

        [SetUp]
        public void Setup() { }

        [Test]
        public void Given_StartController_WhenStart_ThenBoardLoadsTheSquares()
        {
            var board = new Board();
            var coordinate = new Coordinate(0, 0);

            var sut = new StartController(board, new FivesSudokuLoader());

            sut.Start();
            Assert.AreEqual(GetSquareNumber(board, coordinate), "5");

            board.Assign(new Assignment(coordinate, Number.TWO));

            sut.Start();
            Assert.AreEqual(GetSquareNumber(board, coordinate), "5");
        }

        [Test]
        public void Given_StartController_WhenNotStartYet_ThenBoardHasNullSquares()
        {
            var board = new Board();

            var actual = board.GetBoard()[0][0];
            Assert.IsNull(actual);

            actual = board.GetBoard()[8][8];
            Assert.IsNull(actual);
        }


        private string GetSquareNumber(Board board, Coordinate coordinate) {
            return board.GetBoard()[coordinate.Row][coordinate.Column].ToString();
        }
        
    }

    class FivesSudokuLoader : ISudokuLoader
    {
        public string Load() => new string('5', 81);
    }

}