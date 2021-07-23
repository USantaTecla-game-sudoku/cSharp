using System;
using System.Diagnostics;
using usantatecla.sudoku.models;
using usantatecla.utils;

namespace usantatecla.sudoku.views.console
{
    public class ConsoleAssignmentParser {

        private static int ASCII_FIRST_LETTER = 65;
        private string _action;
        private char _column;
        private char _row;
        private char _operator;
        private string _number;

        public ConsoleAssignmentParser(string action) {
            Debug.Assert(action.Length >= 3);
            this._action = action.ToUpper();
            this._column = this._action[0];
            this._row = this._action[1];
            this._operator = this._action[2];
            this._number = this._action.Substring(3);
        }

        public Assignment Parse()
        {
            return new Assignment(new Coordinate(GetRow(), GetColumn()), GetNumber().Value);
        }

        private int GetRow(){
            return (int)Char.GetNumericValue(this._row) - 1;
        }

        private int GetColumn(){
            return ((int)this._column) - ASCII_FIRST_LETTER;
        }

        private Number? GetNumber(){
            return this._number.ToNumber();
        }

        public bool HasError()
        {
            return HasInvalidColumn()
                || HasInvalidRow()
                || HasInvalidOperator()
                || HasInvalidNumber();
        }

        private bool HasInvalidColumn(){
            return !(Char.IsLetter(this._column) && GetColumn() < 9);
        }

        private bool HasInvalidRow(){
            return !(Char.IsDigit(this._row)
                && GetRow() >= 0
                && GetRow() < 9);
        }

        private bool HasInvalidOperator(){
            return !('+'.Equals(this._operator) || '-'.Equals(this._operator));
        }

        private bool HasInvalidNumber(){
            Number? number = GetNumber();
            if(number.HasValue){
                if('-'.Equals(this._operator)){
                    return !Number.EMPTY.Equals(number.Value);
                }
                return !number.HasValue || Number.EMPTY.Equals(number.Value);
            }
            return true;
        }

        public void DisplayError() {
            string message = "";
            if(HasInvalidColumn() || HasInvalidRow()){
                message = Message.ERROR_COORDINATE.GetDescription();
            }else if(HasInvalidOperator()){
                message = Message.ERROR_OPERATOR.GetDescription();
            }else if(HasInvalidNumber()){
                message = Message.ERROR_NUMBER.GetDescription();
            }
            ColorConsole.Instance().WriteLine(message);
        }
    }
}
