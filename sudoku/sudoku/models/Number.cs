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


    public static class NumberExtensions
    {
		public static Number ToNumber(this string value)
		{
			return (value == Board.EMPTY_NUMBER_ASSIGN || value == Board.EMPTY_NUMBER_LOAD || value == string.Empty)
				? Number.EMPTY
				: EnumExtension.GetValueFromDescription<Number>(value);
        }
	}
}
