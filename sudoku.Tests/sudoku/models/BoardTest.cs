using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using usantatecla.utils;

namespace usantatecla.sudoku.models
{
    public class BoardTest
    {
        private Board _board;
        private Square[][] _squares;

        [SetUp]
        public void Setup()
        {
            this._board = new Board();
            _board.Load(CreateStringBoardIncomplete());
            _squares = _board.GetSquares();
        }

        [Test]
        public void GivenBoard_WhenLoad_ThenLoadOk()
        {
            var data = CreateStringBoardIncomplete();

            for (int row = Board.SIZE - 1; row >= 0; row--)
            {
                for (int col = 0; col < Board.SIZE; col++)
                {
                    checkCoordinate(new Coordinate(Board.SIZE - 1 - row, col), data.Substring(col + row * Board.SIZE, 1));
                }
            }
        }

        private void checkCoordinate(Coordinate coordinate, string value)
        {
            Square square = _board.GetSquare(coordinate);
            Assert.AreEqual(value, square.IsEmpty() ? Board.EMPTY_NUMBER_LOAD : square.Number.ToString());
        }

        [Test]
        public void GivenBoard_WhenAssing_ThenAssingOK()
        {
            int row = 0;
            int column = 8;
            _board.Assign(new Assignment(new Coordinate(row, column), Number.NINE));
            Assert.IsTrue(_squares[row][column].HasNumber(Number.NINE));
        }

        [Test]
        public void GivenBoard_WhenCanAssignWithNumberRepeatInRow_ThenNotCanAssing()
        {
            var assignmentResult = _board.CanAssign(new Assignment(new Coordinate(8, 1), Number.EIGHT));
            Assert.AreEqual(AssignmentResult.NUMBER_ALREADY_EXISTS_IN_ROW, assignmentResult);
        }

        [Test]
        public void GivenBoard_WhenCanAssignWithNumberRepeatInColumn_ThenNotCanAssing()
        {
            var assignmentResult = _board.CanAssign(new Assignment(new Coordinate(0, 8), Number.ONE));
            Assert.AreEqual(AssignmentResult.NUMBER_ALREADY_EXISTS_IN_COLUMN, assignmentResult);
        }

        [Test]
        public void GivenBoard_WhenCanAssignWithNumberRepeatInBox_ThenNotCanAssing()
        {
            var assignmentResult = _board.CanAssign(new Assignment(new Coordinate(8, 1), Number.TWO));
            Assert.AreEqual(AssignmentResult.NUMBER_ALREADY_EXISTS_IN_BOX, assignmentResult);
        }

        [Test]
        public void GivenBoard_WhenCanAssignWithNumberNotRepeat_ThenCanAssing()
        {
            var assignmentResult = _board.CanAssign(new Assignment(new Coordinate(8, 8), Number.TWO));
            Assert.AreEqual(AssignmentResult.SUCCESS, assignmentResult);
        }

        [Test]
        public void GivenBoard_WhenCanAssignWithNumberEmpty_ThenCanAssing()
        {
            var coordinate = new Coordinate(8, 8);

            var assignment = new Assignment(coordinate, Number.TWO);
            var assignmentResult = _board.CanAssign(assignment);
            Assert.AreEqual(AssignmentResult.SUCCESS, assignmentResult);

            assignment = new Assignment(coordinate, Number.EMPTY);
            assignmentResult = _board.CanAssign(assignment);
            Assert.AreEqual(AssignmentResult.SUCCESS, assignmentResult);
        }

        [Test]
        public void GivenBoard_WhenHasSudokuWhitBoardCompleted_ThenHasSudoku()
        {
            _board.Load(CreateStringBoardComplete());
            Assert.IsTrue(_board.HasSudoku());
        }

        [Test]
        public void GivenBoard_WhenHasSudokuWhitBoardIncompleted_ThenNotHasSudoku()
        {
            _board.Load(CreateStringBoardIncomplete());
            Assert.IsFalse(_board.HasSudoku());
        }

        private string CreateStringBoardIncomplete()
        {
            return  "5.46789.." +
                    "672195348" +
                    "19.342567" +
                    "859761423" +
                    "4.6853791" +
                    "7.3924856" +
                    "961537284" +
                    "2.7419635" +
                    "345286.7.";
        }

        private string CreateStringBoardComplete()
        {
            return  "534678912" +
                    "672195348" +
                    "198342567" +
                    "859761423" +
                    "426853791" +
                    "713924856" +
                    "961537284" +
                    "287419635" +
                    "345286179";
        }
    }
}
