using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using usantatecla.utils;

namespace usantatecla.sudoku.models
{
	public class Number : Enumeration
	{
		public static Number EMPTY = new Number(0, ".");
		public static Number ONE = new Number(1, "1");
		public static Number TWO = new Number(2, "2");
		public static Number THREE = new Number(3, "3");
		public static Number FOUR = new Number(4, "4");
		public static Number FIVE = new Number(5, "5");
		public static Number SIX = new Number(6, "6");
		public static Number SEVEN = new Number(7, "7");
		public static Number EIGHT = new Number(8, "8");
		public static Number NINE = new Number(9, "9");
		public Number(int id, string value) : base(id, value){}
	}

    public static class NumberExtensions
    {
        public static Number ToNumber(this string value) => 
			(value == Number.EMPTY.ToString())
                ? Number.EMPTY
                : Enumeration.GetByValue<Number>(value);
    }
}
