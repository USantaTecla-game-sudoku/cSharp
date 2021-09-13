using usantatecla.sudoku.models;

namespace usantatecla.sudoku.controllers
{
    public class ResumeController : Controller
    {

        public ResumeController(Board board) : base(board) {

        }

        public void Resume(bool newGame){
            if(newGame){
                this._board._level++;
            }
        }

    }
}
