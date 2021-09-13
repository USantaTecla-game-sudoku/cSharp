using System;
using usantatecla.sudoku.controllers;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console
{
    public class ResumeView : ConsoleView {

        private ResumeController resumeController;
        public ResumeView(ResumeController resumeController) {
            this.resumeController = resumeController;
        }

        public bool Interact() {
            string yesOrNot;
            do{
                yesOrNot = base._colorConsole.Read(Message.RESUME.ToString()).ToLower();
            }while(IsInvalidReading(yesOrNot));
            bool resume = ReadingToBoolean(yesOrNot);
            this.resumeController.Resume(resume);
            return resume;
        }

        private bool IsInvalidReading(string value){
            return !("y".Equals(value) || "n".Equals(value));
        }

        private bool ReadingToBoolean(string value){
            return "y".Equals(value);
        }
    }
}
