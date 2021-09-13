using usantatecla.sudoku.controllers;
using usantatecla.sudoku.models;
using usantatecla.sudoku.views;
using System;

namespace usantatecla.sudoku
{
    public abstract class Sudoku {

        private readonly Board _board;
        private readonly StartController _startController;
        private readonly PlayController _playController;
        private readonly ResumeController _resumeController;
        private readonly View _view;

        protected Sudoku() {
            this._board = new Board();
            this._startController = new StartController(_board);
            this._playController = new PlayController(_board);
            this._resumeController = new ResumeController(_board);
            this._view = this.CreateView(this._startController, this._playController, this._resumeController);
        }

        protected abstract View CreateView(
            StartController startController,
            PlayController playController,
            ResumeController resumeController);

        protected void Play() => this._view.Interact();
    }
}
