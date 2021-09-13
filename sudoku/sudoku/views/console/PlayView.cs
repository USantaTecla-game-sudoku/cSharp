using usantatecla.sudoku.models;
using usantatecla.sudoku.controllers;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console
{
    public class PlayView : ConsoleView
    {
        private PlayController playController;
        public PlayView(PlayController playController)
        {
            this.playController = playController;
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
            base._colorConsole.WriteLine(Message.WINNER.ToString());
        }

        private Assignment GetValidAssignmnet() {

            Assignment assignment;
            AssignmentResult assignmentResult;

            do
            {
                assignment = GetPlayerAssignment();
                assignmentResult = this.playController.CanAssign(assignment);
                base._colorConsole.WriteLine(assignmentResult.ToString());
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
            return base._colorConsole.Read(Message.ASSIGNMENT.ToString());
        }

        private void DisplayBoard() {
            new BoardView(this.playController.GetBoard()).Display();
        }

    }
}
