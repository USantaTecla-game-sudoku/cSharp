using usantatecla.sudoku.controllers;

namespace usantatecla.sudoku.views
{
    public abstract class View {

        public void Interact() {
            do {
                this.Start();
                this.Play();
            } while (this.IsResumed());
        }

        protected abstract void Start();
        protected abstract void Play();
        protected abstract bool IsResumed();

    }
}
