using usantatecla.sudoku.models;

namespace usantatecla.sudoku.controllers
{
    public class StartController : Controller {

        private readonly ISudokuLoader _sudokuLoader;

        public StartController(Board board) : this(board, new RandomFileSudokuLoader()) { }

        public StartController(Board board, ISudokuLoader sudokuLoader) : base(board)
        {
            _sudokuLoader = sudokuLoader;
        }

        public void Start() {
            var sudokuTemplate = _sudokuLoader.Load();
            _board.Load(sudokuTemplate);
        }

    }
}