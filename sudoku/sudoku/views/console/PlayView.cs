using usantatecla.sudoku.models;
using usantatecla.sudoku.controllers;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console
{
    public class PlayView
    {
        private PlayController playController;
        private ColorConsole _colorConsole;

        public PlayView(PlayController playController)
        {
            this.playController = playController;
            this._colorConsole = ColorConsole.Instance();
        }

        public void Interact()
        {
            do
            {
                DisplayBoard();
                var assignment = GetValidAssignmnet();
                this.playController.Assign(assignment);

            } while (!this.playController.HasSudoku());

            DisplayBoard();
            Message.WINNER.ConsoleDisplayLine();
        }

        private Assignment GetValidAssignmnet() {

            Assignment assignment;
            AssignmentResult assignmentResult;

            do
            {
                assignment = GetPlayerAssignment();
                assignmentResult = this.playController.CanAssign(assignment);
                assignmentResult.ConsoleDisplayLine();
            } while (assignmentResult != AssignmentResult.SUCCESS);

            return assignment;
        }

        private Assignment GetPlayerAssignment()
        {
            ConsoleAssignmentParser parser;
            do
            {
                parser = new ConsoleAssignmentParser(GetPlayerAction());
                parser.DisplayError();

            } while (parser.HasError());

            return parser.Parse();
        }

        private string GetPlayerAction() {
            return _colorConsole.Read(Message.ASSIGNMENT.GetDescription());
        }

        private void DisplayBoard() {
            new BoardView(this.playController.GetBoard()).Display();
        }

    }
}