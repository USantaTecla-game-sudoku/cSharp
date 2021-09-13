using System;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console
{
    public class ConsoleView {

        public ColorConsole _colorConsole { get; set; }
        public ConsoleView(){
            this._colorConsole = new ColorConsole();
        }

        public ConsoleView(ColorConsole colorConsole){
            this._colorConsole = colorConsole;
        }

    }
}
