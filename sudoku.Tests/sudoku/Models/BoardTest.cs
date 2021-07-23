using NUnit.Framework;
using usantatecla.utils;

namespace usantatecla.sudoku.models {

    public class BoardTest {

        public string CreateStringBoardIncomplete(){
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

        public string CreateStringBoardComplete(){
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

        [Test]
        public void GivenBoard_WhenLoad_ThenLoadOk(){
            Board board = GetBoard(CreateStringBoardIncomplete());
            Square[][] squares = board.GetBoard();

            checkRow(squares, 0, "345286.7.");
            checkRow(squares, 1, "2.7419635");
            checkRow(squares, 2, "961537284");
            checkRow(squares, 3, "7.3924856");
            checkRow(squares, 4, "4.6853791");
            checkRow(squares, 5, "859761423");
            checkRow(squares, 6, "19.342567");
            checkRow(squares, 7, "672195348");
            checkRow(squares, 8, "5.46789..");
        }

        private Board GetBoard(string stringBoard){
            Board board = new Board();
            board.Load(stringBoard);
            return board;
        }
    
        private void checkRow(Square[][] squares, int row, string file) {
            Assert.IsTrue(checkSquare(squares[row][0], file.Substring(0, 1)));
            Assert.IsTrue(checkSquare(squares[row][1], file.Substring(1, 1)));
            Assert.IsTrue(checkSquare(squares[row][2], file.Substring(2, 1)));
            Assert.IsTrue(checkSquare(squares[row][3], file.Substring(3, 1)));
            Assert.IsTrue(checkSquare(squares[row][4], file.Substring(4, 1)));
            Assert.IsTrue(checkSquare(squares[row][5], file.Substring(5, 1)));
            Assert.IsTrue(checkSquare(squares[row][6], file.Substring(6, 1)));
            Assert.IsTrue(checkSquare(squares[row][7], file.Substring(7, 1)));
            Assert.IsTrue(checkSquare(squares[row][8], file.Substring(8, 1)));
        }

        private bool checkSquare(Square square, string value) {
            if (value == Board.LOAD_EMPTY_SQUARE) {
                return square.IsEmpty();
            }
            else {
                return square.ToString() == value;
            }
        }

        [Test]
        public void GivenBoard_WhenAssing_ThenAssingOK(){
            Board board = GetBoard(CreateStringBoardIncomplete());
            Square[][] squares = board.GetBoard();

            int row = 1;
            int column = 9;
            board.Assign(new Assignment(new Coordinate(row, column), Number.NINE));
            Assert.IsTrue(checkSquare(squares[row-1][column-1], Number.NINE.GetDescription()));
        }

        [Test]
        public void GivenBoard_WhenCanAssignWithNumberRepeatInRow_ThenNotCanAssing(){
            Board board = GetBoard(CreateStringBoardIncomplete());
            Square[][] squares = board.GetBoard();

            int row = 9;
            int column = 2;
            Assert.IsFalse(board.CanAssign(new Assignment(new Coordinate(row, column), Number.EIGHT)));
        }

        [Test]
        public void GivenBoard_WhenCanAssignWithNumberRepeatInColumn_ThenNotCanAssing(){
            Board board = GetBoard(CreateStringBoardIncomplete());
            Square[][] squares = board.GetBoard();

            int row = 1;
            int column = 9;
            Assert.IsFalse(board.CanAssign(new Assignment(new Coordinate(row, column), Number.ONE)));
        }

        [Test]
        public void GivenBoard_WhenCanAssignWithNumberRepeatInBox_ThenNotCanAssing(){
            Board board = GetBoard(CreateStringBoardIncomplete());
            Square[][] squares = board.GetBoard();

            int row = 9;
            int column = 2;
            Assert.IsFalse(board.CanAssign(new Assignment(new Coordinate(row, column), Number.TWO)));
        }

        [Test]
        public void GivenBoard_WhenCanAssignWithNumberNotRepeat_ThenCanAssing(){
            Board board = GetBoard(CreateStringBoardIncomplete());
            Square[][] squares = board.GetBoard();

            int row = 9;
            int column = 9;
            Assert.IsTrue(board.CanAssign(new Assignment(new Coordinate(row, column), Number.TWO)));
        }

        [Test]
        public void GivenBoard_WhenHasSudokuWhitBoardCompleted_ThenHasSudoku(){
            Board board = GetBoard(CreateStringBoardComplete());
            Square[][] squares = board.GetBoard();

            Assert.IsTrue(board.HasSudoku());
        }

        [Test]
        public void GivenBoard_WhenHasSudokuWhitBoardIncompleted_ThenNotHasSudoku(){
            Board board = GetBoard(CreateStringBoardIncomplete());
            Square[][] squares = board.GetBoard();

            Assert.IsFalse(board.HasSudoku());
        }
    }
}
