using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using usantatecla.utils;

namespace usantatecla.sudoku.models
{
    public class BoardTest
    {
        private static readonly string TEMPLATE_INCOMPLETED =   "5.46789.." +
                                                                "672195348" +
                                                                "19.342567" +
                                                                "859761423" +
                                                                "4.6853791" +
                                                                "7.3924856" +
                                                                "961537284" +
                                                                "2.7419635" +
                                                                "345286.7.";

        private readonly static string TEMPLATE_COMPLETED  =    "534678912" +
                                                                "672195348" +
                                                                "198342567" +
                                                                "859761423" +
                                                                "426853791" +
                                                                "713924856" +
                                                                "961537284" +
                                                                "287419635" +
                                                                "345286179";
        private Board _board;

        [SetUp]
        public void Setup()
        {
            this._board = new Board();
        }

        [Test]
        public void GivenBoard_WhenLoad_ThenLoadOk()
        {
            _board.Load(TEMPLATE_INCOMPLETED);

            for (int row = Board.SIZE - 1; row >= 0; row--)
            {
                for (int col = 0; col < Board.SIZE; col++)
                {
                    var coordinate = new Coordinate(Board.SIZE - 1 - row, col);
                    var expectedValue =  TEMPLATE_INCOMPLETED.Substring(col + row * Board.SIZE, 1);

                    Assert.AreEqual(expectedValue, _board.GetNumber(coordinate).ToString());
                }
            }
        }

        [Test]
        public void GivenBoard_WhenAssing_ThenAssingOK()
        {
            var template = TEMPLATE_INCOMPLETED;
            _board.Load(template);

            var coordinate = new Coordinate(0, 8);
            _board.Assign(new Assignment(coordinate, Number.NINE));
            Assert.IsTrue(_board.HasNumber(coordinate, Number.NINE));
        }

        [Test]
        public void GivenBoard_WhenCanAssignWithNumberNotRepeat_ThenCanAssing()
        {
            var template =  "53467891." +
                            "......348" +
                            "......567" +
                            "........3" +
                            "........1" +
                            "........6" +
                            "........4" +
                            "........5" +
                            "........9";
            _board.Load(template);

            var assignmentResult = _board.CanAssign(new Assignment(new Coordinate(8, 8), Number.TWO));
            Assert.AreEqual(AssignmentResult.SUCCESS, assignmentResult);
        }

        [Test]
        public void GivenBoard_WhenCanAssignWithNumberRepeatInRow_ThenNotCanAssing()
        {
            var template =  "5.4678912" +
                            "........." +
                            "........." +
                            "........." +
                            "........." +
                            "........." +
                            "........." +
                            "........." +
                            ".........";
            _board.Load(template);

            var assignmentResult = _board.CanAssign(new Assignment(new Coordinate(8, 1), Number.EIGHT));
            Assert.AreEqual(AssignmentResult.NUMBER_ALREADY_EXISTS_IN_ROW, assignmentResult);
        }

        [Test]
        public void GivenBoard_WhenCanAssignWithNumberRepeatInColumn_ThenNotCanAssing()
        {
            var template =  "........2" +
                            "........8" +
                            "........7" +
                            "........3" +
                            "........1" +
                            "........6" +
                            "........4" +
                            "........5" +
                            ".........";
            _board.Load(template);

            var assignmentResult = _board.CanAssign(new Assignment(new Coordinate(0, 8), Number.ONE));
            Assert.AreEqual(AssignmentResult.NUMBER_ALREADY_EXISTS_IN_COLUMN, assignmentResult);
        }

        [Test]
        public void GivenBoard_WhenCanAssignWithNumberRepeatInBox_ThenNotCanAssing()
        {
            var template =  "5.4......" +
                            "672......" +
                            "198......" +
                            "........." +
                            "........." +
                            "........." +
                            "........." +
                            "........." +
                            ".........";
            _board.Load(template);

            var assignmentResult = _board.CanAssign(new Assignment(new Coordinate(8, 1), Number.TWO));
            Assert.AreEqual(AssignmentResult.NUMBER_ALREADY_EXISTS_IN_BOX, assignmentResult);
        }

        [Test]
        public void GivenBoard_WhenHasSudokuWhitBoardCompleted_ThenHasSudoku()
        {
            _board.Load(TEMPLATE_COMPLETED);
            Assert.IsTrue(_board.HasSudoku());
        }

        [Test]
        public void GivenBoard_WhenHasSudokuWhitBoardIncompleted_ThenNotHasSudoku()
        {
            _board.Load(TEMPLATE_INCOMPLETED);
            Assert.IsFalse(_board.HasSudoku());
        }

    }
}
