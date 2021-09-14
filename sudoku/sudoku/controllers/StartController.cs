using usantatecla.sudoku.models;
using usantatecla.sudoku.controllers.loaders;

namespace usantatecla.sudoku.controllers
{
    public class StartController : Controller {

        private readonly ISudokuLoader _sudokuLoader;

        public StartController(Board board) : this(board, new FileSudokuLoader(new LevelGenerator(board))) { }

        public StartController(Board board, ISudokuLoader sudokuLoader) : base(board)
        {
            this._sudokuLoader = sudokuLoader;
        }

        public void Start() {
            var sudokuTemplate = this._sudokuLoader.Load();
            _board.Load(sudokuTemplate);
        }

    }
}
