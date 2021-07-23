using System;
using usantatecla.sudoku.models;

namespace usantatecla.sudoku.controllers
{
    public class PlayController : Controller
    {

        public PlayController(Board board) : base(board) { }

        public void Assign(Assignment assignment) {
            _board.Assign(assignment);
        }

        public bool CanAssign(Assignment assignment)
        {
            return _board.CanAssign(assignment);
        }

        public bool HasSudoku()
        {
            return _board.HasSudoku();
        }

        public Square[][] GetBoard() {
            return _board.GetBoard();
        }
    }
}