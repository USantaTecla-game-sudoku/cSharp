using System;
using usantatecla.sudoku.models;
using usantatecla.utils;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace usantatecla.sudoku.views.console
{
    public class ConsoleAssignmentParser
    {
        private const int ASCII_FIRST_LETTER = 65;

        private readonly string _action;

        public ConsoleAssignmentParser(string action)
        {
            this._action = action.ToUpper();
        }

        public bool HasError()
        {

            var assignPattern = @"[A-I]{1}[1-9]{1}[+]{1}[1-9]$";
            var removePattern = @"[A-I]{1}[1-9]{1}[-]{1}$";

            var expression = new Regex($"{assignPattern}|{removePattern}");
            var result = expression.Match(_action);

            return !result.Success;
        }

        public Assignment Parse()
        {
            Debug.Assert(!HasError());

            var coordinate = new Coordinate(GetRow(), GetColumn());
            return new Assignment(coordinate, GetNumber());
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

        private Number GetNumber() => this._action.Substring(3).ToNumber();

        public void DisplayError()
        {
            if (HasError())
            {
                Message.ERROR_FORMAT.ConsoleDisplayLine();
            }
        }
    }

}
