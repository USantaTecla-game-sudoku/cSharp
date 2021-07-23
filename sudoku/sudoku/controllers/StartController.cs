using usantatecla.sudoku.models;

namespace usantatecla.sudoku.controllers
{
    public class StartController : Controller {

        private ISudokuLoader _sudokuLoader;

        public StartController(Board board, ISudokuLoader sudokuLoader) : base(board)
        {
            _sudokuLoader = sudokuLoader;
        }

        public void Start() {
            var template = _sudokuLoader.Load();
            _board.Load(template);
        }
    }
}