using usantatecla.sudoku.controllers;
using usantatecla.sudoku.models;
using usantatecla.sudoku.views;
using System;

namespace usantatecla.sudoku
{
    public abstract class Sudoku {

        private Board _board;
        private StartController _startController;
        private PlayController _playController;
        private ResumeController _resumeController;
        private View _view;

        protected Sudoku() {
            this._board = new Board();
            this._startController = new StartController(_board);
            this._playController = new PlayController(_board);
            this._resumeController = new ResumeController(_board, _startController);
            this._view = this.CreateView(this._startController, this._playController, this._resumeController);
        }

        protected abstract View CreateView(
            StartController startController, 
            PlayController playController, 
            ResumeController resumeController);

        protected void Play() => this._view.Interact();
    }
}