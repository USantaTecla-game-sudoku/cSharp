using NUnit.Framework;
using usantatecla.sudoku.models;
using usantatecla.utils;

namespace usantatecla.sudoku.controllers
{
    public class PlayControllerTest
    {
        private PlayController _sut;

        [Test]
        public void Given_PlayController_WhenDontHasSudoku_ThenFalse()
        {
            _sut = new PlayController(BoardBuilder.InCompleted());
            Assert.IsFalse(_sut.HasSudoku());
        }

        [Test]
        public void Given_PlayController_WhenHasSudoku_ThenTrue()
        {
            _sut = new PlayController(BoardBuilder.Completed());
            Assert.IsTrue(_sut.HasSudoku());
        }

        [Test]
        public void Given_PlayController_WhenCantAssign_ThenDontSuccess()
        {
            _sut = new PlayController(BoardBuilder.Completed());

            var assignment = new Assignment(new Coordinate(0, 0), Number.TWO);
            Assert.IsFalse(_sut.CanAssign(assignment) == AssignmentResult.SUCCESS);
        }

        [Test]
        public void Given_PlayController_WhenCanAssign_ThenSuccess()
        {
            _sut = new PlayController(BoardBuilder.Empty());

            var assignment = new Assignment(new Coordinate(0, 0), Number.TWO);
            Assert.IsTrue(_sut.CanAssign(assignment) == AssignmentResult.SUCCESS);
        }

    }

    static class BoardBuilder
    {
        private static string TEMPLATE_INCOMPLETED =   "5.46789.." +
                                                       "672195348" +
                                                       "19.342567" +
                                                       "859761423" +
                                                       "4.6853791" +
                                                       "7.3924856" +
                                                       "961537284" +
                                                       "2.7419635" +
                                                       "345286.7.";

        private static string TEMPLATE_COMPLETED  =    "534678912" +
                                                       "672195348" +
                                                       "198342567" +
                                                       "859761423" +
                                                       "426853791" +
                                                       "713924856" +
                                                       "961537284" +
                                                       "287419635" +
                                                       "345286179";
        

        public static Board Completed() { 
            var board = new Board();
            board.Load(TEMPLATE_COMPLETED);
            return board;
        }
        
        public static Board InCompleted() { 
            var board = new Board();
            board.Load(TEMPLATE_INCOMPLETED);
            return board;
        }

        public static Board Empty() { 
            var board = new Board();
            board.Load(new string('.', 81));
            return board;
        }

    }

}