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
            checkRow(0, "345286.7.");
            checkRow(1, "2.7419635");
            checkRow(2, "961537284");
            checkRow(3, "7.3924856");
            checkRow(4, "4.6853791");
            checkRow(5, "859761423");
            checkRow(6, "19.342567");
            checkRow(7, "672195348");
            checkRow(8, "5.46789..");
        }

        private void checkRow(int row, string file)
        {
            Assert.IsTrue(checkSquare(_squares[row][0], file.Substring(0, 1)));
            Assert.IsTrue(checkSquare(_squares[row][1], file.Substring(1, 1)));
            Assert.IsTrue(checkSquare(_squares[row][2], file.Substring(2, 1)));
            Assert.IsTrue(checkSquare(_squares[row][3], file.Substring(3, 1)));
            Assert.IsTrue(checkSquare(_squares[row][4], file.Substring(4, 1)));
            Assert.IsTrue(checkSquare(_squares[row][5], file.Substring(5, 1)));
            Assert.IsTrue(checkSquare(_squares[row][6], file.Substring(6, 1)));
            Assert.IsTrue(checkSquare(_squares[row][7], file.Substring(7, 1)));
            Assert.IsTrue(checkSquare(_squares[row][8], file.Substring(8, 1)));
        }

        private bool checkSquare(Square square, string value)
        {
            return (value != Board.EMPTY_NUMBER_LOAD)
                ? value == square.Number.GetDescription()
                : square.IsEmpty();

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