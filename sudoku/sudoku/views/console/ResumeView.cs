using System;
using usantatecla.sudoku.controllers;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console
{
    public class ResumeView {

        private ResumeController resumeController;

        public ResumeView(ResumeController resumeController) {
            this.resumeController = resumeController;
        }

        public bool Interact() {
            string yesOrNot;
            do{
                yesOrNot = ColorConsole.Instance().Read(Message.RESUME.GetDescription()).ToLower();
            }while(IsInvalidReading(yesOrNot));
            return ReadingToBoolean(yesOrNot);
        }

        private bool IsInvalidReading(string value){
            return !("y".Equals(value) || "n".Equals(value));
        }

        private bool ReadingToBoolean(string value){
            return "y".Equals(value);
        }
    }
}
