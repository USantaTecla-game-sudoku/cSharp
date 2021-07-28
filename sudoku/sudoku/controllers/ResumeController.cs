using usantatecla.sudoku.models;

namespace usantatecla.sudoku.controllers
{
    public class ResumeController : Controller
    {
        private StartController _startController;

        public ResumeController(Board board, StartController startController) : base(board) {
            _startController = startController;
        }

        public void Resume() => _startController.Start();
    }
}