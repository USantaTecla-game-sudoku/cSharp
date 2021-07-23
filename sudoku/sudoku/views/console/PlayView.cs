using System;
using usantatecla.sudoku.controllers;
using usantatecla.sudoku.models;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console
{
    public class PlayView {

        private PlayController playController;

        public PlayView(PlayController playController) {
            this.playController = playController;
        }

        public void Interact() {
            do {
                new BoardView(this.playController.GetBoard()).Display();
                Assignment assignment = null;
                do {

                    ConsoleAssignmentParser parser;
                    do{

                        parser = new ConsoleAssignmentParser(ColorConsole.Instance().Read(Message.ASSIGNMENT.GetDescription()));
                        if(parser.HasError()){
                            parser.DisplayError();
                        }else{
                            assignment = parser.Parse();
                        }

                    }while(assignment == null);

                }while(!this.playController.CanAssign(assignment));

                this.playController.Assign(assignment);
            }while(!this.playController.HasSudoku());
            new BoardView(this.playController.GetBoard()).Display();
            ColorConsole.Instance().WriteLine(Message.WINNER.GetDescription());
        }
    }
}
