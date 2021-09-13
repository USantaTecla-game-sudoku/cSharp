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
        public void Given_PlayController_WhenCantAssign_ThenDontSuccess()
        {
            _mocketBoard.Setup(x => x.CanAssign(It.IsAny<Assignment>())).Returns(AssignmentResult.NOT_PLAYABLE_SQUARE);

            var assignment = new Assignment(new Coordinate(0, 0), Number.TWO);
            var assignmentResult = _sut.CanAssign(assignment);
            Assert.IsTrue(assignmentResult != AssignmentResult.SUCCESS);
        }

        [Test]
        public void Given_PlayController_WhenCanAssign_ThenSuccess()
        {
            _mocketBoard.Setup(x => x.CanAssign(It.IsAny<Assignment>())).Returns(AssignmentResult.SUCCESS);

            var assignment = new Assignment(new Coordinate(0, 0), Number.TWO);
            var assignmentResult = _sut.CanAssign(assignment);
            Assert.IsTrue(assignmentResult == AssignmentResult.SUCCESS);
        }

        [Test]
        public void Given_PlayController_WhenAssign_ThenOverridesNumber()
        {
            var coordinate = new Coordinate(0, 0);
            var board = new Board();

            new StartController(board, new EmptySudokuTemplateLoader()).Start();

            var sut = new PlayController(board);

            sut.Assign(new Assignment(coordinate, Number.FOUR));
            Assert.AreEqual("4", GetSquareNumber(board, coordinate));

            sut.Assign(new Assignment(coordinate, Number.EMPTY));
            Assert.AreEqual(Board.EMPTY_NUMBER_ASSIGN, GetSquareNumber(board, coordinate));
        }

        private string GetSquareNumber(Board board, Coordinate coordinate)
        {
            return board.GetSquares()[coordinate.Row][coordinate.Column].Number.ToString();
        }


    }

    class EmptySudokuTemplateLoader : ISudokuLoader
    {
        public string Load() => new string('.', 81);
    }


}
