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

        private static int VALUE_ZERO_ASCII = 48;

        public static Number ToNumber(this int value){
            return EnumExtension.GetValueFromDescription<Number>("" + value);
        }

        public static void Display(this Number number){
            ColorConsole.Instance().Write(number.GetDescription(), ConsoleColor.Cyan);
        }

        public static Number? ToNumber(this string assignment){
            if(assignment[2] == '-'){
                return Number.EMPTY;
            }
            if(assignment[2] == '+' && Char.IsDigit(assignment[3])){
                return ((int)Char.GetNumericValue(assignment[3])).ToNumber();
            }
            return null;
        }
    }
}
