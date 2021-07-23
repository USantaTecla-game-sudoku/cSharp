using NUnit.Framework;
using Moq;
using usantatecla.sudoku.models;
using usantatecla.utils;

namespace usantatecla.sudoku.controllers
{
    public class PlayControllerTest
    {
        private Mock<Board> _mocketBoard;
        private PlayController _sut;

        [SetUp]
        public void Setup() {
            _mocketBoard = new Mock<Board>();
            _sut = new PlayController(_mocketBoard.Object);
        }

        [Test]
        public void Given_PlayController_WhenDontHasSudoku_ThenFalse()
        {
            _mocketBoard.Setup(x => x.HasSudoku()).Returns(false);
            Assert.IsFalse(_sut.HasSudoku());
        }

        [Test]
        public void Given_PlayController_WhenHasSudoku_ThenTrue()
        {
            _mocketBoard.Setup(x => x.HasSudoku()).Returns(true);
            Assert.IsTrue(_sut.HasSudoku());
        }

        [Test]
        public void Given_PlayController_WhenCantAssign_ThenFalse()
        {
            _mocketBoard.Setup(x => x.CanAssign(It.IsAny<Assignment>())).Returns(false);

            var assignment = new Assignment(new Coordinate(0, 0), Number.TWO);

            Assert.IsFalse(_sut.CanAssign(assignment));
        }

        [Test]
        public void Given_PlayController_WhenCanAssign_ThenTrue()
        {
            _mocketBoard.Setup(x => x.CanAssign(It.IsAny<Assignment>())).Returns(true);

            var assignment = new Assignment(new Coordinate(0, 0), Number.TWO);

            Assert.IsTrue(_sut.CanAssign(assignment));
        }

        [Test]
        public void Given_PlayController_WhenAssign_ThenOverridesNumber()
        {
            var coordinate = new Coordinate(0, 0);
            var board = new Board();

            new StartController(board, new EmptySudokuTemplateLoader()).Start();

            var sut = new PlayController(board);

            sut.Assign(new Assignment(coordinate, Number.FOUR));
            Assert.AreEqual(GetSquareNumber(board, coordinate), "4");

            sut.Assign(new Assignment(coordinate, Number.EMPTY));
            Assert.AreEqual(GetSquareNumber(board, coordinate), " ");
        }

        private string GetSquareNumber(Board board, Coordinate coordinate)
        {
            return board.GetBoard()[coordinate.Row][coordinate.Column].ToString();
        }


    }

    class EmptySudokuTemplateLoader : ISudokuLoader
    {
        public string Load() => new string('.', 81);
    }


}