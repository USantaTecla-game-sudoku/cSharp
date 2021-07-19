using usantatecla.sudoku.controllers;

namespace usantatecla.sudoku.views.console
{
    public class View : usantatecla.sudoku.views.View {

        private StartView _startView;
        private PlayView _playView;
        private ResumeView _resumeView;

        public View(StartController startController, PlayController playController, ResumeController resumeController) {
            this._startView = new StartView(startController);
            this._playView = new PlayView(playController);
            this._resumeView = new ResumeView(resumeController);
        }

        protected override void Start(){
            this._startView.Interact();
        }

        protected override void Play(){
            this._playView.Interact();
        }

        protected override bool IsResumed(){
            return this._resumeView.Interact();
        }
    }
}