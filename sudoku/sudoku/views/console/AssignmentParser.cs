using System;
using usantatecla.sudoku.models;
using usantatecla.utils;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace usantatecla.sudoku.views.console
{
    public class AssignmentParser : ConsoleView
    {
        private const int ASCII_FIRST_LETTER = 65;

        private readonly string _action;

        public AssignmentParser(string action)
        {
            this._action = action.ToUpper();
        }

        public bool HasError()
        {
            var assignPattern = @"^(?!\s)[A-I]{1}[1-9]{1}[+]{1}[1-9]$";
            var removePattern = @"^(?!\s)[A-I]{1}[1-9]{1}[-]{1}$";

            var expression = new Regex($"{assignPattern}|{removePattern}");
            var result = expression.Match(_action);

            return !result.Success;
        }

        public Assignment Parse()
        {
            Debug.Assert(!HasError());

            var coordinate = new Coordinate(this.GetRow(), this.GetColumn());
            return new Assignment(coordinate, this.GetNumber());
        }

        private int GetRow()
        {
            var userRow = (int)Char.GetNumericValue(this._action[1]);
            return userRow - 1;
        }

        private int GetColumn()
        {
            var userLeterColumn = ((int)this._action[0]);
            return userLeterColumn - ASCII_FIRST_LETTER;
        }

        private Number GetNumber(){
            return this._action.Substring(3).ToNumber();
        }

        public void DisplayError()
        {
            if (HasError())
            {
                base._colorConsole.WriteLine(Message.ERROR_FORMAT.ToString());
            }
        }
    }

}
