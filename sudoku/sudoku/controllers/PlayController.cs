using System;
using usantatecla.sudoku.models;

namespace usantatecla.sudoku.controllers
{
    public class PlayController : Controller
    {

        public PlayController(Board board) : base(board) { }

        public void Assign(Assignment assignment) => this._board.Assign(assignment);

        public AssignmentResult CanAssign(Assignment assignment) => this._board.CanAssign(assignment);

        public bool HasSudoku() => this._board.HasSudoku();

        public Board GetBoard() => this._board;
    }
}