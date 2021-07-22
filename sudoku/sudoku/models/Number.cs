using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using usantatecla.utils;

namespace usantatecla.sudoku.models
{
	public enum Number {
		[Description(" ")]
		EMPTY,

		[Description("1")]
		ONE,

		[Description("2")]
		TWO,

		[Description("3")]
		THREE,

		[Description("4")]
		FOUR,

		[Description("5")]
		FIVE,

		[Description("6")]
		SIX,

		[Description("7")]
		SEVEN,

		[Description("8")]
		EIGHT,

		[Description("9")]
		NINE,
	}

	public static class NumberExtensions {

        public static Number ToNumber(this int value){
            return (Number)Enum.Parse(typeof(Number), "" + value);
        }

        public static Number? ToNumber(this string assignment){
            if(assignment[2] == '-'){
                return Number.EMPTY;
            }
            if(assignment[2] == '+' && Char.IsDigit(assignment[3])){
                return assignment[3].ToNumber();
            }
            return null;
        }

		public static Number ToNumber(this char value){
			if(value == '.'){
				return Number.EMPTY;
			}
			return ((int)Char.GetNumericValue(value)).ToNumber();
		}
    }
}
