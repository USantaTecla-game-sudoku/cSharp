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
            string result;
            do{
                result = ColorConsole.Instance().Read(Message.RESUME.GetDescription()).ToLower();
            }while(IsInvalidReading(result));
            return ReadingToBoolean(result);
        }

        private bool IsInvalidReading(string value){
            return !("y".Equals(value) || "n".Equals(value));
        }

        private bool ReadingToBoolean(string value){
            return "y".Equals(value);
        }
    }
}
