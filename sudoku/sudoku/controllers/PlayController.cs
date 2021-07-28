using System;
using usantatecla.sudoku.models;

namespace usantatecla.sudoku.controllers
{
    public class PlayController : Controller
    {

        public PlayController(Board board) : base(board) { }

        public void Assign(Assignment assignment) => _board.Assign(assignment);

        public AssignmentResult CanAssign(Assignment assignment) => _board.CanAssign(assignment);

        public bool HasSudoku() => _board.HasSudoku();

        public Board GetBoard() => _board;
    }
}