using usantatecla.sudoku.controllers;

namespace usantatecla.sudoku.views.console
{
    public class View : usantatecla.sudoku.views.View {

        private readonly StartView _startView;
        private readonly PlayView _playView;
        private readonly ResumeView _resumeView;

        public View(StartController startController, PlayController playController) {
            this._startView = new StartView(startController);
            this._playView = new PlayView(playController);
            this._resumeView = new ResumeView();
        }

        protected override void Start() => this._startView.Interact();

        protected override void Play() => this._playView.Interact();

        protected override bool IsResumed() => this._resumeView.Interact();
    }
}